INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Bruce", "Right", "Normal")} People these days complicate everything. Give 'em a problem, and they make a big mess out of it. You agree?
* [Not necessarily.] -> ChallengesBruce
* [Simple is better.] -> AgreesWithBruce

=== AgreesWithBruce ===
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} Yeah, I think people overcomplicate things sometimes.  
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Happy")} Exactly! You don't need fancy tricks—just know what needs doing and do it.
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} Makes sense to me.  
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Happy")} Good. If more people thought like that, we'd have fewer problems.
~BruceTrust += 10
-> END

=== ChallengesBruce ===
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} I think some problems need more thought to solve properly.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Suspicious")} Hmph. That's what people say when they want to make things harder than they need to be.
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Suspicious")} Or maybe they just don't want to rush into a bad decision.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Normal")} We'll see if you still think that way when it comes back to bite you.
~BruceTrust -= 10
-> END
