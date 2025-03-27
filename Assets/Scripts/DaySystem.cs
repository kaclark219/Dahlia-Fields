using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using UnityEngine;

public class DaySystem : MonoBehaviour
{
    public int day;
    public int week;
    public List<Cutscene> cutsceneList = new List<Cutscene>();
    [Space]
    public List<int> feedDays = new List<int> { 8, 14, 19, 23 };
    public bool isFeedDay = false;
    public bool npcKilled = false;

    private const string dayKey = "DAY";

    private NPCManager npcManager;
    private PlayerMovement playerMovement;
    private PlayerData playerData;
    private FlowerboxManager flowerManager;
    private SeedStore seedStore;
    private VideoPlayerManager videoPlayerManager;
    private GlobalStateManager globalStateManager;

    private void Awake()
    {
        npcManager = GameObject.Find("NPCManager").GetComponent<NPCManager>();
        flowerManager = GameObject.Find("FlowerboxManager").GetComponent<FlowerboxManager>();
        seedStore = GameObject.Find("SeedStore").GetComponent<SeedStore>();
        GameObject player = GameObject.Find("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        playerData = player.GetComponent<PlayerData>();
        videoPlayerManager = player.GetComponentInChildren<VideoPlayerManager>();
        globalStateManager = GetComponent<GlobalStateManager>();
    }
    public void NextDay()
    {
       // Load next day data
        day++;
        week = (day / 3) + 1;
        LoadDay(day);

        // Save all progress at the start of the next day
        globalStateManager.SaveAllData();
    }

    public int GetDay()
    {
        return day;
    }

    public int GetWeek()
    {
        return week;
    }

    public void ChangeTimeOfDay(int time)
    {
        // move NPCS
        npcManager.MoveNPCs(day, time);
    }

    private void LoadDay(int day)
    {
        Debug.Log("Loading day " + day);

        // Check if yesterday was a kill day before updating
        if (feedDays.Contains(day - 1) && !npcKilled && isFeedDay)  // Player loses, didn't feed plant
        {
            Debug.Log("Player Lost Game!");
            LoseGame();
            return;
        }
        isFeedDay = feedDays.Contains(day);
        npcKilled = false;

        // Check for cutscene
        Cutscene cutscene = CheckForCutscene();
        if (cutscene != null)
        {
            // Load cutscene
            Debug.Log("Loading cutscene: " + cutscene.clip.name);
            videoPlayerManager.StartVideo(cutscene.clip);
        }

        // Reset player location
        playerMovement.ResetLocation();

        // Reset player energy
        playerData.ResetEnergy();

        // Update NPCS (move them and check if kill day
        npcManager.NextDay(day, isFeedDay);

        // reset NPC daily interaction
        npcManager.ResetDailyInteraction();

        // update Flowerboxes
        flowerManager.NextDayBoxes();

        // update inventory with any pending orders
        seedStore.Delivery();  

    }

    private Cutscene CheckForCutscene()
    {
        foreach (Cutscene cutscene in cutsceneList)
        {
            if (cutscene.day == day)
            {
                return cutscene;
            }
        }
        return null;
    }

    private void LoseGame()
    {
        // Disable player movement and interactions
        playerMovement.enabled = false;
        GameObject.Find("Player").GetComponent<PlayerInteractor>().enabled = false;

        // Display lose ui
        globalStateManager.ShowLoseScreen();
    }

    #region SAVE_SYSTEM
    public void SaveData()
    {
        PlayerPrefs.SetInt(dayKey, day);
    }
    public void LoadData()
    {
        if (PlayerPrefs.HasKey(dayKey))
        {
            day = PlayerPrefs.GetInt(dayKey);
        }
        else
        {
            day = 1;
        }

        week = (day / 3) + 1;

        LoadDay(day);
    }
    public void ResetData()
    {
        day = 1;
        week = 1;
        LoadDay(day);
        isFeedDay = false;
    }

    #endregion
}
