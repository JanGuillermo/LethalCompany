# SubtitlesAPI

A centralized API for fetching localized subtitles.

## Feedback

Got any feedback or found bugs? Please do post it in [the Github Issues page](https://github.com/JanGuillermo/LethalCompany/issues)!

## Usage

If you are creating a mod and you want to add subtitles for any custom sounds, it's pretty simple! Add the mod .dll file to your project references, and just add the following code:

```cs
using static SubtitlesAPI.SubtitlesAPI;

try
{
  Localization.AddTranslation("CustomSound", "Custom subtitle");
}
catch
{
  Debug.Log("SubtitlesAPI Mod not Found");
}
```

No need to even require players to use this mod!

There is one method with an overflow that you can use: <br>`SubtitlesAPI.Localization.AddTranslation(string soundFileName, string subtitleText);` and `SubtitlesAPI.Localization.AddSound(Dictionary<string, string>);`<br>Where `Dictionary<string, string>` is a dictionary with `Key: soundFileName`, `Value: subtitleText`.

The method will return a boolean, or list of booleans for the dictionary. The result will be true if the mod was able to add the subtitle, and false if not - which is likely due to the translation for the soundFileName already being created. Maybe another mod has the same sound file name?

## Contributing

Do you want to add or change any subtitles? Do you want to create a new locale for another language? Please do! Create a fork of this repo, make additions or changes there, and submit a pull request.

### Additional Subtitles

Open up the locale you want to modify (ex. EnglishSubtitleLocalization.cs), and add to the dictionary! The dictionary uses the following format for new entries:

```json
{ "SoundFileName" , "Subtitle to add" },
```

### New Locales

To create new locales, just add a new file in the Locales folder, use the ISubtitleLocalization interface, change the Locale to the one being added, and add translations to the dictionary!

#### Example Locale

```cs
public class EnglishSubtitleLocalization : ISubtitleLocalization
{
  public string Locale => "en";

  public Dictionary<string, string> Translations => new(StringComparer.OrdinalIgnoreCase) {
    { "AirHorn1", "Air horn plays" },
  }
}
```
