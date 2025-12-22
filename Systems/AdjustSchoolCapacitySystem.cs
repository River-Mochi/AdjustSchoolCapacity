// File: Systems/AdjustSchoolCapacitySystem.cs
// Applies ASC settings to school entities.
// Base capacity is read from PrefabBase (via PrefabSystem) to prevent stacking.

namespace AdjustSchoolCapacity
{
    using Colossal.Entities;
    using Colossal.Serialization.Entities;
    using Game;
    using Game.Prefabs;
    using Game.SceneFlow;
    using Unity.Collections;
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

            m_SchoolQuery = GetEntityQuery(
                ComponentType.ReadWrite<SchoolData>(),
                ComponentType.ReadWrite<ConsumptionData>());

            RequireForUpdate(m_SchoolQuery);

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
            GameManager gm = GameManager.instance;
            if (gm == null || !gm.gameMode.IsGame())
            {
                m_ReapplyRequested = false;
                Enabled = false;
                return;
            }

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

            NativeArray<Entity> schools = m_SchoolQuery.ToEntityArray(Allocator.Temp);
            if (!schools.IsCreated || schools.Length == 0)
            {
                if (schools.IsCreated)
                    schools.Dispose();
                m_ReapplyRequested = false;
                Enabled = false;
                return;
            }

            for (int i = 0; i < schools.Length; i++)
            {
                Entity entity = schools[i];

                SchoolData schoolData = EntityManager.GetComponentData<SchoolData>(entity);

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
                    EntityManager.SetComponentData(entity, schoolData);
                }
            }

            schools.Dispose();

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

            // Path A: sometimes PrefabSystem can resolve directly.
            if (m_PrefabSystem.TryGetPrefab(entity, out PrefabBase prefabBaseA))
            {
                if (TryReadBaseFromPrefabBase(prefabBaseA, out baseCapacity))
                {
                    return true;
                }
            }

            // Path B: runtime instances often have PrefabRef.
            if (EntityManager.TryGetComponent(entity, out PrefabRef prefabRef))
            {
                if (m_PrefabSystem.TryGetPrefab(prefabRef, out PrefabBase prefabBaseB))
                {
                    if (TryReadBaseFromPrefabBase(prefabBaseB, out baseCapacity))
                    {
                        return true;
                    }
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

            // Preferred: read the prefab component values (authoritative base).
            if (prefabBase.TryGet(out School schoolPrefab))
            {
                baseCapacity = schoolPrefab.m_StudentCapacity;
                return baseCapacity > 0;
            }

            return false;
        }

        private static double GetScalar(Setting setting, byte level)
        {
            int percent;

            switch ((SchoolLevel)level)
            {
                case SchoolLevel.Elementary:
                    percent = SanitizePercent(setting.ElementarySlider);
                    break;
                case SchoolLevel.HighSchool:
                    percent = SanitizePercent(setting.HighSchoolSlider);
                    break;
                case SchoolLevel.College:
                    percent = SanitizePercent(setting.CollegeSlider);
                    break;
                case SchoolLevel.University:
                    percent = SanitizePercent(setting.UniversitySlider);
                    break;
                default:
                    percent = 100;
                    break;
            }

            return percent / 100.0;
        }

        private static int SanitizePercent(int value)
        {
            if (value < 10 || value > 500)
            {
                return 100;
            }

            return value;
        }
    }
}
