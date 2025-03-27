// Holds Global Variables that will persist through all Stories
// must have INCLUDE Globals.ink at the top of other files

// Test variable
VAR Trust = 0

//******************************************************************//
// Town Suspicion 
VAR Suspicion = 0

// Trust for each NPC
VAR GeraldTrust = 0
VAR SebastianTrust = 0
VAR CharlieTrust = 0
VAR MeganTrust = 0
VAR AvaTrust = 0
VAR BruceTrust = 0
VAR MaddieTrust = 0
VAR PoppyTrust = 0
VAR LindaTrust = 0
VAR JeremyTrust = 0

// Player Name
VAR PlayerName = "Y/N"


// Global Functions
EXTERNAL ShowCharacter(characterName, position, mood) 
EXTERNAL HideCharacter(characterName)
EXTERNAL ChangeMood(characterName, mood)

EXTERNAL KillNPC(characterName)