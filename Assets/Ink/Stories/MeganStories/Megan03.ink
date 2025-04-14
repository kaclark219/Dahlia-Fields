INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Megan", "Right", "Normal")} You know, I worry about Ava sometimes. She's such a sweet girl, but I don't want her getting mixed up in the wrong crowd.
* [You might be overthinking it.] -> Overthinking
* [She knows better.] -> ReassureMegan

=== ReassureMegan ===  
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} I think she's a good kid. A little wild, maybe, but she has a good heart.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Happy")} You really think so?
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} Yeah. She's got a strong personality, but that's not a bad thing. She just needs the right guidance.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Happy")} That means a lot to hear. I just want the best for her. Thank you for hearing me out!
~MeganTrust += 10
-> END

=== Overthinking ===
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} I don't mean to be rude, but maybe you're overthinking things. She's just a kid, and I haven't met anyone in town that's really the "wrong crowd" you should be worried about.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Suspicious")} You think so? Because kids don't just grow up right on their own.
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} I just mean sometimes they figure things out better when we don't worry too much.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Normal")} Maybe... but I don't want to take that chance. You wouldn't understand, you're not a parent.
~MeganTrust -= 10
-> END