# AudibleDistanceLib

A small library for audible distance determination.

## Usage

### Example

```cs
using static AudibleDistanceLib.AudibleDistanceLib;

[HarmonyPrefix]
[HarmonyPatch(nameof(AudioSource.PlayOneShotHelper), new[] { typeof(AudioSource), typeof(AudioClip), typeof(float) })]
public static void PlayOneShotHelper_Prefix(AudioSource source, ref AudioClip clip, float volumeScale)
{
    if (IsInWithinAudiableDistance(GameNetworkManager.Instance, audioSource, volumeScale, minimumAudibleVolume: 12f))
    {
        // do something
    }
}
```
