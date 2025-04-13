INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Gerald", "Right", "Normal")} {PlayerName}, do you think hands are too complicated for their own good?
* [What do you mean?] -> JustHands  
* [Absolutely.] -> UnderstandsArt  

=== JustHands ===  
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} I mean.. they're just hands. I don't really think about them or know what you're talking about.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Suspicious")} That's what everyone says until you try to draw them.
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} Wait, is this about anatomy sketches?  
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Normal")} Unfortunately, yes. Maybe I just need to go bother my usual hand model so I can finish these pages in my medical journal.
~GeraldTrust -= 10  
-> END  

=== UnderstandsArt ===  
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Happy")} Oh, absolutely. Hands are a nightmare to draw.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Happy")} Finally, someone who understands! I have drawn hundreds of them, and they still look like weird spaghetti claws.
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} I think that's just a rite of passage for anyone who sketches. The best advice? Just draw them badly on purpose. Then when they come out less bad, you feel like a genius.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Normal")} Unfortunately, that won't do for anatomy sketches in my journal. They have to be pretty detailed to be helpful to anyone else. Thank you for trying, though.
~GeraldTrust += 10
-> END
