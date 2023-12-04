using System.IO;
using HarmonyLib;
using UnityEngine;

namespace Subtitles.Patches;

[HarmonyPatch(typeof(AudioSource))]
public class AudioSourcePatch
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(AudioSource.PlayClipAtPoint), new[] { typeof(AudioClip), typeof(Vector3) })]
    public static bool PlayClipAtPoint_Prefix(AudioClip clip, Vector3 position)
    {
        AddSubtitle(clip);

        return false;
    }

    [HarmonyPrefix]
    [HarmonyPatch(nameof(AudioSource.PlayOneShotHelper), new[] { typeof(AudioSource), typeof(AudioClip), typeof(float) })]
    public static void PlayOneShotHelper_Prefix(AudioSource source, ref AudioClip clip, float volumeScale)
    {
        AddSubtitle(clip);
    }

    private static void AddSubtitle(AudioClip clip)
    {
        if (clip?.name is null ||
            !Constants.Translations.TryGetValue(Path.GetFileNameWithoutExtension(clip.name), out string translation))
        {
            if (clip is not null)
            {
                Plugin.ManualLogSource.LogInfo($"No translation for {clip.name}.");
            }

            return;
        };

        Plugin.ManualLogSource.LogInfo($"Found translation for {clip.name}!");
        Plugin.Instance.subtitles.Add(new Subtitle(translation));
    }
}
