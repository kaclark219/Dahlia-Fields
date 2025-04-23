INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Charlie", "Right", "Normal")} So... if someone hypothetically adopted a stray cat, would you be able to give them any advice?
* [I'd be concerned.] -> ConcernedAboutCat
* [You'd be a great cat owner!] -> SupportsCat

=== SupportsCat ===
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Happy")} You'd be a great cat dad, that's adorable! What's its name?
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Happy")} I was thinking "Meowey." Fits, right?
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} I think you might have to go back to the drawing board with that one.
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Normal")} I don't think the cat hanging out in the park really cares what I call it as long as I keep feeding it, but maybe I'll keep thinking.
~CharlieTrust += 10
-> END

=== ConcernedAboutCat ===
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} Considering your luck? I'd worry for the cat.
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Normal")} Hey! I'll have you know I'd be a great cat dad. Better than that poor thing continuing to sleep outside.
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} As long as it doesn't end up in a trash bag in the dump, I guess.
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Suspicious")} Rude.
~CharlieTrust -= 10
-> END
