INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Ava", "Right", "Happy")} I was hiding for SO LONG and nobody found me! I think I won!
* [Where were you hiding?] -> AskHidingSpot
* [Does anyone know you were hiding?] -> ExpressConcern

=== AskHidingSpot ===
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} Where were you hiding?  
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Happy")} In the lettuce row of Miss Poppy's garden! No one could've found me there!
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Suspicious")} Does Miss Poppy know you were walking around in her garden?  
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Suspicious")} ...Maybe not. You better not tell her! That'd be snitching. And Bruce says that snitches get stitches.
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} Maybe you shouldn't go messing around in other people's yards anymore. Or be hanging around Bruce.
~AvaTrust -= 10
-> END  

=== ExpressConcern ===  
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Suspicious")} Does anyone know you were hiding? I'm a bit worried that nobody found you.  
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Happy")} Nah! I was just really good at hiding. Charlie was supposed to be looking for me!
{HideCharacter("Ava")} {ShowCharacter("Player", "Right", "Normal")} Maybe you should also let your mom know next time you wander that far from your house. Just in case.
{HideCharacter("Player")} {ShowCharacter("Ava", "Right", "Normal")} I guess... Charlie isn't good at hide and seek anyway, so I don't have to try THAT hard.
~AvaTrust += 10
-> END