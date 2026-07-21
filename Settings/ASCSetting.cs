// <copyright file="ASCSetting.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Settings/ASCSetting.cs
// Options UI for "Adjust School Capacity [ASC]".

namespace AdjustSchoolCapacity
{
    using System;                       // Exception
    using Colossal.IO.AssetDatabase;    // FileLocation
    using Game;                         // IsGame
    using Game.Modding;                 // IMod, ModSetting
    using Game.SceneFlow;               // GameManager
    using Game.Settings;                // Settings UI attributes
    using Game.UI;                      // Unit
    using Unity.Entities;               // World
    using UnityEngine;                  // Application.OpenURL

    [FileLocation("ModsSettings/AdjustSchoolCapacity/AdjustSchoolCapacity")]
    [SettingsUIGroupOrder(
        CapacityGroup,
        FeeGroup,
        PresetGroup,
        AboutInfoGroup,
        AboutLinksGroup
    )]
    [SettingsUIShowGroupName(
        CapacityGroup,
        FeeGroup,
        PresetGroup,
        AboutLinksGroup
    )]
    public sealed class ASCSetting : ModSetting
    {
        // ---- Tabs ----
        public const string ActionsTab = "Actions";
        public const string AboutTab = "About";

        // ---- Groups: Actions tab ----
        public const string CapacityGroup = "Student Capacity";
        public const string FeeGroup = "School Fees";
        public const string PresetGroup = "Presets";

        // ---- Groups: About tab ----
        public const string AboutInfoGroup = "Info";
        public const string AboutLinksGroup = "Support Links";

        private const string UrlParadox =
            "https://mods.paradoxplaza.com/authors/River-mochi/cities_skylines_2?games=cities_skylines_2&orderBy=desc&sortBy=best&time=alltime";
        private const string UrlDiscord = "https://discord.gg/gwXgvtyhjc";

        private bool m_ControlEducationFees;
        private bool m_RestoreVanillaFeesRequested;

        public ASCSetting(IMod mod) : base(mod)
        {
            // Existing .coc values overwrite these defaults during LoadSettings.
            SetDefaults();
        }

        public override void Apply()
        {
            RepairInvalidValues();
            base.Apply();

            // Options can also be applied from the main menu; only wake ECS in a city.
            GameManager? gm = GameManager.instance;
            if (gm == null || !gm.gameMode.IsGame())
            {
                return;
            }

            World world = World.DefaultGameObjectInjectionWorld;
            if (world == null)
            {
                return;
            }

            AdjustSchoolCapacitySystem system =
                world.GetExistingSystemManaged<AdjustSchoolCapacitySystem>();
            if (system == null)
            {
                return;
            }

            system.RequestReapplyFromSettings();
        }

        // Elementary / High School: 10–1000%. College / University: 10–500%.

        [SettingsUISlider(min = 10, max = 1000, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, CapacityGroup)]
        public int ElementarySlider
        {
            get; set;
        }

        [SettingsUISlider(min = 10, max = 1000, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, CapacityGroup)]
        public int HighSchoolSlider
        {
            get; set;
        }

        [SettingsUISlider(min = 10, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, CapacityGroup)]
        public int CollegeSlider
        {
            get; set;
        }

        [SettingsUISlider(min = 10, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, CapacityGroup)]
        public int UniversitySlider
        {
            get; set;
        }

        // ---- School fees ----

        [SettingsUISection(ActionsTab, FeeGroup)]
        public bool ControlEducationFees
        {
            get => m_ControlEducationFees;
            set
            {
                if (m_ControlEducationFees && !value)
                {
                    // Restore vanilla fees the next time the city system runs.
                    m_RestoreVanillaFeesRequested = true;
                }

                m_ControlEducationFees = value;
            }
        }

        [SettingsUISlider(min = -20, max = 200, step = 5, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUIDisableByCondition(typeof(ASCSetting), nameof(DisableEducationFeeSliders))]
        [SettingsUISection(ActionsTab, FeeGroup)]
        public int ElementaryFeePercent
        {
            get; set;
        }

        [SettingsUISlider(min = -20, max = 200, step = 5, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUIDisableByCondition(typeof(ASCSetting), nameof(DisableEducationFeeSliders))]
        [SettingsUISection(ActionsTab, FeeGroup)]
        public int HighSchoolFeePercent
        {
            get; set;
        }

        [SettingsUISlider(min = -20, max = 200, step = 5, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUIDisableByCondition(typeof(ASCSetting), nameof(DisableEducationFeeSliders))]
        [SettingsUISection(ActionsTab, FeeGroup)]
        public int HigherEducationFeePercent
        {
            get; set;
        }

        [SettingsUIButton]
        [SettingsUISection(ActionsTab, FeeGroup)]
        public bool ResetEducationFees
        {
            set
            {
                if (!value)
                {
                    return;
                }

                SetEducationFeesToGameDefaults();
                ApplyAndSave();
            }
        }

        // Keep both capacity buttons in the same UI row.
        [SettingsUIButtonGroup(PresetGroup)]
        [SettingsUIButton]
        [SettingsUISection(ActionsTab, PresetGroup)]
        public bool ResetToVanilla
        {
            set
            {
                if (!value)
                {
                    return;
                }

                SetToVanilla();
                ApplyAndSave();
            }
        }

        [SettingsUIButtonGroup(PresetGroup)]
        [SettingsUIButton]
        [SettingsUISection(ActionsTab, PresetGroup)]
        public bool ResetToModDefault
        {
            set
            {
                if (!value)
                {
                    return;
                }

                SetQuickStart();
                ApplyAndSave();
            }
        }

        // ---- About tab ----

        [SettingsUISection(AboutTab, AboutInfoGroup)]
        public string NameDisplay => Mod.ModName;

        [SettingsUISection(AboutTab, AboutInfoGroup)]
        public string VersionDisplay => Mod.ModVersion;

        [SettingsUIButtonGroup(AboutLinksGroup)]
        [SettingsUIButton]
        [SettingsUISection(AboutTab, AboutLinksGroup)]
        public bool OpenParadoxMods
        {
            set
            {
                if (!value)
                {
                    return;
                }

                try
                {
                    Application.OpenURL(UrlParadox);
                }
                catch (Exception)
                {
                }
            }
        }

        [SettingsUIButtonGroup(AboutLinksGroup)]
        [SettingsUIButton]
        [SettingsUISection(AboutTab, AboutLinksGroup)]
        public bool OpenDiscord
        {
            set
            {
                if (!value)
                {
                    return;
                }

                try
                {
                    Application.OpenURL(UrlDiscord);
                }
                catch (Exception)
                {
                }
            }
        }

        // ---- Defaults / presets ----

        public override void SetDefaults()
        {
            SetToVanilla();

            // Fee control is opt-in for new and existing players.
            ControlEducationFees = false;
            ElementaryFeePercent = 100;
            HighSchoolFeePercent = 100;
            HigherEducationFeePercent = 100;
        }

        public void SetToVanilla()
        {
            ElementarySlider = 100;
            HighSchoolSlider = 100;
            CollegeSlider = 100;
            UniversitySlider = 100;
        }

        public void SetQuickStart()
        {
            ElementarySlider = 200;
            HighSchoolSlider = 150;
            CollegeSlider = 110;
            UniversitySlider = 100;
        }

        public void SetEducationFeesToGameDefaults()
        {
            ElementaryFeePercent = 100;
            HighSchoolFeePercent = 100;
            HigherEducationFeePercent = 100;

            // Restore the live city fees even when fee control is currently OFF.
            m_RestoreVanillaFeesRequested = true;
        }

        internal bool ConsumeRestoreVanillaFeesRequest()
        {
            bool requested = m_RestoreVanillaFeesRequested;
            m_RestoreVanillaFeesRequested = false;
            return requested;
        }

        internal bool RepairInvalidValues()
        {
            int elementary = SanitizePercent(ElementarySlider, 10, 1000);
            int highSchool = SanitizePercent(HighSchoolSlider, 10, 1000);
            int college = SanitizePercent(CollegeSlider, 10, 500);
            int uni = SanitizePercent(UniversitySlider, 10, 500);
            int elementaryFee = SanitizePercent(ElementaryFeePercent, -20, 200);
            int highSchoolFee = SanitizePercent(HighSchoolFeePercent, -20, 200);
            int higherEducationFee = SanitizePercent(HigherEducationFeePercent, -20, 200);

            bool changed =
                elementary != ElementarySlider ||
                highSchool != HighSchoolSlider ||
                college != CollegeSlider ||
                uni != UniversitySlider ||
                elementaryFee != ElementaryFeePercent ||
                highSchoolFee != HighSchoolFeePercent ||
                higherEducationFee != HigherEducationFeePercent;

            ElementarySlider = elementary;
            HighSchoolSlider = highSchool;
            CollegeSlider = college;
            UniversitySlider = uni;
            ElementaryFeePercent = elementaryFee;
            HighSchoolFeePercent = highSchoolFee;
            HigherEducationFeePercent = higherEducationFee;

            return changed;
        }

        private bool DisableEducationFeeSliders()
        {
            return !ControlEducationFees;
        }

        private static int SanitizePercent(int value, int minPercent, int maxPercent)
        {
            // Invalid file values return to vanilla instead of an extreme limit.
            return value < minPercent || value > maxPercent ? 100 : value;
        }
    }
}
