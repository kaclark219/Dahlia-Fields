INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Sebastian", "Right", "Normal")} ...Don't laugh, but I've been spending more time at the post office lately. Maddie keeps dragging me into her mailroom chaos. It's not as awful as I thought it'd be.
* [I wouldn't have guessed you two hang out.] -> SurprisedResponse
* [Maddie's hard to say no to.] -> UnderstandingResponse

=== SurprisedResponse ===
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} I never would've pictured you willingly hanging out there, or with someone so upbeat.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Normal")} Yeah, well, she talks enough for both of us. I just nod and sort packages sometimes.
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} Sounds... oddly wholesome.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Suspicious")} I wasn't asking for your opinion, I just noticed that you caught me a couple times and needed to clear it up.
~SebastianTrust -= 10
-> END

=== UnderstandingResponse ===
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} Yeah, Maddie's hard to say no to once she decides you're her friend. She's just so cheerful!
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Happy")} Exactly. It's annoying... but in a way you get used to. She even convinced me to paint a poster for behind the counter.
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} You're practically part-time staff now.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Normal")} Don't remind me, I don't get paid.
~SebastianTrust += 10
-> END
