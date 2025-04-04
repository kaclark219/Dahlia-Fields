using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class FlowerboxManager : MonoBehaviour
{
    [SerializeField] private GameObject FlowerBoxUI;
    [SerializeField] TextMeshProUGUI[] counts;
    [SerializeField] private List<FlowerBox> FlowerBoxes; 
    public FlowerBox ActiveBox;

    private InventoryManager inventoryManager;
    private PlayerInteractor plint;

    [SerializeField] private int numActiveBoxes = 2;
    private const string activeBoxesKey = "Active_Boxes";

    void Awake()
    {
        plint = GameObject.FindWithTag("Player").GetComponent<PlayerInteractor>();
        inventoryManager = GameObject.Find("Inventory").GetComponent<InventoryManager>();
    }

    public void OpenUI()
    {
        int i=0;
        foreach(var item in inventoryManager.inventory){
            counts[i].text = item.Value.seedStock.ToString();
            i++;
        }
        FlowerBoxUI.SetActive(true);
    }

    public void CloseUI()
    {
        FlowerBoxUI.SetActive(false);
        plint.EndInteract();
        ActiveBox = null;
    }

    public void NextDayBoxes()
    {
        UpdateVisibleBoxes();

        foreach (var box in FlowerBoxes)
        {
            if (box.transform.parent.gameObject.activeSelf)
            {
                box.NextDayBox();
            }
        }
    }

    public void Plant(string plantName){
        if(ActiveBox != null){
            Flowers flower;
            Enum.TryParse(plantName, out flower);
            ActiveBox.Plant(flower);
        }
    }

    public bool AddBox()
    {
        if( numActiveBoxes == FlowerBoxes.Count)
        {
            return false;
        }
        numActiveBoxes++;
        return true;
    }

    private void UpdateVisibleBoxes()
    {
        int i = 0;
        foreach (FlowerBox box in FlowerBoxes)
        {
            if (i < numActiveBoxes)
            {
                box.transform.parent.gameObject.SetActive(true);
            }
            else
            {
                box.transform.parent.gameObject.SetActive(false);
            }
            i++;
        }
    }

    #region SAVE_SYSTEM
    public void SaveData()
    {
        foreach (FlowerBox box in FlowerBoxes)
        {
            if (box.transform.parent.gameObject.activeSelf)
            {
                box.SaveData();
            }
        }

        PlayerPrefs.SetInt(activeBoxesKey, numActiveBoxes);
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey(activeBoxesKey))
        {
            numActiveBoxes = PlayerPrefs.GetInt(activeBoxesKey);
        }
        else
        {
            numActiveBoxes = 2;
        }
        UpdateVisibleBoxes();

        foreach (FlowerBox box in FlowerBoxes)
        {
            if (box.transform.parent.gameObject.activeSelf) 
            {
                box.LoadData();
            }
        }
    }

    public void ResetData()
    {
        foreach (FlowerBox box in FlowerBoxes)
        {
            if (box.transform.parent.gameObject.activeSelf)
            {
                box.ResetData();
            }
        }
        numActiveBoxes = 2;
        UpdateVisibleBoxes();
    }

    #endregion
}
