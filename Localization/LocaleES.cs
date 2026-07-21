// <copyright file="LocaleES.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleES.cs
// Spanish (es-ES) for Options UI.

namespace AdjustSchoolCapacity
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleES : IDictionarySource
    {
        private readonly ASCSetting m_Setting;

        public LocaleES(ASCSetting setting)
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
                { m_Setting.GetOptionTabLocaleID(ASCSetting.ActionsTab), "Acciones" },
                { m_Setting.GetOptionTabLocaleID(ASCSetting.AboutTab),   "Acerca de" },

                // Groups - Actions
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.CapacityGroup), "Capacidad de alumnos" },
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.FeeGroup),      "Cuotas escolares" },

                // Groups - About
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.AboutInfoGroup),  "Información" },
                { m_Setting.GetOptionGroupLocaleID(ASCSetting.AboutLinksGroup), "Enlaces de soporte" },

                // Capacity sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ElementarySlider)), "Escuela primaria" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ElementarySlider)),
                    "**Escuela primaria** – personaliza la capacidad con el deslizador.\n" +
                    "100% = capacidad predeterminada del juego."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HighSchoolSlider)), "Instituto" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HighSchoolSlider)),
                    "**Instituto** – personaliza la capacidad con el deslizador.\n" +
                    "100% = capacidad predeterminada del juego."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.CollegeSlider)), "College" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.CollegeSlider)),
                    "**College** – personaliza la capacidad con el deslizador.\n" +
                    "100% = capacidad predeterminada del juego."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.UniversitySlider)), "Universidad" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.UniversitySlider)),
                    "**Universidad** – personaliza la capacidad con el deslizador.\n" +
                    "100% = capacidad predeterminada del juego."
                },

                // Capacity preset buttons
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetToVanilla)), "Restablecer a Vanilla" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetToVanilla)),
                    "Devuelve todos los deslizadores de capacidad al 100% (valor predeterminado del juego)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetToModDefault)), "Preajustes de inicio rápido" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetToModDefault)),
                    "Aplicar preajuste de inicio rápido:\n" +
                    "**200 / 150 / 110 / 100**"
                },

                // School fees
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ControlEducationFees)), "Cuotas de educación" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ControlEducationFees)),
                    "OFF mantiene sin cambios las cuotas educativas normales del juego.\n" +
                    "ON permite que ASC controle las cuotas de toda la ciudad indicadas abajo. Al desactivarlo se restauran las cuotas Vanilla.\n" +
                    "Las cuotas negativas pagan una beca a todos los hogares con estudiantes matriculados y reducen el presupuesto de la ciudad.\n" +
                    "Esto puede aliviar la presión económica sobre las familias pobres y reducir las mudanzas. En esta versión, todos los hogares reciben las mismas cuotas.\n" +
                    "No es dinero gratis ni mágico.\n" +
                    "Los hogares reciben dinero; la tesorería de la ciudad pierde ingresos de la misma categoría.\n" +
                    "**------------------**\n" +
                    "<100%: cuota Vanilla>\n" +
                    "<0%: los hogares no pagan nada.>\n" +
                    "<-20%: los hogares reciben una beca equivalente al 20% de la cuota Vanilla.>\n" +
                    "<200%: el doble de la cuota Vanilla>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ElementaryFeePercent)), "Cuota de primaria" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ElementaryFeePercent)),
                    "<100% = cuota Vanilla (100).>\n" +
                    "<0% = sin cuota> No se descuenta nada del hogar.\n" +
                    "**-5% a -20%** paga una beca mientras el alumno está matriculado."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HighSchoolFeePercent)), "Cuota de instituto" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HighSchoolFeePercent)),
                    "<100% = cuota Vanilla (200).>\n" +
                    "<0% = sin cuota> No se descuenta nada del hogar.\n" +
                    "**-5% a -20%** paga una beca mientras el alumno está matriculado."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.HigherEducationFeePercent)), "Cuota de College + Universidad" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.HigherEducationFeePercent)),
                    "College y Universidad comparten una sola cuota del juego.\n" +
                    "<100% = cuota Vanilla (300).>\n" +
                    "<0% = sin cuota.>\n" +
                    "Las cuotas bajas o nulas pueden reducir la presión por abandonar, pero no aumentan directamente la probabilidad de solicitar plaza."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.FreeSchools)), "Escuelas gratuitas" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.FreeSchools)),
                    "Establece todas las cuotas educativas al 0%. Los hogares con estudiantes no pagan cuotas escolares."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.ResetEducationFees)), "Valores del juego" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.ResetEducationFees)),
                    "Restablece las tres cuotas educativas al 100% y recupera las cuotas Vanilla del juego."
                },

                // About tab
                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.NameDisplay)),     "Nombre de este mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.VersionDisplay)), "Versión" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.VersionDisplay)),  "Versión actual del mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.OpenParadoxMods)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.OpenParadoxMods)),  "Abrir en Paradox Mods la página de los mods del autor." },

                { m_Setting.GetOptionLabelLocaleID(nameof(ASCSetting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(ASCSetting.OpenDiscord)),  "Abrir el Discord de la comunidad en el navegador." },
            };
        }

        public void Unload()
        {
        }
    }
}
