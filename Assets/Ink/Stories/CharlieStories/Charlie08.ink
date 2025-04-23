INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Charlie", "Right", "Happy")} —so then I realized the keys weren't in my pocket anymore, and I had already walked the couple miles back from the trash pit!
* [Please tell me you went back.] -> WalkedBack
* [Charlie... how do you survive?] -> QuestionHisLife

=== WalkedBack ===
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} Did you actually have to walk all the way back and search for your house keys?
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Normal")} Thankfully, no! I forgot to lock my front door that morning, so I just waltzed right in and found one of my spare sets.
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Happy")} Spare sets? I'm kinda impressed with your forethought.
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Happy")} Stick with me and you'll find I'm full of surprises.
~CharlieTrust += 10
-> END

=== QuestionHisLife ===
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} Seriously, how do you make it through a day?
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Normal")} Honestly? Mostly luck.
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Suspicious")} ...That explains a lot.
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Suspicious")} I don't think I like the way you said that.
~CharlieTrust -= 5
-> END
