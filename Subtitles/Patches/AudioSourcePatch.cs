using System.Collections.Generic;
using System.IO;
using System.Linq;
using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;
using static SubtitlesAPI.SubtitlesAPI;

namespace Subtitles.Patches;

[HarmonyPatch(typeof(AudioSource))]
public class AudioSourcePatch
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(AudioSource.PlayClipAtPoint), new[] { typeof(AudioClip), typeof(Vector3), typeof(float) })]
    public static bool PlayClipAtPoint_Prefix(AudioClip clip, Vector3 position, float volume)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("One shot audio");
        GameObject gameObject = gameObjects.Where(gameObject => gameObject.transform.position == position).FirstOrDefault();

        if (gameObject is null)
        {
            return false;
        }

        AudioSource source = gameObject.GetComponent<AudioSource>();

        if (IsInWithinAudiableDisable(source, volume))
        {
            AddSubtitle(clip);
        }

        return false;
    }

    [HarmonyPrefix]
    [HarmonyPatch(nameof(AudioSource.PlayOneShotHelper), new[] { typeof(AudioSource), typeof(AudioClip), typeof(float) })]
    public static void PlayOneShotHelper_Prefix(AudioSource source, ref AudioClip clip, float volumeScale)
    {
        if (IsInWithinAudiableDisable(source, volumeScale))
        {
            AddSubtitle(clip);
        }
    }

    [HarmonyPrefix]
    [HarmonyPatch(nameof(AudioSource.Play), new[] { typeof(double) })]
    public static void PlayDelayed_Prefix(AudioSource __instance)
    {
        if (__instance.clip == null) return;
        if (IsInWithinAudiableDisable(__instance, __instance.volume))
        {
            AddSubtitle(__instance.clip);
        }
    }

    [HarmonyPrefix]
    [HarmonyPatch(nameof(AudioSource.Play), new System.Type[] { })]
    public static void Play_Prefix(AudioSource __instance)
    {
        if (__instance.clip == null) return;
        if (IsInWithinAudiableDisable(__instance, __instance.volume))
        {
            AddSubtitle(__instance.clip);
        }
    }

    private static void AddSubtitle(AudioClip clip)
    {
        if (clip?.name is null)
        {
            return;
        }

        string clipName = Path.GetFileNameWithoutExtension(clip.name);

        if (Localization.Translations.TryGetValue(clipName, out string soundTranslation))
        {
            if (Plugin.Instance.logSoundNames.Value)
            {
                Plugin.ManualLogSource.LogInfo($"Found translation for {clipName}!");
            }

            Plugin.Instance.subtitles.Add(FormatSoundTranslation(soundTranslation));
        }
        else if (Localization.DialogueTranslations.TryGetValue(clipName, out List<(float, string)> translations))
        {
            if (Plugin.Instance.logSoundNames.Value)
            {
                Plugin.ManualLogSource.LogInfo($"Found dialogue translation for {clipName}!");
            }

            foreach ((float startTimestamp, string timedTranslation) in translations)
            {
                Plugin.Instance.subtitles.Add(ForamtDialogueTranslation(timedTranslation), startTimestamp);
            }
        }
        else
        {
            if (Plugin.Instance.logSoundNames.Value)
            {
                Plugin.ManualLogSource.LogInfo($"No translation for {clipName}.");
            }
        }
    }

    private static string FormatSoundTranslation(string translation)
    {
        if (translation.StartsWith("[") && translation.EndsWith("]"))
        {
            return $"<color=yellow>{translation}</color>";
        }

        return $"<color=yellow>[{translation}]</color>";
    }

    private static string ForamtDialogueTranslation(string translation)
    {
        if (translation.StartsWith("[") && translation.EndsWith("]"))
        {
            return FormatSoundTranslation(translation);
        }

        return $"<color=green>{translation}</color>";
    }

    private static bool IsInWithinAudiableDisable(AudioSource source, float volume)
    {
        if (volume == 0 || source is null || GameNetworkManager.Instance?.localPlayerController is null)
        {
            return false;
        }

        bool isPlayerDead = GameNetworkManager.Instance.localPlayerController.isPlayerDead;
        bool isSpeculating = ((Object)(object)GameNetworkManager.Instance.localPlayerController.spectatedPlayerScript != null);
        PlayerControllerB playerController = (!isPlayerDead || !isSpeculating) ? GameNetworkManager.Instance.localPlayerController : GameNetworkManager.Instance.localPlayerController.spectatedPlayerScript;

        float distance = Vector3.Distance(playerController.transform.position, source.transform.position);
        float audibleVolume = EvaluateVolumeAt(source, distance) * volume;

        return audibleVolume >= (Plugin.Instance.minimumAudibleVolume.Value / 100);
    }

    private static float EvaluateVolumeAt(AudioSource source, float distance)
    {
        AnimationCurve curve = null;
        float range = source.maxDistance - source.minDistance;

        if (distance < source.minDistance)
        {
            return 1;
        }

        if (distance > source.maxDistance)
        {
            return 0;
        }

        switch (source.rolloffMode)
        {
            case AudioRolloffMode.Linear:
                curve = AnimationCurve.Linear(0, 1, 1, 0);
                break;
            case AudioRolloffMode.Logarithmic:
                // My best guess at what the logarithmic curve is
                curve = new(new(0, 1), new(range / 4, 1 / (source.minDistance + range / 4)), new(range / 2, 1 / (source.minDistance + range / 2)), new(3 * range / 4, 1 / (source.minDistance + 3 * range / 4)), new(1, 0));
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
