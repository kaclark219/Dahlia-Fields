INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Jeremy", "Right", "Normal")} Dude, you ever collected anything?
* [Not really.] -> NoCollection
* [Yeah, I have a collection.] -> HasCollection

=== HasCollection ===
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} Yeah, I collect a few things.
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Happy")} That's sick! Nothing beats the thrill of the hunt, you know? I've been building my card collection since I was a kid. Got some real gems in there.
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} What's the rarest one you have?
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Happy")} Bro, I don't know if I've mentioned it, but I’ve got a pristine condition PSA 10 First Edition Shiny Magikorp. You wouldn't believe how many wisps that thing is worth.
~JeremyTrust += 10
-> END

=== NoCollection ===
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Suspicious")} Seriously? Not even like, cool rocks or something?
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} Man, you gotta start. Collections tell you a lot about a person. Like, my cards? They show I've got patience, dedication, and an eye for value. Just think about it, it's some real wordly type of stuff.
~JeremyTrust -= 10
-> END
