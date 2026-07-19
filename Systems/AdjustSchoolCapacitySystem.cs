// <copyright file="AdjustSchoolCapacitySystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

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
    using Game.SceneFlow;

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

            // Cached query with filters.
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
            // Safety bail: never do work outside actual gameplay.
            // Cheap guard for edge cases.
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

            // Iterate directly, no ToEntityArray.
            foreach ((RefRW<SchoolData> schoolRef, Entity entity) in SystemAPI
                         .Query<RefRW<SchoolData>>()
                         .WithAll<ConsumptionData>()
                         .WithEntityAccess())
            {
                ref SchoolData schoolData = ref schoolRef.ValueRW;

                double scalar = GetScalar(setting, schoolData.m_EducationLevel);

                // reliable base to avoid stacking.
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

            // Authoritative base value from prefab component.
            if (prefabBase != null && prefabBase.TryGet(out School schoolPrefab))
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
                SchoolLevel.Elementary => SanitizePercent(
                    setting.ElementarySlider,
                    Setting.ElementaryHighMaxPercent),

                SchoolLevel.HighSchool => SanitizePercent(
                    setting.HighSchoolSlider,
                    Setting.ElementaryHighMaxPercent),

                SchoolLevel.College => SanitizePercent(
                    setting.CollegeSlider,
                    Setting.CollegeUniMaxPercent),

                SchoolLevel.University => SanitizePercent(
                    setting.UniSlider,
                    Setting.CollegeUniMaxPercent),

                _ => Setting.VanillaPercent,
            };

            return percent / 100.0;
        }

        private static int SanitizePercent(int value, int maxPercent)
        {
            return value < Setting.MinPercent || value > maxPercent
                ? Setting.VanillaPercent
                : value;
        }
    }
}
