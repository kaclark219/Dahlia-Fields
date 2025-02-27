INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Gerald", "Right", "Normal")} You wouldn't happen to be a casual chess player, would you?
* [Yes.] -> Yes
* [No.] -> No

=== Yes ===
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} I've played a few times, why do you ask?
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Happy")} Ah, perfect! Ahem, I mean, that's good news! I'm looking for a practice partner. 
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} I might be able to help. What are you practiciting for?
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Normal")} Linda and I play a few games here and there, but I fear I've been in a bit of a rut lately. Out of the last 10 matches, I've only won twice. And unfortunately, my partner refuses to play with me.
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} I'm not very good, but maybe just playing against someone else could help snap you out of it.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Normal")} Thank you! That would be such a help! We can do some scheduling later. Have a good one, {PlayerName}!
~GeraldTrust += 10
-> END

=== No ===
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} No, I'm not really into games like that.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Suspicious")} Oh, that's disappointing. For some reason, you seem like the strategizing type.
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Suspicious")} The strategizing type? Definitely not me, don't worry.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Normal")} No worries, {PlayerName}. I was just hoping to find a practice partner so I can get out of a slump. Looks like Linda's getting another win from me.
~GeraldTrust -= 10
-> END