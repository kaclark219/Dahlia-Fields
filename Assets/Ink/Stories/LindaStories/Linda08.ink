INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Linda", "Right", "Normal")} If Poppy tells you any rumors about me, don't believe them. Half the town thinks I'm a vampire with the way she describes my sleeping habits.
* [Should I be worried?] -> PlayAlong
* [People actually believe that?] -> DoubtTown

=== PlayAlong ===
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Happy")} Should I start carrying garlic? I don't want to get drained by the local bloodsucker.
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Suspicious")} Only if you want to waste perfectly good seasoning.
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} I'm just joking, no need to be uptight.
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Normal")} You haven't seen me truly uptight.
~LindaTrust -= 10
-> END

=== DoubtTown ===
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} People actually believe that nonsense?
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Normal")} You'd be surprised how fast gossip spreads when people are bored.
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} I'll take everything Poppy says with a grain of salt.
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Happy")} Make it a handful.
~LindaTrust += 10
-> END