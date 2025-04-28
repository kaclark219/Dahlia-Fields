INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Linda", "Right", "Normal")} Since you like strategy so much, how about a bet? Beat me at chess, and I'll owe you a favor.
* [You're on.] -> AcceptChallenge
* [I'm not falling for that.] -> DeclineChallenge

=== AcceptChallenge ===
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} You're on. Hope you're ready to lose.
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Happy")} Confidence. I like that. Let's see if you can back it up.
~LindaTrust += 10
-> END

=== DeclineChallenge ===
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} You can't be that bored of Gerald, and I know a trap when I see one. I'll pass.
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Suspicious")} Smart... or cowardly. Time will tell.
~LindaTrust -= 5
-> END
