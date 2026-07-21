// <copyright file="LocalePT_BR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocalePT_BR.cs
// Portuguese (Brazil) (pt-BR) for Options UI.

namespace AdjustSchoolCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocalePT_BR : IDictionarySource
    {
        private readonly ASCSetting m_Setting;

        public LocalePT_BR(ASCSetting setting)
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
                { m_Setting.GetOptionTabLocaleID(ASCSetting.ActionsTab), "Ações" },
                { m_Setting.GetOptionTabLocaleID(ASCSetting.AboutTab),   "Sobre" },

                // Groups - Actions
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.CapacityGroup), "Capacidade de alunos" },
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.FeeGroup),      "Taxas escolares" },

                // Groups - About
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.AboutInfoGroup),  "Informações" },
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.AboutLinksGroup), "Links de suporte" },

                // Capacity sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ElementarySlider)), "Escola primária" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ElementarySlider)),
                    "**Escola primária** – personalize a capacidade com o controle deslizante.\n" +
                    "100% = capacidade padrão do jogo."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HighSchoolSlider)), "Ensino médio" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HighSchoolSlider)),
                    "**Ensino médio** – personalize a capacidade com o controle deslizante.\n" +
                    "100% = capacidade padrão do jogo."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.CollegeSlider)), "Faculdade" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.CollegeSlider)),
                    "**Faculdade** – personalize a capacidade com o controle deslizante.\n" +
                    "100% = capacidade padrão do jogo."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.UniversitySlider)), "Universidade" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.UniversitySlider)),
                    "**Universidade** – personalize a capacidade com o controle deslizante.\n" +
                    "100% = capacidade padrão do jogo."
                },

                // Capacity preset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetToVanilla)), "Restaurar Vanilla" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetToVanilla)),
                    "Retorna todos os controles de capacidade para 100% (padrão do jogo)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetToModDefault)), "Predefinições rápidas" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetToModDefault)),
                    "Aplicar predefinição de início rápido:\n" +
                    "**200 / 150 / 110 / 100**"
                },

                // School fees
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ControlEducationFees)), "Taxas de educação" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ControlEducationFees)),
                    "OFF mantém as taxas normais de educação do jogo inalteradas.\n" +
                    "ON permite que o ASC controle as taxas da cidade abaixo. Desativar restaura as taxas Vanilla.\n" +
                    "Taxas negativas pagam uma bolsa a todas as famílias com estudantes matriculados e reduzem o orçamento da cidade.\n" +
                    "Isso pode aliviar a pressão financeira sobre famílias pobres e reduzir mudanças. Nesta versão, todas as famílias recebem as mesmas taxas.\n" +
                    "Não é dinheiro gratuito nem criado por mágica.\n" +
                    "As famílias recebem dinheiro; o tesouro da cidade perde receita na mesma categoria.\n" +
                    "**------------------**\n" +
                    "<100%: taxa Vanilla>\n" +
                    "<0%: as famílias não pagam nada.>\n" +
                    "<-20%: as famílias recebem uma bolsa igual a 20% da taxa Vanilla.>\n" +
                    "<200%: o dobro da taxa Vanilla>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ElementaryFeePercent)), "Taxa da escola primária" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ElementaryFeePercent)),
                    "<100% = taxa Vanilla (100).>\n" +
                    "<0% = sem taxa> Nada é retirado da família.\n" +
                    "**-5% a -20%** paga uma bolsa durante os estudos."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HighSchoolFeePercent)), "Taxa do ensino médio" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HighSchoolFeePercent)),
                    "<100% = taxa Vanilla (200).>\n" +
                    "<0% = sem taxa> Nada é retirado da família.\n" +
                    "**-5% a -20%** paga uma bolsa durante os estudos."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HigherEducationFeePercent)), "Taxa Faculdade + Universidade" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HigherEducationFeePercent)),
                    "Faculdade e Universidade compartilham uma única taxa do jogo.\n" +
                    "<100% = taxa Vanilla (300).>\n" +
                    "<0% = sem taxa.>\n" +
                    "Taxas menores ou zeradas podem reduzir a pressão por abandono, mas não aumentam diretamente a chance de inscrição."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.FreeSchools)), "Educação gratuita" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.FreeSchools)),
                    "Define todas as taxas de educação como 0%. Famílias com estudantes não pagam taxas escolares."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetEducationFees)), "Padrões do jogo" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetEducationFees)),
                    "Retorna as três taxas de educação para 100% e restaura as taxas Vanilla do jogo."
                },

                // About tab
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.NameDisplay)),     "Nome deste mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.VersionDisplay)), "Versão" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.VersionDisplay)),  "Versão atual do mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.OpenParadoxMods)),  "Abrir a página de mods do autor no Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.OpenDiscord)),  "Abrir o Discord da comunidade no navegador." },
            };
        }

        public void Unload()
        {
        }
    }
}
