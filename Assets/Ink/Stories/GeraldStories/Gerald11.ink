INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Gerald", "Right", "Normal")} Is it overkill that I carry a first aid kit everywhere? Be honest.
* [Honestly? That's smart.] -> ApprovesPrepared
* [A little overkill.] -> ThinksOverkill

=== ApprovesPrepared ===
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} Honestly? It's just being prepared, you're smart for that.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Happy")} Finally, someone who gets it! You never know when someone's going to trip over a rock or get a surprise paper cut. We might be too far from the clinic to get real supplies.
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} Better safe than sorry.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Normal")} Exactly! Plus.. somehow I keep running out of bandages at the clinic. Now that I think about it, I always notice we're out after Bruce drops in for a visit...
~GeraldTrust += 10
-> END

=== ThinksOverkill ===
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} That feels like overkill unless you're expecting disaster.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Normal")} In this town? I've seen people twist ankles walking to the park.
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} Fair, but still a bit much.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Suspicious")} I'll stick to my methods. You never know when I'll be urgently needed. With my first aid kit.
~GeraldTrust -= 10
-> END
