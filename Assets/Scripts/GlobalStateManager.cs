using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStateManager : MonoBehaviour
{
    [SerializeField] private DialogueVariables dialogueVariables;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private DaySystem daySystem;
    [SerializeField] private NPCManager npcManager;

    private const string newGameKey = "NEW_GAME";   // used to tell GlobalStateManager on load if its a new game 
    private const string nameKey = "PLAYER_NAME";

    private void Awake()
    {
        dialogueVariables = GameObject.Find("InkManager").GetComponent<DialogueVariables>();
        playerData = GameObject.Find("Player").GetComponent<PlayerData>();  
        daySystem = GetComponent<DaySystem>();  
        npcManager = GameObject.Find("NPCManager").GetComponent<NPCManager>();  
    }

    private void Start()
    {
        int newGame = 0;
        if (PlayerPrefs.HasKey(newGameKey))
        {
            newGame = PlayerPrefs.GetInt(newGameKey);
        }

        if (newGame == 1)   // reset all data, create new game
        {
            string name = PlayerPrefs.GetString(nameKey);
            ResetAllData();
            playerData.SetName(name);
        }
        else
        {
            LoadAllData();
        }
        PlayerPrefs.DeleteKey(newGameKey);
    }

    public void SaveAllData()
    {
        Debug.Log("Saving Data...");
        dialogueVariables.SaveData();
        playerData.SaveData();
        daySystem.SaveData();
        npcManager.SaveData();
    }

    public void LoadAllData()
    {
        Debug.Log("Loading Data...");
        dialogueVariables.LoadData();
        playerData.LoadData();
        daySystem.LoadData();
        npcManager.LoadData();
    }

    public void ResetAllData()
    {
        Debug.Log("Resetting Data Data...");
        dialogueVariables.ResetData();
        playerData.ResetData();
        daySystem.ResetData();
        npcManager.ResetData();

        PlayerPrefs.DeleteAll();
    }
    private void OnApplicationQuit()
    {
        SaveAllData();
    }
}
