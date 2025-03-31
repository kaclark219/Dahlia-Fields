INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Sebastian", "Right", "Normal")} Sebastian takes a long drag from his cigarette, exhaling slowly. #thought
* [You should quit.] -> Scold
* [What brand?] -> BrandInquiry

=== Scold ===
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} You really should quit that. It’s not good for you.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Suspicious")} He shrugs, taking another drag. #thought
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} Seriously, it’ll catch up to you eventually.
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Suspicious")} I don't need you scolding me like a little kid. I get that enough from other people around here. Buzz off, or maybe the smoke'll get you too.
~SebastianTrust -= 10
-> END

=== BrandInquiry ===
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} Hey, what brand are you smoking? Never seen those before.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Normal")} Oh, these? They're "Blues." Some local brand from the next town over I came across a while ago. Not the healthiest habit, but they’re smooth.
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} Smooth, huh? Well, as long as you enjoy them.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Happy")} We all have our habits. As long as you don't say anything about mine, I won't say anything about yours.
~SebastianTrust += 10
-> END
