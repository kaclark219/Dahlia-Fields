INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Linda", "Right", "Normal")} You picked an interesting time to move in. Town meetings are coming up, and everyone suddenly thinks they know how to do my job better than me.
* [Complaints?] -> Complaints
* [Sounds exhausting.] -> Sympathize

=== Complaints ===
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} What kind of things do people complain about?
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Normal")} Oh, you know. The usual nonsense. Someone thinks the park is too small. Someone else thinks it's too big. Permit expansion. Poppy wants a new liquor license... Nothing that really effects you, though.
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} I was just curious. It sounds like a lot to juggle, though.
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Normal")} It is. And no matter what I decide, someone will be furious about it. But that's the job.
~LindaTrust -= 10
-> END

=== Sympathize ===
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Normal")} Running a town sounds exhausting.  
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Normal")} You have no idea. It's endless paperwork, public complaints, and somehow I'm also expected to know when Maddie's deliveries are running late. I swear, sometimes people forget I'm not their babysitter.  
{HideCharacter("Linda")} {ShowCharacter("Player", "Right", "Happy")} That sounds frustrating, I'm sorry.  
{HideCharacter("Player")} {ShowCharacter("Linda", "Right", "Happy")} It is, but someone has to keep this place running. May as well be me.
~LindaTrust += 10
-> END