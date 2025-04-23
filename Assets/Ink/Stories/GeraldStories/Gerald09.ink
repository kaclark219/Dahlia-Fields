INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Gerald", "Right", "Normal")} You know, {PlayerName}, you should be careful flashing that smile around town. Someone might get the wrong idea.
* [Oh? And what idea is that?] -> FlirtBack
* [Very funny, doctor.] -> BrushItOff

=== FlirtBack ===
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} And what idea would that be, Gerald?
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Happy")} That you're trying to charm the locals. Dangerous game.
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Happy")} Maybe I like danger.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Normal")} I'll keep that in mind. All I'm saying is that three of Charlie's last four bar stories were about you.
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} Oh, gosh. Maybe I DO need to be careful.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Happy")} Hah! I'm glad we're on the same page.
~GeraldTrust += 10
-> END

=== BrushItOff ===
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} Very funny, doctor. I'm not interested in you, save the lines for someone else.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Normal")} Oh, I'm not talking about me. It's just that there's a couple impressionable bachelors in the town you should be weary of leading on.
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} Who says I'm leading them on?
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Suspicious")} Don't get defensive. I'm just looking out for my friends.
~GeraldTrust -= 10
-> END
