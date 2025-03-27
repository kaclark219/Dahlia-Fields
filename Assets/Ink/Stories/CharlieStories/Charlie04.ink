INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Charlie", "Right", "Normal")} So, I have a serious question. Hypothetically.
* [Okay?] -> EntertainedByCharlie
* [I'm not sure I want to know.] -> SuspiciousOfCharlie

=== SuspiciousOfCharlie ===
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Suspicious")} This already sounds sketchy, Charlie. What did you do?
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Suspicious")} Pfft, what? Me? Nothing! Just, uh.. how mad would you be at me if you slipped on a banana peel because it fell out of one of my bags?
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} ... Who fell?
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Normal")} Look, all I’m saying is that physics works really well when you least expect it, and I might have to hide from Bruce for forever now.
~CharlieTrust -= 5
-> END

=== EntertainedByCharlie ===
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} Huh, okay? Go on.
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Happy")} Okay, so, hear me out. Banana peels? Actually slippery! I thought that was just a cartoon thing.
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} Oh no.
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Normal")} Oh yes. And I might have been the reason it was on the ground. On accident, I swear! But Bruce isn't seeing it that way.
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Normal")} I think you might be a hazard.
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Happy")} I prefer "funny side character," but I’ll take it.
~CharlieTrust += 10
-> END
