// <copyright file="LocaleIT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleIT.cs
// Italian (it-IT) for Options UI.

namespace AdjustSchoolCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleIT : IDictionarySource
    {
        private readonly ASCSetting m_Setting;

        public LocaleIT(ASCSetting setting)
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
                { m_Setting.GetOptionTabLocaleID(ASCSetting.ActionsTab), "Azioni" },
                { m_Setting.GetOptionTabLocaleID(ASCSetting.AboutTab),   "Informazioni" },

                // Groups - Actions
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.CapacityGroup), "Capacità studenti" },
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.FeeGroup),      "Tasse scolastiche" },

                // Groups - About
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.AboutInfoGroup),  "Info" },
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.AboutLinksGroup), "Link di supporto" },

                // Capacity sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ElementarySlider)), "Scuola elementare" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ElementarySlider)),
                    "**Scuola elementare** – personalizza la capacità con il cursore.\n" +
                    "100% = capacità predefinita del gioco."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HighSchoolSlider)), "Scuola superiore" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HighSchoolSlider)),
                    "**Scuola superiore** – personalizza la capacità con il cursore.\n" +
                    "100% = capacità predefinita del gioco."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.CollegeSlider)), "College" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.CollegeSlider)),
                    "**College** – personalizza la capacità con il cursore.\n" +
                    "100% = capacità predefinita del gioco."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.UniversitySlider)), "Università" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.UniversitySlider)),
                    "**Università** – personalizza la capacità con il cursore.\n" +
                    "100% = capacità predefinita del gioco."
                },

                // Capacity preset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetToVanilla)), "Ripristina Vanilla" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetToVanilla)),
                    "Riporta tutti i cursori della capacità al 100% (valore predefinito del gioco)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetToModDefault)), "Preset avvio rapido" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetToModDefault)),
                    "Applica il preset di avvio rapido:\n" +
                    "**200 / 150 / 110 / 100**"
                },

                // School fees
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ControlEducationFees)), "Tasse scolastiche" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ControlEducationFees)),
                    "OFF lascia invariate le normali tasse scolastiche del gioco.\n" +
                    "ON permette ad ASC di controllare le tasse cittadine qui sotto. Disattivandolo vengono ripristinate le tasse Vanilla.\n" +
                    "Le tasse negative pagano un sussidio a tutte le famiglie con studenti iscritti e riducono il bilancio cittadino.\n" +
                    "Questo può alleviare la pressione economica sulle famiglie povere e ridurre i traslochi. In questa versione, le stesse tasse valgono per tutte le famiglie.\n" +
                    "Non è denaro gratuito o creato magicamente.\n" +
                    "Le famiglie ricevono denaro; la tesoreria cittadina perde entrate nella stessa categoria.\n" +
                    "**------------------**\n" +
                    "<100%: tassa Vanilla>\n" +
                    "<0%: le famiglie non pagano nulla.>\n" +
                    "<-20%: le famiglie ricevono un sussidio pari al 20% della tassa Vanilla.>\n" +
                    "<200%: il doppio della tassa Vanilla>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ElementaryFeePercent)), "Tassa scuola elementare" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ElementaryFeePercent)),
                    "<100% = tassa Vanilla (100).>\n" +
                    "<0% = gratuita> Non viene sottratto nulla alla famiglia.\n" +
                    "**Da -5% a -20%** paga un sussidio durante gli studi."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HighSchoolFeePercent)), "Tassa scuola superiore" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HighSchoolFeePercent)),
                    "<100% = tassa Vanilla (200).>\n" +
                    "<0% = gratuita> Non viene sottratto nulla alla famiglia.\n" +
                    "**Da -5% a -20%** paga un sussidio durante gli studi."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HigherEducationFeePercent)), "Tassa College + Università" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HigherEducationFeePercent)),
                    "College e Università condividono una sola tassa di gioco.\n" +
                    "<100% = tassa Vanilla (300).>\n" +
                    "<0% = gratuita.>\n" +
                    "Tasse basse o nulle possono ridurre il rischio di abbandono, ma non aumentano direttamente la probabilità di iscrizione."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.FreeSchools)), "Scuole gratuite" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.FreeSchools)),
                    "Imposta tutte le tasse scolastiche allo 0%. Le famiglie con studenti non pagano tasse scolastiche."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetEducationFees)), "Valori di gioco" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetEducationFees)),
                    "Riporta tutte e tre le tasse scolastiche al 100% e ripristina le tasse Vanilla del gioco."
                },

                // About tab
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.NameDisplay)),     "Nome di questa mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.VersionDisplay)), "Versione" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.VersionDisplay)),  "Versione attuale della mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.OpenParadoxMods)),  "Apri la pagina delle mod dell’autore su Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.OpenDiscord)),  "Apri il Discord della community nel browser." },
            };
        }

        public void Unload()
        {
        }
    }
}
