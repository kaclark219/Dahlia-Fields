INCLUDE ../Globals.ink

-> start

=== start ===  
{ShowCharacter("Poppy", "Right", "Normal")} You ever notice how people show their true colors in the pub?  
* [What do you mean?] -> Curious
* [Sounds judgy.] -> Defensive

=== Curious ===
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} What do you mean?
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Happy")} Well, people start out polite, but give 'em time, and you see what’s underneath when they start slipping up.
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} And what do you see?
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Normal")} Oh, a bit of everything. Some folks are all talk, others are sharper than they let on.
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Happy")} But don’t worry, {PlayerName}. You’re still a mystery to me. For now.
~PoppyTrust += 10
-> END

=== Defensive ===
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Suspicious")} Sounds like you’re just judging people.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Normal")} Nah, not judging. Just watching. People say things when they think no one's paying attention. It’s not my fault if I happen to be in the room when they do.  
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Suspicious")} And what do you do with that information?
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Suspicious")} You sound a little nervous. Would you like to know?
~PoppyTrust -= 10
-> END
