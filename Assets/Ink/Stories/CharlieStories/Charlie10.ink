INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Charlie", "Right", "Normal")} Y'know, people joke about my job a lot, but I actually like it. Feels good keeping the town clean.
* [I respect that.] -> RespectCharlie
* [Someone's gotta do it.] -> BackhandedComment

=== RespectCharlie ===
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} Seriously. Not everyone can say they help out like that.
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Happy")} Thanks, {PlayerName}. I'm glad I have someone to talk to about this kind of stuff.
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} What do you mean? You have plenty of friends.
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Normal")} Those friends being a small child and a dude so chill he never feels sad. Nah, I need to keep you around.
~CharlieTrust += 10
-> END

=== BackhandedComment ===
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} Hey, someone's gotta do the dirty work.
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Normal")} ...Gee, thanks for the glowing praise. I'm so lad I shared my innermost thoughts with you.
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} I didn't mean it like that, you know that Charlie.
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Suspicious")} Do I? Sometimes it feels like you're not really into being my friend, {PlayerName}.
~CharlieTrust -= 10
-> END