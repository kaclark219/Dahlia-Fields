INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Bruce", "Right", "Normal")} Hey you. Ever sharpen a blade before, or do you just let your tools get dull?
* [I don’t really use blades.] -> NoTools
* [I keep my tools nice.] -> TakesCare

=== TakesCare ===  
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} Of course. Dull tools just make more work for yourself.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Happy")} Hah! That’s what I like to hear. Nothing worse than someone who doesn’t respect their own tools.
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} I wouldn’t be much of a shop owner if I didn’t.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Normal")} Guess you’re not totally hopeless after all.
~BruceTrust += 10
-> END

=== NoTools ===
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} I don’t really use blades much, so I don’t think about it.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Suspicious")} So what, you just fumble around with whatever’s in front of you? That’s how you get hurt.
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} I manage just fine.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Suspicious")} We’ll see how long that lasts.
~BruceTrust -= 10
-> END
