INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Sebastian", "Right", "Normal")} Hey, {PlayerName}, have you ever played a tabletop RPG?
* [Yeah, I love them!] -> RPGBond
* [Never tried one.] -> RPGLoss

=== RPGBond ===  
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} Yeah, I love them! I haven't played much since moving to Dahlia Fields, though.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Happy")} Good. That means you understand the suffering of a bad dice roll.
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} Oh yeah, nothing like failing a simple lockpick check and ruining an entire heist.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Normal")} I once rolled three natural ones in a row. My character tripped over his own sword and died.  
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} Ouch.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Happy")} It was tragic. But also? Kinda hilarious.
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} Yeah, I'd play again just for moments like that.
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Happy")} Then you should join my group. Gerald, Maddie, and I have a campaign going. You in?
* [Sounds fun!] -> JoinGroup
* [I’ll pass.] -> DeclineGroup

=== JoinGroup ===
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Happy")} Sounds fun! It would be nice to play again.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Happy")} Cool. We meet at my place once a week.
~SebastianTrust += 10
-> END  

=== DeclineGroup ===  
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} I’ll pass. I'm busy enough these days.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Normal")} Your loss. But hey, if you ever change your mind, let me know.
~SebastianTrust += 5
-> END

=== RPGLoss ===
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} I've never tried one. They've always seemed a little too nerdy for me.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Suspicious")} Too nerdy? It's justs a good time with friends. I guess you just don't get it.
{HideCharacter("Sebastian")} {ShowCharacter("Player", "Right", "Normal")} I guess not. Maybe I'll try it one day.
{HideCharacter("Player")} {ShowCharacter("Sebastian", "Right", "Normal")} I'd invite you to play with Maddie, Gerald, and I, but I wouldn't want to make you spend your evenings hanging around nerds.
~SebastianTrust -= 10 
-> END

