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

        private static bool s_BannerLogged;

        public static readonly string ModVersion =
            Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "1.0.0";

        public static readonly ILog s_Log =
            LogManager.GetLogger("AdjustSchoolCapacity").SetShowsErrorsInUI(false);

        public static Setting? Setting
        {
            get; private set;
        }

        public void OnLoad(UpdateSystem updateSystem)
        {
            if (!s_BannerLogged)
            {
                s_BannerLogged = true;
                s_Log.Info($"{ModName} {ModTag} v{ModVersion} OnLoad");
            }

            Setting setting = new Setting(this);
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
                s_Log.Warn("LocalizationManager is null; skipping locale registration.");
            }

            // Load saved settings (if any), then sanitize, then register Options UI.
            Setting defaults = new Setting(this);               // seeds vanilla defaults
            AssetDatabase.global.LoadSettings(ModId, setting, defaults);

            setting.SanitizeAfterLoad();
            setting.RegisterInOptionsUI();

            // Intentionally NOT scheduling into prefab phases.
            // System will run on GameLoadingComplete and on Apply().
        }

        public void OnDispose()
        {
            if (Setting != null)
            {
                Setting.UnregisterInOptionsUI();
                Setting = null;
            }

            s_Log.Info("OnDispose");
        }
    }
}
