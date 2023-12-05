using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using Subtitles.Locales;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Subtitles;

[BepInPlugin(pluginGuid, pluginName, pluginVersion)]
public class Plugin : BaseUnityPlugin
{
    private const string pluginGuid = "JustJelly.Subtitles";
    private const string pluginName = "Subtitles";
    private const string pluginVersion = "1.1.2";

    private Harmony harmony;

    public static Plugin Instance;
    public static ManualLogSource ManualLogSource;

    public SubtitleList subtitles = [];
    public ILocalizationTable LocalizationTable;

    public static ConfigEntry<string> selectedLocale;

    private void Awake()
    {
        Instance ??= this;

        ManualLogSource = BepInEx.Logging.Logger.CreateLogSource(pluginGuid);
        ManualLogSource.LogInfo($"{pluginName} {pluginVersion} loaded!");

        selectedLocale = Config.Bind<string>(
            "​Options",
            "Locale",
            "en",
            "The localization to use. This uses ISO 639-1 codes for locales. \nCurrent Supported Codes: en");

        var allLocalizations = GetAllClassesImplementingInterface<ILocalizationTable>();

        foreach (var localizationTable in allLocalizations)
        {
            var tempTable = (ILocalizationTable)Activator.CreateInstance(localizationTable);
            if (selectedLocale.Value.ToLower() == tempTable.Locale.ToLower())
            {
                LocalizationTable = (ILocalizationTable)tempTable;
            }
        }

        if (LocalizationTable == null)
        {
            LocalizationTable = new En_Subtitles();
            ManualLogSource.LogWarning("Unable to find chosen locale, defaulted to english");
        }

        harmony = new Harmony(pluginGuid);
        harmony.PatchAll();
    }

    private IEnumerable<Type> GetAllClassesImplementingInterface<T>()
    {
        return System.Reflection.Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(type => typeof(T).IsAssignableFrom(type) && !type.IsInterface);
    }
}