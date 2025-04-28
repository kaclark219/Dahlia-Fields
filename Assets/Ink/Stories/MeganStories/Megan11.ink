INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Megan", "Right", "Normal")} I was working on some embroidery last night. It's silly, but I always find it relaxing.
* [That sounds peaceful.] -> AppreciateHobby
* [I'd get too bored doing that.] -> DismissHobby

=== AppreciateHobby ===
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} That actually sounds really peaceful. It's good to have something like that.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Normal")} It really is! There's something nice about making tiny stitches and seeing a pattern slowly come to life, you know? Like, no matter how messy things get, at least the thread follows some order.I could show you some of my designs sometime. If you're interested, of course!
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Happy")} I'd like that.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Happy")} Oh! I'll pick out some of my best ones then.
~MeganTrust += 10
-> END

=== DismissHobby ===
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} I think I'd get too bored doing something like that.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Suspicious")} Oh... yeah, I guess it's not for everyone.
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} I'm more of a "keep moving" type.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Normal")} Well, if you ever want to try slowing down, let me know. It would be nice to bond with another adult a little.
~MeganTrust -= 10
-> END