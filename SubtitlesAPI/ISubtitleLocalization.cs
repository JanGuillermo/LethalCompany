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
    /// Utilize this to add any custom sounds to the subtitles.
    /// </summary>
    /// <remarks>Meant for mod developers.</remarks>
    /// <param name="sound">The filename of the sound being played. Ex: AirHorn1</param>
    /// <param name="subtitle">The text to be displayed when the sound is heard. Ex: Air horn plays</param>
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
}