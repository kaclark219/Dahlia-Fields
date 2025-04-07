INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Poppy", "Right", "Normal")} So, {PlayerName}, what's your poison?
* [Tea, usually.] -> PrefersTea
* [Whatever's strongest.] -> PrefersStrong

=== PrefersTea ===
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} I'm more of a tea person, honestly.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Normal")} Ah, a bit refined, are we? I've got some nice herbal blends behind the counter. Even some lavender if you like a floral touch.
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Happy")} That actually sounds nice. I might have to stop by sometime.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Normal")} You should! I'll even let you in on a secret.. sometimes I sneak a splash of something extra in mine after a long day.
~PoppyTrust += 5
-> END

=== PrefersStrong ===
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} I'll usually take whatever's strongest.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Happy")} That's what I like to hear! I've got a house special that'll knock your socks off. But fair warning, it's not for the faint of heart.
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} I feel like that's more of a challenge than a warning.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Normal")} Maybe it is. Guess you'll have to find out, mate!
~PoppyTrust += 10
-> END