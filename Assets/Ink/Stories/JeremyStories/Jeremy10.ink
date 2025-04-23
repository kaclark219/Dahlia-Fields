INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Jeremy", "Right", "Normal")} You know, if you're ever stressed, just do what I do, take a nap under your workbench.
* [That sounds nice.] -> AgreeWithAdvice
* [That sounds unsafe.] -> DisagreeWithAdvice

=== AgreeWithAdvice ===
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} Honestly? That doesn't sound too bad.
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Happy")} Exactly! Nothing like a solid power nap surrounded by tools.
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} You're definitely one of a kind. In a good way! Of course.
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Normal")} Yeah, duh bro.
~JeremyTrust += 10
-> END

=== DisagreeWithAdvice ===
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} Jeremy, that's a terrible idea.
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Suspicious")} Hey, don’t knock it till you try it!
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} I'll pass. That sounds incredibly unsafe. What if something falls off the bench and hits you in the head?
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Normal")} Then you get a longer nap? I'm not seeing the problem here.
~JeremyTrust -= 10
-> END