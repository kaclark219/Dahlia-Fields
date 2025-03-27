INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Jeremy", "Right", "Normal")} I've been in the bad habit of starting projects and just never finishing them lately.
* [You should work on that.] -> NotRelatable
* [I do that all the time.] -> Relatable

=== Relatable ===
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} I do that all the time, sometimes you just have too much creativity and not enough time. 
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Happy")} Glad I'm not alone. I got like five projects in my shop, all half-done. I just have so many ideas,
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Happy")} What's the oldest one sitting around?
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Normal")} A chair. Been sitting unfinished for three years. I just can't decide what finish to put on it though. Don't get it twisted though, if you pay me to do something I'll totally get it done! That's different.
~JeremyTrust += 10
-> END

=== NotRelatable ===
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} Not really. I like to finish what I start.
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Normal")} Huh. Can’t relate. My workshop’s basically a graveyard of good intentions.
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} Maybe one day you’ll get back to them. For the sake of your customers, I hope so.
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Suspicious")} Woah there, careful bro. I always get my paid projects done, these are just my personal creative stints.
~JeremyTrust -= 10
-> END
