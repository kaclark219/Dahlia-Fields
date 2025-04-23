INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Ava", "Right", "Normal")} Hey, {PlayerName}! If you could have a pet dragon, what color would it be?
* [Hmm, maybe pink?] -> PinkDragon
* [Dragons aren't real, Ava.] -> NoDragon

=== PinkDragon ===
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} Probably one that's pink or purple. Something with really shiny scales.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Happy")} YES! That's what I'd pick too! We could fly around together and scare Bruce.
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} He'd probably run away screaming.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Normal")} Haha! You're funny. I like you.
~AvaTrust += 10
-> END

=== NoDragon ===
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} I hate to break it to you, but dragons aren't real.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Suspicious")} What?! You don't know that! Maybe they're just hiding!
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} I guess anything's possible...
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Suspicious")} Hmph. Even if they aren't real, don't you know how to play pretend? You must be too old.
~AvaTrust -= 10
-> END
