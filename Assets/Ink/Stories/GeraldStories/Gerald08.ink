INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Gerald", "Right", "Normal")} I'd love to stay and chat longer, but someone's waiting for me at the pub.
* [Hot date?] -> TeaseGerald
* [I won't keep you.] -> RespectfulExit

=== TeaseGerald ===
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Happy")} Oooh, meeting someone special?
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Happy")} Something like that. Let's just say he gets cranky if I'm late.
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} Enjoy your night, Gerald.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Happy")} Always do.
~GeraldTrust += 10
-> END

=== RespectfulExit ===
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} No worries, I'll catch you later.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Normal")} Appreciate it. He's not the patient type.
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Suspicious")} "He," huh?
{HideCharacter("Player")} {ShowCharacter("Player", "Right", "Normal")} I think I'm starting to put the pieces together... #thought
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Suspicious")} See you around, {PlayerName}.
~GeraldTrust -= 5
-> END
