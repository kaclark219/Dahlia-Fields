INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Gerald", "Right", "Normal")} Alright, {PlayerName}, serious question. But you have to promise not to laugh.
* [Okay, I promise.] -> Promise
* [No promises.] -> NoPromises

=== NoPromises ===
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Happy")} No promises. Now I have to hear this.  
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Suspicious")} See, now that just makes me more hesitant... Fine. I'm a doctor, right? I work with all kinds of things like bones, injuries, illnesses. But you know what gets to me?
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} No, go on.
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} Snails. I cannot stand snails.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Happy")} ...Pfft.
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Suspicious")} I knew you'd laugh! I was just hoping you'd be willing to get the snails off my front door but I guess this was silly to ask.
~GeraldTrust -= 10
-> END

=== Promise ===
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} Okay, I promise. What is it?
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Normal")} Alright. I cannot stand snails. They creep me out. The slimy trail? The way they move? I'd take a broken bone over a snail on my shoe any day. And I have no idea why! It’s completely irrational.  
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Happy")} Okay, I did promise not to laugh, but that's pretty funny.
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Happy")} I knew you'd laugh! I was just hoping you'd be willing to get the snails off my front door, you having to deal with them in your garden and all. If you ever get bored, just know I would appreciate it.
~GeraldTrust += 10
-> END
