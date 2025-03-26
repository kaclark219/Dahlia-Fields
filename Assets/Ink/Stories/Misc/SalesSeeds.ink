INCLUDE ../Globals.ink

EXTERNAL OpenSeedUI()
VAR BoughtSeeds = 0

-> start  

=== start ===  
{ShowCharacter("Maddie", "Right", "Normal")} Hey, there! Welcome to the post office! Anything I can put down for you in the mail order for tomorrow?
* [Yes, I have a few seeds to buy.] -> Check
* [No, thank you.] -> No

=== Check ===
{OpenSeedUI()}
{ BoughtSeeds==1: -> Yes }
{ BoughtSeeds==0: -> Broke }

=== Yes ===
{ShowCharacter("Maddie", "Right", "Normal")} Excellent choices! I will deliver the seeds tommorrow.
-> END

=== Broke ===
{ShowCharacter("Maddie", "Right", "Normal")} Changed your mind about the seeds? No problem at all! Our selection will be here whenever you're ready.
-> END

=== No ===
{ShowCharacter("Maddie", "Right", "Normal")} Alright then! Stop by anytime if you change your mind.
-> END