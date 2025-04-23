INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Poppy", "Right", "Normal")} How adventurous are you feeling today? Because I may have just invented a new drink.
* [I'm in.] -> TryDrink
* [No thanks.] -> PlayItSafe

=== TryDrink ===
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Happy")} I'm always up for something new. Hit me with your best shot.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Happy")} That's the spirit! If you survive, I'll even name it after you.
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} Sounds like a fair deal. Wait.. if I survive??
~PoppyTrust += 10
-> END

=== PlayItSafe ===
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} I think I'll pass. I like knowing I'll still be standing after a drink.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Suspicious")} Where's your sense of adventure, mate?
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} Hidden behind common sense.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Normal")} Boring, but fair. Maybe I'll trick Charlie or Jeremy into trying it.
~PoppyTrust -= 10
-> END