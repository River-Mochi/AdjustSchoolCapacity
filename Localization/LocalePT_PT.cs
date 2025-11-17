// Localization/LocalePT_PT.cs
// European Portuguese (pt-PT) for Options UI.

namespace AdjustSchoolCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocalePT_PT : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocalePT_PT(Setting setting)
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
                { m_Setting.GetSettingsLocaleID(), "Ajustar Capacidade das Escolas [ASC]" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Ações" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "Sobre" },

                // Groups - Actions
                { m_Setting.GetOptionGroupLocaleID(Setting.CapacityGroup), "Capacidade de Alunos" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PresetGroup),   "Predefinições" },

                // Groups - About
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGroup),  "Informações" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGroup), "Ligações de Suporte" },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ElementarySlider)), "Escola primária" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ElementarySlider)),
                    "**Escola primária** – ajusta a capacidade entre 10% e 500% usando o slider.\n" +
                    "100% = capacidade padrão do jogo."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HighSchoolSlider)), "Escola secundária" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.HighSchoolSlider)),
                    "**Escola secundária** – ajusta a capacidade entre 10% e 500% usando o slider.\n" +
                    "100% = capacidade padrão do jogo."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CollegeSlider)), "Faculdade" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.CollegeSlider)),
                    "**Faculdade** – ajusta a capacidade entre 10% e 500% usando o slider.\n" +
                    "100% = capacidade padrão do jogo."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UniversitySlider)), "Universidade" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UniversitySlider)),
                    "**Universidade** – ajusta a capacidade entre 10% e 500% usando o slider.\n" +
                    "100% = capacidade padrão do jogo."
                },

                // Preset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Repor para Vanilla" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "Coloca todos os sliders de capacidade em 100% (capacidade padrão do jogo)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToModDefault)), "Repor para predefinições ASC" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToModDefault)),
                    "Define o preset inicial ASC:\n" +
                    "**200 / 150 / 120 / 120**"
                },

                // About tab
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)),     "Nome deste mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Versão" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)),  "Versão atual do mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxMods)),  "Abrir o site da Paradox com os mods deste autor." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),  "Abrir o servidor Discord de suporte no navegador." },
            };
        }

        public void Unload()
        {
        }
    }
}
