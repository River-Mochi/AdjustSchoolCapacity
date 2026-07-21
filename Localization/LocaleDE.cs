// <copyright file="LocaleDE.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleDE.cs
// German (de-DE) for Options UI.

namespace AdjustSchoolCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleDE : IDictionarySource
    {
        private readonly ASCSetting m_Setting;

        public LocaleDE(ASCSetting setting)
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
                { m_Setting.GetOptionTabLocaleID(ASCSetting.ActionsTab), "Aktionen" },
                { m_Setting.GetOptionTabLocaleID(ASCSetting.AboutTab),   "Info" },

                // Groups - Actions
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.CapacityGroup), "Schülerkapazität" },
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.FeeGroup),      "Schulgebühren" },

                // Groups - About
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.AboutInfoGroup),  "Info" },
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.AboutLinksGroup), "Support-Links" },

                // Capacity sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ElementarySlider)), "Grundschule" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ElementarySlider)),
                    "**Grundschule** – Kapazität mit dem Schieberegler anpassen.\n" +
                    "100% = Standardkapazität des Spiels."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HighSchoolSlider)), "Gymnasium" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HighSchoolSlider)),
                    "**Gymnasium** – Kapazität mit dem Schieberegler anpassen.\n" +
                    "100% = Standardkapazität des Spiels."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.CollegeSlider)), "College" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.CollegeSlider)),
                    "**College** – Kapazität mit dem Schieberegler anpassen.\n" +
                    "100% = Standardkapazität des Spiels."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.UniversitySlider)), "Universität" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.UniversitySlider)),
                    "**Universität** – Kapazität mit dem Schieberegler anpassen.\n" +
                    "100% = Standardkapazität des Spiels."
                },

                // Capacity preset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetToVanilla)), "Auf Vanilla zurücksetzen" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetToVanilla)),
                    "Alle Kapazitätsregler auf 100% zurücksetzen (Standardkapazität des Spiels)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetToModDefault)), "Schnellstart-Presets" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetToModDefault)),
                    "Schnellstart-Preset anwenden:\n" +
                    "**200 / 150 / 110 / 100**"
                },

                // School fees
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ControlEducationFees)), "Bildungsgebühren" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ControlEducationFees)),
                    "OFF lässt die normalen Bildungsgebühren des Spiels unverändert.\n" +
                    "ON lässt ASC die unten aufgeführten stadtweiten Gebühren steuern. Beim Ausschalten werden die Vanilla-Gebühren wiederhergestellt.\n" +
                    "Negative Gebühren zahlen allen Haushalten mit eingeschriebenen Schülern oder Studierenden ein Stipendium und belasten den Stadthaushalt.\n" +
                    "Dies kann den finanziellen Druck auf arme Familien senken und Wegzüge reduzieren. In dieser Version gelten dieselben Gebühren für alle Haushalte.\n" +
                    "Das Geld wird nicht kostenlos oder magisch erzeugt.\n" +
                    "Die Haushalte erhalten Geld; der Stadthaushalt verliert Einnahmen in derselben Kategorie.\n" +
                    "**------------------**\n" +
                    "<100%: Vanilla-Gebühr>\n" +
                    "<0%: Haushalte zahlen nichts.>\n" +
                    "<-20%: Haushalte erhalten ein Stipendium in Höhe von 20% der Vanilla-Gebühr.>\n" +
                    "<200%: doppelte Vanilla-Gebühr>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ElementaryFeePercent)), "Grundschulgebühr" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ElementaryFeePercent)),
                    "<100% = Vanilla-Gebühr (100).>\n" +
                    "<0% = gebührenfrei> Dem Haushalt wird nichts abgezogen.\n" +
                    "**-5% bis -20%** zahlt während der Schulzeit ein Stipendium."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HighSchoolFeePercent)), "Gymnasialgebühr" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HighSchoolFeePercent)),
                    "<100% = Vanilla-Gebühr (200).>\n" +
                    "<0% = gebührenfrei> Dem Haushalt wird nichts abgezogen.\n" +
                    "**-5% bis -20%** zahlt während der Schulzeit ein Stipendium."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HigherEducationFeePercent)), "College- und Universitätsgebühr" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HigherEducationFeePercent)),
                    "College und Universität verwenden dieselbe Spielgebühr.\n" +
                    "<100% = Vanilla-Gebühr (300).>\n" +
                    "<0% = gebührenfrei.>\n" +
                    "Niedrigere oder keine Gebühren können den Abbruchdruck verringern, erhöhen aber nicht direkt die Bewerbungswahrscheinlichkeit."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.FreeSchools)), "Kostenlose Bildung" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.FreeSchools)),
                "Alle Bildungsgebühren auf 0% setzen. Haushalte mit Schülern oder Studierenden zahlen keine Schulgebühren.\n" +
                "Das Geld wird nicht kostenlos oder magisch erzeugt.\n" +
                "Der Stadthaushalt verliert die normalen Einnahmen aus Bildungsgebühren.\n" +
                "**------------------**\n" +
                "<100%: Vanilla-Gebühr>\n" +
                "<0%: Haushalte zahlen nichts.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetEducationFees)), "Spielstandard" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetEducationFees)),
                    "Alle drei Bildungsgebühren auf 100% setzen und die Vanilla-Gebühren des Spiels wiederherstellen."
                },

                // About tab
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.NameDisplay)),     "Name dieses Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.VersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.VersionDisplay)),  "Aktuelle Mod-Version." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.OpenParadoxMods)),  "Die Mod-Seite des Autors auf Paradox Mods öffnen." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.OpenDiscord)),  "Den Community-Discord im Browser öffnen." },
            };
        }

        public void Unload()
        {
        }
    }
}
