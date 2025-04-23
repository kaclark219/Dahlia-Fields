INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Bruce", "Right", "Normal")} What's your opinion on hunting? Ever tried it, or are you too squeamish?
* [I can handle it.] -> SupportsHunting
* [I don't believe in hunting.] -> AgainstHunting

=== SupportsHunting ===
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} I can handle it. It's a part of survival.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Happy")} Finally, someone with sense. People forget where their food comes from.
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} Exactly. It's not about fun, it's about necessity.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Normal")} Tell that to some of the softies in this town. They'll eat it unless I tell them about where it came from.
~BruceTrust += 10
-> END

=== AgainstHunting ===
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} I don't believe in hunting. It's unnecessary.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Suspicious")} Unnecessary? Let's see how you feel when you're starving.
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} There are other ways to get food, it's called being a vegetarian.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Normal")} Keep telling yourself that.
~BruceTrust -= 10
-> END
