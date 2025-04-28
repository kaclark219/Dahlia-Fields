INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Linda", "Right", "Normal")} Don't tell anyone, but sometimes I miss the man who lived in your house before you.
* [What, am I not good enough?] -> TeaseLinda
* [You were close?] -> AskAboutPast

=== AskAboutPast ===
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} You two were close?
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Normal")} The man who lived there before you was the old mayor, and he was a good mentor. Tough, fair, and he didn't care about being liked. He just cared about doing what was right.
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} Sounds like someone I know.
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Happy")} Hah. I'll take that as a compliment.
~LindaTrust += 10
-> END

=== TeaseLinda ===
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Happy")} What, am I not good enough as a replacement?
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Suspicious")} The man who lived there before you was the old mayor, he was around for a lot of my life.
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} Oh. I'm sorry, I didn't know.
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Suspicious")} No, you didn't.
~LindaTrust -= 10
-> END
