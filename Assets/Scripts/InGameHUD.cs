using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameHUD : MonoBehaviour
{
    [SerializeField] public GameObject energyBar;
    [SerializeField] public GameObject susBar;
    [SerializeField] public TextMeshProUGUI moneyUI; 

    public void UpdateEnergy(int energy)
    {
        float scale = (energy * 2.0f) / 100.0f;
        Debug.Log(scale);
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
}
