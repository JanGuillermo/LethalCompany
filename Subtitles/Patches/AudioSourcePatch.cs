using System.Collections.Generic;
using System.IO;
using System.Linq;
using HarmonyLib;
using UnityEngine;
using static AudibleDistanceLib.AudibleDistanceLib;
using static SubtitlesAPI.SubtitlesAPI;

namespace Subtitles.Patches;

[HarmonyPatch(typeof(AudioSource))]
public class AudioSourcePatch
{
    /*
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

        if (IsInWithinAudiableDistance(GameNetworkManager.Instance, source, volume, Plugin.Instance.minimumAudibleVolume.Value))
        {
            AddSubtitle(clip);
        }

        return false;
    }
    */

    [HarmonyPrefix]
    [HarmonyPatch(nameof(AudioSource.PlayOneShotHelper), new[] { typeof(AudioSource), typeof(AudioClip), typeof(float) })]
    public static void PlayOneShotHelper_Prefix(AudioSource source, ref AudioClip clip, float volumeScale)
    {
        if (IsInWithinAudiableDistance(GameNetworkManager.Instance, source, volumeScale, Plugin.Instance.minimumAudibleVolume.Value))
        {
            AddSubtitle(clip);
        }
    }

    [HarmonyPrefix]
    [HarmonyPatch(nameof(AudioSource.Play), new[] { typeof(double) })]
    public static void PlayDelayed_Prefix(AudioSource __instance)
    {
        if (__instance.clip == null) return;
        if (IsInWithinAudiableDistance(GameNetworkManager.Instance, __instance, __instance.volume, Plugin.Instance.minimumAudibleVolume.Value))
        {
            AddSubtitle(__instance.clip);
        }
    }

    [HarmonyPrefix]
    [HarmonyPatch(nameof(AudioSource.Play), new System.Type[] { })]
    public static void Play_Prefix(AudioSource __instance)
    {
        if (__instance.clip == null) return;
        if (IsInWithinAudiableDistance(GameNetworkManager.Instance, __instance, __instance.volume, Plugin.Instance.minimumAudibleVolume.Value))
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
}
