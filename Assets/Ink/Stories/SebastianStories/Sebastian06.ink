INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Sebastian", "Right", "Normal")} I feel like the local frog population has been declining. Have you noticed?
* [No.] -> FrogConfusion  
* [Yeah.] -> FrogBonding  

=== FrogConfusion ===
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} Uh... no? I don't really think that hard about frogs.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Suspicious")} See, that's where you're missing out.  
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} On what, exactly?
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Normal")} On the pure, chaotic existence of a frog. They just sit there. Existing. Sometimes they scream. It's great.
{HideCharacter("Sebastian")} {ShowCharacter("Sebastian", "Right", "Suspicious")} You should try caring about living things other than yourself sometimes. It's humbling.  
~SebastianTrust -= 10
-> END  

=== FrogBonding ===
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} Yeah, I've noticed there aren't enough cuties around lately.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Happy")} Right?! No one has noticed but me, I feel like I'm going crazy!
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} I mean, they're just little guys. We need to look out for them.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Normal")} Exactly. Just little guys, minding their business. Living the dream. You should come with me to bring this up to Linda. There could be a serious issue.
~SebastianTrust += 10
-> END
