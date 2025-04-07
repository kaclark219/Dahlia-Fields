INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Jeremy", "Right", "Normal")} Man, I've had the weirdest day. You ever just feel like you're so close to figuring something out, but it's just out of reach? I feel like every idea I have for my current project just falls flat.
* [Maybe you need a change of scenery. #Kill] -> Kill
* [No, I can't relate.] -> NoKill

=== Kill ===
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} Sometimes when I get stuck on something, I just need a new environment to clear my head. You know, shake things up a little.  
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Normal")} Yeah? That actually makes a lot of sense.  
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Special")} I’ve got a nice setup at my place. It's quiet, there's plenty of space to think, and I even have card games if you need to get your mind going. It might be just what you need.
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Happy")} Huh. Yeah, yeah, I could see that working. And you know what? I could use a break. Alright, you’ve convinced me! Let's head over!
{KillNPC("Jeremy")}
-> END

=== NoKill ===
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} No, I can't really relate.
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Normal")} Eh, fair enough. Guess I’ll just keep thinking it over.
-> END
