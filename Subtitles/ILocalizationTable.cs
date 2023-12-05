using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Subtitles
{
    /// <summary>
    /// An interface to easily implement new localizations
    /// </summary>
    public interface ILocalizationTable
    {
        /// <summary>
        /// What locale this translation applies to. Use the ISO 639-1 codes. Case does not matter. Ex: en, EN, eN, En (all stand for English)
        /// </summary>
        public string Locale { get; }

        /// <summary>
        /// A dictionary of the translations for this locale. The key (first string) is the sound, the second is the translation. Ex: { "AirHorn1" , "Air horn plays" }
        /// </summary>
        public Dictionary<string, string> Translations { get; }

        /// <summary>
        /// Utilize this to add any custom sounds to the subtitles. Meant for mod developers.
        /// </summary>
        /// <param name="sound">The filename of the sound being played. Ex: AirHorn1</param>
        /// <param name="subtitle">The text to be displayed when the sound is heard. Ex: Air horn plays</param>
        /// <returns>(bool) Whether the subtitle was able to be added.</returns>
        bool AddSound(string sound, string subtitle)
        {
            if (Translations.ContainsKey(sound))
                return false;

            Translations.Add(sound, subtitle);
            return true;
        }
    }
}
