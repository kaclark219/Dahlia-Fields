INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Poppy", "Right", "Normal")} Hey, {PlayerName}, what's up?  
* [You want to try something new? #kill] -> Kill
* [Nothing much.] -> NoKill

=== Kill ===
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} Actually, I've got this new drink recipe I've been working on using some of my flowers. It's a bit experimental, but I think you'll like it.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Normal")} Oh, I love trying new things! What's in it?
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Special")} I muddled some rose petals and threw a couple other things together. If you want to come over to my place, I can show you the whole process and you can taste it.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Happy")} Sounds intriguing, I could really level up my cocktail game with something like that. I'd love to come try it right now!
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} Perfect! I really think it's something special.
{KillNPC("Poppy")}
-> END

=== NoKill ===
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} Oh, nothing. I was going to ask you a question about how you protect your begetable garden, but I figured it out on my way over here.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Normal")} Oh, right on, mate. Sounds good!
-> END