INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Charlie", "Right", "Normal")} Hey {PlayerName}! Do you think racoon bites can get infected?
* [What?] -> Shocked
* [Tell me the story.] -> StoryTime

=== Shocked ===
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Suspicious")} Excuse me?! What have you been doing?
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Suspicious")} Nothing TOO weird. Don't sound all concerned like that.
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Normal")} It's just that last week this lil guy was going after some old donuts in the can outside of the pub. Didn't even see me coming. And it wasn't happy.
{HideCharacter("Player")} {ShowCharacter("Player", "Right", "Normal")} Maybe you should go talk to Gerald.
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Normal")} I'm trying to avoid a doctor's visit! Why do you think I asked you for advice?
~CharlieTrust -= 10
-> END

=== StoryTime ===
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} I feel like this question has a story attached to it.
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Happy")} Oh, does it! Picture this: 8 a.m., I'm grabbing the bag out of the can by the pub, mindin’ my business... and BAM! Raccoon jumps out like a ninja, right onto my chest.
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} ...And?  
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Happy")} We stared at each other for a solid five seconds before I flailed around, he bit me, and then flew off into the trees. Majestic little dude.
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} Let's hope the majestic little dude doesn't have rabies.
~CharlieTrust += 10
-> END
