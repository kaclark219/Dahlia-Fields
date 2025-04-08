INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Ava", "Right", "Suspicious")} Hey... do you think Bruce is scary?
* [He's just grumpy.] -> Reassure
* [A little.] -> Agree

=== Reassure ===
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} No, he's just a little grumpy. He won't hurt you or anything.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Suspicious")} I don't know... he's really big. And he looks at me like I'm a squirrel.
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} He probably just doesn't know how to talk to kids. I bet if you gave him a flower, he'd be nice to you.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Happy")} Hmm... maybe if I can spare one. I'll think about it. But that sounds like a good idea. Kinda.
~AvaTrust += 5
-> END

=== Agree ===
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} Yeah, I can see why you'd think that. He's a little intense.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Happy")} Right?! I knew I wasn't just imagining it! Mom says it's mean of me to call him scary.
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} Don't tell your mom this, but I just try to stay away when he's around.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Normal")} That sounds like a good idea! Maybe I'll do that too!
~AvaTrust += 10
-> END
