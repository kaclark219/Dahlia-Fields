INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Sebastian", "Right", "Normal")} If you're wondering why I'm not at the park more often, it's because Jeremy and Charlie decided that's their new hangout spot.
{HideCharacter("Sebastian")} {ShowCharacter("Sebastian", "Right", "Suspicious")} It's impossible to enjoy the quiet when they're arguing about playing cards and whatever nonsense Charlie's always rambling about.
* [They're just having fun.] -> DefendThem
* [They can be a bit much.] -> AgreeWithSebastian

=== AgreeWithSebastian ===
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} Yeah, I get it. They're... loud.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Happy")} Finally, someone with ears. I swear, I should start charging them for ruining the atmosphere.
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} You could put up a "No Nonsense Allowed" sign.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Normal")} Tempting.
~SebastianTrust += 10
-> END

=== DefendThem ===
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} They're just having fun. It's a public park.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Suspicious")} Doesn't mean they need to turn it into a circus.
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} Maybe find a quieter spot?
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Normal")} Already scouting.
~SebastianTrust -= 10
-> END