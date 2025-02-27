INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Bruce", "Right", "Normal")} Hmph. You again. Tell me something.. you ever work with your hands, or are you one of those people who just stares at flowers all day?
* [I take care of things.] -> ProveYourself  
* [Leave flowers out of it.] -> DefendFlowers  

=== ProveYourself ===  
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} You'd be surprised what I can do for myself. I know how to take care of things.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Happy")} That so? Good. Too many people these days can’t do a thing without somebody else telling 'em how.
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} I think knowing how to take care of myself is important.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Happy")} Hah! You’ve got some sense in you, at least. Maybe you’re not as soft as I thought.
~BruceTrust += 10
-> END

=== DefendFlowers ===  
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Suspicious")} What’s wrong with flowers? They take skill to grow, you know.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Normal")} Skill? Tch. Back in my day, skill meant knowing how to build something, fix something, survive in the wild. Not arranging daisies.
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} Sounds like you don’t know much about plants. They can be useful, even for survival.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Suspicious")} Hmph. I’ll believe it when I see it.
~BruceTrust -= 10
-> END
