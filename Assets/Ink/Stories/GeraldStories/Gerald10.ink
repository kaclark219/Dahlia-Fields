INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Gerald", "Right", "Normal")} What's your opinion on smoking, {PlayerName}? Bad habit, or does it have its moments?
* [It's terrible for you.] -> AgainstSmoking
* [I get why people do it.] -> UnderstandsSmoking

=== AgainstSmoking ===
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} It's awful. There's no excuse for it.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Happy")} Exactly. I keep telling him there are healthier options, but you know how stubborn some folks can be.
{HideCharacter("Gerald")} {ShowCharacter("Gerald", "Right", "Normal")} I don't mind keeping them company outside, but I'd rather not lose a patient I don't have to.
~GeraldTrust += 10
-> END

=== UnderstandsSmoking ===
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} I get it. Some people just need a way to unwind.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Suspicious")} Hmph. Try telling that to someone who lights up a pack after every rough day.
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} Maybe they need better coping mechanisms.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Normal")} Easier said than done. I'd prefer this patient live for quite a long time, but they're making it difficult for me.
~GeraldTrust -= 10
-> END