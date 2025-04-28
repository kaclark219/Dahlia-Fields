INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Ava", "Right", "Normal")} Guess what, {PlayerName}! I made a potion from puddle water! Wanna try it?
* [I'll pretend to drink it.] -> DrinkPotion
* [No thanks.] -> RefusePotion

=== DrinkPotion ===
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Happy")} Yum! That's some powerful magic!
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Happy")} Haha! You didn't even make a face! You're brave, just like Charlie!
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} Gotta keep up my reputation.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Normal")} Huh? What reputation?
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} This brat. #thought
~AvaTrust += 10
-> END

=== RefusePotion ===
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} I think I'll pass on puddle water today.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Suspicious")} What?? You don't trust my potions?
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} I trust you... just not the puddle.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Normal")} Hmph. Boring.
~AvaTrust -= 10
-> END
