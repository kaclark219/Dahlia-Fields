INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Gerald", "Right", "Normal")} Coming from out of town, do you ever get bored around here?
* [Sometimes, yeah.] -> AdmitBoredom
* [Not really.] -> NeverBored

=== AdmitBoredom ===  
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} Sometimes, yeah. But what can I do? It's a small community.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Happy")} Agreed. But I've learned that boredom is just an opportunity to be creative or do more for others.
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Happy")} That's surprisingly optimistic.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Normal")} I try to be. Otherwise, I’d go insane. I was never really planning to stay in Dahlia Fields long-term, but I found something to keep me here. So here I am.
~GeraldTrust += 10
-> END

=== NeverBored ===
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} Not really.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Suspicious")} Huh. Are you easily entertained, or just too polite to tell me the truth?
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} Maybe. There's always something happening, you just have to frame it in your mind as interesting.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Normal")} I admire the mindset.
~GeraldTrust -= 5
-> END
