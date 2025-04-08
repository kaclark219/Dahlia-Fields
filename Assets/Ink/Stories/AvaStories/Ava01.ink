INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Ava", "Right", "Normal")} Hey! You're new! Do you like dirt?
* [Dirt is okay.] -> LikesDirt
* [Dirt is too messy.] -> DislikesDirt

=== LikesDirt ===  
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} Uh, yeah? Dirt is pretty cool, I guess.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Happy")} I KNEW IT! You're like Charlie! He plays in the dirt ALL day. I wanna do that when I grow up!
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Happy")} Sounds like fun. You must really like Charlie, huh?  
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Happy")} Yeah! He's the coolest person ever. But maybe you're cool too. I'll think about it.
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Happy")} Fair enough. I’m {PlayerName}, by the way.  
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Happy")} Okay, {PlayerName}! I gotta go now, but maybe I'll show you my best mud cake later!
~AvaTrust += 10
-> END

=== DislikesDirt ===  
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} Not really. I'd rather stay clean.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Suspicious")} Huh? But dirt is fun! You can make cakes and dig for worms and—and—
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} I mean, you can do that. I'll just watch.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Suspicious")} Hmmm… that's kinda weird. You're not scared of dirt, are you?
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} No! I grow flowers, I just don't want it all over me right now.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Suspicious")} I dunno about that. You sound kinda scared.
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} I promise I'm not.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Normal")} Okay… if you say so.
~AvaTrust -= 10
-> END

