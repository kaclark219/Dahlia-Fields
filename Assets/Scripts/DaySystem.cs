using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using UnityEngine;

public class DaySystem : MonoBehaviour
{
    public int day;
    public int week;

    private const string dayKey = "DAY";

    [SerializeField] private NPCManager npcManager;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerData playerData;
    [SerializeField] public  FlowerBox box1;

    private void Awake()
    {
        npcManager = GameObject.Find("NPCManager").GetComponent<NPCManager>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerData = GameObject.Find("Player").GetComponent<PlayerData>();
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
        // Reset player location
        playerMovement.ResetLocation();

        // Reset player energy
        playerData.ResetEnergy();

        // move NPCS
        npcManager.MoveNPCs(day, 1);

        // reset NPC daily interaction
        npcManager.ResetDailyInteraction();

        // update Flowerboxes
        StartCoroutine(box1.NextDayBox());
    }

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
}
