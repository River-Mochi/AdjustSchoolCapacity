// <copyright file="LocaleFR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleFR.cs
// French (fr-FR) for Options UI.

namespace AdjustSchoolCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleFR : IDictionarySource
    {
        private readonly ASCSetting m_Setting;

        public LocaleFR(ASCSetting setting)
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
                { m_Setting.GetOptionTabLocaleID(ASCSetting.ActionsTab), "Actions" },
                { m_Setting.GetOptionTabLocaleID(ASCSetting.AboutTab),   "À propos" },

                // Groups - Actions
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.CapacityGroup), "Capacité des élèves" },
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.FeeGroup),      "Frais scolaires" },

                // Groups - About
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.AboutInfoGroup),  "Infos" },
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.AboutLinksGroup), "Liens d’assistance" },

                // Capacity sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ElementarySlider)), "École primaire" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ElementarySlider)),
                    "**École primaire** – personnalisez la capacité avec le curseur.\n" +
                    "100% = capacité par défaut du jeu."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HighSchoolSlider)), "Lycée" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HighSchoolSlider)),
                    "**Lycée** – personnalisez la capacité avec le curseur.\n" +
                    "100% = capacité par défaut du jeu."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.CollegeSlider)), "Faculté" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.CollegeSlider)),
                    "**Faculté** – personnalisez la capacité avec le curseur.\n" +
                    "100% = capacité par défaut du jeu."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.UniversitySlider)), "Université" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.UniversitySlider)),
                    "**Université** – personnalisez la capacité avec le curseur.\n" +
                    "100% = capacité par défaut du jeu."
                },

                // Capacity preset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetToVanilla)), "Réinitialiser à Vanilla" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetToVanilla)),
                    "Ramène tous les curseurs de capacité à 100% (capacité par défaut du jeu)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetToModDefault)), "Préréglages rapides" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetToModDefault)),
                    "Appliquer le préréglage rapide :\n" +
                    "**200 / 150 / 110 / 100**"
                },

                // School fees
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ControlEducationFees)), "Frais d’éducation" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ControlEducationFees)),
                    "OFF conserve les frais d’éducation normaux du jeu.\n" +
                    "ON permet à ASC de contrôler les frais municipaux ci-dessous. Les désactiver restaure les frais Vanilla.\n" +
                    "Des frais négatifs versent une allocation à tous les foyers ayant un élève ou un étudiant inscrit et réduisent le budget municipal.\n" +
                    "Cela peut alléger la pression financière sur les familles pauvres et limiter les déménagements. Dans cette version, les mêmes frais s’appliquent à tous les foyers.\n" +
                    "Cet argent n’est ni gratuit ni créé magiquement.\n" +
                    "Les foyers reçoivent de l’argent ; la trésorerie municipale perd des recettes dans la même catégorie.\n" +
                    "**------------------**\n" +
                    "<100% : frais Vanilla>\n" +
                    "<0% : les foyers ne paient rien.>\n" +
                    "<-20% : les foyers reçoivent une allocation égale à 20% des frais Vanilla.>\n" +
                    "<200% : deux fois les frais Vanilla>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ElementaryFeePercent)), "Frais d’école primaire" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ElementaryFeePercent)),
                    "<100% = frais Vanilla (100).>\n" +
                    "<0% = gratuit> Rien n’est retiré au foyer.\n" +
                    "**-5% à -20%** verse une allocation pendant la scolarité."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HighSchoolFeePercent)), "Frais de lycée" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HighSchoolFeePercent)),
                    "<100% = frais Vanilla (200).>\n" +
                    "<0% = gratuit> Rien n’est retiré au foyer.\n" +
                    "**-5% à -20%** verse une allocation pendant la scolarité."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HigherEducationFeePercent)), "Frais Faculté + Université" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HigherEducationFeePercent)),
                    "La Faculté et l’Université partagent les mêmes frais dans le jeu.\n" +
                    "<100% = frais Vanilla (300).>\n" +
                    "<0% = gratuit.>\n" +
                    "Des frais faibles ou nuls peuvent réduire le risque d’abandon, mais n’augmentent pas directement la probabilité de candidature."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.FreeSchools)), "Écoles gratuites" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.FreeSchools)),
                    "Fixe tous les frais d’éducation à 0%. Les foyers avec des élèves ou étudiants ne paient aucun frais scolaire."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetEducationFees)), "Valeurs du jeu" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetEducationFees)),
                    "Remet les trois frais d’éducation à 100% et restaure les frais Vanilla du jeu."
                },

                // About tab
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.NameDisplay)),     "Nom de ce mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.VersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.VersionDisplay)),  "Version actuelle du mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.OpenParadoxMods)),  "Ouvrir la page des mods de l’auteur sur Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.OpenDiscord)),  "Ouvrir le Discord de la communauté dans le navigateur." },
            };
        }

        public void Unload()
        {
        }
    }
}
