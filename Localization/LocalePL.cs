// <copyright file="LocalePL.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocalePL.cs
// Polish (pl-PL) for Options UI.

namespace AdjustSchoolCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocalePL : IDictionarySource
    {
        private readonly ASCSetting m_Setting;

        public LocalePL(ASCSetting setting)
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
                { m_Setting.GetOptionTabLocaleID(ASCSetting.ActionsTab), "Działania" },
                { m_Setting.GetOptionTabLocaleID(ASCSetting.AboutTab),   "O modzie" },

                // Groups - Actions
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.CapacityGroup), "Pojemność szkół" },
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.FeeGroup),      "Opłaty za naukę" },

                // Groups - About
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.AboutInfoGroup),  "Informacje" },
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.AboutLinksGroup), "Łącza pomocy" },

                // Capacity sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ElementarySlider)), "Szkoła podstawowa" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ElementarySlider)),
                    "**Szkoła podstawowa** – dostosuj pojemność suwakiem.\n" +
                    "100% = domyślna pojemność w grze."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HighSchoolSlider)), "Szkoła średnia" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HighSchoolSlider)),
                    "**Szkoła średnia** – dostosuj pojemność suwakiem.\n" +
                    "100% = domyślna pojemność w grze."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.CollegeSlider)), "College" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.CollegeSlider)),
                    "**College** – dostosuj pojemność suwakiem.\n" +
                    "100% = domyślna pojemność w grze."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.UniversitySlider)), "Uniwersytet" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.UniversitySlider)),
                    "**Uniwersytet** – dostosuj pojemność suwakiem.\n" +
                    "100% = domyślna pojemność w grze."
                },

                // Capacity preset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetToVanilla)), "Przywróć Vanilla" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetToVanilla)),
                    "Przywraca wszystkie suwaki pojemności do 100% (domyślne wartości gry)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetToModDefault)), "Szybkie ustawienia" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetToModDefault)),
                    "Zastosuj szybkie ustawienia:\n" +
                    "**200 / 150 / 110 / 100**"
                },

                // School fees
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ControlEducationFees)), "Opłaty edukacyjne" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ControlEducationFees)),
                    "OFF pozostawia standardowe opłaty edukacyjne gry bez zmian.\n" +
                    "ON pozwala ASC sterować poniższymi opłatami w całym mieście. Wyłączenie przywraca opłaty Vanilla.\n" +
                    "Ujemne opłaty wypłacają stypendium wszystkim gospodarstwom ze studentami i zmniejszają budżet miasta.\n" +
                    "Może to zmniejszyć presję finansową na biedne rodziny i ograniczyć wyprowadzki. W tej wersji wszystkie gospodarstwa mają takie same opłaty.\n" +
                    "Nie są to darmowe ani magicznie tworzone pieniądze.\n" +
                    "Gospodarstwa otrzymują pieniądze; skarbiec miasta traci dochód w tej samej kategorii.\n" +
                    "**------------------**\n" +
                    "<100%: opłata Vanilla>\n" +
                    "<0%: gospodarstwa nic nie płacą.>\n" +
                    "<-20%: gospodarstwa otrzymują stypendium równe 20% opłaty Vanilla.>\n" +
                    "<200%: podwójna opłata Vanilla>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ElementaryFeePercent)), "Opłata za szkołę podstawową" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ElementaryFeePercent)),
                    "<100% = opłata Vanilla (100).>\n" +
                    "<0% = bez opłat> Nic nie jest pobierane z gospodarstwa.\n" +
                    "**-5% do -20%** wypłaca stypendium podczas nauki."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HighSchoolFeePercent)), "Opłata za szkołę średnią" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HighSchoolFeePercent)),
                    "<100% = opłata Vanilla (200).>\n" +
                    "<0% = bez opłat> Nic nie jest pobierane z gospodarstwa.\n" +
                    "**-5% do -20%** wypłaca stypendium podczas nauki."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HigherEducationFeePercent)), "Opłata College + Uniwersytet" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HigherEducationFeePercent)),
                    "College i Uniwersytet korzystają z jednej wspólnej opłaty gry.\n" +
                    "<100% = opłata Vanilla (300).>\n" +
                    "<0% = bez opłat.>\n" +
                    "Niższe lub zerowe opłaty mogą zmniejszyć ryzyko rezygnacji z nauki, ale nie zwiększają bezpośrednio szansy zgłoszenia."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.FreeSchools)), "Bezpłatna edukacja" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.FreeSchools)),
                    "Ustawia wszystkie opłaty edukacyjne na 0%. Gospodarstwa ze studentami nie płacą za naukę."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetEducationFees)), "Domyślne gry" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetEducationFees)),
                    "Przywraca wszystkie trzy opłaty edukacyjne do 100% i odtwarza opłaty Vanilla gry."
                },

                // About tab
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.NameDisplay)),     "Nazwa tego moda." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.VersionDisplay)), "Wersja" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.VersionDisplay)),  "Bieżąca wersja moda." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.OpenParadoxMods)),  "Otwórz stronę modów autora w Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.OpenDiscord)),  "Otwórz Discord społeczności w przeglądarce." },
            };
        }

        public void Unload()
        {
        }
    }
}
