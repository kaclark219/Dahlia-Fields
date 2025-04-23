INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Megan", "Right", "Normal")} Can I ask you something? It's about Gerald... I know he's the town doctor and all, and he's always polite, but... do you ever feel like his smile doesn't really reach his eyes?
He just knows so much about everyone, it makes me nervous.

* [I think he's just observant.] -> DefendGerald
* [Now that you mention it...] -> AgreeWithMegan

=== DefendGerald ===
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} I think he's just good at reading people, it must come with the job.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Normal")} You're probably right... I mean, I'm sure I'm just overthinking it. He did give Ava a free house call last month after she scraped her knee.
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} That was nice of him.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Happy")} Yeah... I should focus on that, huh? Thanks for talking this through with me.
~MeganTrust += 10
-> END

=== AgreeWithMegan ===
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} Now that you mention it... he does seem like he's always a step ahead.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Suspicious")} Right?! It's like he's already guessed what you're going to say. Makes me nervous sometimes. And his charming little smirk doesn't help.
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} Maybe just don't overthink it too much.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Suspicious")} Easier said than done. Now I'm even more uneasy about my upcoming doctor's appointment.
~MeganTrust += 5
-> END
