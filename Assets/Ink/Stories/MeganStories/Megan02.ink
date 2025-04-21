INCLUDE ../Globals.ink

-> start

=== start ===
{ShowCharacter("Megan", "Right", "Normal")} If you were to get some sort of welcome goodies, would you prefer cookies or cupcakes>
* [Cookies.] -> Cookies
* [Cupcakes.] -> Cupcakes

=== Cookies ===  
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} I'm more of a cookie person, I don't really like frosting.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Normal")} You don't like frosting? At all? Well I make a really good homemade buttercream that could change your min—
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} No really, I don't like frosting. Thank you anyway, though.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Suspicious")} ... you could at least try it, especially when I'm trying to be nice. It's fine. Just keep an eye out in front of your door for sweets.
~MeganTrust -= 10
-> END

=== Cupcakes ===  
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Normal")} I'm more into cupcakes. A dessert just isn't the same without frosting.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Happy")} Ah, perfect! I make a mean buttercream frosting, and I can't wait for you to try it. Maybe with a lemon cake?
{HideCharacter("Megan")} {ShowCharacter("Player", "Right", "Happy")} That sounds delicious! Thank you so much for being so kind, I really appreciate it.
{HideCharacter("Player")} {ShowCharacter("Megan", "Right", "Normal")} Well, keep an eye out in front of your door for sweets!
~MeganTrust += 10
-> END