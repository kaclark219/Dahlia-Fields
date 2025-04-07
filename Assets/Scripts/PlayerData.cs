using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayerData : MonoBehaviour
{
    private const string nameKey = "PLAYER_NAME";
    private const string moneyKey = "MONEY";
    private const int startEnergy = 35;
    private const int startMoney = 150;

    [SerializeField] private DayNightCycle dayNightCycle;
    [SerializeField] private DaySystem daySystem;
    [SerializeField] public InGameHUD inGameHud;

    private string playerName = "";
    public int money;
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
    public bool ModifyMoney(int amount)
    {
        if ((money + amount) >= 0)
        {
            money += amount;
            inGameHud.UpdateMoney(money); //Update UI
            return true;
        }
        else // not enough money
        {
            return false;
        }
    }

    private void SetMoney(int amount)
    {
        money = amount;
        inGameHud.UpdateMoney(money);
    }
    
    // For testing
    public void IncreaseMoney()
    {
        money += 50;
        inGameHud.UpdateMoney(money);
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
        if (energy > 50)
        {
            energy = 50;
        }
        inGameHud.UpdateEnergy(energy); //Update UI
        Debug.Log("Player Energy changed by " + amount + ", new energy is " + energy);


        if (amount < 0) // Increasing energy should not affect dayNightCycle
        {
            dayNightCycle.UpdateLight(energy);

            if (energy <= 24 && energy > 12 && timeOfDay != 2)  // Change to Afternoon
            {
                timeOfDay = 2;
                StartCoroutine(daySystem.ChangeTimeOfDay(timeOfDay));
                Debug.Log("Change Time of Day to Afternoon");
            }
            else if (energy <= 12 && energy > 0 && timeOfDay != 3)  // Change to Evening
            {
                timeOfDay = 3;
                StartCoroutine(daySystem.ChangeTimeOfDay(timeOfDay));
                Debug.Log("Change Time of Day to Evening");
            }
        }
    }

    public bool CheckEnergy(int amount)
    {
        return energy >= amount;
    }

    public string GetName()
    {
        return playerName;
    }
    public void SetName(string name)
    {
        Debug.Log("Set Name: " + name);
        playerName = name;
        GameObject.Find("InkManager").GetComponent<DialogueVariables>().ChangeVariable("PlayerName", playerName);
    }

    #region SAVE_SYSTEM
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
            SetMoney(PlayerPrefs.GetInt(moneyKey));
        }
        else
        {
            SetMoney(startMoney);
        }
        ResetEnergy();
    }

    public void ResetData()
    {
        SetName("Y/N");
        SetMoney(startMoney);
        ResetEnergy();
    }
    #endregion
}
