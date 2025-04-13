INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Charlie", "Right", "Normal")} So, uh... Linda and Poppy. They're, like, roommates, right?  
* [I don't know about that.] -> Misunderstanding
* [You really think that?] -> CallHimOut

=== Misunderstanding ===
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} Oh, buddy... I don't know about that one.
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Happy")} What? They live together, they're really friendly... Sounds like prime roommate material to me!
{HideCharacter("Charlie")}{ShowCharacter("Charlie", "Right", "Normal")} I was thinking about finding a roomie to supplement my rent, and I wanted to ask them how they found each other.
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} ...Have you ever see them act like just roommates?
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Normal")} ...I mean, I saw Poppy fix Linda's tie once when she was leaving for work. That's roommate stuff, right?
{HideCharacter("Player")} {ShowCharacter("Player", "Right", "Happy")} Uh huh. Sure.
~CharlieTrust += 5
-> END

=== CallHimOut ===  
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} Is that really what you think?  
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Suspicious")} Well, yeah? What else would they be? You sound kind of weirdly judgy right now.
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} Oh, Charlie...
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Normal")} What?
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} Nothing. You'll figure it out eventually.
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Suspicious")} I don't like the way you said that.
~CharlieTrust -= 10
-> END
