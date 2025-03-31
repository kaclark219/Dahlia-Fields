INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Linda", "Right", "Normal")} I’ve always thought a town’s gardens say a lot about its people. Some towns go for clean-cut hedges and fountains. Others let wildflowers take over. What’s your style, {PlayerName}?  
* [Wildflowers.] -> WildGarden  
* [Clean-cut.] -> NeatGarden  

=== NeatGarden ===  
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} I prefer neat and structured gardens. Everything has its place, and it looks intentional.  
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Happy")} A tidy garden takes dedication. It’s the same with running a town .. you can’t let things grow wild, or they take over.  
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} That makes sense. A little order keeps things running smoothly.  
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Happy")} Exactly. I respect someone who understands that.  
~LindaTrust += 10  
-> END  

=== WildGarden ===
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} I like wild gardens. They feel more natural, like the plants are growing where they’re meant to be.
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Suspicious")} Hm. So you think structure is unnecessary?
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} Not unnecessary, it's just that sometimes things flourish better when left alone.
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Normal")} Maybe, but if you leave things unchecked too long, you’ll find weeds creeping in where they don’t belong.
~LindaTrust -= 10
-> END
