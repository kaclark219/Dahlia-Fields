INCLUDE ../Globals.ink

=== start ===
{ShowCharacter("Linda", "Right", "Normal")} Ah, {PlayerName}. Do you play chess?
* [I do.] -> PlayChess
* [Not really.] -> NotIntoChess

=== PlayChess ===
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} I do! Want to play a round?
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Happy")} Excellent. Let's see what you've got.
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} I should warn you, I'm not half bad.
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Happy")} Good. I'd rather not take it easy on you. Don't tell Gerald this, but I'm starting to read his strategies a little too easily.
~LindaTrust += 10
-> END

=== NotIntoChess ===
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} Chess isn't really my thing.
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Suspicious")} A shame. It teaches patience, foresight... important skills for life.
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} I guess, but I don’t really have the patience for it.
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Normal")} That explains a few things.
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Suspicious")} ...
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Normal")} I’m joking. Well, mostly.
~LindaTrust -= 10
-> END