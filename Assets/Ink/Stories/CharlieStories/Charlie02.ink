INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Charlie", "Right", "Normal")} Hey! Remember me? Charlie?
* [Who?] -> Who
* [Of course!] -> OfCourse

=== Who ===
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} Sorry, who? I've met a lot of people since I've moved in.
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Normal")} Aw, c'mon! I feel like I've gotta stand out even a little bit. And I remembered you, {PlayerName}!
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} I feel bad, but I don't know what else to tell you.
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Normal")} Nah, I get it. Everyone forgets the garbage man.
~CharlieTrust -= 10
-> END

=== OfCourse ===
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} Yeah, of course I remember you Charlie! I didn't have a conversation with anyone else about boxes!
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Happy")} Haha, yeah! I thought so! Well, anyway, I hang around the park a lot, so if you ever see me feel free to join. I'm a BIIIG cloud watcher. See you around!
~CharlieTrust += 10
-> END