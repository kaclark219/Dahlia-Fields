INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Charlie", "Right", "Normal")} Okay, so don't judge me, but what's the best flower for hiding bad smells?
* [Why?] -> QuestionableNeeds
* [Roses, probably.] -> HelpfulAdvice

=== QuestionableNeeds ===
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Suspicious")} Uh... why?  
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Normal")} No reason! Just, uh... my uniform's got a bit of a funk to it, y'know? Thought maybe a few flowers would class it up.
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} As much as I'd like the business, a few flowers might not fix that problem.
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Suspicious")} No, but it might distract from it.. I don't smell THAT bad.
~CharlieTrust -= 10  
-> END

=== HelpfulAdvice ===
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} Roses, probably. Or maybe lavender. They both have strong scents.
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Happy")} Perfect! If you see a request from me, just know it's urgent. 
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} You do realize flowers won't cancel out actual garbage, right?  
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Normal")} Maybe not, but they'll make my uniform look a little snazzier, maybe!
~CharlieTrust += 10
-> END
