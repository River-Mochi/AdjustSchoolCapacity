// Localization/LocaleJA.cs
// Japanese (ja-JP) for Options UI.

namespace AdjustSchoolCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleJA : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleJA(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "アクション" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "概要" },

                // Groups - Actions
                { m_Setting.GetOptionGroupLocaleID(Setting.CapacityGroup), "生徒収容人数" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PresetGroup),   "プリセット" },

                // Groups - About
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGroup),  "情報" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGroup), "サポートリンク" },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ElementarySlider)), "小学校" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ElementarySlider)),
                    "**小学校** – スライダーで収容人数を 10% ～ 500% に設定。\n" +
                    "100% = ゲームのデフォルト収容人数。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HighSchoolSlider)), "高校" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.HighSchoolSlider)),
                    "**高校** – スライダーで収容人数を 10% ～ 500% に設定。\n" +
                    "100% = ゲームのデフォルト収容人数。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CollegeSlider)), "カレッジ" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.CollegeSlider)),
                    "**カレッジ** – スライダーで収容人数を 10% ～ 500% に設定。\n" +
                    "100% = ゲームのデフォルト収容人数。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UniversitySlider)), "大学" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UniversitySlider)),
                    "**大学** – スライダーで収容人数を 10% ～ 500% に設定。\n" +
                    "100% = ゲームのデフォルト収容人数。"
                },

                // Preset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "バニラにリセット" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "すべてのスライダーを 100%（ゲーム標準）に戻します。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToModDefault)), "ASC デフォルト" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToModDefault)),
                    "ASC 推奨の初期プリセットを使用：\n" +
                    "**200 / 150 / 120 / 120**"
                },

                // About tab
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)),     "この Mod の名前。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "バージョン" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)),  "現在の Mod バージョン。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxMods)),  "ブラウザーで Paradox Mods のページを開きます。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),  "ブラウザーでコミュニティ Discord を開きます。" },
            };
        }

        public void Unload()
        {
        }
    }
}
