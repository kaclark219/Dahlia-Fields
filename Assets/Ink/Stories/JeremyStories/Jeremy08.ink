INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Jeremy", "Right", "Normal")} You ever think about how weird it is that flowers grow just to be cut down and put in a vase?
* [That's... kind of deep.] -> DeepResponse
* [I think you're overthinking it.] -> BrushItOff

=== DeepResponse ===
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} Huh. Never thought of it like that, but you're right.
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Happy")} Yeah, man. Nature's got jokes. But hey, at least they get to brighten someone's day before they wilt.
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Happy")} That's one way to look at it.
~JeremyTrust += 10
-> END

=== BrushItOff ===
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} I think you might need a nap or something.
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Suspicious")} Pfft, nah. This is peak brainpower, bro.
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} That's what worries me.
~JeremyTrust -= 10
-> END
