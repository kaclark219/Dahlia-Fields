INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Charlie", "Right", "Normal")} Hey, {PlayerName}! You ever wonder what’s at the bottom of the dump?
* [We could look through my place instead.] -> Kill
* [Nope, and I don’t wanna know.] -> NoKill

=== Kill ===
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Special")} You know, Charlie, I bet I've got way better junk at my place. There was all kinds of stuff in the basement left behind from the old owner.
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Happy")} Whoa, seriously?! Like.. vintage trash?
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} Oh yeah. But you have to come over to check it out. No one else knows about my stash.
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Happy")} Oh man, a secret trash collection?? You're speaking my language! What are we waiting for, let's go!
{KillNPC("Charlie")}
-> END

=== NoKill ===  
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} Nope, and I don't wanna know.
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Normal")} Pfft, suit yourself. But don’t come crying to me when I find a golden toilet seat or something and you miss out.
-> END