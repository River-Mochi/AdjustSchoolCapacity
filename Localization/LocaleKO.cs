// Localization/LocaleKO.cs
// Korean (ko-KR) for Options UI.

namespace CustomSchoolCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleKO : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleKO(Setting setting)
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
                { m_Setting.GetSettingsLocaleID(), "Custom School Capacity [CSC]" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "동작" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "정보" },

                // Groups - Actions
                { m_Setting.GetOptionGroupLocaleID(Setting.CapacityGroup), "학생 수용 인원" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PresetGroup),   "프리셋" },

                // Groups - About
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGroup),  "정보" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGroup), "지원 링크" },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ElementarySlider)), "초등학교" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ElementarySlider)),
                    "**초등학교** – 슬라이더로 수용 인원을 10% - 500% 사이로 설정.\n" +
                    "100% = 게임 기본 수용 인원."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HighSchoolSlider)), "고등학교" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.HighSchoolSlider)),
                    "**고등학교** – 슬라이더로 수용 인원을 10% - 500% 사이로 설정.\n" +
                    "100% = 게임 기본 수용 인원."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CollegeSlider)), "대학 (College)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.CollegeSlider)),
                    "**대학 (College)** – 슬라이더로 수용 인원을 10% - 500% 사이로 설정.\n" +
                    "100% = 게임 기본 수용 인원."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UniversitySlider)), "대학교" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UniversitySlider)),
                    "**대학교** – 슬라이더로 수용 인원을 10% - 500% 사이로 설정.\n" +
                    "100% = 게임 기본 수용 인원."
                },

                // Preset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "바닐라로 초기화" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "모든 수용 인원 슬라이더를 100% (게임 기본값)로 되돌립니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToModDefault)), "CSC 기본값" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToModDefault)),
                    "CSC 추천 시작 프리셋 사용:\n" +
                    "**200 / 150 / 120 / 120**"
                },

                // About tab
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)),     "이 모드의 이름." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "버전" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)),  "현재 모드 버전." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxMods)),  "브라우저에서 Paradox Mods 페이지를 엽니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),  "브라우저에서 커뮤니티 Discord 를 엽니다." },
            };
        }

        public void Unload()
        {
        }
    }
}
