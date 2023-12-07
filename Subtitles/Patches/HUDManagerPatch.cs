using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmonyLib;
using TMPro;
using UnityEngine;

namespace Subtitles.Patches;

[HarmonyPatch(typeof(HUDManager))]
public class HUDManagerPatch
{
    private static TextMeshProUGUI subtitleGUItext;

    [HarmonyPostfix]
    [HarmonyPatch("Awake")]
    private static void Awake_Postfix(ref HUDManager __instance)
    {
        GameObject subtitlesGUI = new("SubtitlesGUI");
        subtitlesGUI.AddComponent<RectTransform>();
        TextMeshProUGUI textComponent = subtitlesGUI.AddComponent<TextMeshProUGUI>();

        RectTransform rectTransform = textComponent.rectTransform;
        rectTransform.SetParent(GameObject.Find(Constants.PlayerScreenGUIName).transform, false);
        rectTransform.sizeDelta = new Vector2(600, 200);
        rectTransform.anchoredPosition = new Vector2(0, -125);

        textComponent.alignment = TextAlignmentOptions.Center;
        textComponent.color = Color.yellow;
        textComponent.font = __instance.controlTipLines[0].font;
        textComponent.fontSize = 14f;

        subtitleGUItext = textComponent;
    }

    [HarmonyPostfix]
    [HarmonyPatch("Update")]
    private static void Update_Postfix()
    {
        subtitleGUItext.text = GetLatestSubtitles();
    }

    private static string GetLatestSubtitles()
    {
        StringBuilder stringBuilder = new();
        IList<string> latestSubtitles = Plugin.Instance.subtitles.TakeLast(Constants.DefaultVisibleSubtitleLines).ToList();
        string delimiter = string.Empty;

        foreach (string subtitle in latestSubtitles)
        {
            stringBuilder.Append(delimiter);
            stringBuilder.Append(subtitle);

            delimiter = Constants.HtmlLineBreakTag;
        }

        return stringBuilder.ToString();
    }
}
