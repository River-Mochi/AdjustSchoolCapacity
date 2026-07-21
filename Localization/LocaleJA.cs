// <copyright file="LocaleJA.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleJA.cs
// Japanese (ja-JP) for Options UI.

namespace AdjustSchoolCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleJA : IDictionarySource
    {
        private readonly ASCSetting m_Setting;

        public LocaleJA(ASCSetting setting)
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
                { m_Setting.GetOptionTabLocaleID(ASCSetting.ActionsTab), "アクション" },
                { m_Setting.GetOptionTabLocaleID(ASCSetting.AboutTab),   "情報" },

                // Groups - Actions
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.CapacityGroup), "生徒定員" },
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.FeeGroup),      "教育費" },

                // Groups - About
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.AboutInfoGroup),  "情報" },
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.AboutLinksGroup), "サポートリンク" },

                // Capacity sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ElementarySlider)), "小学校" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ElementarySlider)),
                    "**小学校** – スライダーで定員を調整します。\n" +
                    "100% = ゲーム標準の定員です。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HighSchoolSlider)), "高校" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HighSchoolSlider)),
                    "**高校** – スライダーで定員を調整します。\n" +
                    "100% = ゲーム標準の定員です。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.CollegeSlider)), "カレッジ" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.CollegeSlider)),
                    "**カレッジ** – スライダーで定員を調整します。\n" +
                    "100% = ゲーム標準の定員です。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.UniversitySlider)), "大学" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.UniversitySlider)),
                    "**大学** – スライダーで定員を調整します。\n" +
                    "100% = ゲーム標準の定員です。"
                },

                // Capacity preset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetToVanilla)), "バニラに戻す" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetToVanilla)),
                    "すべての定員スライダーを100%（ゲーム標準）に戻します。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetToModDefault)), "クイックスタート" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetToModDefault)),
                    "クイックスタートのプリセットを適用：\n" +
                    "**200 / 150 / 110 / 100**"
                },

                // School fees
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ControlEducationFees)), "教育費" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ControlEducationFees)),
                    "OFFではゲーム標準の教育費を変更しません。\n" +
                    "ONではASCが下の都市全体の教育費を制御します。OFFに戻すとバニラの教育費を復元します。\n" +
                    "負の教育費は、在学中の生徒・学生がいる全世帯に給付金を支払い、都市予算を減らします。\n" +
                    "貧困世帯の負担を軽くし、転出を減らす可能性があります。このバージョンでは全世帯に同じ教育費が適用されます。\n" +
                    "無料または魔法で生み出されるお金ではありません。\n" +
                    "世帯が受け取った分だけ、都市財政の同じ収入項目が減ります。\n" +
                    "**------------------**\n" +
                    "<100%：バニラの教育費>\n" +
                    "<0%：世帯は教育費を支払いません。>\n" +
                    "<-20%：バニラ教育費の20%に相当する給付金を世帯が受け取ります。>\n" +
                    "<200%：バニラ教育費の2倍>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ElementaryFeePercent)), "小学校の教育費" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ElementaryFeePercent)),
                    "<100% = バニラ教育費（100）。>\n" +
                    "<0% = 無料> 世帯からお金を引きません。\n" +
                    "**-5%～-20%**では在学中に給付金を支払います。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HighSchoolFeePercent)), "高校の教育費" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HighSchoolFeePercent)),
                    "<100% = バニラ教育費（200）。>\n" +
                    "<0% = 無料> 世帯からお金を引きません。\n" +
                    "**-5%～-20%**では在学中に給付金を支払います。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HigherEducationFeePercent)), "カレッジ＋大学の教育費" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HigherEducationFeePercent)),
                    "カレッジと大学はゲーム内で同じ教育費を共有します。\n" +
                    "<100% = バニラ教育費（300）。>\n" +
                    "<0% = 無料。>\n" +
                    "教育費を下げるか無料にすると中退圧力が下がる可能性がありますが、入学申請率を直接高めるものではありません。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.FreeSchools)), "教育費無料" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.FreeSchools)),
                    "すべての教育費を0%にします。生徒・学生がいる世帯は教育費を支払いません。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetEducationFees)), "ゲーム標準" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetEducationFees)),
                    "3つの教育費を100%に戻し、ゲームのバニラ教育費を復元します。"
                },

                // About tab
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.NameDisplay)),     "このModの表示名です。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.VersionDisplay)), "バージョン" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.VersionDisplay)),  "現在のModバージョンです。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.OpenParadoxMods)),  "作者のParadox Modsページを開きます。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.OpenDiscord)),  "コミュニティDiscordをブラウザーで開きます。" },
            };
        }

        public void Unload()
        {
        }
    }
}
