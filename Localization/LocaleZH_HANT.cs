// <copyright file="LocaleZH_HANT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleZH_HANT.cs
// Traditional Chinese (zh-HANT) for Options UI.

namespace AdjustSchoolCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleZH_HANT : IDictionarySource
    {
        private readonly ASCSetting m_Setting;

        public LocaleZH_HANT(ASCSetting setting)
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
                { m_Setting.GetOptionTabLocaleID(ASCSetting.ActionsTab), "操作" },
                { m_Setting.GetOptionTabLocaleID(ASCSetting.AboutTab),   "關於" },

                // Groups - Actions
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.CapacityGroup), "學生容量" },
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.FeeGroup),      "教育費用" },

                // Groups - About
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.AboutInfoGroup),  "資訊" },
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.AboutLinksGroup), "支援連結" },

                // Capacity sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ElementarySlider)), "小學" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ElementarySlider)),
                    "**小學** – 使用滑桿調整容量。\n" +
                    "100% = 遊戲預設容量。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HighSchoolSlider)), "高中" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HighSchoolSlider)),
                    "**高中** – 使用滑桿調整容量。\n" +
                    "100% = 遊戲預設容量。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.CollegeSlider)), "學院" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.CollegeSlider)),
                    "**學院** – 使用滑桿調整容量。\n" +
                    "100% = 遊戲預設容量。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.UniversitySlider)), "大學" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.UniversitySlider)),
                    "**大學** – 使用滑桿調整容量。\n" +
                    "100% = 遊戲預設容量。"
                },

                // Capacity preset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetToVanilla)), "恢復原版" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetToVanilla)),
                    "將所有容量滑桿恢復為100%（遊戲預設容量）。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetToModDefault)), "快速開始預設" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetToModDefault)),
                    "套用快速開始預設：\n" +
                    "**200 / 150 / 110 / 100**"
                },

                // School fees
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ControlEducationFees)), "教育費用" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ControlEducationFees)),
                    "OFF不會變更遊戲的正常教育費用。\n" +
                    "ON允許ASC控制下方的全市教育費用。關閉後會恢復原版費用。\n" +
                    "負費用會向所有有在校學生的家庭發放補助，並減少城市預算。\n" +
                    "這可能減輕貧困家庭的經濟壓力並減少搬離。本版本對所有家庭使用相同費用。\n" +
                    "這不是免費或憑空產生的金錢。\n" +
                    "學生家庭收到多少錢，城市財政就在同一收入類別中減少多少錢。\n" +
                    "**------------------**\n" +
                    "<100%：原版費用>\n" +
                    "<0%：家庭無須支付費用。>\n" +
                    "<-20%：家庭獲得相當於原版費用20%的補助。>\n" +
                    "<200%：原版費用的兩倍>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ElementaryFeePercent)), "小學費用" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ElementaryFeePercent)),
                    "<100% = 原版費用（100）。>\n" +
                    "<0% = 免費> 不會從家庭扣除任何費用。\n" +
                    "**-5%至-20%**會在就讀期間發放補助。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HighSchoolFeePercent)), "高中費用" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HighSchoolFeePercent)),
                    "<100% = 原版費用（200）。>\n" +
                    "<0% = 免費> 不會從家庭扣除任何費用。\n" +
                    "**-5%至-20%**會在就讀期間發放補助。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HigherEducationFeePercent)), "學院 + 大學費用" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HigherEducationFeePercent)),
                    "學院和大學共用一項遊戲費用。\n" +
                    "<100% = 原版費用（300）。>\n" +
                    "<0% = 免費。>\n" +
                    "降低或取消費用可能減少退學壓力，但不會直接提高市民申請入學的機率。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.FreeSchools)), "免費教育" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.FreeSchools)),
                    "將所有教育費用設為0%。有在校學生的家庭無須支付教育費用。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetEducationFees)), "遊戲預設值" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetEducationFees)),
                    "將三項教育費用恢復為100%，並恢復遊戲的原版教育費用。"
                },

                // About tab
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.NameDisplay)),    "模組" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.NameDisplay)),     "此模組的顯示名稱。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.VersionDisplay)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.VersionDisplay)),  "目前的模組版本。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.OpenParadoxMods)),  "開啟作者的Paradox Mods頁面。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.OpenDiscord)),  "在瀏覽器中開啟社群Discord。" },
            };
        }

        public void Unload()
        {
        }
    }
}
