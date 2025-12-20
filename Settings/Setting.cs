// File: Settings/Setting.cs
// Options UI for "Adjust School Capacity [ASC]".

namespace AdjustSchoolCapacity
{
    using System;
    using Colossal.IO.AssetDatabase;
    using Game.Modding;
    using Game.Settings;
    using Game.UI;
    using Unity.Entities;
    using UnityEngine;

    [FileLocation("ModsSettings/AdjustSchoolCapacity/AdjustSchoolCapacity")]    // Saved settings path
    [SettingsUIGroupOrder(
        CapacityGroup,
        PresetGroup,
        AboutInfoGroup,
        AboutLinksGroup
    )]
    [SettingsUIShowGroupName(
        CapacityGroup,
        PresetGroup,
        AboutLinksGroup
    )]
    public sealed class Setting : ModSetting
    {
        private const int MinPercent = 10;
        private const int MaxPercent = 500;
        private const int VanillaPercent = 100;

        // ---- Tabs ----
        public const string ActionsTab = "Actions";
        public const string AboutTab = "About";

        // ---- Groups Actions tab ----
        public const string CapacityGroup = "Student Capacity";
        public const string PresetGroup = "Presets";

        // ---- Groups About tab ----
        public const string AboutInfoGroup = "Info";
        public const string AboutLinksGroup = "Support Links";

        // ---- External links ----
        private const string UrlParadox =
            "https://mods.paradoxplaza.com/authors/River-mochi/cities_skylines_2?games=cities_skylines_2&orderBy=desc&sortBy=best&time=alltime";
        private const string UrlDiscord = "https://discord.gg/HTav7ARPs2";

        // Optional: helps future migrations. Old files load this as 0.
        public int SettingsVersion
        {
            get; set;
        }

        public Setting(IMod mod) : base(mod)
        {
            // True first install: no .coc yet => all ints default to 0.
            bool allZero =
                ElementarySlider == 0 &&
                HighSchoolSlider == 0 &&
                CollegeSlider == 0 &&
                UniversitySlider == 0;

            if (SettingsVersion == 0)
            {
                if (allZero)
                {
                    // First install should be vanilla to avoid confusion.
                    SetDefaults();
                }
                else
                {
                    // Not first install: repair missing/invalid values to vanilla-safe.
                    RepairAndClamp();
                }

                SettingsVersion = 1;
            }
            else
            {
                // Normal loads: keep user values, but sanitize just in case.
                RepairAndClamp();
            }
        }

        public override void Apply()
        {
            RepairAndClamp();

            base.Apply();

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

        // ---- Sliders (10–500%, step 10%) ----

        [SettingsUISlider(min = 10, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, CapacityGroup)]
        public int ElementarySlider
        {
            get; set;
        }

        [SettingsUISlider(min = 10, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
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

        // ---- Preset buttons, same group → side-by-side ----

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
                Apply();
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

                // Keep the "Quick Start Presets" button behavior.
                SetQuickStart();
                Apply();
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
            // Default install behavior: vanilla (no change unless user opts in).
            SetToVanilla();
        }

        public void SetToVanilla()
        {
            ElementarySlider = VanillaPercent;
            HighSchoolSlider = VanillaPercent;
            CollegeSlider = VanillaPercent;
            UniversitySlider = VanillaPercent;
        }

        public void SetQuickStart()
        {
            ElementarySlider = 200;
            HighSchoolSlider = 150;
            CollegeSlider = 110;
            UniversitySlider = 100;
        }

        private void RepairAndClamp()
        {
            ElementarySlider = SanitizePercent(ElementarySlider);
            HighSchoolSlider = SanitizePercent(HighSchoolSlider);
            CollegeSlider = SanitizePercent(CollegeSlider);
            UniversitySlider = SanitizePercent(UniversitySlider);
        }

        private static int SanitizePercent(int value)
        {
            // Disk can be anything. Invalid => vanilla-safe.
            if (value < MinPercent || value > MaxPercent)
            {
                return VanillaPercent;
            }

            return value;
        }

        public void SanitizeAfterLoad()
        {
            // Old / corrupt settings can load as 0 or out-of-range.
            ElementarySlider = SanitizePercent(ElementarySlider);
            HighSchoolSlider = SanitizePercent(HighSchoolSlider);
            CollegeSlider = SanitizePercent(CollegeSlider);
            UniversitySlider = SanitizePercent(UniversitySlider);

            // If SettingsVersion, force it forward.
            if (SettingsVersion < 1)
            {
                SettingsVersion = 1;
            }
        }

    }
}
