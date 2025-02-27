INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Ava", "Right", "Normal")} Hey, {PlayerName}! Guess what? I drew the BIGGEST sun ever with chalk today!
* [Sounds cool!] -> ExcitedForChalk
* [Chalk isn't my favorite.] -> NotExcitedForChalk

=== ExcitedForChalk ===  
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Happy")} That sounds awesome! How big is it?
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Happy")} SO BIG! It takes up the whole sidewalk! Charlie said it looks like it’s smiling at him.
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} That’s a pretty important sun, then.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Happy")} Right?! You get it! Maybe you’re cool after all.
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Happy")} I’ll take that as a compliment.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Happy")} You should! Maybe tomorrow I’ll let you help me draw a rainbow!
~AvaTrust += 10
-> END  

=== NotExcitedForChalk ===  
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} Chalk isn’t really my thing, to be honest.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Suspicious")} Huh? But it’s the BEST! You can draw anything you want!
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} I just don’t like how it feels on my hands.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Norma;")} What?! But chalk makes everything look pretty! How do you decorate stuff?
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} I find other ways!
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Suspicious")} Hmmmm… I dunno about that. Sounds kinda boring.
~AvaTrust -= 10
-> END