INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Ava", "Right", "Normal")} I'm a little busy playing shop right now, are you here to buy something?
* [You could play shop at my house if you want. #kill] -> Kill
* [Nevermind.] -> NoKill

=== Kill ===
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Special")} Playing shop? You know who has a real shop you can use? Me! I'm sure your mom wouldn't mind if you came over to play at my house. What else are neighbors for?
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Happy")} That sounds like a GREAT idea, {PlayerName}! Let's go right now!
{KillNPC("Ava")}
-> END

=== NoKill ===
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} Oh, I didn't realize. Never mind me! You can get back to it.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Normal")} Okay! But just so you know, my shop has everything you could ever want. If the thing you want you want is always grass.
-> END