INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Gerald", "Right", "Normal")} You ever notice how I don’t drink much?
* [Why is that?] -> CuriousLimit
* [Never paid attention.] -> Unobservant

=== CuriousLimit ===
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} Yeah, why is that? Is it something about the negative health effects or something?
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Happy")} Hah! I'm glad that's your first thought. No, I like to stay in control. I'm a bit of a lightweight.
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} I didn't picture you to not handle your drinks. That's fair, though.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Normal")} It'll be our little secret, then. If anyone asks, tell them I gave you a lecture about the dangers of drinking.
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} I can respect that, sure thing.
~GeraldTrust += 10
-> END

=== Unobservant ===
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} Never paid attention.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Suspicious")} I thought you were more observant than that, I guess not.
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} Guess I'm just focused on other things.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Normal")} Fair enough. But yeah, I like to keep my head clear. Never know when you’ll need your wits about you. Plus excessive drinking is bad for your health. Remember that next pub night.
~GeraldTrust -= 5
-> END