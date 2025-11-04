// Localization/LocaleZH_CN.cs
// Simplified Chinese (zh-HANS) for Options UI.

namespace AdjustSchoolCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleZH_CN : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleZH_CN(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Mod root in Options
                { m_Setting.GetSettingsLocaleID(), "Adjust School Capacity [ASC]" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "操作" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "关于" },

                // Groups - Actions
                { m_Setting.GetOptionGroupLocaleID(Setting.CapacityGroup), "学生容量" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PresetGroup),   "预设" },

                // Groups - About
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGroup),  "信息" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGroup), "支持链接" },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ElementarySlider)), "小学" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ElementarySlider)),
                    "**小学** – 用滑条设置容量 10% - 500%。\n" +
                    "100% = 游戏默认容量。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HighSchoolSlider)), "高中" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.HighSchoolSlider)),
                    "**高中** – 用滑条设置容量 10% - 500%。\n" +
                    "100% = 游戏默认容量。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CollegeSlider)), "学院 / College" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.CollegeSlider)),
                    "**学院 / College** – 用滑条设置容量 10% - 500%。\n" +
                    "100% = 游戏默认容量。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UniversitySlider)), "大学" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UniversitySlider)),
                    "**大学** – 用滑条设置容量 10% - 500%。\n" +
                    "100% = 游戏默认容量。"
                },

                // Preset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "重置为原版" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "把所有容量滑条重置为 100%（游戏默认）。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToModDefault)), "重置为 ASC 预设" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToModDefault)),
                    "使用 ASC 推荐预设：\n" +
                    "**200 / 150 / 120 / 120**"
                },

                // About tab
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)),    "模组" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)),     "这个模组的名称。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)),  "当前模组版本。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxMods)),  "在浏览器中打开 Paradox Mods 上的这个模组页面。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),  "在浏览器中打开社区 Discord。" },
            };
        }

        public void Unload()
        {
        }
    }
}
