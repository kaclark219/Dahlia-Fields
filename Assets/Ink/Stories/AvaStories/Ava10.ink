INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Ava", "Right", "Normal")} {PlayerName}, if you found a treasure chest, what would you hope is inside?
* [Maybe sweets?] -> CandyTreasure
* [It'd be cool to find some antiques.] -> JunkTreasure

=== CandyTreasure ===
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} I'd hope it's full of sweets and candy.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Happy")} Especially chocolate coins, right?! We'd be rich AND have snacks!
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Happy")} Best treasure ever.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Normal")} You should be my new treasure hunting buddy! Charlie always just wants to find weird rusty things.
~AvaTrust += 10
-> END

=== JunkTreasure ===
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} There has to be a bunch of cool junk and antiques floating around this town. That could be fun to go through!
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Normal")} Wow... you're REALLY boring, huh?
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Suspicious")} And you're being REALLY disrespectful. So I guess we're even.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Suspicious")} You were the one who came over to play with me. And you're not my mom.
~AvaTrust -= 10
-> END
