INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Megan", "Right", "Normal")} If you see Ava today... could you let me know if she's, um, covered in mud again? Or climbing something she shouldn't be?

* [I'll keep an eye on her.] -> Supportive
* [Sounds like typical kid stuff.] -> Dismissive

=== Supportive ===
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} Don't worry, I'll keep an eye out, I know you get busy with the chicken coop.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Normal")} Thank you! She's a good kid, really, but has this active imagination... Yesterday, she tried to "plant" cookies in the garden to grow a cookie tree.
{HideCharacter("Megan")} {ShowCharacter("Megan", "Right", "Happy")} I just... I can't keep up sometimes. It's nice knowing someone else is watching out for her too.
~MeganTrust += 10
-> END

=== Dismissive ===
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} Honestly, that just sounds like normal kid behavior.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Normal")} Maybe... but normal doesn't mean safe. Last time she was "just being a kid," I had to get her down from the top of the swing set.
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} Yikes. It sounds like you should probably keep her on a tighter leash.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Suspicious")} It's hard singlehandedly supplying eggs and chicken to the town while raising a kid on my own. It wasn't the plan, but I'm doing my best.
~MeganTrust -= 10
-> END
