INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Megan", "Right", "Normal")} Oh! Hello there, you must be the new neighbor. I’m Megan. Have you settled in okay?
* [Yes, everything’s going well.] -> SettledIn
* [Still figuring things out.] -> StillAdjusting

=== SettledIn ===  
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Happy")} Yeah, I think I’m getting the hang of things. It’s a nice town.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Happy")} That’s great! It can take some time, but I think you’ll like it here. If you ever need anything, just ask!
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} Thanks, that means a lot. I’m {PlayerName}, by the way.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Happy")} Nice to meet you, {PlayerName}! I’ll see you around.
~MeganTrust += 5
-> END

=== StillAdjusting ===  
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} Not quite yet. There’s a lot to take in.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Normal")} That’s understandable. Moving is a big change. Just take your time.
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Happy")} I’ll try. Thanks for the advice.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Happy")} Of course! Oh, and if you ever need a little pick-me-up, I bake cookies sometimes.
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} That sounds nice. I might take you up on that.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Happy")} I’ll be right next door. Take care, {PlayerName}!
~MeganTrust += 10
-> END
