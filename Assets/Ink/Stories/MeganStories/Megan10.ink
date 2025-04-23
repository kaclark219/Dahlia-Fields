INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Megan", "Right", "Normal")} Sometimes I just bake to feel like I'm in control of something... I mean- sorry, that's totally out of nowhere. I've just been baking nonstop lately because there's a lot on my mind.
Cookies, bread, cupcakes... Ava says if I keep going, we'll have to start giving pastries to the birds.
* [Maybe take a break?] -> SuggestStop
* [Whatever helps you unwind.] -> Encouraging

=== Encouraging ===
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} Hey, if it helps you relax, keep baking.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Happy")} That's what I was thinking! Plus, who's going to complain about too many sweets, right?
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} Definitely not me.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Normal")} I'll make sure you get a fresh loaf soon!
~MeganTrust += 10
-> END

=== SuggestStop ===
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} Maybe you should take a little break before your kitchen turns into a bakery.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Normal")} Oh... yeah, I guess I have gone a little overboard.
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} Just don't burn yourself out.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Suspicious")} You're probably right... I just don't know what else to do right now, with people disappearing and all.
~MeganTrust -= 10
-> END