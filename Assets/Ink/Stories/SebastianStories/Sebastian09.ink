INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Sebastian", "Right", "Normal")} You ever make something just for yourself? Not for selling, not for anyone else, butjust because you felt like it.
* [Personal projects are important.] -> RelateToSebastian
* [I prefer my work to be worth something.] -> PracticalMindset

=== RelateToSebastian ===
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} Yeah, it's nice creating without the pressure. Personal projects are important
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Normal")} Exactly. I've got a shelf full of things no one will ever see but me. And that's how I like it.
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} Sometimes that's when the best stuff happens.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Happy")} You get it.
~SebastianTrust += 10
-> END

=== PracticalMindset ===
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} If I'm making something, it better have a purpose or be worth something.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Suspicious")} Not everything needs a purpose. Sometimes existing is enough, and worth is subjective.
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} Guess we see it differently.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Normal")} Clearly.
~SebastianTrust -= 10
-> END