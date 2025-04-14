INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Bruce", "Right", "Normal")} You believe in luck?
* [Not really.] -> LuckIsFake
* [Yeah, sometimes.] -> LuckIsReal

=== LuckIsFake ===
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} Not really, it's just superstition.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Suspicious")} Hmph. Tell that to the last guy who went hunting without a charm.
{HideCharacter("Player")} {ShowCharacter("Player", "Right", "Suspicious")} ...What happened?
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Normal")} Nothing. But he thought something would, and that's worse.
~BruceTrust -= 10
-> END

=== LuckIsReal ===
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} Yeah, sometimes. There has to be some sort of reason things happen the way they do.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Happy")} Good. You get it. I keep a charm when I hunt. Ain't taking chances.  
{HideCharacter("Player")} {ShowCharacter("Player", "Right", "Normal")} What kind of charm?
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Suspicious")} A fresh daisy.  
{HideCharacter("Player")} {ShowCharacter("Player", "Right", "Happy")} ... 
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Normal")} Say anything and I'll throw you in a bush.
~BruceTrust += 10
-> END  