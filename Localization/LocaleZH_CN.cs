// <copyright file="LocaleZH_CN.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleZH_CN.cs
// Simplified Chinese (zh-HANS) for Options UI.

namespace AdjustSchoolCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleZH_CN : IDictionarySource
    {
        private readonly ASCSetting m_Setting;

        public LocaleZH_CN(ASCSetting setting)
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
                { m_Setting.GetOptionTabLocaleID(ASCSetting.AboutTab),   "关于" },

                // Groups - Actions
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.CapacityGroup), "学生容量" },
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.FeeGroup),      "教育费用" },

                // Groups - About
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.AboutInfoGroup),  "信息" },
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.AboutLinksGroup), "支持链接" },

                // Capacity sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ElementarySlider)), "小学" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ElementarySlider)),
                    "**小学** – 使用滑块调整容量。\n" +
                    "100% = 游戏默认容量。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HighSchoolSlider)), "高中" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HighSchoolSlider)),
                    "**高中** – 使用滑块调整容量。\n" +
                    "100% = 游戏默认容量。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.CollegeSlider)), "学院" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.CollegeSlider)),
                    "**学院** – 使用滑块调整容量。\n" +
                    "100% = 游戏默认容量。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.UniversitySlider)), "大学" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.UniversitySlider)),
                    "**大学** – 使用滑块调整容量。\n" +
                    "100% = 游戏默认容量。"
                },

                // Capacity preset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetToVanilla)), "恢复原版" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetToVanilla)),
                    "将所有容量滑块恢复为100%（游戏默认容量）。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetToModDefault)), "快速开始预设" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetToModDefault)),
                    "应用快速开始预设：\n" +
                    "**200 / 150 / 110 / 100**"
                },

                // School fees
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ControlEducationFees)), "教育费用" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ControlEducationFees)),
                    "OFF不会改变游戏的正常教育费用。\n" +
                    "ON允许ASC控制下方的全市教育费用。关闭后会恢复原版费用。\n" +
                    "负费用会向所有有在校学生的家庭发放补助，并减少城市预算。\n" +
                    "这可能减轻贫困家庭的经济压力并减少搬离。本版本对所有家庭使用相同费用。\n" +
                    "这不是免费或凭空产生的钱。\n" +
                    "学生家庭收到多少钱，城市财政就在同一收入类别中减少多少钱。\n" +
                    "**------------------**\n" +
                    "<100%：原版费用>\n" +
                    "<0%：家庭无需支付费用。>\n" +
                    "<-20%：家庭获得相当于原版费用20%的补助。>\n" +
                    "<200%：原版费用的两倍>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ElementaryFeePercent)), "小学费用" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ElementaryFeePercent)),
                    "<100% = 原版费用（100）。>\n" +
                    "<0% = 免费> 不会从家庭扣除任何费用。\n" +
                    "**-5%至-20%**会在就读期间发放补助。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HighSchoolFeePercent)), "高中费用" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HighSchoolFeePercent)),
                    "<100% = 原版费用（200）。>\n" +
                    "<0% = 免费> 不会从家庭扣除任何费用。\n" +
                    "**-5%至-20%**会在就读期间发放补助。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HigherEducationFeePercent)), "学院 + 大学费用" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HigherEducationFeePercent)),
                    "学院和大学共用一个游戏费用。\n" +
                    "<100% = 原版费用（300）。>\n" +
                    "<0% = 免费。>\n" +
                    "降低或取消费用可能减少退学压力，但不会直接提高市民申请入学的概率。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.FreeSchools)), "免费教育" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.FreeSchools)),
                    "将所有教育费用设为0%。有在校学生的家庭无需支付教育费用。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetEducationFees)), "游戏默认值" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetEducationFees)),
                    "将三项教育费用恢复为100%，并恢复游戏的原版教育费用。"
                },

                // About tab
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.NameDisplay)),    "模组" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.NameDisplay)),     "此模组的显示名称。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.VersionDisplay)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.VersionDisplay)),  "当前模组版本。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.OpenParadoxMods)),  "打开作者的Paradox Mods页面。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.OpenDiscord)),  "在浏览器中打开社区Discord。" },
            };
        }

        public void Unload()
        {
        }
    }
}
