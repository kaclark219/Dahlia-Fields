INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Bruce", "Right", "Normal")} If you had to pick... daisies or sunflowers?
* [Daisies. Simple and classic.] -> PicksDaisies
* [Sunflowers. They stand tall.] -> PicksSunflowers

=== PicksDaisies ===
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} Daisies. There's something honest about them.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Happy")} ...Yeah. You've got good taste.
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Happy'")} Thought you'd agree.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Normal")} Don't get cocky.
~BruceTrust += 10
-> END

=== PicksSunflowers ===
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} Sunflowers. They're bold.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Suspicious")} Flashy doesn't always mean better.
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} Just my opinion.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Suspicious")} Wrong opinion. You and that Sebastian kid must be cut from the same weird cloth.
~BruceTrust -= 10
-> END
