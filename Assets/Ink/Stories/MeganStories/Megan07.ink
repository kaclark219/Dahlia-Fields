INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Megan", "Right", "Normal")} Oh, um... can I ask your opinion on something?
* [Of course.] -> AskAboutLinda
* [I'm a bit busy right now.] -> Busy

=== AskAboutLinda ===
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} Of course! I have a bit of time to spare.  
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Normal")} It's about Linda. She's been helping me a lot, but I feel like I should be doing more to repay her.  
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} What has she been helping with?  
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Normal")} A little bit of everything. Advice, watching Ava so I can deliver baked goods... she's always been there for me.  
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} Maybe just telling her how much you appreciate her would mean a lot.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Happy")} You think so?  
{HideCharacter("Megan")} {ShowCharacter("Megan", "Right", "Normal")} Yeah. I bet she'd appreciate knowing she made a difference.
{HideCharacter("Player")} {ShowCharacter("Player", "Right", "Happy")} Huh. I'll do that. Thanks, {PlayerName}.
~MeganTrust += 10
-> END

=== Busy ===
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} I'm actually a bit busy right now, do you mind if we talk later?
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Suspicious")} Ah, that's okay. I actually needed the advice for the plans I had tonight. Never mind.
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} Oh. Sorry.  
~MeganTrust -= 5
-> END
