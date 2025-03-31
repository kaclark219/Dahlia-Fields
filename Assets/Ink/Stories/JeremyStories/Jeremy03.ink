INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Jeremy", "Right", "Normal")} Hey, {PlayerName}, quick question. Do you know anything about tools?
* [A little.] -> KnowsTools
* [Not really.] -> NoTools

=== KnowsTools ===
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} I know my way around a toolbox. Why do you ask?
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Happy")} Nice! I was hoping you could help me settle a debate with Bruce. He says a hammer is the most useful tool, but I say it's the wrench. What do you think?
* [Hammer.] -> Hammer
* [Wrench.] -> Wrench

=== Hammer ===
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} I’d have to side with Bruce. A hammer can do a lot more than just hammer nails.
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Suspicious")} Man, I thought you had better taste than that. A wrench can tighten, loosen, and even break things apart if you need it to. Versatility, bro.
-> END

=== Wrench ===
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} I think you’ve got a point. A wrench is pretty versatile.
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Happy")} Right? Finally, someone who gets it! Thanks for having some sense, {PlayerName}. Now to rub this in Bruce's face!
~JeremyTrust += 10
-> END

=== NoTools ===
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} Not really, sorry.
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Normal")} Ah, man, that’s a shame. Tools are the backbone of civilization, you know? Plus I needed you to help me win a debate with Bruce, but oh well.
~JeremyTrust -= 10
-> END
