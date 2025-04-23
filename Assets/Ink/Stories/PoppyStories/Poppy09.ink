INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Poppy", "Right", "Normal")} Tell you what, if you can guess which drink is most popular in this town, first round's on me next time.
* [Something fancy, to show off.] -> GuessWrong
* [Something strong and simple.] -> GuessCorrect


=== GuessCorrect ===
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} I'm betting on something strong and no-nonsense.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Happy")} Nailed it! These people like their drinks straightforward. Well, that, and they like getting drunk quick!
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Happy")} I'll remember that free drink.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Normal")} And I'll remember to water down whatever you're ordering when you cash that in.
~PoppyTrust += 10
-> END

=== GuessWrong ===
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} Probably something fancy, right? People love to show off.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Normal")} Oh, you sweet summer child. How long have you lived here? This isn't that kind of town.
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} Worth a guess.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Suspicious")} Maybe you should be buying everyone else's next round as an apology for forgetting every conversation you've ever had with them.
~PoppyTrust -= 10
-> END
