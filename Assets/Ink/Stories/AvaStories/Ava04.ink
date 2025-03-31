INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Ava", "Right", "Normal")} Hey, {PlayerName}! What do you think is better for a mud pie? Leaves or flower petals?
* [Flower petals.] -> FlowerPetals
* [Leaves.] -> Leaves

=== FlowerPetals ===
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Happy")} Flower petals, for sure! It’ll be the fanciest mud pie ever.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Happy")} Ooooh! You’re right! It’ll be a MUD CAKE instead! With decorations!
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} That sounds nice! Maybe you'll even get to open your own mud bakery.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Normal")} You get it! I like you. You can have the first bite! ... Just pretend to eat it though.
~AvaTrust += 10
-> END

=== Leaves ===
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} Leaves are probably better. They’d make it more stable.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Suspicious")} Stable?! It’s not a bridge! It’s a PIE!
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} But if it falls apart, no one can eat it, right?
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Suspicious")} Hmmmm... I dunno. You sound like Bruce.
~AvaTrust -= 10
-> END
