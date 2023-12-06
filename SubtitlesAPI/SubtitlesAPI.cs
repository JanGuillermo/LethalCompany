using System;
using System.Collections.Generic;
using System.Linq;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using SubtitlesAPI.Locales;

namespace SubtitlesAPI;

[BepInPlugin(pluginGuid, pluginName, pluginVersion)]
public class SubtitlesAPI : BaseUnityPlugin
{
    private const string pluginGuid = "JustJelly.SubtitlesAPI";
    private const string pluginName = "SubtitlesAPI";
    private const string pluginVersion = "0.0.0";

    public static ManualLogSource ManualLogSource;

    public static ILocalization Localization;
    public static ConfigEntry<string> SelectedLocale;

    private void Awake()
    {
        ManualLogSource = BepInEx.Logging.Logger.CreateLogSource(pluginGuid);
        ManualLogSource.LogInfo($"{pluginName} {pluginVersion} loaded!");

        SelectedLocale = Config.Bind<string>(
            section: "​Options",
            key: "Locale",
            defaultValue: "en",
            description: "The localization to use. This uses ISO 639-1 codes for locales. \nCurrent Supported Codes: en");

        IEnumerable<Type> allLocalizations = GetAllClassesImplementingInterface<ILocalization>();

        foreach (Type localization in allLocalizations)
        {
            ILocalization tempLocalization = (ILocalization)Activator.CreateInstance(localization);

            if (string.Equals(SelectedLocale.Value, tempLocalization.Locale, StringComparison.OrdinalIgnoreCase))
            {
                Localization = tempLocalization;
                break;
            }
        }

        if (Localization is null)
        {
            Localization = new EnglishSubtitles();

            ManualLogSource.LogWarning("Unable to find chosen locale, defaulted to English");
        }
    }

    private IEnumerable<Type> GetAllClassesImplementingInterface<T>()
    {
        return System.Reflection.Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(type => typeof(T).IsAssignableFrom(type) && !type.IsInterface);
    }
}
