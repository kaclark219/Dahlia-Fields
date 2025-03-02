using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public enum PlayerState {  Normal, Interacting }
    private const string nameKey = "PLAYER_NAME";
    private const string moneyKey = "MONEY";
    private const int startEnergy = 50;
    private const int startMoney = 0;

    [SerializeField] private DayNightCycle dayNightCycle;
    [SerializeField] private DaySystem daySystem;
    [SerializeField] public InGameHUD inGameHud;

    public PlayerState state = PlayerState.Normal;

    private string playerName = "";
    private int money;
    public int energy;

    private int timeOfDay;  // 1: morning, 2: afternoon, 3:evening

    private void Awake()
    {
        daySystem = GameObject.Find("GameManager").GetComponent<DaySystem>();
        dayNightCycle = GameObject.Find("GameManager").GetComponent<DayNightCycle>();
        inGameHud = GameObject.Find("InGameHUD").GetComponent<InGameHUD>(); 
    }
    public int GetMoney()
    {
        return money;
    }
    public void ModifyMoney(int amount)
    {
        money += amount;
        inGameHud.UpdateMoney(money); //Update UI
    }
    
    public int GetEnergy()
    {
        return energy;
    }
    public void ResetEnergy()
    {
        energy = startEnergy;
        timeOfDay = 1;
        dayNightCycle.ResetLight();
        inGameHud.UpdateEnergy(energy); //Update UI
    }
    public void ModifyEnergy(int amount)
    {
        energy += amount;
        dayNightCycle.UpdateLight(energy);

        if (energy <= 36 && energy > 15 && timeOfDay != 2)  // Change to Afternoon
        {
            timeOfDay = 2;
            daySystem.ChangeTimeOfDay(timeOfDay);
        }
        else if (energy <= 15 && energy > 0 && timeOfDay != 3)  // Change to Evening
        {
            timeOfDay = 3;
            daySystem.ChangeTimeOfDay(timeOfDay);
        }
        if (energy <= 0)    // change to Next Day
        {
            daySystem.NextDay();
            ResetEnergy();
        }

        inGameHud.UpdateEnergy(energy); //Update UI

        Debug.Log("Player Energy changed by " + amount + ", new energy is " + energy);
    }

    public string GetName()
    {
        return playerName;
    }
    public void SetName(string name)
    {
        playerName = name;
        GameObject.Find("InkManager").GetComponent<DialogueVariables>().ChangeVariable("PlayerName", playerName);
    }   

    public void SaveData()
    {
        PlayerPrefs.SetString(nameKey, playerName); 
        PlayerPrefs.SetInt(moneyKey, money);
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey(nameKey))
        {
            SetName(PlayerPrefs.GetString(nameKey));
        }
        else
        {
            SetName("Y/N");
        }

        if (PlayerPrefs.HasKey(moneyKey))
        {
            money = PlayerPrefs.GetInt(moneyKey);
        }
        else
        {
            money = startMoney;
        }
        ResetEnergy();
    }

    public void ResetData()
    {
        SetName("Y/N");
        money = startMoney;
        ResetEnergy();
    }

}
