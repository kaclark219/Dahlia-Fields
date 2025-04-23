INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Charlie", "Right", "Normal")} Hey uh... weird favor. Can I borrow some soap? I might've spilled...something... in my pocket.
{ShowCharacter("Player", "Right", "Suspicious")} Define "something."
{ShowCharacter("Charlie", "Right", "Normal")} Let's just say the garbage juice won this round.

* [Fine, but you owe me.] -> Loan
* [You need to handle it yourself.] -> Refuse

=== Loan ===
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} I'll lend you some, but you're buying me a drink after this.
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Happy")} Deal! You're a lifesaver.
~CharlieTrust += 10
-> END

=== Refuse ===
{HideCharacter("Charlie")} {ShowCharacter("Player", "Right", "Normal")} You're an adult, Charlie. You'll figure it out.
{HideCharacter("Player")} {ShowCharacter("Charlie", "Right", "Suspicious")} That's harsh! I can't believe you're going to make me wait for a mail delivery with garbage juices in my pocket, {PlayerName}.
~CharlieTrust -= 10
-> END
