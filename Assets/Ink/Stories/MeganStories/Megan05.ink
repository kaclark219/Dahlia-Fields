INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Megan", "Right", "Normal")} Oh no... oh no, oh no...  
* [What happened?] -> BakingDisaster
* [Did Ava do something?] -> BakingBlameAva

=== BakingDisaster ===
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} Are you okay? What happened?
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Normal")} I may have... uh... set an entire tray of cookies on fire. And now the whole house is full of smoke.
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} How did you even manage that?
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Normal")} I don't know! One second, they were baking, the next... whoosh! Maybe I got distracted...
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} At least your house is still standing! It could've been so much worse!
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Happy")} True. But now I need to bake a whole new batch. Want to help? I'd love for you to be my taste tester, Ava is hyper enough today.
~MeganTrust += 10
-> END

=== BakingBlameAva ===
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} Did Ava do something?
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Suspicious")} Why would you assume Ava is causing trouble?
{HideCharacter("Megan")} {ShowCharacter("Megan", "Right", "Normal")} This one was all me. I burnt a batch of cookies. But she did watch the fire and say, "Wow, Mom, you're really bad at this."
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} She's so supportive.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Normal")} Right? Well, I have to make a new batch as soon as the house airs out, so I'll see you later.
~MeganTrust -= 10
-> END
