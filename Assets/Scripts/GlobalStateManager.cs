using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalStateManager : MonoBehaviour
{
    public string menuSceneName = "Prototype_Menu";
    public GameObject LoseUI;
    public GameObject WinUI;
    [Space]
    [SerializeField] private DialogueVariables dialogueVariables;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private DaySystem daySystem;
    [SerializeField] private NPCManager npcManager;
    [SerializeField] private FlowerboxManager flowerboxManager;
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private RequestBoard requestBoard;
    [SerializeField] private SeedStore seedStore;

    private const string newGameKey = "NEW_GAME";   // used to tell GlobalStateManager on load if its a new game 
    private const string nameKey = "PLAYER_NAME";

    private void Awake()
    {
        dialogueVariables = dialogueVariables ? dialogueVariables: FindObjectOfType<DialogueVariables>(); ;
        playerData = playerData ? playerData : FindObjectOfType<PlayerData>(); ;  
        daySystem = daySystem ? daySystem : GetComponent<DaySystem>();  
        npcManager = npcManager ? npcManager : FindObjectOfType<NPCManager>(); ;  
        flowerboxManager = flowerboxManager ? flowerboxManager : FindObjectOfType<FlowerboxManager>();
        inventoryManager = inventoryManager ? inventoryManager : FindObjectOfType<InventoryManager>(); ;
        requestBoard = requestBoard ? requestBoard : FindObjectOfType<RequestBoard>();
        seedStore = seedStore ? seedStore : FindFirstObjectByType<SeedStore>();
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
            ResetAllData();
        }
        else
        {
            LoadAllData();
        }
        PlayerPrefs.DeleteKey(newGameKey);

        WinUI.SetActive(false);
        LoseUI.SetActive(false);
    }

    public void SaveAllData()
    {
        //Debug.Log("Saving Data...");
        dialogueVariables.SaveData();
        playerData.SaveData();
        daySystem.SaveData();
        npcManager.SaveData();
        flowerboxManager.SaveData();
        requestBoard.SaveData();
        seedStore.SaveData();
        inventoryManager.SaveData();
    }

    public void LoadAllData()
    {
        //Debug.Log("Loading Data...");
        dialogueVariables.LoadData();
        playerData.LoadData();
        daySystem.LoadData();
        npcManager.LoadData();
        flowerboxManager.LoadData();
        inventoryManager.LoadData();
        requestBoard.LoadData();
        seedStore.LoadData();
    }

    public void ResetAllData()
    {
        //Debug.Log("Resetting Data Data...");
        string name = PlayerPrefs.GetString(nameKey);

        dialogueVariables.ResetData();
        playerData.ResetData();
        daySystem.ResetData();
        npcManager.ResetData();
        flowerboxManager.ResetData();
        inventoryManager.ResetData();
        requestBoard.ResetData();
        seedStore.ResetData();

        playerData.SetName(name);
    }

    public void ShowLoseScreen()
    {
        ResetAllData();
        LoseUI.SetActive (true);
    }

    public void ShowWinScreen()
    {
        ResetAllData();
        WinUI.SetActive (true);
    }

    public void PlayAgain()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(menuSceneName);
    }
}
