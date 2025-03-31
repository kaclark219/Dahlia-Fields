INCLUDE ../Globals.ink

-> start

=== start ===  
{ShowCharacter("Poppy", "Right", "Normal")} So.. I might have overheard some drunken ramblings I definitely shouldn’t have.
* [Tell me!] -> PoppyGossip
* [You shouldn't spread rumors.] -> PoppyScold  

=== PoppyGossip ===
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} Oh? Spill! I NEED to know.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Normal")} I could tell you, but that would make me a bad bartender, wouldn't it?
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} Oh, come on. Just a little?
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Happy")} Fine, fine. Let's just say, someone in town has a very strong crush. And no, I won't say who. That's for you to figure out.  
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} You tease!  
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Happy")} I have to keep things interesting somehow.  
~PoppyTrust += 10
-> END

=== PoppyScold ===
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} You know, eavesdropping and spreading rumors isn't great.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Suspicious")} Oh, I wasn't eavesdropping, mate. People just forget I exist when they've had a few drinks.
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} That still doesn't mean you should spread whatever you heard around.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Normal")} Just say you don't want to know, that's fine. Someone has to make this town a little more interesting, so it might as well be me.
~PoppyTrust -= 10
-> END