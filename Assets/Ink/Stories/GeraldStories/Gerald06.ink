INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Gerald", "Right", "Normal")} You know, some of your flowers have medicinal properties.
* [Oh? Like what?] -> CuriousMedicinal
* [That’s just old folklore.] -> SkepticalMedicinal

=== CuriousMedicinal ===
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Happy")} Oh? That's interesting, like what? 
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Happy")} Lavender can help with sleep, dandelions are good for digestional health, and the scent of roses can help ease depression.
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} Do you actually use them?
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Normal")} Of course. Science and nature work best together.
~GeraldTrust += 10
-> END

=== SkepticalMedicinal ===
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} That’s just old folklore. There's no real proof.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Suspicious")} You don’t trust centuries of herbal remedies?
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} I mean, I trust medicine, just not the frilly stories of the scent of roses curing depression and such.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Normal")} Good thing I use all types of medical remedies. Just don’t be surprised when I turn out to be right.
~GeraldTrust -= 10
-> END
