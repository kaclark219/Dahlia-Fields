INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Jeremy", "Right", "Normal")} Random favor, can I borrow a bucket of nails? I ran out mid-project.
* [I bet Bruce has some.] -> LendNails
* [Who just has nails lying around?] -> NoNails

=== LendNails ===
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} I'm sure Bruce has some lying around, why don't you ask him?
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Happy")} You're so right! I'll head over there right now. Thanks, {PlayerName}!
~JeremyTrust += 10
-> END

=== NoNails ===
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} Who just keeps spare nails?
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Normal")} Uh... people with good preparedness vibes?
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} Or people who hoard junk.
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Suspicious")} Tomato, tomahto.
~JeremyTrust -= 10
-> END