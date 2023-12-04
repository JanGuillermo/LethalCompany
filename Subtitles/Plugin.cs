using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace Subtitles;

[BepInPlugin(pluginGuid, pluginName, pluginVersion)]
public class Plugin : BaseUnityPlugin
{
    private const string pluginGuid = "JustJelly.Subtitles";
    private const string pluginName = "Subtitles";
    private const string pluginVersion = "1.0.0";

    private Harmony harmony;

    public static Plugin Instance;
    public static ManualLogSource ManualLogSource;

    public SubtitleList subtitles = [];

    private void Awake()
    {
        Instance ??= this;

        ManualLogSource = BepInEx.Logging.Logger.CreateLogSource(pluginGuid);
        ManualLogSource.LogInfo($"{pluginName} {pluginVersion} loaded!");

        harmony = new Harmony(pluginGuid);
        harmony.PatchAll();
    }
}