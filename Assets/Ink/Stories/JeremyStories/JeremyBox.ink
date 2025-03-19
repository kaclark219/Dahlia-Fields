INCLUDE ../Globals.ink

EXTERNAL BuyFlowerbox()
VAR BoughtFlowerbox = 0

-> start  

=== start ===  
{ShowCharacter("Jeremy", "Right", "Normal")} Oh, hey, {PlayerName}. Were you interested in getting another flowerbox put in at over at your place? I could do it for about 50 wisps, with all the supplies and labor included. What do you think?
* [Sounds great!] -> Check
* [No, thank you.] -> No

=== Check ===
{BuyFlowerbox()}
{ BoughtFlowerbox==1: -> Yes }
{ BoughtFlowerbox==0: -> Broke }

=== Yes ===
{ShowCharacter("Jeremy", "Right", "Happy")} Great! I'll get started on that this evening and your new box will be good to go by tomorrow.
-> END

=== Broke ===
{ShowCharacter("Jeremy", "Right", "Suspicious")} Are you trying to scam me right now dude? That's not enough wisps!
{HideCharacter("Jeremy")}{ShowCharacter("Jeremy", "Right", "Normal")} If you ever scrape up the rest of the money you need, I'll be floating around. Come talk to me about more planters then.
-> END

=== No ===
{ShowCharacter("Jeremy", "Right", "Normal")} Eh, no biggie. I'm always floating around if you change your mind.
-> END