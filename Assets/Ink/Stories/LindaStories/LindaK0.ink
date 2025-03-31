INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Linda", "Right", "Normal")} Hey, {PlayerName}. What's on your mind today?
* [There's a water leak in my basement.] -> Kill
* [Nevermind.] -> NoKill

=== Kill ===
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Special")} Actually, there's something in my basement I need your help with. I've got a bit of a water leak down there, and I'm not sure how to fix it myself.
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Normal")} Oh, that's not good. Water leaks can cause a lot of damage if left unchecked. I'll come over and take a look.
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} Thanks, I really appreciate it.  
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Normal")} No problem. I've seen worse. Let's get it fixed before it turns into a bigger issue!  
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} Sounds like a plan. We can head over to my place right now.
{KillNPC("Linda")}
-> END

=== NoKill ===
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} Oh, nothing. I must've been spacing out, sorry.
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Normal")} No problem. Feel free to talk to me if there's anything I can help with.
-> END