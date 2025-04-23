INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Poppy", "Right", "Normal")} Y'know, some days I wonder what life would be like if I didn't run this place. But then I think, who else would keep this town entertained?
* [You're like the heart of this place.] -> ComplimentPoppy
* [It'd be quieter.] -> TeasePoppy

=== ComplimentPoppy ===
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} You're probably what keeps this town from getting too dull.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Happy")} Flattery will get you everywhere, mate.
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} Just calling it like I see it.
~PoppyTrust += 10
-> END

=== TeasePoppy ===
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Happy")} Bet it'd be a lot quieter without you stirring things up.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Suspicious")} Oh, harsh! I thought we were friendlier than that, {PlayerName}. I just like having a little fun.
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} I'd say you're doing a good job of that.
~PoppyTrust -= 10
-> END
