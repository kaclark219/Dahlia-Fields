INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Linda", "Right", "Normal")} Have you noticed the birds around town? There’s a nesting pair of red-tailed hawks near the square.
* [I've noticed.] -> LikesBirds
* [Not really.] -> NoBirds

=== LikesBirds ===
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} Yeah, I’ve always liked birds, hawks are impressive.
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Happy")} They are. Sharp, efficient, focused. If I believed in spirit animals, I think mine would be a hawk.
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} Do you birdwatch often?
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Normal")} When I have time. It’s one of the few peaceful activities I can enjoy without someone demanding a permit or a tax cut.
~LindaTrust += 10
-> END

=== NoBirds ===
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} Not really. I don’t pay much attention to them.
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Suspicious")} Hm. I suppose people tend to overlook the smaller details in life.
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} I guess I never thought about it like that.
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Normal")} Maybe you should. It’s amazing what you notice when you actually look.
~LindaTrust -= 10
-> END
