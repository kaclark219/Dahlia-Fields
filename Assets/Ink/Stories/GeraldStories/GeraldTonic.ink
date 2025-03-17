INCLUDE ../Globals.ink

EXTERNAL BuyTonic()
VAR BoughtTonic = 0

-> start  

=== start ===  
{ShowCharacter("Gerald", "Right", "Normal")} Ah, {PlayerName}! You’re looking a little drained. Long days at the shop catching up to you? I’ve got a fresh batch of my energy tonics, they're only 100 wisps per serving if you're interested.
* [Yes, I'll take one.] -> Check
* [No, thank you.] -> No

=== Check ===
{BuyTonic()}
{ BoughtTonic==1: -> Yes }
{ BoughtTonic==0: -> Broke }

=== Yes ===
{ShowCharacter("Gerald", "Right", "Happy")} Excellent choice! You won't be disappointed.
-> END

=== Broke ===
{ShowCharacter("Gerald", "Right", "Suspicious")} I really wish I could help you out, but you're going to need to come back another time when you have more wisps to spend.
{HideCharacter("Gerald")}{ShowCharacter("Gerald", "Right", "Normal")} Have a good rest of your day, {PlayerName}.
-> END

=== No ===
{ShowCharacter("Gerald", "Right", "Normal")} Not a problem, you can come back later if you change your mind.
-> END