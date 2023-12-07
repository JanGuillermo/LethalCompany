using System.Collections.Generic;

namespace SubtitlesAPI;

/// <summary>
/// An interface to easily implement new subtitle localizations
/// </summary>
public interface ISubtitleLocalization
{
    /// <summary>
    /// What locale this translation applies to.
    /// </summary>
    /// <remarks>Use the ISO 639-1 codes. Case does not matter.</remarks>
    /// <example>en, EN, eN, En (all stand for English)</example>
    string Locale { get; }

    /// <summary>
    /// A dictionary of the translations for this locale.
    /// </summary>
    /// <remarks>The key (first string) is the sound, the second is the translation.</remarks>
    /// <example>{ "AirHorn1" , "Air horn plays" }</example>
    Dictionary<string, string> Translations { get; }

    /// <summary>
    /// A dictionary of the dialogue translations for this locale.
    /// </summary>
    /// <remark>
    /// For the list of tuples...
    /// - The float parameter represents the start timestamp.
    /// - The string parameter represents the actual subtitle.
    /// </remark>
    Dictionary<string, List<(float, string)>> DialogueTranslations { get; }

    /// <summary>
    /// Utilize this to add any custom sounds to the subtitles.
    /// </summary>
    /// <remarks>Meant for mod developers.</remarks>
    /// <param name="sound">The filename of the sound being played.</param>
    /// <param name="subtitle">The text to be displayed when the sound is heard.</param>
    /// <example>AddTranslation(sound: "AirHorn1", subtitle: "Air horn plays")</example>
    /// <returns>A <see cref="bool"/> indicating whether the subtitle was able to be added.</returns>
    bool AddTranslation(string sound, string subtitle)
    {
        if (Translations.ContainsKey(sound))
        {
            return false;
        }

        Translations.Add(sound, subtitle);

        return true;
    }

    /// <summary>
    /// Utilize this to add any custom sounds to the subtitles.
    /// </summary>
    /// <remarks>Meant for mod developers.</remarks>
    /// <param name="translationsToAdd">A dictionary of the filenames and subtitles of played sounds.</param>
    /// <returns>An array of <see cref="bool"/> of whether each subtitle was able to be added.</returns>
    bool[] AddTranslation(Dictionary<string, string> translationsToAdd)
    {
        bool[] added = new bool[translationsToAdd.Count];
        int i = 0;

        foreach ((string sound, string subtitle) in translationsToAdd)
        {
            added[i] = AddTranslation(sound, subtitle);
            i++;
        }

        return added;
    }

    /// <summary>
    /// Utilize this to add any custom sounds to the subtitles.
    /// </summary>
    /// <remarks>Meant for mod developers.</remarks>
    /// <param name="sound">The filename of the sound being played.</param>
    /// <param name="subtitles">
    /// A list of tuples, whose the first item represent the timestamp and
    /// the second item represent the text to be displayed when the sound is heard.
    /// </param>
    /// <example>
    /// AddDialogueTranslation(
    ///     sound: "0DaysLeftAlert",
    ///     subtitles: new List<(float, string)>()
    ///         {
    ///             (0, "[Company Jingle plays]"),
    ///             (4.969f, "Report to the company building immediately"),
    ///             (7.189f, "to sell your scrap metal and other goods."),
    ///             (9.758f, "You have zero days left to meet the profit quota."),
    ///             (13.085f, "You can use the terminal to route"),
    ///             (14.874f, "the autopilot to the company building."),
    ///         })
    /// </example>
    /// <returns>A <see cref="bool"/> indicating whether the subtitle was able to be added.</returns>
    bool AddDialogueTranslation(string sound, List<(float, string)> subtitles)
    {
        if (DialogueTranslations.ContainsKey(sound))
        {
            return false;
        }

        DialogueTranslations.Add(sound, subtitles);

        return true;
    }

    /// <summary>
    /// Utilize this to add any custom sounds to the subtitles.
    /// </summary>
    /// <remarks>Meant for mod developers.</remarks>
    /// <param name="translationsToAdd">A dictionary of the filenames and subtitles of played sounds.</param>
    /// <returns>An array of <see cref="bool"/> of whether each subtitle was able to be added.</returns>
    bool[] AddDialogueTranslation(Dictionary<string, List<(float, string)>> translationsToAdd)
    {
        bool[] added = new bool[translationsToAdd.Count];
        int i = 0;

        foreach ((string sound, List<(float, string)> subtitles) in translationsToAdd)
        {
            added[i] = AddDialogueTranslation(sound, subtitles);
            i++;
        }

        return added;
    }
}