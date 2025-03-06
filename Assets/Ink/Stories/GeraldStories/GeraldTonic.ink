INCLUDE ../Globals.ink

EXTERNAL BuyTonic()

VAR BoughtTonic = 0

-> start

=== start ===
{ShowCharacter("Gerald", "Right", "Happy")} Hello {PlayerName}, welcome to the clinic!
{ChangeMood("Gerald", "Normal")} How can I help you?
* [I'd like to buy an Energy Tonic.] -> Tonic
* [Just came by to say hello.] -> JustHello

=== Tonic===
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} I'd like to buy an energy tonic today.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Happy")} Sounds good! An Energy Tonic will cost your soul and replenish some energy.
* [I'll take one.] -> Check
* [Nevermind.] -> NoTonic


=== Check ===
{BuyTonic()}
{ BoughtTonic==1: -> YesTonic }
{ BoughtTonic==0: -> Broke }

=== YesTonic ===
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Happy")} Thank you for your business.
-> END

=== Broke ===
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Happy")} Looks like you don't have enough money for an energy tonic. Come back again when you aren't broke. 
-> END

=== NoTonic ===
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Happy")} That's all, goodbye!
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Happy")} Have a nice day! Come again soon.
-> END

=== JustHello ===
{HideCharacter("Gerald")} {ShowCharacter("Player", "Right", "Normal")} I just came by to say hello.
{HideCharacter("Player")} {ShowCharacter("Gerald", "Right", "Happy")} Have a nice day {PlayerName}!
-> END

