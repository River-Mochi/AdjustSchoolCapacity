// <copyright file="Setting.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Settings/Setting.cs
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

    using UnityEngine;                  // Application URL

    [FileLocation("ModsSettings/AdjustSchoolCapacity/AdjustSchoolCapacity")]
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
        internal const int MinPercent = 10;
        internal const int ElementaryHighMaxPercent = 1000;
        internal const int CollegeUniMaxPercent = 500;
        internal const int VanillaPercent = 100;

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

        public Setting(IMod mod) : base(mod)
        {
            // New Install starts with vanilla defaults.
            // If a .coc exists, LoadSettings will overwrite these.
            SetDefaults();
        }

        public override void Apply()
        {
            RepairAndClamp();

            // Apply in-memory settings + notify Options UI.
            // (Sliders are persisted by Options UI pipeline.)
            base.Apply();

            // Only poke ECS when a city is running.
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

        // ---- Sliders (step 10%) ----
        // Elementary / High School: 10–1000%
        // College / University: 10–500%

        [SettingsUISlider(
            min = MinPercent,
            max = ElementaryHighMaxPercent,
            step = 10,
            scalarMultiplier = 1,
            unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, CapacityGroup)]
        public int ElementarySlider
        {
            get; set;
        }

        [SettingsUISlider(
            min = MinPercent,
            max = ElementaryHighMaxPercent,
            step = 10,
            scalarMultiplier = 1,
            unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, CapacityGroup)]
        public int HighSchoolSlider
        {
            get; set;
        }

        [SettingsUISlider(
            min = MinPercent,
            max = CollegeUniMaxPercent,
            step = 10,
            scalarMultiplier = 1,
            unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, CapacityGroup)]
        public int CollegeSlider
        {
            get; set;
        }

        [SettingsUISlider(
            min = MinPercent,
            max = CollegeUniMaxPercent,
            step = 10,
            scalarMultiplier = 1,
            unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, CapacityGroup)]
        public int UniSlider
        {
            get; set;
        }


        // ---- Preset buttons, keep in same group for same row display ----

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
                // Persist immediately (matches vanilla UI behavior for manual slider edits).
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
                ApplyAndSave(); // Persist immediately
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
            // First install set to game defaults (vanilla).
            SetToVanilla();
        }

        public void SetToVanilla()
        {
            ElementarySlider = VanillaPercent;
            HighSchoolSlider = VanillaPercent;
            CollegeSlider = VanillaPercent;
            UniSlider = VanillaPercent;
        }

        public void SetQuickStart()
        {
            ElementarySlider = 200;
            HighSchoolSlider = 150;
            CollegeSlider = 110;
            UniSlider = 100;
        }

        // Called from Mod.cs AFTER LoadSettings, before RegisterInOptionsUI.
        public void SanitizeAfterLoad()
        {
            RepairAndClamp();
        }

        private void RepairAndClamp()
        {
            ElementarySlider =
                SanitizePercent(ElementarySlider, ElementaryHighMaxPercent);

            HighSchoolSlider =
                SanitizePercent(HighSchoolSlider, ElementaryHighMaxPercent);

            CollegeSlider =
                SanitizePercent(CollegeSlider, CollegeUniMaxPercent);

            UniSlider =
                SanitizePercent(UniSlider, CollegeUniMaxPercent);
        }

        private static int SanitizePercent(int value, int maxPercent)
        {
            // Invalid values return to vanilla capacity.
            if (value < MinPercent || value > maxPercent)
            {
                return VanillaPercent;
            }

            return value;
        }
      
    }
}
