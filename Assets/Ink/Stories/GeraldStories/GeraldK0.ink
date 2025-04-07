INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Gerald", "Right", "Normal")} Hey there, {PlayerName}. You wouldn't happen to have any types of herbs, would you? I'm running low on some key tonic ingredients.
* [I've got something special at my place. #kill] -> Kill
* [Sorry, can't help.] -> NoKill

=== Kill ===
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Special")} Actually, I do have something you might like. I have a personal collection of interesting plants I mainly use in cooking.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Happy")} Really now? You've piqued my curiosity. What kind of interesting?
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} Rare. Strong. Potent. Not the kind of thing you'd be able to find in the wild.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Normal")} This sounds like some sort of dream come true. What's the catch?
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} There's no catch. I keep them in my basement so customers don't get confused. You're more than welcome to come see them right now.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Happy")} Well now, how can I resist a private viewing? Lead the way, {PlayerName}.
{KillNPC("Gerald")}
-> END

=== NoKill ===
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} Sorry, I don't have anything to help.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Normal")} Ah, well. Guess I'll have to make do.
-> END