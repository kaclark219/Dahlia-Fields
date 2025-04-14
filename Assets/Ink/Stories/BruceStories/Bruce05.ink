INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Bruce", "Right", "Normal")} Hey, {PlayerName}, you had a drink at the pub yet?
* [Not really.] -> NotMuchOfADrinker
* [Sometimes.] -> CasualDrinker

=== CasualDrinker ===
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} Yeah, sometimes. You?
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Happy")} Of course, with the way Poppy makes these mango things, I'd be there every day of the week if my liver could handle it.
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} Oh? Mango things?
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Normal")} You know, mango things. They've got liquor and pulp, like a real man drinks.
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} Oh, sure. That sound delicious. And ... really manly.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Normal")} Yeah, I knew you'd get it.
~BruceTrust += 10
-> END

=== NotMuchOfADrinker ===
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} Not really.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Suspicious")} Huh. No wonder you walk around looking bored all the time. You haven't ever experienced one of Poppy's 'Manly Mango' drinks.
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Suspicious")} Manly Mango? Are you talking about a fruity cocktail?
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Normal")} Absolutely not! You wouldn't get it. They're only for the stronger drinkers.
~BruceTrust -= 10
-> END
