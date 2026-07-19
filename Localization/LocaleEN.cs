// <copyright file="LocaleEN.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// Localization/LocaleEN.cs
// English (en-US) for Options UI.

namespace AdjustSchoolCapacity
{
    using System.Collections.Generic;

    using Colossal;

    public sealed class LocaleEN : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleEN(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            string title = Mod.ShortName;

            // Show "Adjust School (1.6.2)" title
            if (!string.IsNullOrEmpty(Mod.ModVersion))
            {
                title = title + " (" + Mod.ModVersion + ")";
            }

            return new Dictionary<string, string>
            {

                // Mod name in options
                { m_Setting.GetSettingsLocaleID(), title },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Actions" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "About"   },

                // Groups - Actions
                { m_Setting.GetOptionGroupLocaleID(Setting.CapacityGroup), "Student Capacity" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PresetGroup),   "Presets" },

                // Groups - About
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGroup),  "Info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGroup), "Support Links" },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ElementarySlider)), "Elementary" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ElementarySlider)),
                    "**Elementary school** – customize capacity 10% - 500% using the slider.\n" +
                    "100% = game's default capacity."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HighSchoolSlider)), "High School" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.HighSchoolSlider)),
                    "**High school** – customize capacity 10% - 500% using the slider.\n" +
                    "100% = game's default capacity."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CollegeSlider)), "College" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.CollegeSlider)),
                    "**College** – customize capacity 10% - 500% using the slider.\n" +
                    "100% = game's default capacity."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UniSlider)), "University" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UniSlider)),
                    "**University** – customize capacity 10% - 500% using the slider.\n" +
                    "100% = game's default capacity."
                },

                // Preset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Reset to Vanilla" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "Bring all capacity sliders back to 100% (game's default capacity)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToModDefault)), "Quick Start Presets" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToModDefault)),
                    "Set Quick Start preset:\n" +
                    "**200 / 150 / 110 / 100**"
                },

                // About tab
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)),     "Display name of this mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)),  "Current mod version." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxMods)),  "Open Paradox website for the author's mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),  "Open Discord community support in a browser." },
            };
        }

        public void Unload()
        {
        }
    }
}
