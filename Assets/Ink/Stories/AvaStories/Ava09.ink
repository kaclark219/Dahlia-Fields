INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Ava", "Right", "Normal")} {PlayerName}, do flowers talk when we're not around? You would know!
* [Of course not!] -> FlowersDontTalk
* [Of course!] -> FlowersTalk

=== FlowersTalk ===
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} Absolutely! Weeds in the grass gossip all day, and the flowers in my garden love to argue over who's the prettiest.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Happy")} I KNEW IT! I bet your flowers tell you secrets too!
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} Maybe... but I can't spill their secrets!
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Normal")} Aw man! Just one? I won't tell anyone, I promise.
~AvaTrust += 10
-> END

=== FlowersDontTalk ===
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Suspicious")} Absolutely not. Flowers can't talk, where did you hear something like that?
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Normal")} Are you sure? Maybe they just don't like you, because I swear I can hear them laughing when I pass your house...
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Suspicious")} I'm sure. Don't go around saying ridiculous things like that.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Suspicious")} Sorry, I didn't mean to upset you, {PlayerName}...
~AvaTrust -= 10
-> END