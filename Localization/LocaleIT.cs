// <copyright file="LocaleIT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// Localization/LocaleIT.cs
// Italian (it-IT) for Options UI.

namespace AdjustSchoolCapacity
{
    using System.Collections.Generic;

    using Colossal;

    public sealed class LocaleIT : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleIT(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Azioni" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "Info" },

                // Groups - Actions
                { m_Setting.GetOptionGroupLocaleID(Setting.CapacityGroup), "Capienza studenti" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PresetGroup),   "Preset" },

                // Groups - About
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGroup),  "Informazioni" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGroup), "Link di supporto" },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ElementarySlider)), "Scuola elementare" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ElementarySlider)),
                    "**Scuola elementare** – imposta la capienza tra 10% e 1000% con lo slider.\n" +
                    "100% = capienza predefinita del gioco."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HighSchoolSlider)), "Scuola superiore" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.HighSchoolSlider)),
                    "**Scuola superiore** – imposta la capienza tra 10% e 1000% con lo slider.\n" +
                    "100% = capienza predefinita del gioco."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CollegeSlider)), "College" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.CollegeSlider)),
                    "**College** – imposta la capienza tra 10% e 500% con lo slider.\n" +
                    "100% = capienza predefinita del gioco."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UniversitySlider)), "Università" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UniversitySlider)),
                    "**Università** – imposta la capienza tra 10% e 500% con lo slider.\n" +
                    "100% = capienza predefinita del gioco."
                },

                // Preset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Ripristina Vanilla" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "Riporta tutti gli slider di capienza al 100% (valore base del gioco)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToModDefault)), "Preset di avvio rapido" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToModDefault)),
                    "Imposta il preset di avvio rapido:\n" +
                    "**200 / 150 / 110 / 100**"
                },

                // About tab
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)),     "Nome di questa mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Versione" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)),  "Versione attuale della mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxMods)),  "Apri questa mod su Paradox Mods nel browser." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),  "Apri il Discord della community nel browser." },
            };
        }

        public void Unload()
        {
        }
    }
}
