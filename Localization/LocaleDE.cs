// <copyright file="LocaleDE.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// Localization/LocaleDE.cs
// German (de-DE) for Options UI.

namespace AdjustSchoolCapacity
{
    using System.Collections.Generic;

    using Colossal;

    public sealed class LocaleDE : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleDE(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Aktionen" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "Info" },

                // Groups - Actions
                { m_Setting.GetOptionGroupLocaleID(Setting.CapacityGroup), "Schülerkapazität" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PresetGroup),   "Voreinstellungen" },

                // Groups - About
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGroup),  "Info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGroup), "Support-Links" },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ElementarySlider)), "Grundschule" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ElementarySlider)),
                    "**Grundschule** – Kapazität mit dem Schieberegler auf 10% - 1000% einstellen.\n" +
                    "100% = Standardkapazität des Spiels."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HighSchoolSlider)), "Gymnasium" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.HighSchoolSlider)),
                    "**Gymnasium** – Kapazität mit dem Schieberegler auf 10% - 1000% einstellen.\n" +
                    "100% = Standardkapazität des Spiels."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CollegeSlider)), "College" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.CollegeSlider)),
                    "**College** – Kapazität mit dem Schieberegler auf 10% - 500% einstellen.\n" +
                    "100% = Standardkapazität des Spiels."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UniSlider)), "Universität" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UniSlider)),
                    "**Universität** – Kapazität mit dem Schieberegler auf 10% - 500% einstellen.\n" +
                    "100% = Standardkapazität des Spiels."
                },

                // Preset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Auf Vanilla zurücksetzen" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "Setzt alle Kapazitätsregler auf 100% zurück (Standard im Spiel)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToModDefault)), "Schnellstart-Presets" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToModDefault)),
                    "Schnellstart-Preset setzen:\n" +
                    "**200 / 150 / 110 / 100**"
                },

                // About tab
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)),     "Name dieses Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)),  "Aktuelle Mod-Version." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxMods)),  "Diese Mod-Seite auf Paradox Mods im Browser öffnen." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),  "Den Community-Discord im Browser öffnen." },
            };
        }

        public void Unload()
        {
        }
    }
}
