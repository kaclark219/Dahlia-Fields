INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Bruce", "Right", "Normal")} You live next door to Megan, {PlayerName}, do you talk to her often?
* [Yeah, she's nice.] -> MeganIsNice
* [Yeah, why?] -> CallOutCrush

=== MeganIsNice ===
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} Yeah, she's nice.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Happy")} ...Yeah. Real nice.
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} She's a good mom, too. Ava's a menace, but Megan keeps her in check.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Normal")} Tough job. She does it well. And she smells like daisies.
{HideCharacter("Bruce")} {ShowCharacter("Bruce", "Right", "Suspicious")} ...Not that I care or notice or anything.  
~BruceTrust += 10
-> END

=== CallOutCrush ===
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Happy")} Why? Are you interested in her?
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Suspicious")} What? No. That's stupid.
{HideCharacter("Bruce")} {ShowCharacter("Bruce", "Right", "Normal")} She's just... I respect her. That's all. And she's nice to look at. But that's got nothin' to do with it.  
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Happy")} Sure. Nothing to do with it.  
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Suspicious")} Drop it kid.
~BruceTrust -= 10
-> END
