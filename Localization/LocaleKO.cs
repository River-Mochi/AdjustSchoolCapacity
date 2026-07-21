// <copyright file="LocaleKO.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleKO.cs
// Korean (ko-KR) for Options UI.

namespace AdjustSchoolCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleKO : IDictionarySource
    {
        private readonly ASCSetting m_Setting;

        public LocaleKO(ASCSetting setting)
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
                { m_Setting.GetOptionTabLocaleID(ASCSetting.ActionsTab), "작업" },
                { m_Setting.GetOptionTabLocaleID(ASCSetting.AboutTab),   "정보" },

                // Groups - Actions
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.CapacityGroup), "학생 정원" },
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.FeeGroup),      "교육비" },

                // Groups - About
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.AboutInfoGroup),  "정보" },
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.AboutLinksGroup), "지원 링크" },

                // Capacity sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ElementarySlider)), "초등학교" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ElementarySlider)),
                    "**초등학교** – 슬라이더로 정원을 조정합니다.\n" +
                    "100% = 게임 기본 정원입니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HighSchoolSlider)), "고등학교" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HighSchoolSlider)),
                    "**고등학교** – 슬라이더로 정원을 조정합니다.\n" +
                    "100% = 게임 기본 정원입니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.CollegeSlider)), "전문대학" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.CollegeSlider)),
                    "**전문대학** – 슬라이더로 정원을 조정합니다.\n" +
                    "100% = 게임 기본 정원입니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.UniversitySlider)), "대학교" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.UniversitySlider)),
                    "**대학교** – 슬라이더로 정원을 조정합니다.\n" +
                    "100% = 게임 기본 정원입니다."
                },

                // Capacity preset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetToVanilla)), "바닐라로 초기화" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetToVanilla)),
                    "모든 정원 슬라이더를 100%(게임 기본값)로 되돌립니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetToModDefault)), "빠른 시작 프리셋" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetToModDefault)),
                    "빠른 시작 프리셋 적용:\n" +
                    "**200 / 150 / 110 / 100**"
                },

                // School fees
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ControlEducationFees)), "교육비" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ControlEducationFees)),
                    "OFF는 게임의 일반 교육비를 변경하지 않습니다.\n" +
                    "ON은 ASC가 아래의 도시 전체 교육비를 제어합니다. OFF로 전환하면 바닐라 교육비가 복원됩니다.\n" +
                    "음수 교육비는 재학 중인 학생이 있는 모든 가구에 장학금을 지급하고 도시 예산을 줄입니다.\n" +
                    "빈곤 가구의 재정 부담을 줄이고 이사를 줄이는 데 도움이 될 수 있습니다. 이 버전에서는 모든 가구에 동일한 교육비가 적용됩니다.\n" +
                    "무료 또는 마법으로 생기는 돈이 아닙니다.\n" +
                    "학생 가구가 돈을 받는 만큼 도시 재정의 같은 수입 항목이 줄어듭니다.\n" +
                    "**------------------**\n" +
                    "<100%: 바닐라 교육비>\n" +
                    "<0%: 가구가 아무것도 내지 않음.>\n" +
                    "<-20%: 가구가 바닐라 교육비의 20%에 해당하는 장학금을 받음.>\n" +
                    "<200%: 바닐라 교육비의 2배>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ElementaryFeePercent)), "초등학교 교육비" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ElementaryFeePercent)),
                    "<100% = 바닐라 교육비 (100).>\n" +
                    "<0% = 무료> 가구에서 돈이 빠져나가지 않습니다.\n" +
                    "**-5%~-20%**는 재학 중 장학금을 지급합니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HighSchoolFeePercent)), "고등학교 교육비" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HighSchoolFeePercent)),
                    "<100% = 바닐라 교육비 (200).>\n" +
                    "<0% = 무료> 가구에서 돈이 빠져나가지 않습니다.\n" +
                    "**-5%~-20%**는 재학 중 장학금을 지급합니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HigherEducationFeePercent)), "전문대학 + 대학교 교육비" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HigherEducationFeePercent)),
                    "전문대학과 대학교는 게임에서 하나의 교육비를 공유합니다.\n" +
                    "<100% = 바닐라 교육비 (300).>\n" +
                    "<0% = 무료.>\n" +
                    "교육비를 낮추거나 무료로 하면 중퇴 압박이 줄 수 있지만, 입학 지원 확률을 직접 높이지는 않습니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.FreeSchools)), "무상 교육" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.FreeSchools)),
                    "모든 교육비를 0%로 설정합니다. 학생 가구는 교육비를 내지 않습니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetEducationFees)), "게임 기본값" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetEducationFees)),
                    "세 교육비를 모두 100%로 되돌리고 게임의 바닐라 교육비를 복원합니다."
                },

                // About tab
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.NameDisplay)),    "모드" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.NameDisplay)),     "이 모드의 표시 이름입니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.VersionDisplay)), "버전" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.VersionDisplay)),  "현재 모드 버전입니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.OpenParadoxMods)),  "제작자의 Paradox Mods 페이지를 엽니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.OpenDiscord)),  "커뮤니티 Discord를 브라우저에서 엽니다." },
            };
        }

        public void Unload()
        {
        }
    }
}
