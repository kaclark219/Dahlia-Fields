INCLUDE ../Globals.ink

// Variable Trust & Functions are from Globals.ink

-> start

=== start ===
Voldemart and his death eaters wait eagerly in the Dark Forest... #thought
{ShowCharacter("Gerald", "Right", "Sad")}
I thought he would come.
... {PlayerName}
{ShowCharacter("Player", "Left", "Sad")}
Harry Potter enters the clearing... #thought
{ChangeMood("Gerald", "Happy")}
Harry Potter, the boy who lived, come to die?!
AVADA CADAVRAAAAAAAA!!!!
{HideCharacter("Player")}
{HideCharacter("Gerald")}

Cake or Pie?
*** Cake
-> Cake
*** Pie
-> Pie

=== Cake ===
Increase Trust
~Trust += 10
-> continue_conversation

=== Pie
Decrease Trust
~Trust -= 10
-> continue_conversation

=== continue_conversation
{ShowCharacter("Player", "Center", "Fine")}
{ Trust>10: You chose cake }
{ Trust <10: You chose pie }
The end.

->END
