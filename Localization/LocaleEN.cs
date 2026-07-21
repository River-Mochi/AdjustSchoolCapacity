// <copyright file="LocaleEN.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleEN.cs
// English (en-US) for Options UI.

namespace AdjustSchoolCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleEN : IDictionarySource
    {
        private readonly ASCSetting m_Setting;

        public LocaleEN(ASCSetting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            string title = Mod.ShortName;

            // Include the current mod version in the Options title.
            if (!string.IsNullOrEmpty(Mod.ModVersion))
            {
                title = title + " (" + Mod.ModVersion + ")";
            }

            return new Dictionary<string, string>
            {
                // Mod name in options
                { m_Setting.GetSettingsLocaleID(), title },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(ASCSetting.ActionsTab), "Actions" },
                { m_Setting.GetOptionTabLocaleID(ASCSetting.AboutTab),   "About"   },

                // Groups - Actions
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.CapacityGroup), "Student Capacity" },
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.FeeGroup),      "School Fees" },
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.PresetGroup),   "Presets" },

                // Groups - About
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.AboutInfoGroup),  "Info" },
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.AboutLinksGroup), "Support Links" },

                // Capacity sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ElementarySlider)), "Elementary" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ElementarySlider)),
                    "**Elementary school** – customize capacity 10% - 1000% using the slider.\n" +
                    "100% = game's default capacity."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HighSchoolSlider)), "High School" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HighSchoolSlider)),
                    "**High school** – customize capacity 10% - 1000% using the slider.\n" +
                    "100% = game's default capacity."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.CollegeSlider)), "College" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.CollegeSlider)),
                    "**College** – customize capacity 10% - 500% using the slider.\n" +
                    "100% = game's default capacity."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.UniversitySlider)), "University" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.UniversitySlider)),
                    "**University** – customize capacity 10% - 500% using the slider.\n" +
                    "100% = game's default capacity."
                },

                // School fees
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ControlEducationFees)),
                    "Education Fees"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ControlEducationFees)),
                    "OFF leaves the game's normal education fees unchanged.\n" +
                    "ON lets ASC control the city-wide fees below. Turning it OFF restores vanilla fees.\n" +
                    "Negative fees pay a stipend to every enrolled student's household and reduce the city budget. " +
                    "This can ease financial pressure on poor families. This first version applies equally to all families."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ElementaryFeePercent)),
                    "Elementary Fee"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ElementaryFeePercent)),
                    "100% = vanilla fee (100). 0% = no fee, so nothing is removed from the household.\n" +
                    "-1% to -20% pays a student stipend while enrolled."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HighSchoolFeePercent)),
                    "High School Fee"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HighSchoolFeePercent)),
                    "100% = vanilla fee (200). 0% = no fee, so nothing is removed from the household.\n" +
                    "-1% to -20% pays a student stipend while enrolled."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HigherEducationFeePercent)),
                    "College + University fee"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HigherEducationFeePercent)),
                    "College and University share one game fee.\n" +
                    "<100% = vanilla fee (300)>\n" +
                    "<0% = no fee.>\n" +
                    "Lower or zero fees may reduce dropout pressure, but fees do not directly make cims more likely to apply."
                },

                // Preset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetToVanilla)), "Reset to Vanilla" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetToVanilla)),
                    "Bring all capacity sliders back to 100% (game's default capacity)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetToModDefault)), "Quick Start Presets" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetToModDefault)),
                    "Set Quick Start preset:\n" +
                    "**200 / 150 / 110 / 100**"
                },

                // About tab
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.NameDisplay)),     "Display name of this mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.VersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.VersionDisplay)),  "Current mod version." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.OpenParadoxMods)),  "Open Paradox website for the author's mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.OpenDiscord)),  "Open Discord community support in a browser." },
            };
        }

        public void Unload()
        {
        }
    }
}
