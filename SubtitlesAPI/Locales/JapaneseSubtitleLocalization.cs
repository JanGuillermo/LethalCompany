﻿using System;
using System.Collections.Generic;

namespace SubtitlesAPI.Locales;

public class JapaneseSubtitleLocalization : ISubtitleLocalization
{
    public string Locale => "jp";

    public Dictionary<string, string> Translations => new(StringComparer.OrdinalIgnoreCase)
    {
        { "AirHorn1", "エアホーンが鳴る" },
        { "AirHornFar", "遠くからエアホーンが鳴り響く" },
        { "AlertHUD", "警告音" },
        { "Angered", "ざわめき" },
        { "AngryScreech", "虫の鳴き声" },
        { "AngryScreech2", "虫の鳴き声" },
        { "BaboonEnterFight", "タカが怒って羽ばたく" },
        { "BareFootstep1", "足音" },
        { "BareFootstep2", "足音" },
        { "BareFootstep3", "足音" },
        { "BareFootstep4", "足音" },
        { "BeesAngry", "ハチが怒って羽ばたく" },
        { "BoomboxMusic1", "ラジカセが鳴る" },
        { "BoomboxMusic2", "ラジカセが鳴る" },
        { "BoomboxMusic2TVVersion", "テレビの音" },
        { "BoomboxMusic3", "ラジカセが鳴る" },
        { "BoomboxMusic4", "ラジカセが鳴る" },
        { "BoomboxMusic5Zedfox", "ラジカセが鳴る" },
        { "BoomboxStop", "ラジカセが止まる" },
        { "BootStomp1", "ドシンという音" },
        { "BootStomp2", "ドシンという音" },
        { "BootStomp3", "ドシンという音" },
        { "BreakerBoxClose", "ブレーカーボックスが開く" },
        { "BreakerBoxOpen", "ブレーカーボックスが閉じる" },
        { "BreakerLever1", "スイッチの操作音" },
        { "BreakerLevel2", "スイッチの操作音" },
        { "BreakerLever3", "スイッチの操作音" },
        { "Breathe1", "呼吸音" },
        { "Breathing", "呼吸音" },
        { "BridgeCreak1", "橋が崩れ落ちる" },
        { "BridgeCreak2", "橋が崩れ落ちる" },
        { "BridgeCreak3", "橋が崩れ落ちる" },
        { "BugWalk1", "虫の歩く音" },
        { "BugWalk2", "虫の歩く音" },
        { "BugWalk3", "虫の歩く音" },
        { "BugWalk4", "虫の歩く音" },
        { "BurrowingRumbleLoud1", "地面が揺れる" },
        { "BurrowingRumble1", "地響き" },
        { "BurrowingRumble2", "地響き" },
        { "BurrowingRumble3", "地響き" },
        { "CashRegisterDing", "チーンと鳴りレジが開く" },
        { "CawScream1", "タカが鳴く" },
        { "CawScream2", "タカが鳴く" },
        { "CawScream3", "タカが鳴く" },
        { "CawScream4", "タカが鳴く" },
        { "CawScream5", "タカが鳴く" },
        { "ClingToPlayer", "Snare Fleaが巻き付く音" },
        { "ClingToPlayerLocal", "Snare Fleaが巻き付く音" },
        { "ClownHorn1", "ラッパの音" },
        { "ClownHornFar", "遠くからラッパが鳴り響く" },
        { "CrackNeck", "首の折れる音" },
        { "DistantRumble1", "遠くの轟音" },
        { "DistantRumble2", "遠くの轟音" },
        { "DistantRumble3", "遠くの轟音" },
        { "DocileLocustBeesEvade", "バッタが散る" },
        { "DoorClose1", "ドアが開く" },
        { "DoorClose2", "ドアが開く" },
        { "DoorOpen1", "ドアが閉じる" },
        { "DoorOpen2", "ドアが閉じる" },
        { "DoorShut", "セキュリティドアが閉鎖される" },
        { "DoorSlam1", "ドアがバタンと鳴る" },
        { "DoorSlam2", "ドアがバタンと鳴る" },
        { "DoorUnlock", "セキュリティドアのロックが解除される" },
        { "DoorUnlock2", "セキュリティドアのロックが解除される" },
        { "DoublewingFlap1", "バタバタと羽ばたく" },
        { "DoublewingFlap2", "バタバタと羽ばたく" },
        { "DoublewingFlap3", "バタバタと羽ばたく" },
        { "DuckQuack", "ゴムのアヒルがグワッと鳴く" },
        { "EmergeFromGround1", "リヴァイアサンが地面を突き破る" },
        { "ExplodeHead", "頭がはじけ飛ぶ音" },
        { "ExplodeHeadSecondarySFX", "頭がはじけ飛ぶ音" },
        { "ExtensionLadderAlarm", "伸縮はしごのタイマー音" },
        { "ExtensionLadderExtend", "伸縮はしごが伸びる" },
        { "ExtensionLadderShrink", "伸縮はしごが収納される" },
        { "Fart1", "ブーブークッションがブッと鳴る" },
        { "Fart2", "ブーブークッションがブッと鳴る" },
        { "Fart3", "ブーブークッションがブッと鳴る" },
        { "Fart5", "ブーブークッションがブッと鳴る" },
        { "FGiantEatPlayerSFX", "誰かが食べられる音" },
        { "Fireplace", "火のパチパチと弾ける音" },
        { "FlashbangExplode", "フラッシュグレネードがさく裂する" },
        { "FlashlightClick", "フラッシュグレネードのピンが抜ける" },
        { "FlashlightClickMini", "ライトが付く" },
        { "FlashlightClickMini2", "ライトが消える" },
        { "Footstep1", "足音" },
        { "Footstep2", "足音" },
        { "Footstep3", "足音" },
        { "Footstep4", "足音" },
        { "Footstep5", "足音" },
        { "Found1", "ざわめき" },
        { "Frighten1", "クリーチャーが怯える" },
        { "Frighten3", "クリーチャーが怯える" },
        { "GiantStomp1", "巨人の足音" },
        { "GiantStomp2", "巨人の足音" },
        { "GiantStomp3", "巨人の足音" },
        { "GiantStomp4", "巨人の足音" },
        { "GiantStomp5", "巨人の足音" },
        { "growl", "犬のうなり声" },
        { "HangarDoorOpen1", "船のハッチが開く" },
        { "HangarDoorOpening", "船のハッチの操作音" },
        { "HangarDoorShut", "船のハッチが閉じる" },
        { "HoarderBugCry", "Hoarder bugが鳴く" },
        { "ItemDropshipLand", "輸送ポッドが着陸" },
        { "ItemDropshipOpenDoors", "輸送ポッドが開く" },
        { "JackInTheBoxTheme", "オルゴールが奏でられる" },
        { "JackOLanternHit", "ジャックオーランタンの笑い声" },
        { "JesterStomp1", "激しくドタドタ走る音" },
        { "JesterStomp2", "激しくドタドタ走る音" },
        { "JesterStomp3", "激しくドタドタ走る音" },
        { "KillPlayer", "誰かが殴打される音" },
        { "KillPlayer_0", "誰かが殴打される音" },
        { "LightningStrike1", "雷が落ちる音" },
        { "LightningStrike2", "雷が落ちる音" },
        { "LightningStrike3", "雷が落ちる音" },
        { "LightningStrike4", "雷が落ちる音" },
        { "LongRoar1", "クリーチャーが吠える" },
        { "LongRoar2", "クリーチャーが吠える" },
        { "LongRoar3", "クリーチャーが吠える" },
        { "LoudCreak1", "大きなギシギシという音" },
        { "LoudCreak2", "大きなギシギシという音" },
        { "LoudCreak3", "大きなギシギシという音" },
        { "Lunge1", "犬の息づかい" },
        { "LungMachineDisconnect", "装置が抜き取られる" },
        { "MaskCry1", "くぐもった泣き声" },
        { "MaskCry2", "くぐもった泣き声" },
        { "MaskCry3", "くぐもった泣き声" },
        { "MaskCry4", "くぐもった泣き声" },
        { "MaskLaugh1", "くぐもった笑い声" },
        { "MaskLaugh2", "くぐもった笑い声" },
        { "MaskLaugh3", "くぐもった笑い声" },
        { "MaskPuke", "何かを噴きかけられる" },
        { "MetalDoorShut1 1", "ドアのバタンという音" },
        { "MetalDoorShut1", "ドアのバタンという音" },
        { "MetalDoorShut2", "ドアのバタンという音" },
        { "MineBeep", "地雷の警告音" },
        { "MineTrigger", "地雷が作動" },
        { "MineDetonate", "地雷が爆発する" },
        { "MineDetonateDistance", "遠くで地雷が爆発する" },
        { "monsterNoise", "モンスターの音" },
        { "monsterNoise2", "モンスターの音" },
        { "monsterNoiseB", "モンスターの音" },
        { "Nervous", "クリーチャーが緊張する" },
        { "NutcrackerAngry", "Nutcrackerが怒る" },
        { "PlushieSqueeze", "人形をぷにゅっと押す音" },
        { "Pop1", "Jesterが箱から飛び出す" },
        { "PullCord", "紐を引く音" },
        { "RattleTail", "尻尾が鳴る" },
        { "Roar", "巨人の咆哮" },
        { "Roar_0", "犬が吠える" },
        { "RobotToyCheer", "ロボットのおもちゃが鳴る" },
        { "SandWormRoar", "リヴァイアサンが鳴く" },
        { "SandWormRoar2", "リヴァイアサンが鳴く" },
        { "Scan", "スキャン音" },
        { "Scream1", "低い悲鳴" },
        { "ShipTeleporterSpin", "テレポーターが起動する" },
        { "ShipTeleporterSpinInverse", "逆テレポーターが起動する" },
        { "ShipThrusterClose", "船のスラスター音" },
        { "ShortRoar1", "短い咆哮" },
        { "ShotgunBlast", "ショットガンの銃声" },
        { "ShotgunBlast2", "ショットガンの銃声" },
        { "ShotgunReload", "ショットシェルを込める" },
        { "ShotgunReloadNutcracker", "ショットシェルを込める音" },
        { "Shriek1", "悲鳴" },
        { "Shriek2", "悲鳴" },
        { "ShipAlarmHornConstant", "船のホーンが鳴り響く" },
        { "ShipAlarmHornConstantDistant", "遠くから聞こえる船のホーン" },
        { "SkipWalk", "スキップする音" },
        { "SkipWalk1", "スキップする音" },
        { "SkipWalk2", "スキップする音" },
        { "SkipWalk3", "スキップする音" },
        { "SkipWalk4", "スキップする音" },
        { "SkipWalk5", "スキップする音" },
        { "SkipWalk6", "スキップする音" },
        { "SlimeAngry", "スライムが怒る" },
        { "SlimeDance", "スライムが踊る" },
        { "SlimeIdle", "スライムが這いずる" },
        { "SlimeKillPlayer", "スライムに飲み込まれる音" },
        { "SpiderAttack", "クモが攻撃する" },
        { "Spring1", "バネの音" },
        { "Spring2", "バネの音" },
        { "Spring3", "バネの音" },
        { "SpringWobble1", "バネがギシッと鳴る" },
        { "SpringWobble2", "バネがギシッと鳴る" },
        { "Squeak1", "ギシッという音" },
        { "Squeak2", "ギシッという音" },
        { "StickyNote", "紙をめくる音" },
        { "Stomp", "踏みつける音" },
        { "Stomp1", "踏みつける音" },
        { "Stomp1double", "踏みつける音" },
        { "Stomp2", "踏みつける音" },
        { "Stomp2double", "踏みつける音" },
        { "Stomp3", "踏みつける音" },
        { "Stomp3double", "ドタドタという音" },
        { "StormStaticElectricity", "静電気がビリビリとなる音" },
        { "StuckInWeb", "クモの糸が揺れる" },
        { "StunCrawler", "Thumperがスタンする" },
        { "StunDog", "Dogがスタンする" },
        { "StunDoublewing", "Birdがスタンする" },
        { "StunFlowerman", "Brackenがスタンする" },
        { "StunGiant", "Giantがスタンする" },
        { "StunSpider", "Spiderがスタンする" },
        { "Thunder1", "雷が鳴る" },
        { "Thunder2", "雷が鳴る" },
        { "Thunder3", "雷が鳴る" },
        { "ToiletFlush", "トイレの流れる音" },
        { "TunnelIntoGround1", "リヴァイアサンが出てくる" },
        { "TurnTVOff", "テレビが消える" },
        { "TurnTVOn", "テレビが付く" },
        { "TurretActivate", "タレットが起動する" },
        { "TurretBerserkMode", "タレットの動作音" },
        { "TurretDeactivate", "タレットが無効化される" },
        { "TurretFire", "タレットの銃声" },
        { "TurretFireDistance", "遠くから聞こえるタレットの銃声" },
        { "TurretSeePlayer", "タレットが狙いを定める" },
        { "TVKittenTheme", "間の抜けたトロンボーンの曲" },
        { "VentCrawl1", "通気口の奥から聞こえる声" },
        { "VentOpen1", "通気口の開く音" },
        { "WarningHUD", "警告音" },
        { "WarningHUD2", "警告音" },
        { "WarningHUD3", "警告音" },
    };

    public Dictionary<string, List<(float, string)>> DialogueTranslations => new(StringComparer.OrdinalIgnoreCase)
    {
        {
            "0DaysLeftAlert",
            new()
            {
                (0, "[会社のジングルが流れる]"),
                (4.969f, "すぐに社屋に出向いて"),
                (7.189f, "スクラップやその他の品物を売ってください。"),
                (9.758f, "利益ノルマ達成当日です。"),
                (13.085f, "ターミナルを使うことで"),
                (14.874f, "自動操縦船を社屋に向かわせることができます。"),
            }
        },
        {
            "IntroCompanySpeech",
            new()
            {
                (0, "[会社のジングルが流れる]"),
                (7.310f, "勤務初日へようこそ！"),
                (10.140f, "これは契約期間中に"),
                (12.440f, "食事や寝泊まりをする"),
                (13.800f, "あなた専用の自動操縦船です。"),
                (15.280f, "［不明瞭な早口言葉］"),
                (19.940f, "どうぞおくつろぎください。"),
                (21.690f, "乗船手続きを完了するには"),
                (23.770f, "操縦席に置いてあるマニュアルを確認し"),
                (25.650f, "船内のターミナルにアクセスしてください。"),
                (28.290f, "あなたが会社にとって大きな戦力となることを期待しています。"),
                (31.035f, "おっおっ大きな戦力会社の…"),
                (32.830f, "戦力おっおっおっ大きな戦力会社の…"),
                (35.235f, "大きなせっせっ戦力…"),
            }
        },
        {
            "LightningAudio",
            new()
            {
                (0.0f, "[明るい音楽が流れる]"),
                (3.020f, "[雷が落ちる]"),
                (4.300f, "[笑い声]"),
            }
        },
        {
            "SnareFleaTipChannel",
            new()
            {
                (0.330f, "エンティティがクルーに接触した際"),
                (2.830f, "即座に自己防衛を行うのは控えてください。"),
                (5.300f, "その代わりに、クルーに次のように尋ねてください："),
                (7.495f, "\"彼らは攻撃的ですか？\""),
                (9.410f, "\"ケガはしていませんか？\""),
                (10.635f, "\"手助けが必要ですか？\""),
                (11.730f, "これらの質問に対する答えがすべて「イエス」なら"),
                (13.920f, "自衛措置を開始してください。"),
                (15.900f, "クルーがストレスを感じている場合"),
                (17.190f, "\"今日はどうだった？\"などと声掛けを行いましょう。"),
                (19.620f, "ご視聴ありがとうございました。良い旅を！"),
            }
        },
        {
            "VoiceHey",
            new()
            {
                (0.0f, "やあ。"),
            }
        },
    };
}
