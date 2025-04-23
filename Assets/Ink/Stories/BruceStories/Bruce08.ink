INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Bruce", "Right", "Normal")} Do you sell flower arrangments? Not that I want one... just curious.
* [Yes.] -> LikesArranging
* [No.] -> InsultsArranging

=== LikesArranging ===
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} Yeah, in my free time I'll make some to sell. I find it relaxing.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Happy")} Guess there's worse ways to spend time. What kind of floral tape do you usually use?
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} You have a bit of a hobby too, don't you?
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Normal")} Keep that to yourself, kid.
~BruceTrust += 10
-> END

=== InsultsArranging ===
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} It's not something I enjoy doing, so I don't waste my time on arranging.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Suspicious")} Tch. Shows what you know.
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} What, like you know anything about floral arrangement. ...Oh wait, or do you?
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Normal")} Forget I asked.
~BruceTrust -= 10
-> END
