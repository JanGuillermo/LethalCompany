using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

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
    public ConfigEntry<float> minimumAudibleVolume;
    public ConfigEntry<bool> logSoundNames;

    private void Awake()
    {
        Instance ??= this;

        ManualLogSource = BepInEx.Logging.Logger.CreateLogSource(pluginGuid);
        ManualLogSource.LogInfo($"{pluginName} {pluginVersion} loaded!");

        minimumAudibleVolume = Config.Bind<float>(
            "​Options",
            "MinimumAudibleVolume",
            2f,
            "The minimum volume this mod determines is audible. Scale of 0-100. Any sound heard above this volume will be displayed on subtitles, any sound below will not.");
        logSoundNames = Config.Bind<bool>(
            "Contributors/Developers",
            "LogSoundNames",
            false,
            "Whether the mod should log the names of sounds. Only valuable if trying to add more subtitles / localization.");

        harmony = new Harmony(pluginGuid);
        harmony.PatchAll();
    }
}