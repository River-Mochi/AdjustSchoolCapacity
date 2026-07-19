// <copyright file="LocalePL.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// Localization/LocalePL.cs
// Polish (pl-PL) for Options UI.

namespace AdjustSchoolCapacity
{
    using System.Collections.Generic;

    using Colossal;

    public sealed class LocalePL : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocalePL(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Opcje" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "O modzie" },

                // Groups - Actions
                { m_Setting.GetOptionGroupLocaleID(Setting.CapacityGroup), "Pojemność uczniów" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PresetGroup),   "Presety" },

                // Groups - About
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGroup),  "Informacje" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGroup), "Linki wsparcia" },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ElementarySlider)), "Szkoła podstawowa" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ElementarySlider)),
                    "**Szkoła podstawowa** – dostosuj pojemność od 10% do 500% suwakiem.\n" +
                    "100% = domyślna pojemność gry."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HighSchoolSlider)), "Liceum" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.HighSchoolSlider)),
                    "**Liceum** – dostosuj pojemność od 10% do 500% suwakiem.\n" +
                    "100% = domyślna pojemność gry."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CollegeSlider)), "Kolegium" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.CollegeSlider)),
                    "**Kolegium** – dostosuj pojemność od 10% do 500% suwakiem.\n" +
                    "100% = domyślna pojemność gry."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UniSlider)), "Uniwersytet" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UniSlider)),
                    "**Uniwersytet** – dostosuj pojemność od 10% do 500% suwakiem.\n" +
                    "100% = domyślna pojemność gry."
                },

                // Preset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Przywróć domyślne" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "Ustaw wszystkie suwaki pojemności z powrotem na 100% (domyślne wartości gry)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToModDefault)), "Presety szybkiego startu" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToModDefault)),
                    "Ustaw preset szybkiego startu:\n" +
                    "**200 / 150 / 110 / 100**"
                },

                // About tab
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)),     "Nazwa tego moda." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Wersja" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)),  "Aktualna wersja moda." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxMods)),  "Otwórz ten mod na stronie Paradox Mods w przeglądarce." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),  "Otwórz społeczność Discord w przeglądarce." },
            };
        }

        public void Unload()
        {
        }
    }
}
