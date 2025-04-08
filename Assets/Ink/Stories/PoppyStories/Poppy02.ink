INCLUDE ../Globals.ink

-> start

=== start ===  
{ShowCharacter("Poppy", "Right", "Normal")} Hey there, {PlayerName}. Hope the drinks are celebratory and you're settling in alright.
* [Yeah, doing well.] -> SettlingIn
* [I'm working on it.] -> Overwhelmed

=== SettlingIn ===
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Happy")} Yeah, I think I'm getting the hang of things.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Happy")} That's the spirit! Small town life has its quirks, but it's not so bad.
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} Yeah, everyone seems to be in each other's business, though.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Normal")} Oh, tell me about it. If it's not town gossip, it's town business — literally.
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} What do you mean?
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Normal")} I mean my kitchen table is currently buried under a stack of expense reports. Someone insists that “home is just an extension of the office.”
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} Huh, I guess that's one mindset.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Normal")} But hey, at least I get first dibs on hearing about every little town news before it's official. Perks, right?
~PoppyTrust += 10
-> END

=== Overwhelmed ===
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} It's been a bit overwhelming. Everyone knows everything about each other.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Normal")} Oh yeah, privacy's more of a suggestion around here. Comes with the territory. I'd complain, but I can't exactly throw stones; I'm stuck hearing about every town decision whether I like it or not.   
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} Why's that?
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Suspicious")} Let's just say some people have a habit of turning my pub into an unofficial town hall. And leaving stacks of paperwork in places where I like to eat.
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} Sounds frustrating.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Normal")} You have no idea. But I guess I signed up for it.
~PoppyTrust -= 5
-> END
