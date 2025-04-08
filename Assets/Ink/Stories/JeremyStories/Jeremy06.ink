INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Jeremy", "Right", "Normal")} Have you met Sebastian yet?
* [Yeah, why?] -> CuriousSebastian
* [Not yet.] -> HaventMet

=== CuriousSebastian ===
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} Yeah, why?
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Normal")} He's got it out for me. Won't admit it, but I can tell. His energy is just off.
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} What'd you do?
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Normal")} Existed. Apparently, that's enough.
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} Sounds rough. Maybe I can talk to him about it!
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Happy")} That might not be too bad of an idea. But I think it's kind of funny. One day I'll make him crack a smile.
~JeremyTrust += 10
-> END

=== HaventMet ===
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} Not yet, I just haven't had the chance.
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Normal")} When you do, tell him I said hi. No, actually, don't. He might not like you if he knows you know me.
{HideCharacter("Jeremy")} {ShowCharacter("Player", "Right", "Normal")} That bad, huh?
{HideCharacter("Player")} {ShowCharacter("Jeremy", "Right", "Normal")} Oh, it's hilarious. He glares at me like I stole his doorknob or something. Even though that totally wasn't me!
~JeremyTrust += 5
-> END