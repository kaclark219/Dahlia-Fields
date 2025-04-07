INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Sebastian", "Right", "Normal")} You're staring.
* [Sorry.] -> Compliment
* [Didn't realize I was.] -> PlayItCool

=== Compliment ===
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} Oh, sorry! I just noticed your wood carving bracelets. They're really impressive.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Happy")} ...Thanks. Most people don't really care about stuff like that.
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} Well, I do. It's cool seeing something handmade with that much detail.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Normal")} Hm. Well. I guess I'll keep that in mind.
~SebastianTrust += 10
-> END

=== PlayItCool ===
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} Huh? Oh. Didn't even realize I was looking.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Suspicious")} Right.
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} But now that I am.. what've you been doing these days?
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Suspicious")} Just working on a commission. Nothing you'd be interested in.
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} Got it. Well... I won't bother you, then.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Normal")} Mhm.
~SebastianTrust -= 10
-> END