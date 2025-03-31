INCLUDE ../Globals.ink

=== start ===
{ShowCharacter("Linda", "Right", "Normal")} Something on your mind, {PlayerName}?
* [How do shop hours work?] -> ShopHours
* [How do ordinances get decided?] -> TownOrdinances

=== ShopHours ===
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} Yeah, I heard that businesses here have to stay open for a minimum number of hours each week. Is that true?
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Normal")} That's right. We implemented it a few years ago to keep commerce flowing steadily, especially because we're such a small community.
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} That seems a little strict. What if someone just wants to run a shop part-time?
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Suspicious")} Then maybe they shouldn't run a shop at all. This town needs consistency to thrive. If other people take time out from their day expecting open stores and find everything closed, they'll struggle.
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Normal")} Hmm. I guess that makes sense.
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} It's not about control, {PlayerName}. It's about making sure we're a community people can rely on.
~LindaTrust -= 10
-> END

=== TownOrdinances ===
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} I was just wondering, how do new rules and policies get decided around here?
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Normal")} Most major decisions go through a town council vote. We take resident feedback seriously, but someone has to keep things organized.
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} So... you have the final say?
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Suspicious")} That's not exactly how it works. But, yes, I do sign off on most policies before they're enacted.
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} Must be a lot of pressure. Thank goodness you're the one in charge.
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Happy")} It is, but I wouldn't do it if I didn't care. I appreciate the confidence.
~LindaTrust += 10
-> END