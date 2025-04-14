using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using UnityEngine;

public class DaySystem : MonoBehaviour
{
    public int day;
    public int week;
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
    private GameObject floorDirections; 
    private GameObject startingNote;

    private InGameHUD inGameHud;

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

        floorDirections = GameObject.Find("WASDFloor"); 
        floorDirections.SetActive(true);

        startingNote = GameObject.Find("StartingNoteObj");
        startingNote.SetActive(true);

        inGameHud = GameObject.Find("InGameHUD").GetComponent<InGameHUD>();


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

        playerInteractor.Interact();
        yield return StartCoroutine(transition.FadeIn(1f));

        yield return videoPlayerManager.PlayTimeChange(time);

        npcManager.MoveNPCs(day, time);

        yield return StartCoroutine(transition.FadeOut(1f));
        playerInteractor.EndInteract();
    }

    private IEnumerator LoadDay(int day, bool startingGame)
    {
        Debug.Log("Loading day " + day);

        playerInteractor.Interact();
        musicManager.fadeOut();

        // Check if yesterday was a kill day before updating
        if (feedDays.Contains(day - 1) && !npcKilled && isFeedDay)  // Player loses, didn't feed plant
        {
            Debug.Log("Player Lost Game!");
            LoseGame();
            yield break;
        }
        isFeedDay = feedDays.Contains(day);
        npcKilled = false;
        
        yield return StartCoroutine(transition.FadeIn(2));

        if (playCutscenes)
        {
            Cutscene cutscene = CheckForCutscene();
            yield return StartCoroutine(videoPlayerManager.PlayNextDay(cutscene ? cutscene.clip : null, startingGame));
        }

        UpdateGameState(day);

        yield return StartCoroutine(transition.FadeOut(2));

        playerInteractor.EndInteract();
        musicManager.fadeIn();
    }

    private void UpdateGameState(int day)
    {
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

        //Update Day counter
        inGameHud.UpdateDay(day); 

        if(day == 1)
        {
            floorDirections.SetActive(true);
            startingNote.SetActive(true);
            startingNote.GetComponent<BoxCollider2D>().enabled = true;
        } else
        {
            floorDirections.SetActive(false);
            startingNote.SetActive(false);
        }
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
