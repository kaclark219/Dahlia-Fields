INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Poppy", "Right", "Normal")} If you're ever looking for me in the mornings, I'm probably out in my vegetable garden. Or sleeping in. One or the other!
* [You're into gardening?] -> CuriousResponse
* [You really do it all.] -> ComplimentPoppy

=== CuriousResponse ===
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} I didn't know you were into gardening.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Happy")} Oh, absolutely. Gotta balance out all the late nights somehow, right? Plus, homegrown veggies make the best pub meals.
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} That's a pretty solid setup.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Happy")} Stick with me and you'll have fresh salads whenever you want.
~PoppyTrust += 10
-> END

=== ComplimentPoppy ===
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Happy")} Fresh veggies and drinks? You really do it all.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Normal")} What can I say? I like keeping busy. And I like being well-fed even more.
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} Sounds like you've got the perfect balance.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Happy")} Took some practice, but I'd say I've mastered it.
~PoppyTrust += 5
-> END