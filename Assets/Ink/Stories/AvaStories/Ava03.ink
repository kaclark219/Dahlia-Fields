INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Ava", "Right", "Normal")} Hey, {PlayerName}! Maddie gave me ANOTHER note today! Do you think it's a secret message?
* [Are you talking about the mail?] -> RegularMail
* [Oh, definitely.] -> SecretMessage

=== SecretMessage ===
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Happy")} Totally! Maybe it’s a treasure map and she’s leaving clues for you!
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Happy")} THAT’S WHAT I THOUGHT! I bet it’s a super top-secret mission. I should ask Maddie what it means!
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} Or you could try solving it yourself first!
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Normal")} Good idea! You’re smart. Maybe I’ll let you in on the secret when I figure it out. Or maybe I'll just ask Charlie to solve it for me.
~AvaTrust += 10
-> END

=== RegularMail ===  
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} I think it’s just regular mail, Ava. Maddie delivers letters to everyone.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Suspicious")} Huh?! No way. She ALWAYS gives me notes. That has to mean something!
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} It means people are sending letters to your house.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Suspicious")} Hmmm… I dunno. That sounds kinda boring.
~AvaTrust -= 10
-> END  