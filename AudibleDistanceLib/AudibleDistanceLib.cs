using BepInEx;
using BepInEx.Logging;
using GameNetcodeStuff;
using UnityEngine;

namespace AudibleDistanceLib;

[BepInPlugin(pluginGuid, pluginName, pluginVersion)]
public class AudibleDistanceLib : BaseUnityPlugin
{
    private const string pluginGuid = "JustJelly.AudibleDistanceLib";
    private const string pluginName = "AudibleDistanceLib";
    private const string pluginVersion = "0.0.0";

    public static ManualLogSource ManualLogSource;

    private void Awake()
    {
        ManualLogSource = BepInEx.Logging.Logger.CreateLogSource(pluginGuid);
        ManualLogSource.LogInfo($"{pluginName} {pluginVersion} loaded!");
    }

    /// <summary>
    /// Checks if the <see cref="GameNetworkManager.localPlayerController"/> is within
    /// the audible distance.
    /// </summary>
    /// <param name="gameNetworkManager">A <see cref="GameNetworkManager"/> instance.</param>
    /// <param name="source">An <see cref="AudioSource"/> instance.</param>
    /// <param name="volume">An <see cref="float"/> value passed as volume.</param>
    /// <param name="minimumAudibleVolume">An <see cref="float"/> value configured as minimum audible volume.</param>
    /// <returns>True if the local/speculating player is in within audible distance.</returns>
    public static bool IsInWithinAudiableDistance(GameNetworkManager gameNetworkManager, AudioSource source, float volume, float minimumAudibleVolume = 12f)
    {
        if (volume == 0
            || source is null
            || gameNetworkManager?.localPlayerController is null)
        {
            return false;
        }

        bool isPlayerDead = gameNetworkManager.localPlayerController.isPlayerDead;
        bool isSpeculating = (Object)(object)gameNetworkManager.localPlayerController.spectatedPlayerScript != null;
        PlayerControllerB playerController = (!isPlayerDead || !isSpeculating) ? gameNetworkManager.localPlayerController : gameNetworkManager.localPlayerController.spectatedPlayerScript;

        float distance = Vector3.Distance(playerController.transform.position, source.transform.position);
        float audibleVolume = EvaluateVolumeAt(source, distance) * volume;

        return audibleVolume >= (minimumAudibleVolume / 100);
    }

    private static float EvaluateVolumeAt(AudioSource source, float distance)
    {
        AnimationCurve curve = null;
        float range = source.maxDistance - source.minDistance;

        if (distance < source.minDistance)
        {
            return 1;
        }
        else if (distance > source.maxDistance)
        {
            return 0;
        }

        switch (source.rolloffMode)
        {
            case AudioRolloffMode.Linear:
                curve = AnimationCurve.Linear(0, 1, 1, 0);
                break;
            case AudioRolloffMode.Logarithmic:
                curve = new(
                    new(0, 1),
                    new(range / 4, 1 / (source.minDistance + range / 4)),
                    new(range / 2, 1 / (source.minDistance + range / 2)),
                    new(3 * range / 4, 1 / (source.minDistance + 3 * range / 4)),
                    new(1, 0));
                break;
            case AudioRolloffMode.Custom:
                curve = source.GetCustomCurve(AudioSourceCurveType.CustomRolloff);
                break;
        }

        if (curve is null)
        {
            return 1;
        }

        float evalutationDistance = (distance - source.minDistance) / range;

        return curve.Evaluate(evalutationDistance);
    }
}