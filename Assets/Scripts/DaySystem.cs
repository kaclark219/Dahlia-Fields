using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using UnityEngine;

public class DaySystem : MonoBehaviour
{
    public int day;
    public int week;
    [SerializeField] GameObject MorningToAfternoon;
    [SerializeField] GameObject AfternoonToEvening;

    [Space]
    public bool playCutscenes = true;   // for testing sake
    public List<Cutscene> cutsceneList = new List<Cutscene>();
    [Space]
    public List<int> feedDays = new List<int> { 8, 14, 19, 23 };
    public bool isFeedDay = false;
    public bool npcKilled = false;

    private const string dayKey = "DAY";

    private NPCManager npcManager;
    private PlayerMovement playerMovement;
    private PlayerData playerData;
    private PlayerInteractor playerInteractor;
    private FlowerboxManager flowerManager;
    private SeedStore seedStore;
    private VideoPlayerManager videoPlayerManager;
    private GlobalStateManager globalStateManager;
    private FadeInFadeOut transition;
    private MusicManager musicManager;

    private void Awake()
    {
        npcManager = GameObject.Find("NPCManager").GetComponent<NPCManager>();
        flowerManager = GameObject.Find("FlowerboxManager").GetComponent<FlowerboxManager>();
        seedStore = GameObject.Find("SeedStore").GetComponent<SeedStore>();
        GameObject player = GameObject.Find("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        playerData = player.GetComponent<PlayerData>();
        playerInteractor = player.GetComponent<PlayerInteractor>();
        videoPlayerManager = FindFirstObjectByType<VideoPlayerManager>();
        globalStateManager = GetComponent<GlobalStateManager>();
        transition = FindFirstObjectByType<FadeInFadeOut>();
        musicManager = FindFirstObjectByType<MusicManager>();
    }

    private void Start()
    {
        MorningToAfternoon.SetActive(false);
        AfternoonToEvening.SetActive(false);
    }
    public void NextDay()
    {
        day++;
        week = (day / 3) + 1;

        StartCoroutine(LoadDay(day, true));

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

    public IEnumerator ChangeTimeOfDay(int time)
    {
        yield return new WaitUntil(() => playerInteractor.canInteract); // Wait until player is done interacting

        transition.FadeIn();
        playerInteractor.Interact();

        while (transition.coroutine != null) { yield return null; }
        
        GameObject UI = time == 2 ? MorningToAfternoon : AfternoonToEvening;
        UI.SetActive(true);
        yield return new WaitForSeconds(.75f);
        UI.SetActive(false);

        npcManager.MoveNPCs(day, time);

        transition.FadeOut();
        playerInteractor.EndInteract();
    }

    private IEnumerator LoadDay(int day, bool startingGame)
    {
        Debug.Log("Loading day " + day);

        

        playerInteractor.Interact();

        Cutscene cutscene = CheckForCutscene();

        yield return StartCoroutine(videoPlayerManager.PlayNextDay(cutscene ? cutscene.clip : null, startingGame));   

        UpdateGameState(day);

        playerInteractor.EndInteract();
    }

    private void UpdateGameState(int day)
    {
        // Check if yesterday was a kill day before updating
        if (feedDays.Contains(day - 1) && !npcKilled && isFeedDay)  // Player loses, didn't feed plant
        {
            Debug.Log("Player Lost Game!");
            LoseGame();
            return;
        }
        isFeedDay = feedDays.Contains(day);
        npcKilled = false;

        //Restart music
        musicManager.fadeIn();

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
        playerInteractor.Interact();
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

        StartCoroutine(LoadDay(day, false));
    }
    public void ResetData()
    {
        day = 1;
        week = 1;
        StartCoroutine(LoadDay(day, false));
        isFeedDay = false;
    }

    #endregion
}
