// Localization/LocaleTR.cs
// Turkish (tr-TR) for Options UI.

namespace AdjustSchoolCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleTR : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleTR(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "İşlemler" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "Hakkında" },

                // Groups - Actions
                { m_Setting.GetOptionGroupLocaleID(Setting.CapacityGroup), "Öğrenci Kapasitesi" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PresetGroup),   "Ön Ayarlar" },

                // Groups - About
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGroup),  "Bilgi" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGroup), "Destek Linkleri" },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ElementarySlider)), "İlkokul" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ElementarySlider)),
                    "**İlkokul** – kaydırıcı ile kapasiteyi %10 - %500 arasında özelleştirin.\n" +
                    "%100 = oyunun varsayılan kapasitesi."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HighSchoolSlider)), "Lise" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.HighSchoolSlider)),
                    "**Lise** – kaydırıcı ile kapasiteyi %10 - %500 arasında özelleştirin.\n" +
                    "%100 = oyunun varsayılan kapasitesi."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CollegeSlider)), "Kolej" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.CollegeSlider)),
                    "**Kolej** – kaydırıcı ile kapasiteyi %10 - %500 arasında özelleştirin.\n" +
                    "%100 = oyunun varsayılan kapasitesi."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UniversitySlider)), "Üniversite" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UniversitySlider)),
                    "**Üniversite** – kaydırıcı ile kapasiteyi %10 - %500 arasında özelleştirin.\n" +
                    "%100 = oyunun varsayılan kapasitesi."
                },

                // Preset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Vanilla'ya Sıfırla" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "Tüm kapasite kaydırıcılarını %100'e geri döndürür (oyunun varsayılan kapasitesi)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToModDefault)), "ASC varsayılanlarına sıfırla" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToModDefault)),
                    "ASC başlangıç ön ayarını kullan:\n" +
                    "**200 / 150 / 120 / 120**"
                },

                // About tab
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)),     "Bu modun adı." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Sürüm" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)),  "Mevcut mod sürümü." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxMods)),  "Bu mod için Paradox Mods web sitesini aç." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),  "Topluluk Discord'unu tarayıcıda aç." },
            };
        }

        public void Unload()
        {
        }
    }
}
