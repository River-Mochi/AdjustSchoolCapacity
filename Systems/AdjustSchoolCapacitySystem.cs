// <copyright file="AdjustSchoolCapacitySystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/AdjustSchoolCapacitySystem.cs
// Applies ASC settings to school entities.
// Base capacity is read from PrefabBase to prevent repeated multiplication.

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

        protected override void OnCreate()
        {
            base.OnCreate();

            m_PrefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();

            // Do not update until school service entities exist.
            RequireForUpdate(
                SystemAPI.QueryBuilder()
                    .WithAllRW<SchoolData>()
                    .WithAll<ConsumptionData>()
                    .Build());

            Enabled = false; // Run once only when a city loads or settings change.
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

            Enabled = true;
        }

        protected override void OnUpdate()
        {
            ASCSetting? setting = Mod.Setting;
            if (setting == null)
            {
                Enabled = false;
                return;
            }

            // Iterate directly without creating a temporary entity array.
            foreach ((RefRW<SchoolData> schoolRef, Entity entity) in SystemAPI
                         .Query<RefRW<SchoolData>>()
                         .WithAll<ConsumptionData>()
                         .WithEntityAccess())
            {
                ref SchoolData schoolData = ref schoolRef.ValueRW;

                // Always scale the prefab value, never the already-modified runtime value.
                if (!TryGetSchoolBaseCapacity(entity, out int baseCapacity))
                {
                    continue;
                }

                int newCapacity =
                    (int)(baseCapacity * GetScalar(setting, schoolData.m_EducationLevel));

                if (newCapacity != schoolData.m_StudentCapacity)
                {
                    schoolData.m_StudentCapacity = newCapacity;
                }
            }

            Enabled = false;
        }

        public void RequestReapplyFromSettings()
        {
            Enabled = true;
#if DEBUG
            Mod.s_Log.Info("[ASC] Settings changed → reapply requested.");
#endif
        }

        private bool TryGetSchoolBaseCapacity(Entity entity, out int baseCapacity)
        {
            baseCapacity = 0;

            // Prefab entities may resolve directly.
            if (m_PrefabSystem.TryGetPrefab(entity, out PrefabBase directPrefab) &&
                TryReadBaseCapacity(directPrefab, out baseCapacity))
            {
                return true;
            }

            // Runtime school entities normally point to their prefab through PrefabRef.
            if (EntityManager.TryGetComponent(entity, out PrefabRef prefabRef) &&
                m_PrefabSystem.TryGetPrefab(prefabRef, out PrefabBase referencedPrefab) &&
                TryReadBaseCapacity(referencedPrefab, out baseCapacity))
            {
                return true;
            }

            return false;
        }

        private static bool TryReadBaseCapacity(PrefabBase prefabBase, out int baseCapacity)
        {
            baseCapacity = 0;

            if (prefabBase != null && prefabBase.TryGet(out School schoolPrefab))
            {
                baseCapacity = schoolPrefab.m_StudentCapacity;
                return baseCapacity > 0;
            }

            return false;
        }

        private static double GetScalar(ASCSetting setting, byte level)
        {
            return (SchoolLevel)level switch
            {
                SchoolLevel.Elementary => setting.ElementarySlider / 100.0,
                SchoolLevel.HighSchool => setting.HighSchoolSlider / 100.0,
                SchoolLevel.College => setting.CollegeSlider / 100.0,
                SchoolLevel.University => setting.UniversitySlider / 100.0,
                _ => 1.0,
            };
        }
    }
}
