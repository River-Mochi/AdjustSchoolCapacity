// <copyright file="LocaleFR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// Localization/LocaleFR.cs
// French (fr-FR) for Options UI.

namespace AdjustSchoolCapacity
{
    using System.Collections.Generic;

    using Colossal;

    public sealed class LocaleFR : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleFR(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            string title = Mod.ShortName;

            // Show "Adjust School (1.6.2)" title
            if (!string.IsNullOrEmpty(Mod.ModVersion))
            {
                title = title + " (" + Mod.ModVersion + ")";
            }

            return new Dictionary<string, string>
            {
                // Mod root in Options
                { m_Setting.GetSettingsLocaleID(), title },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Actions" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "À propos" },

                // Groups - Actions
                { m_Setting.GetOptionGroupLocaleID(Setting.CapacityGroup), "Capacité des élèves" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PresetGroup),   "Préréglages" },

                // Groups - About
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGroup),  "Infos" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGroup), "Liens de support" },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ElementarySlider)), "École primaire" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ElementarySlider)),
                    "**École primaire** – régler la capacité entre 10% et 1000% avec le curseur.\n" +
                    "100% = capacité par défaut du jeu."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HighSchoolSlider)), "Lycée" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.HighSchoolSlider)),
                    "**Lycée** – régler la capacité entre 10% et 1000% avec le curseur.\n" +
                    "100% = capacité par défaut du jeu."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CollegeSlider)), "Collège / Campus" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.CollegeSlider)),
                    "**Collège / campus** – régler la capacité entre 10% et 500% avec le curseur.\n" +
                    "100% = capacité par défaut du jeu."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UniversitySlider)), "Université" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UniversitySlider)),
                    "**Université** – régler la capacité entre 10% et 500% avec le curseur.\n" +
                    "100% = capacité par défaut du jeu."
                },

                // Preset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Réinitialiser en vanilla" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)),
                    "Remet tous les curseurs de capacité à 100% (valeur par défaut du jeu)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToModDefault)), "Préréglages de démarrage rapide" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToModDefault)),
                    "Appliquer le préréglage de démarrage rapide :\n" +
                    "**200 / 150 / 110 / 100**"
                },

                // About tab
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)),     "Nom de ce mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)),  "Version actuelle du mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxMods)),  "Ouvrir ce mod sur le site Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),  "Ouvrir le Discord de la communauté dans le navigateur." },
            };
        }

        public void Unload()
        {
        }
    }
}
