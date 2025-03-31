INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Ava", "Right", "Happy")} Do you wanna meet my new pet?
* [No thanks.] -> Decline
* [What is it?] -> Curious


=== Curious ===  
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Happy")} Sure! What kind of pet is it?
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Happy")} His name is Squiggles, and he’s a worm! He likes mud cakes, just like me! Wanna hold him?
* [Hold Squiggles.] -> HoldWorm
* [Refuse.] -> RefuseWorm

=== HoldWorm ===
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} ...Okay, I’ll try, I guess.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Happy")} Yay! He’s really wiggly. Be careful!
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} Yeah, I noticed.
~AvaTrust += 10
-> END

=== RefuseWorm ===
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} No, thanks. You can have have him all to yourself.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Suspicious")} Aww, you’re missing out. He’s the best worm ever.
{HideCharacter("Ava")} {ShowCharacter("Ava", "Right", "Normal")} But that’s okay. More Squiggles time for me!
~AvaTrust += 5
-> END

=== Decline ===
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} Uh... no thanks. I’m good.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Suspicious")} Your loss! He’s the best pet ever. And if I cut him in half, I can have two pets!
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Suspicious")} Sorry, what? Please don't cut whatever animal you have in half.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Suspicious")} He's MY worm, you didn't want to even meet him. I can do whatever I want with him.
~AvaTrust -= 10  
-> END
