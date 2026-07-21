// <copyright file="LocaleUK.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleUK.cs
// Ukrainian (uk-UA) for Options UI.

namespace AdjustSchoolCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleUK : IDictionarySource
    {
        private readonly ASCSetting m_Setting;

        public LocaleUK(ASCSetting setting)
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
                { m_Setting.GetOptionTabLocaleID(ASCSetting.ActionsTab), "Дії" },
                { m_Setting.GetOptionTabLocaleID(ASCSetting.AboutTab),   "Про мод" },

                // Groups - Actions
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.CapacityGroup), "Місткість навчальних закладів" },
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.FeeGroup),      "Плата за навчання" },

                // Groups - About
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.AboutInfoGroup),  "Інформація" },
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.AboutLinksGroup), "Посилання підтримки" },

                // Capacity sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ElementarySlider)), "Початкова школа" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ElementarySlider)),
                    "**Початкова школа** – налаштуйте місткість за допомогою повзунка.\n" +
                    "100% = стандартна місткість гри."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HighSchoolSlider)), "Старша школа" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HighSchoolSlider)),
                    "**Старша школа** – налаштуйте місткість за допомогою повзунка.\n" +
                    "100% = стандартна місткість гри."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.CollegeSlider)), "Коледж" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.CollegeSlider)),
                    "**Коледж** – налаштуйте місткість за допомогою повзунка.\n" +
                    "100% = стандартна місткість гри."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.UniversitySlider)), "Університет" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.UniversitySlider)),
                    "**Університет** – налаштуйте місткість за допомогою повзунка.\n" +
                    "100% = стандартна місткість гри."
                },

                // Capacity preset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetToVanilla)), "Скинути до стандартних" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetToVanilla)),
                    "Повернути всі повзунки місткості до 100% (стандартна місткість гри)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetToModDefault)), "Швидкі налаштування" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetToModDefault)),
                    "Застосувати швидке налаштування:\n" +
                    "**200 / 150 / 110 / 100**"
                },

                // School fees
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ControlEducationFees)), "Плата за освіту" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ControlEducationFees)),
                    "OFF не змінює звичайну плату за освіту в грі.\n" +
                    "ON дозволяє ASC керувати наведеними нижче загальноміськими платежами. Вимкнення повертає стандартні значення гри.\n" +
                    "Від’ємна плата виплачує стипендію всім домогосподарствам із зарахованими учнями або студентами та зменшує міський бюджет.\n" +
                    "Це може зменшити фінансовий тиск на бідні сім’ї та скоротити кількість переїздів. У цій версії однакові платежі застосовуються до всіх домогосподарств.\n" +
                    "Це не безкоштовні або чарівним чином створені гроші.\n" +
                    "Домогосподарства отримують гроші; міська скарбниця втрачає дохід у тій самій категорії.\n" +
                    "**------------------**\n" +
                    "<100%: стандартна плата гри>\n" +
                    "<0%: домогосподарства нічого не сплачують.>\n" +
                    "<-20%: домогосподарства отримують стипендію, що дорівнює 20% стандартної плати.>\n" +
                    "<200%: подвійна стандартна плата>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ElementaryFeePercent)), "Плата за початкову школу" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ElementaryFeePercent)),
                    "<100% = стандартна плата гри (100).>\n" +
                    "<0% = безкоштовно> З домогосподарства нічого не списується.\n" +
                    "**Від -5% до -20%** виплачує стипендію під час навчання."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HighSchoolFeePercent)), "Плата за старшу школу" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HighSchoolFeePercent)),
                    "<100% = стандартна плата гри (200).>\n" +
                    "<0% = безкоштовно> З домогосподарства нічого не списується.\n" +
                    "**Від -5% до -20%** виплачує стипендію під час навчання."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HigherEducationFeePercent)), "Плата за коледж + університет" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HigherEducationFeePercent)),
                    "Коледж і університет використовують одну спільну плату в грі.\n" +
                    "<100% = стандартна плата гри (300).>\n" +
                    "<0% = безкоштовно.>\n" +
                    "Нижча або нульова плата може зменшити ризик відрахування, але не підвищує безпосередньо ймовірність вступу."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.FreeSchools)), "Безкоштовна освіта" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.FreeSchools)),
                    "Встановити всю плату за освіту на 0%. Домогосподарства учнів і студентів не сплачують за навчання.\n" +
                    "Це не безкоштовні або чарівним чином створені гроші.\n" +
                    "Міська скарбниця втрачає звичайний дохід від плати за освіту.\n" +
                    "**------------------**\n" +
                    "<100%: стандартна плата гри>\n" +
                    "<0%: домогосподарства нічого не сплачують.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetEducationFees)), "Стандартні значення гри" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetEducationFees)),
                    "Повернути всі повзунки плати за освіту до 100% і відновити стандартні значення гри."
                },

                // About tab
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.NameDisplay)),    "Мод" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.NameDisplay)),     "Назва цього мода." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.VersionDisplay)), "Версія" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.VersionDisplay)),  "Поточна версія мода." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.OpenParadoxMods)),  "Відкрити сторінку модів автора на Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.OpenDiscord)),  "Відкрити Discord спільноти у браузері." },
            };
        }

        public void Unload()
        {
        }
    }
}
