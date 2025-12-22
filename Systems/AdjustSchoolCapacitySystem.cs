// File: Systems/AdjustSchoolCapacitySystem.cs
// Applies ASC settings to school entities.
// Base capacity is read from PrefabBase (via PrefabSystem) to prevent stacking.
// Uses SystemAPI (QueryBuilder + Query) to avoid ToEntityArray allocations.

namespace AdjustSchoolCapacity
{
    using Colossal.Entities;
    using Colossal.Serialization.Entities;
    using Game;
    using Game.Prefabs;
    using Unity.Entities;

    public sealed partial class AdjustSchoolCapacitySystem : GameSystemBase
    {
        private PrefabSystem m_PrefabSystem = null!;
        private EntityQuery m_SchoolQuery;
        private bool m_ReapplyRequested;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_PrefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();

            // Cached query (recommended modern pattern).
            // Filter: entities that have SchoolData + ConsumptionData.
            m_SchoolQuery = SystemAPI.QueryBuilder()
                                     .WithAllRW<SchoolData>()
                                     .WithAll<ConsumptionData>()
                                     .Build();

            RequireForUpdate(m_SchoolQuery);

            // Run only when explicitly enabled (city load or settings change).
            Enabled = false;
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);

            bool isRealGame =
                mode == GameMode.Game &&
                (purpose == Purpose.NewGame || purpose == Purpose.LoadGame);

            if (!isRealGame)
            {
                return;
            }

            m_ReapplyRequested = true;
            Enabled = true;
        }

        protected override void OnUpdate()
        {
            if (!m_ReapplyRequested)
            {
                Enabled = false;
                return;
            }

            if (Mod.Setting == null)
            {
                m_ReapplyRequested = false;
                Enabled = false;
                return;
            }

            Setting setting = Mod.Setting;

            // Iterate directly, no ToEntityArray.
            foreach ((RefRW<SchoolData> schoolRef, Entity entity) in SystemAPI
                         .Query<RefRW<SchoolData>>()
                         .WithAll<ConsumptionData>()
                         .WithEntityAccess())
            {
                ref SchoolData schoolData = ref schoolRef.ValueRW;

                double scalar = GetScalar(setting, schoolData.m_EducationLevel);

                // Must have a reliable base to avoid stacking.
                if (!TryGetSchoolBaseCapacity(entity, out int baseCap))
                {
                    continue;
                }

                if (baseCap <= 0)
                {
                    continue;
                }

                int newCap = (int)(baseCap * scalar);
                if (newCap <= 0)
                {
                    newCap = baseCap;
                }

                if (newCap != schoolData.m_StudentCapacity)
                {
                    schoolData.m_StudentCapacity = newCap;
                }
            }

            m_ReapplyRequested = false;
            Enabled = false;
        }

        public void RequestReapplyFromSettings()
        {
            m_ReapplyRequested = true;
            Enabled = true;
#if DEBUG
            Mod.s_Log.Info("[ASC] Settings changed → reapply requested.");
#endif
        }

        private bool TryGetSchoolBaseCapacity(Entity entity, out int baseCapacity)
        {
            baseCapacity = 0;

            if (m_PrefabSystem == null)
            {
                return false;
            }

            // Path A: entity itself can sometimes be resolved as a prefab entity.
            if (m_PrefabSystem.TryGetPrefab(entity, out PrefabBase prefabBaseA))
            {
                return TryReadBaseFromPrefabBase(prefabBaseA, out baseCapacity);
            }

            // Path B: runtime instances usually have PrefabRef.
            if (EntityManager.TryGetComponent(entity, out PrefabRef prefabRef))
            {
                if (m_PrefabSystem.TryGetPrefab(prefabRef, out PrefabBase prefabBaseB))
                {
                    return TryReadBaseFromPrefabBase(prefabBaseB, out baseCapacity);
                }
            }

            return false;
        }

        private static bool TryReadBaseFromPrefabBase(PrefabBase prefabBase, out int baseCapacity)
        {
            baseCapacity = 0;

            if (prefabBase == null)
            {
                return false;
            }

            // Authoritative base value comes from prefab component.
            if (prefabBase.TryGet(out School schoolPrefab))
            {
                baseCapacity = schoolPrefab.m_StudentCapacity;
                return baseCapacity > 0;
            }

            return false;
        }

        private static double GetScalar(Setting setting, byte level)
        {
            int percent = (SchoolLevel)level switch
            {
                SchoolLevel.Elementary => SanitizePercent(setting.ElementarySlider),
                SchoolLevel.HighSchool => SanitizePercent(setting.HighSchoolSlider),
                SchoolLevel.College => SanitizePercent(setting.CollegeSlider),
                SchoolLevel.University => SanitizePercent(setting.UniversitySlider),
                _ => 100,
            };

            return percent / 100.0;
        }

        private static int SanitizePercent(int value)
        {
            return (value < 10 || value > 500) ? 100 : value;
        }
    }
}
