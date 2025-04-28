INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Bruce", "Right", "Normal")} I'm in the mood to sit outside and listen to the forest. No talking. Just quiet.
* [Sounds boring.] -> DislikesQuiet
* [Sounds peaceful.] -> EnjoysQuiet

=== EnjoysQuiet ===
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} That sounds nice, maybe I'll join you. I like the quiet.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Normal")} Hah. Didn't take you for someone who appreciated that, with how much you go around town yapping.
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} There's value in silence. Sometimes you just need to think.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Happy")} You're alright, kid. I'd be happy for you to join me.
~BruceTrust += 10
-> END

=== DislikesQuiet ===
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} Sounds boring, I'd prefer to spend tonight at the pub.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Suspicious")} Figures. Most people can't handle their own thoughts.
{HideCharacter("Bruce")} {ShowCharacter("Player", "Right", "Normal")} I just like energy around me.
{HideCharacter("Player")} {ShowCharacter("Bruce", "Right", "Normal")} We have a different idea of where energy comes from, then.
~BruceTrust -= 10
-> END
