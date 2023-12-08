﻿using System;
using System.Collections.Generic;

namespace SubtitlesAPI.Locales;

public class EnglishSubtitleLocalization : ISubtitleLocalization
{
    public string Locale => "en";

    public Dictionary<string, string> Translations => new(StringComparer.OrdinalIgnoreCase) {
        { "AirHorn1", "Air horn plays" },
        { "AirHornFar", "Distant air horn plays" },
        { "AlertHUD", "Warning alarm" },
        { "Angered", "Rustling" },
        { "AngryScreech", "Bug screeches" },
        { "AngryScreech2", "Bug screeches" },
        { "BaboonEnterFight", "Aggressive hawk" },
        { "BareFootstep1", "Footsteps" },
        { "BareFootstep2", "Footsteps" },
        { "BareFootstep3", "Footsteps" },
        { "BareFootstep4", "Footsteps" },
        { "BeesAngry", "Bees buzz angrily" },
        { "BoomboxMusic1", "Boombox plays" },
        { "BoomboxMusic2", "Boombox plays" },
        { "BoomboxMusic2TVVersion", "TV plays music" },
        { "BoomboxMusic3", "Boombox plays" },
        { "BoomboxMusic4", "Boombox plays" },
        { "BoomboxMusic5Zedfox", "Boombox plays" },
        { "BoomboxStop", "Boombox stops" },
        { "BreakerBoxClose", "Breaker opens" },
        { "BreakerBoxOpen", "Breaker closes" },
        { "BreakerLever1", "Lever flips" },
        { "BreakerLevel2", "Lever flips" },
        { "BreakerLever3", "Lever flips" },
        { "Breathe1", "Breathing" },
        { "Breathing", "Breathing" },
        { "BridgeCreak1", "Bridge creaks" },
        { "BridgeCreak2", "Bridge creaks" },
        { "BridgeCreak3", "Bridge creaks" },
        { "BugWalk1", "Bug walks" },
        { "BugWalk2", "Bug walks" },
        { "BugWalk3", "Bug walks" },
        { "BugWalk4", "Bug walks" },
        { "BurrowingRumbleLoud1", "Ground shakes" },
        { "BurrowingRumble1", "Ground rumbles" },
        { "BurrowingRumble2", "Ground rumbles" },
        { "BurrowingRumble3", "Ground rumbles" },
        { "CawScream1", "Hawk screeches" },
        { "CawScream2", "Hawk screeches" },
        { "CawScream3", "Hawk screeches" },
        { "CawScream4", "Hawk screeches" },
        { "CawScream5", "Hawk screeches" },
        { "ClingToPlayer", "Snare Flea clings" },
        { "ClingToPlayerLocal", "Snare Flea clings" },
        { "ClownHorn1", "Clown horn plays" },
        { "ClownHornFar", "Distant clown horn plays" },
        { "CrackNeck", "Neck snap" },
        { "DistantRumble1", "Distant rumbles" },
        { "DistantRumble2", "Distant rumbles" },
        { "DistantRumble3", "Distant rumbles" },
        { "DocileLocustBeesEvade", "Locusts disperse" },
        { "DoorClose1", "Door opens" },
        { "DoorClose2", "Door opens" },
        { "DoorOpen1", "Door closes" },
        { "DoorOpen2", "Door closes" },
        { "DoorShut", "Door shuts" },
        { "DoorSlam1", "Door slams" },
        { "DoorSlam2", "Door slams" },
        { "DoorUnlock", "Door unlocks" },
        { "DoorUnlock2", "Door unlocks" },
        { "DoublewingFlap1", "Flapping" },
        { "DoublewingFlap2", "Flapping" },
        { "DoublewingFlap3", "Flapping" },
        { "DuckQuack", "Rubber duck quacks" },
        { "EmergeFromGround1", "Earth Leviathan attacks" },
        { "ExplodeHead", "Head explodes" },
        { "ExplodeHeadSecondarySFX", "Head explodes" },
        { "ExtensionLadderAlarm", "Extension Ladder expiring alarm" },
        { "ExtensionLadderExtend", "Extension Ladder extending" },
        { "ExtensionLadderShrink", "Extension Ladder shrinking" },
        { "FGiantEatPlayerSFX", "Player is eaten" },
        { "Fireplace", "Crackling" },
        { "FlashbangExplode", "Flashbang explodes" },
        { "FlashlightClick", "Flashlight clicks" },
        { "FlashlightClickMini", "Light switch turns on" },
        { "FlashlightClickMini2", "Light switch turns off" },
        { "Footstep1", "Footsteps" },
        { "Footstep2", "Footsteps" },
        { "Footstep3", "Footsteps" },
        { "Footstep4", "Footsteps" },
        { "Footstep5", "Footsteps" },
        { "Found1", "Rustling" },
        { "Frighten1", "Creature frightened" },
        { "Frighten3", "Creature frightened" },
        { "GiantStomp1", "Giant stomps" },
        { "GiantStomp2", "Giant stomps" },
        { "GiantStomp3", "Giant stomps" },
        { "GiantStomp4", "Giant stomps" },
        { "GiantStomp5", "Giant stomps" },
        { "growl", "Dog growls" },
        { "HangarDoorOpen1", "Ship door opens" },
        { "HangarDoorOpening", "Ship door opening" },
        { "HangarDoorShut", "Ship door closes" },
        { "HoarderBugCry", "Hoarder bug cries" },
        { "ItemDropshipLand", "Item dropship lands" },
        { "ItemDropshipOpenDoors", "Item doorship door opens" },
        { "JackInTheBoxTheme", "Jack in the Box theme plays" },
        { "JackOLanternHit", "Jack-O-Lantern laughs" },
        { "JesterStomp1", "Intense stomps" },
        { "JesterStomp2", "Intense stomps" },
        { "JesterStomp3", "Intense stomps" },
        { "KillPlayer", "Player is mauled" },
        { "KillPlayer_0", "Player is mauled" },
        { "LightningStrike1", "Lightning strikes" },
        { "LightningStrike2", "Lightning strikes" },
        { "LightningStrike3", "Lightning strikes" },
        { "LightningStrike4", "Lightning strikes" },
        { "LongRoar1", "Creature roars" },
        { "LongRoar2", "Creature roars" },
        { "LongRoar3", "Creature roars" },
        { "LoudCreak1", "Loud creaks" },
        { "LoudCreak2", "Loud creaks" },
        { "LoudCreak3", "Loud creaks" },
        { "Lunge1", "Dog lunges" },
        { "LungMachineDisconnect", "Apparatus disconnects" },
        { "MetalDoorShut1 1", "Metal door shuts" },
        { "MetalDoorShut1", "Metal door shuts" },
        { "MetalDoorShut2", "Metal door shuts" },
        { "MineBeep", "Landmine beeps" },
        { "MineTrigger", "Landmine triggers" },
        { "MineDetonate", "Landmine detonates" },
        { "MineDetonateDistance", "Landmine detonates distantly" },
        { "monsterNoise", "Monster noises" },
        { "monsterNoise2", "Monster noises" },
        { "monsterNoiseB", "Monster noises" },
        { "Nervous", "Creature nervous" },
        { "Pop1", "Jack in the Box pops" },
        { "PullCord", "Cord pulled" },
        { "RattleTail", "Rattling tail" },
        { "Roar", "Giant Rumbles" },
        { "Roar_0", "Dog roars" },
        { "SandWormRoar", "Earth Leviathan roars" },
        { "SandWormRoar2", "Earth Leviathan roars" },
        { "Scan", "Scan activates" },
        { "Scream1", "Low screaming" },
        { "ShortRoar1", "Short roars" },
        { "ShipTeleporterSpin", "Teleporter activates" },
        { "ShipTeleporterSpinInverse", "Inverse Teleporter activates" },
        { "ShipThrusterClose", "Ship thruster" },
        { "Shriek1", "Shriek" },
        { "Shriek2", "Shriek" },
        { "ShipAlarmHornConstant", "Ship horn blares" },
        { "ShipAlarmHornConstantDistant", "Ship horn blares distantly" },
        { "SkipWalk", "Skipping" },
        { "SkipWalk1", "Skipping" },
        { "SkipWalk2", "Skipping" },
        { "SkipWalk3", "Skipping" },
        { "SkipWalk4", "Skipping" },
        { "SkipWalk5", "Skipping" },
        { "SkipWalk6", "Skipping" },
        { "SlimeAngry", "Slime angers" },
        { "SlimeDance", "Slime dances" },
        { "SlimeIdle", "Slime idles" },
        { "SlimeKillPlayer", "Player is absorbed" },
        { "SpiderAttack", "Spider attacks" },
        { "Spring1", "Spring" },
        { "Spring2", "Spring" },
        { "Spring3", "Spring" },
        { "SpringWobble1", "Spring wobbles" },
        { "SpringWobble2", "Spring wobbles" },
        { "Squeak1", "Squeaks" },
        { "Squeak2", "Squeaks" },
        { "StickyNote", "Paper rustling" },
        { "Stomp1", "Stomps" },
        { "Stomp1double", "Stomps" },
        { "Stomp2", "Stomps" },
        { "Stomp2double", "Stomps" },
        { "Stomp3", "Stomps" },
        { "StormStaticElectricity", "Static electricity buzzing" },
        { "StuckInWeb", "Web rustling" },
        { "StunCrawler", "Thumper stunned" },
        { "StunDog", "Dog stunned" },
        { "StunDoublewing", "Bird stunned" },
        { "StunFlowerman", "Bracken stunned" },
        { "StunGiant", "Giant stunned" },
        { "StunSpider", "Spider stunned" },
        { "Thunder1", "Thunder" },
        { "Thunder2", "Thunder" },
        { "Thunder3", "Thunder" },
        { "TunnelIntoGround1", "Earth Leviathan lands" },
        { "TurnTVOff", "TV turns off" },
        { "TurnTVOn", "TV turns on" },
        { "TurretActivate", "Turret activates" },
        { "TurretBerserkMode", "Turret berserks" },
        { "TurretDeactivate", "Turret deactivates" },
        { "TurretFire", "Turret fires" },
        { "TurretFireDistance", "Turret fires distantly" },
        { "TurretSeePlayer", "Turret locks aim" },
        { "TVKittenTheme", "Muffled trombone music" },
        { "VentCrawl1", "Vent noises" },
        { "VentOpen1", "Vent opens" },
        { "WarningHUD", "Warning beep" },
        { "WarningHUD2", "Warning beep" },
        { "WarningHUD3", "Warning beep" },
    };

    public Dictionary<string, List<(float, string)>> DialogueTranslations => new(StringComparer.OrdinalIgnoreCase)
    {
        {
            "0DaysLeftAlert",
            new()
            {
                (0, "[Company Jingle plays]"),
                (4.969f, "Report to the company building immediately"),
                (7.189f, "to sell your scrap metal and other goods."),
                (9.758f, "You have zero days left to meet the profit quota."),
                (13.085f, "You can use the terminal to route"),
                (14.874f, "the autopilot to the company building."),
            }
        },
        {
            "IntroCompanySpeech",
            new()
            {
                (0, "[Company Jingle plays]"),
                (7.310f, "Welcome to your first day on the job!"),
                (10.140f, "This is your very own autopilot ship"),
                (12.440f, "where you will eat and sleep"),
                (13.800f, "for the duration of your contract."),
                (15.280f, "[Unintelligible fast speech]"),
                (19.940f, "Make yourself at home."),
                (21.690f, "To complete the onboarding process,"),
                (23.770f, "you will want to check the instruction manual"),
                (25.650f, "and sign into your ship's computer terminal."),
                (28.290f, "We trust you will be a great asset to the company."),
                (31.035f, "Great-great asset to the company-"),
                (32.830f, "asset great-great-great asset to the company-"),
                (35.235f, "asset to great-great asset to the-"),
            }
        },
        {
            "LightningAudio",
            new()
            {
                (0.0f, "[Upbeat music plays]"),
                (3.020f, "[Lightning strikes]"),
                (4.300f, "[Laugh track]"),
            }
        },
        {
            "SnareFleaTipChannel",
            new()
            {
                (0.330f, "If an entity has come in contact with a crew member,"),
                (2.830f, "please refrain from immediate self-defense."),
                (5.300f, "Instead, ask the crew member the following:"),
                (7.495f, "\"Is the entity being aggressive?\""),
                (9.410f, "\"Are you injured?\""),
                (10.635f, "\"Do you need assistance?\""),
                (11.730f, "If the answer to all of these questions is yes,"),
                (13.920f, "you begin your self-defense measures."),
                (15.900f, "If the crew member is stressed,"),
                (17.190f, "strike a question like \"How was your day?\""),
                (19.620f, "Thank you for your cooperation, and happy travels!"),
            }
        },
    };
}