INCLUDE ../Globals.ink

-> start

=== start ===  
{ShowCharacter("Poppy", "Right", "Normal")} Y'know, people always assume I've lived here for a while.  
* [Haven't you?] -> PoppyLocal  
* [Then where are you from?] -> PoppyMystery  

=== PoppyLocal ===  
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} Haven't you? Everyone is so comfortable around you.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Happy")} Nope! Moved here about... six years ago? But I guess I blend in well.
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} Huh. Never would've guessed.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Happy")} Good! That means I’ve successfully infiltrated the town.  
{HideCharacter("Poppy")} {ShowCharacter("Poppy", "Right", "Normal")} ...Kidding! Probably.  
~PoppyTrust += 10
-> END  

=== PoppyMystery ===
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Normal")} Wait, where did you come from then?
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Normal")} Ooooh, mysterious, isn't it? A stranger, rolling into town with no past, no history... wait am I talking about myself or you right now?
{HideCharacter("Poppy")} {ShowCharacter("Player", "Right", "Suspicious")} I'd prefer if you didn't call me suspicious.
{HideCharacter("Player")} {ShowCharacter("Poppy", "Right", "Suspicious")} You're no fun.
~PoppyTrust -= 5
-> END