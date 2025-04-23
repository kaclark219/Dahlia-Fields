INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Sebastian", "Right", "Normal")} People keep asking why I don't hire someone to help with my orders. As if I want someone hovering over my shoulder, messing up my rhythm.
* [Sometimes help isn't bad.] -> SuggestHelp
* [Working alone has its perks.] -> AgreeWithSolo

=== AgreeWithSolo ===
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} I get it. Sometimes it's better to just rely on yourself.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Normal")} Exactly. No one to mess things up but me.
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} At least you know who to blame.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Happy")} Hah. True.
~SebastianTrust += 10
-> END

=== SuggestHelp ===
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} Sometimes having help isn't the worst thing.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Suspicious")} Yeah? And who's going to match my standards?
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} Fair point... Although I'm pretty sure I know a certain doctor that seems to be up to your standards.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Suspicious")} You don't know what you're talking about, that's none of your business.
~SebastianTrust -= 10
-> END
