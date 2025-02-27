INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Linda", "Right", "Normal")} Ah, yes, {PlayerName}. Any issues with the property so far? It's been vacant for quite a while, so don't hesitate to let me know if anything needs to be fixed or updated.
* [I'll handle things myself.] -> NoEnter
* [Everything's fine.] -> DoingFine

=== NoEnter ===
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} No, don't worry about it. I'll handle any issues with the house myself. I'd rather not have my personal space disturbed.
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Suspicious")} Well, just don't forget that I'm your landlord. It's my job to deal with things and check in around the property.
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} Right. Everything is all good for now, thank you though.
~LindaTrust -= 10
-> END

=== DoingFine ===
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} Everything has been doing well! The house has solid bones. Thank you again for letting me rent from you.
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Happy")} Not a problem! I'm just glad there's someone new in that old property. I've got to get back to work, but have a good one, dear!
~LindaTrust += 10
-> END