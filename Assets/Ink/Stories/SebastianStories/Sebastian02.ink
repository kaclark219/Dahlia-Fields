INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Sebastian", "Right", "Normal")} You need something?  
* [Just saying hello.] -> JustSayingHi
* [Do you have any home decor ideas?] -> LookingForDecor

=== JustSayingHi ===
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Happy")} Nope, just saying hello.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Suspicious")} Right… okay.  
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} Uh… I just thought I’d check in.  
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Suspicious")} You don’t have to do that.
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Suspicious")} Oh. Well, see you around.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Suspicious")} Yeah.
~SebastianTrust -= 10
-> END

=== LookingForDecor ===
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} Actually, I was hoping to find some things to decorate my place with. Any ideas?
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Normal")} Oh. I’ve got a few things. Little wood carvings, a couple of glass pieces.
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Happy")} That sounds perfect! You make them yourself?
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Happy")} Yeah. Helps pass the time. Keeps my hands busy.   
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Happy")} That’s really cool. I’d love to see what you have.  
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Happy")} Alright. Come by later, I’ll set some things aside.  
~SebastianTrust += 10
-> END
