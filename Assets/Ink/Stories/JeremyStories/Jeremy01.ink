INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Jeremy", "Right", "Normal")} Hey, man. Are you here about the card?
* [This is shady.] -> Shady
* [What card?] -> Card

=== Shady ===
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} What do you mean? This whole thing feels kind of shady.
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Suspicious")} What's shady about trading and selling collector's cards, bro? I was even going to give you a deal on my PSA 10 First Edition Shadowless Reverse Holo Magikarp GX Full Art card. I'm trying to get it out of my stock. Market price is like 25000 wisp. So, you interested?
~JeremyTrust -= 10
* [Yes.] -> Yes
* [No.] -> No

=== Card ===
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} I'm a bit confused, what card are you talking about?
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Happy")} My PSA 10 First Edition Shadowless Reverse Holo Magikarp GX, of course. I've been trying to sell it from my collection for a while. It's like no one is serious about collecting cards these days, bro. Market price is like 25000 wisp, you interested?
~JeremyTrust += 10
* [Yes.] -> Yes
* [No.] -> No

=== Yes ===
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} Sure! I'd love to buy it.
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Suspicious")} Man, are you trying to scam me or something? There's no way you have that kind of cash on you right now. I appreciate the thought, though.
-> END

=== No ===
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} I'll have to pass, sorry.
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Normal")} No problem! Just keep me in mind next time you have money to spend. It would be a good investment!
-> END