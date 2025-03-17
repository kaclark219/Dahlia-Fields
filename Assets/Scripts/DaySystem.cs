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

    private const string dayKey = "DAY";

    private NPCManager npcManager;
    private PlayerMovement playerMovement;
    private PlayerData playerData;
    private FlowerboxManager flowerManager;
    private VideoPlayerManager videoPlayerManager;

    private void Awake()
    {
        npcManager = GameObject.Find("NPCManager").GetComponent<NPCManager>();
        flowerManager = GameObject.Find("FlowerboxManager").GetComponent<FlowerboxManager>();
        GameObject player = GameObject.Find("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        playerData = player.GetComponent<PlayerData>();
        videoPlayerManager = player.GetComponentInChildren<VideoPlayerManager>();
    }
    public void NextDay()
    {
        day++;
        week = (day / 3) + 1;
        LoadDay(day);
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

        // move NPCS
        npcManager.MoveNPCs(day, 1);

        // reset NPC daily interaction
        npcManager.ResetDailyInteraction();

        // update Flowerboxes
        //StartCoroutine(flowerManager.NextDayBox());
        flowerManager.NextDayBoxes();
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
    }

    #endregion
}
