INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Jeremy", "Right", "Normal")} Hey, man. What's up?
* [Running errands.] -> Bad
* [Not much.] -> Good

=== Bad ===
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} I've been out and about running some errands. Just getting things done.
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Suspicious")} Aw man, I guess you're not in tune with nature. Because it's been telling me to chill all day.
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Suspicious")} What is that even supposed to mean?
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Normal")} Don't you smell the wind? Man, if there was open water nearby this would be the perfect surf day. I guess I'll just go put my feet in the lake or something. Have fun getting back to the grind or whatever.
~JeremyTrust -= 10
-> END

=== Good ===
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} Nothing much, I've just been going with the flow.
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Happy")} Aw, yeah! So you're in tune with the universe, too! Because it's been telling me to chill all day.
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} Yeah, of course. I was thinking about going to the park just to enjoy it a bit more.
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Happy")} Man, you speak my language. I miss sand on my skin on surf days, but putting my feet in the lake is a close second best. You're not all that bad, {PlayerName}.
~JeremyTrust += 10
-> END
