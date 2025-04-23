INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Jeremy", "Right", "Happy")} Hey! I'll trade you a rare card if you can answer this: what type beats water?
* [Grass.] -> CorrectAnswer
* [Psychic.] -> WrongAnswer

=== CorrectAnswer ===
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Happy")} Easy! Grass.
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Happy")} Haha, nice! You actually know your stuff. A deal's a deal.
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} Pleasure doing business.
~JeremyTrust += 10
-> END

=== WrongAnswer ===
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} Psychic, right?
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Normal")} Bro... They have, like, NO relation. I can't give you a card for that.
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} Worth a shot, I guess.
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Suspicious")} Maybe you should listen more when I'm talking about my matches.
~JeremyTrust -= 10
-> END
