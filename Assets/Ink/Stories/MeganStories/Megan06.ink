INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Megan", "Right", "Normal")} I ran into Charlie earlier. That man is an enigma.
* [What did he do?] -> CharlieStory
* [You don't like him?] -> MeganCharlieOpinion

=== CharlieStory ===  
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} Oh, goodness. What did he do this time?  
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Normal")} He told me he found a 'historic artifact' while on his garbage pickup route.
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} And what was it?
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Normal")} A very moldy sandwich. He was SO sure it belonged in a museum. I told him to throw it away before it grew legs and ran off.
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} You probably saved the town from an outbreak.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Happy")} I know, right?
~MeganTrust += 10  
-> END  

=== MeganCharlieOpinion ===
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} You don't like him?
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Normal")} No, I ... appreciate him. He's just a little exhausting. It's like having another kid.
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} That's fair.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Normal")} But he always makes Ava laugh, so I guess he's doing something right.
~MeganTrust += 5
-> END
