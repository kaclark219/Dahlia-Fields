INCLUDE ../Globals.ink

-> start

=== start ===  
{ShowCharacter("Sebastian", "Right", "Normal")} Nighttime's the best time to be outside. No contest.  
* [Why?] -> NightPeace
* [That sounds creepy.] -> NightMock

=== NightPeace ===  
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} Nighttime? Why?
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Normal")} No noise. No people. Just the wind in the trees and the sound of your own thoughts.
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} That’s kind of poetic.
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Happy")} Don’t tell anyone I said that.
~SebastianTrust += 10
-> END

=== NightMock ===
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} That sounds creepy.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Suspicious")} Only if you're a child. But hey, if you ever want to face your fears, try the bench by the lake. Preferably when I'm not already there. Best seat in town.
~SebastianTrust -= 10
-> END