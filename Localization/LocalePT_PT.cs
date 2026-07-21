// <copyright file="LocalePT_PT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocalePT_PT.cs
// Portuguese (Portugal) (pt-PT) for Options UI.

namespace AdjustSchoolCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocalePT_PT : IDictionarySource
    {
        private readonly ASCSetting m_Setting;

        public LocalePT_PT(ASCSetting setting)
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
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.FeeGroup),      "Propinas escolares" },

                // Groups - About
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.AboutInfoGroup),  "Informações" },
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.AboutLinksGroup), "Ligações de suporte" },

                // Capacity sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ElementarySlider)), "Escola primária" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ElementarySlider)),
                    "**Escola primária** – personaliza a capacidade com o controlo deslizante.\n" +
                    "100% = capacidade predefinida do jogo."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HighSchoolSlider)), "Escola secundária" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HighSchoolSlider)),
                    "**Escola secundária** – personaliza a capacidade com o controlo deslizante.\n" +
                    "100% = capacidade predefinida do jogo."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.CollegeSlider)), "Faculdade" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.CollegeSlider)),
                    "**Faculdade** – personaliza a capacidade com o controlo deslizante.\n" +
                    "100% = capacidade predefinida do jogo."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.UniversitySlider)), "Universidade" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.UniversitySlider)),
                    "**Universidade** – personaliza a capacidade com o controlo deslizante.\n" +
                    "100% = capacidade predefinida do jogo."
                },

                // Capacity preset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetToVanilla)), "Repor Vanilla" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetToVanilla)),
                    "Repõe todos os controlos de capacidade em 100% (predefinição do jogo)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetToModDefault)), "Predefinições rápidas" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetToModDefault)),
                    "Aplicar predefinição de início rápido:\n" +
                    "**200 / 150 / 110 / 100**"
                },

                // School fees
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ControlEducationFees)), "Propinas de educação" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ControlEducationFees)),
                    "OFF mantém inalteradas as propinas normais de educação do jogo.\n" +
                    "ON permite que o ASC controle as propinas da cidade abaixo. Desativar repõe as propinas Vanilla.\n" +
                    "Propinas negativas pagam um subsídio a todos os agregados com estudantes inscritos e reduzem o orçamento da cidade.\n" +
                    "Isto pode aliviar a pressão financeira sobre famílias pobres e reduzir mudanças de residência. Nesta versão, todos os agregados têm as mesmas propinas.\n" +
                    "Não é dinheiro gratuito nem criado por magia.\n" +
                    "Os agregados recebem dinheiro; o tesouro da cidade perde receita na mesma categoria.\n" +
                    "**------------------**\n" +
                    "<100%: propina Vanilla>\n" +
                    "<0%: os agregados não pagam nada.>\n" +
                    "<-20%: os agregados recebem um subsídio igual a 20% da propina Vanilla.>\n" +
                    "<200%: o dobro da propina Vanilla>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ElementaryFeePercent)), "Propina da escola primária" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ElementaryFeePercent)),
                    "<100% = propina Vanilla (100).>\n" +
                    "<0% = sem propina> Nada é retirado ao agregado.\n" +
                    "**-5% a -20%** paga um subsídio durante os estudos."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HighSchoolFeePercent)), "Propina da escola secundária" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HighSchoolFeePercent)),
                    "<100% = propina Vanilla (200).>\n" +
                    "<0% = sem propina> Nada é retirado ao agregado.\n" +
                    "**-5% a -20%** paga um subsídio durante os estudos."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HigherEducationFeePercent)), "Propina Faculdade + Universidade" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HigherEducationFeePercent)),
                    "Faculdade e Universidade partilham uma única propina do jogo.\n" +
                    "<100% = propina Vanilla (300).>\n" +
                    "<0% = sem propina.>\n" +
                    "Propinas reduzidas ou nulas podem diminuir a pressão para abandonar, mas não aumentam diretamente a probabilidade de candidatura."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.FreeSchools)), "Ensino gratuito" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.FreeSchools)),
                    "Define todas as propinas de educação como 0%. Os agregados com estudantes não pagam propinas."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetEducationFees)), "Predefinições do jogo" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetEducationFees)),
                    "Repõe as três propinas de educação em 100% e restaura as propinas Vanilla do jogo."
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
