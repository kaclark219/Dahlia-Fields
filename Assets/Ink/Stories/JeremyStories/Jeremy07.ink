INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Jeremy", "Right", "Normal")} Aw man, you haven't seen it around, have you?
* [No?] -> No
* [Did you lose something?] -> AskIfLost

=== No ===
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} No? I have no idea what you're talking about
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Normal")} I've got a lucky hammer that's never let me down. But it's disappeared from my workbench, and I'm freaking out, man.
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} A lucky hammer?
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Normal")} Yeah. Only broke, like, twice. But it’s got good vibes, y'know? You sure you haven't seen it?
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} Yeah, I have not.
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Suspicious")} Ugh this is the WORST! I'm going insane and no one can help me out.
~JeremyTrust -= 10
-> END

=== AskIfLost ===
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} Did you lose something? Do you need help looking around?
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Normal")} Actually, yeah... I think I've lost my lucky hammer.
{HideCharacter("Jeremy")} {ShowCharacter("Jeremy", "Right", "Happy")} I'd love some help looking for it!
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} So, when did you last see it?  
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Normal")} On my workbench. I swear it was right there.
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} Could it be, uh... somewhere else?
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Normal")} No, it couldn't. Which makes me think that maybe someone thinks it was okay to borrow it. POPPY!
~JeremyTrust += 10
-> END
