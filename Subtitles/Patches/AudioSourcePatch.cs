using System.IO;
using System.Linq;
using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;

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

    private static void AddSubtitle(AudioClip clip)
    {
        if (clip?.name is null ||
            !Plugin.Instance.LocalizationTable.Translations.TryGetValue(Path.GetFileNameWithoutExtension(clip.name), out string translation))
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

        return distance <= source.maxDistance;
    }
}
