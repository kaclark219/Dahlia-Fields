INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Sebastian", "Right", "Normal")} Can I help you? 
* [I grew something you should come take a look at.] -> Kill
* [Just wanted to chat.] -> NoKill

=== Kill ===  
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Special")} I grew this plant, and I'm pretty sure Gerald's going to lose his mind over it. I wanted to give you first dibs on it though, it'd make a nice gift for a special occasion.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Normal")} Gerald? Losing his mind over a plant? Yeah, that tracks. What is it?
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} It's a flower with special medical uses, something that's really hard to grow to fruition.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Suspicious")} And you're just going to let me have it? What kind of a prank is this?
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} No prank. And I'm not giving it to you for free, if that's what you're worried about. I just think that you guys might appreciate it more than me.
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Happy")} If this is real, it'll be a hell of an anniversary present. Let's go see it, {PlayerName}.
{KillNPC("Sebastian")}
-> END

=== NoKill ===
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} Nothing, I just came over to chat a little.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Normal")} Well, as you can see, I'm pretty busy right now. We can 'chat a little' later, maybe.
-> END