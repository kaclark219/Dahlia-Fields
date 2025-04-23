INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Linda", "Right", "Normal")} A word of advice: while you're running a business here, don't make promises you can't keep.
* [I always deliver.] -> Reliable
* [Sometimes things happen.] -> MakesExcuses

=== Reliable ===
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} Don't worry, I keep my word.
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Happy")} Good. Reputation is everything in a small town.
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} I'll keep that in mind.
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Normal")} See that you do.
~LindaTrust += 10
-> END

=== MakesExcuses ===
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} Well, sometimes things are out of my control.
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Suspicious")} That's how trust erodes, {PlayerName}.
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} I'll try to be better.
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Normal")} Trying is a lazy person's doing.
~LindaTrust -= 10
-> END