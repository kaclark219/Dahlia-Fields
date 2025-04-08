INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Charlie", "Right", "Normal")} Hey, uh... random question. You ever had a smell just... follow you around?
* [Not really.] -> QuestionsCharlie
* [All the time!] -> RelatesToCharlie

=== QuestionsCharlie ===
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Suspicious")} No? That's a pretty weird thing to ask. Why?
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Suspicious")} Uhh... no reason. Definitely not because I've been trying to track one down all day or anything.
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} Charlie, do you think maybe it's you?
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Normal")} Hey, HEY. I prefer "odor challenged." It’s different.
~CharlieTrust -= 10
-> END

=== RelatesToCharlie ===
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} Oh yeah, definitely. Sometimes you just can't get rid of something, no matter how much soap you use. Sometimes I can only smell wet dirt.
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Happy")} RIGHT?! I knew it wasn't just me! I mean, mine might be work related, but still.
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} Yeah... I'm gonna guess it's the sanitation thing.
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Happy")} Y'know, that's a fair assumption. I respect that.
~CharlieTrust += 10
-> END
