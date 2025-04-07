INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Linda", "Right", "Normal")} Hello there, {PlayerName}. What can I help you with?
* [Can we chat about my neighbors?] -> NeighborProblems
* [Can we talk about my request board?] -> RequestBoard

=== NeighborProblems ===
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} I'm having some issues with my neighbors. Their chickens are keeping me up all night.
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Normal")} Megan's chickens? I'm afraid that's not something I can "fix" for you. Those coops provide a lot of the town's eggs and meat, as well as Megan's livelihood.
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} I get that, but can't you make her insulate them better or something? I need to be able to sleep.
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Suspicious")} Megan already has enough on her plate. If you really have such a problem with them, you can volunteer to pay for the labor or do it yourself. I can't force her to do anything.
~LindaTrust -= 10
-> END

=== RequestBoard ===
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} So I've been wondering .. how have the flowers from my request board been getting delivered?
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Normal")} I've been collecting and distributing them in my free time. Why?
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} Oh, wow. Thanks! I was just curious, but I really appreciate your help!
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Happy")} No problem! Just doing my part to stimulate the town economy.
~LindaTrust += 10
-> END