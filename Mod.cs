// <copyright file="Mod.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Mod.cs
// Entry point for "Adjust School Capacity [ASC]".

namespace AdjustSchoolCapacity
{
    using System.Reflection;

    using Colossal.IO.AssetDatabase;
    using Colossal.Localization;
    using Colossal.Logging;

    using Game;
    using Game.Modding;
    using Game.SceneFlow;

    public sealed class Mod : IMod
    {
        public const string ModName = "Adjust School Capacity";
        public const string ModId = "AdjustSchoolCapacity";
        public const string ModTag = "[ASC]";
        public const string ShortName = "Adjust School";

        private static bool s_BannerLogged;

        public static readonly string ModVersion =
            Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "1.0.0";

        public static readonly ILog s_Log =
            LogManager.GetLogger("AdjustSchoolCapacity").SetShowsErrorsInUI(false);

        public static ASCSetting? Setting
        {
            get; private set;
        }

        public void OnLoad(UpdateSystem updateSystem)
        {
            if (!s_BannerLogged)
            {
                s_BannerLogged = true;
                s_Log.Info($"{ModId} {ModTag} v{ModVersion} OnLoad");
            }

            ASCSetting setting = new ASCSetting(this);
            Setting = setting;

            LocalizationManager? lm = GameManager.instance?.localizationManager;
            if (lm != null)
            {
                lm.AddSource("en-US", new LocaleEN(setting));
                lm.AddSource("de-DE", new LocaleDE(setting));
                lm.AddSource("es-ES", new LocaleES(setting));
                lm.AddSource("fr-FR", new LocaleFR(setting));
                lm.AddSource("it-IT", new LocaleIT(setting));
                lm.AddSource("ja-JP", new LocaleJA(setting));
                lm.AddSource("ko-KR", new LocaleKO(setting));
                lm.AddSource("pl-PL", new LocalePL(setting));
                lm.AddSource("pt-BR", new LocalePT_BR(setting));
                lm.AddSource("pt-PT", new LocalePT_PT(setting));
                lm.AddSource("zh-HANS", new LocaleZH_CN(setting));
                lm.AddSource("zh-HANT", new LocaleZH_HANT(setting));
            }
            else
            {
                s_Log.Warn($"{ModTag} LocalizationManager is null; skipping locale registration.");
            }

            AssetDatabase.global.LoadSettings(ModId, setting, new ASCSetting(this));

            // Save only when invalid values were repaired.
            if (setting.RepairInvalidValues())
            {
                setting.ApplyAndSave();
                s_Log.Info($"{ModTag} Repaired invalid slider values to vanilla settings.");
            }

            setting.RegisterInOptionsUI();

            // Prefab data must be ready before capacities are applied.
            updateSystem.UpdateAfter<AdjustSchoolCapacitySystem>(SystemUpdatePhase.PrefabUpdate);
        }

        public void OnDispose()
        {
            if (Setting != null)
            {
                Setting.UnregisterInOptionsUI();
                Setting = null;
            }
        }
    }
}
