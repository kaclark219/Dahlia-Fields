INCLUDE ../Globals.ink

-> start

=== start ===  
{ShowCharacter("Poppy", "Right", "Normal")} Man, I wish I could be spending time with Jeff right now.  
* [Are you cheating on Linda?] -> PoppyCheating
* [Who is Jeff?] -> Jeff  

=== PoppyCheating ===  
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} Jeff? Are you cheating on Linda?
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Suspicious")} That sure is bold of you to assume missy!
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} Well what else should I assume when you're talking about some mystery guy?
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Suspicious")} Jeff is my pet BIRD. Not some mystery guy. I can't believe you'd think so low of my character.  
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} Oh... sorry.
~PoppyTrust -= 10
-> END

=== Jeff ===
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} I haven't met any Jeff around town yet, who is he?
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Happy")} Jeff's my pet bird! He hangs out in the pub with me because he loves taking in all the sounds of people.
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} That's so fun! Maybe I should look into getting myself some sort of pet.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Normal")} You should! It's the perfect balance between kids and no kids. No kids and a bird!
~PoppyTrust += 10
-> END