INCLUDE ../Globals.ink

-> start

=== start ===  
{ShowCharacter("Megan", "Right", "Normal")} You've talked to Linda, right? She can be a little blunt, but she's a good person.
* [She seems nice.] -> SupportsLinda
* [She's intimidating.] -> FindsLindaIntimidating

=== SupportsLinda ===  
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Happy")} Yeah, she seems nice. Straight to the point, but I respect that.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Happy")} Exactly! People don't always see it, but she does so much for the town. She just doesn't sugarcoat things.
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} I get that. Honesty isn't a bad thing.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Normal")} Glad you think so! It's nice when someone else sees what I do.
~MeganTrust += 10
-> END

=== FindsLindaIntimidating ===
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} She's a bit intimidating, to be honest.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Normal")} Yeah, I get that. She has a way of looking at you like she's deciding whether you're worth her time. But once you get past that, she's a great friend. I mean, she's always looked out for me.
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} That's good to know. Maybe I just need to talk to her more.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Normal")} You should! I think you'd get along.
~MeganTrust += 5
-> END
