INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Bruce", "Right", "Normal")} What's going on kid?
* [Do you want to come look at my vintage tool collection?] -> Kill
* [Nevermind.] -> NoKill

=== Kill ===
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Special")} I was going through some of the boxes I hasn't unpacked yet, and I found my collection of vintage knives. Would you want to come over and take a look?
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Happy")} Vintage knives... how did you know I was an aficionado? Show the way, {PlayerName}!
{KillNPC("Bruce")}
-> END

=== NoKill ===
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} Oh, nothing. I forgot what I was going to say, sorry.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Normal")} Hmph. Kids these days walking around with nothing in their head.
-> END