// File: Systems/AdjustSchoolCapacitySystem.cs
// Applies ASC settings to all school-related entities including school extensions.
// Notes to future self:
// PrefabRef: pointer to locate the prefab entity this instance came from; value can differ from vanilla.
// PrefabData is the lookup key, PrefabSystem is the bridge to PrefabBase,
// PrefabBase holds the authoritative base component values - use this for multipliers to prevent stacking values.

namespace AdjustSchoolCapacity
{
    using Colossal.Entities;
    using Colossal.Serialization.Entities;
    using Game;
    using Game.Prefabs;
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
                {
                    schools.Dispose();
                }

                m_ReapplyRequested = false;
                Enabled = false;
                return;
            }

            for (int i = 0; i < schools.Length; i++)
            {
                Entity entity = schools[i];

                SchoolData schoolData = EntityManager.GetComponentData<SchoolData>(entity);

                double scalar = GetScalar(setting, schoolData.m_EducationLevel);

                int baseCap;
                if (!TryGetSchoolBaseCapacity(entity, out baseCap))
                {
                    // Fallback: use current if sane.
                    baseCap = schoolData.m_StudentCapacity;
                }

                if (baseCap <= 0)
                {
                    // Never write broken data.
                    continue;
                }

                int newCap = (int)(baseCap * scalar);
                if (newCap <= 0)
                {
                    newCap = baseCap; // vanilla-safe fallback
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

            // Case 1: entity itself is a prefab entity (has PrefabData)
            if (m_PrefabSystem.TryGetPrefab(entity, out PrefabBase prefabBaseA))
            {
                if (prefabBaseA != null && prefabBaseA.TryGet(out School schoolA))
                {
                    baseCapacity = schoolA.m_StudentCapacity;
                    return true;
                }
            }

            // Case 2: entity is a runtime instance with PrefabRef pointer
            if (EntityManager.TryGetComponent(entity, out PrefabRef prefabRef))
            {
                if (m_PrefabSystem.TryGetPrefab(prefabRef, out PrefabBase prefabBaseB))
                {
                    if (prefabBaseB != null && prefabBaseB.TryGet(out School schoolB))
                    {
                        baseCapacity = schoolB.m_StudentCapacity;
                        return true;
                    }
                }
            }

            return false;
        }

        private static double GetScalar(Setting setting, byte level)
        {
            int percent = 100;

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
            // UI is 10..500, but disk can be anything. Invalid => vanilla-safe.
            if (value < 10 || value > 500)
            {
                return 100;
            }

            return value;
        }
    }
}
