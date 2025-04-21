using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameHUD : MonoBehaviour
{
    [SerializeField] public GameObject energyBar;
    [SerializeField] public GameObject susBar;
    [SerializeField] public TextMeshProUGUI moneyUI;
    [SerializeField] public TextMeshProUGUI dayUI;

    public void UpdateEnergy(int energy)
    {
        float minScale = 0f;
        float maxScale = 1.0f;

        float energyPercentage = (40.0f - energy) / 40.0f;

        float scale = minScale + (energyPercentage * (maxScale - minScale));

        energyBar.transform.localScale = new Vector3(scale, 1f, 1f);
    }

    public void UpdateSus(int sus)
    {
        float scale = sus / 100.0f;
        susBar.transform.localScale = new Vector3(1f, scale, 1f);
    }

    public void UpdateMoney(int money)
    {
        moneyUI.text = money.ToString();
    }

    public void UpdateDay(int day) 
    { 
        dayUI.text = day.ToString();
    }
}
