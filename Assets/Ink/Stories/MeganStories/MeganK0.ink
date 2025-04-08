INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Megan", "Right", "Normal")} Hey dear, what's going on?  
* [I need your help with a recipe. #kill] -> Kill
* [Nothing much.] -> NoKill

=== Kill ===
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} So, I'm trying to make this recipe, but it's not turning out quite right. I was hoping you could give me a hand.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Normal")} Of course! What are you trying to make?
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Special")} It's a bread recipe, but the dough's too sticky and it's just not proofing. I have a proof drawer in my basement, and I can't tell what's going wrong. I was hoping you could come over and take a look.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Happy")} I LOVE working with bread! I'd be happy to come over and help.
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} Thank you so much! It should only take a few minutes, we can head over now.
{KillNPC("Megan")}
-> END

=== NoKill ===
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} Nothing much, I'm just on a quick walk.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Normal")} Alright, well, if you change your mind, I'm always here to help.
-> END