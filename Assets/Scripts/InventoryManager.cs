using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Dictionary<Flowers, InventoryItem> inventory = new Dictionary<Flowers, InventoryItem>();

    private void Awake()
    {
        InventoryItem[] list = Resources.LoadAll<InventoryItem>("InventoryItems/");
        foreach (var item in list)
        {
            inventory.Add(item.itemName, item);
        }
    }

    //Use to get attributes of inventory item, but do not modifiy attributes this returns (read only) 
    public InventoryItem FindItem(Flowers itemName)
    {
        if (inventory.ContainsKey(itemName))
            return inventory[itemName];
        return null;
    }

    //Use to edit inventory
    public int GetSeedStock(Flowers itemName)
    {
        if (inventory.ContainsKey(itemName))
            return inventory[itemName].seedStock;
        return 0;
    }

    public void SetSeedStock(Flowers itemName, int newStock)
    {
        if (inventory.ContainsKey(itemName))
            inventory[itemName  ].seedStock += newStock;
    }

    public int GetFlowerStock(Flowers itemName)
    {
        if (inventory.ContainsKey(itemName))
            return inventory[itemName].flowerStock;
        return 0;
    }

    public void SetFlowerStock(Flowers itemName, int newStock)
    {
        if (inventory.ContainsKey(itemName))
            inventory[itemName].flowerStock += newStock;
    }


    #region SAVE_SYSTEM
    public void SaveData()
    {
        foreach (KeyValuePair<Flowers, InventoryItem> item in inventory)
        {
            PlayerPrefs.SetInt(item.Key.ToString() + "_Seed", item.Value.seedStock);
            PlayerPrefs.SetInt(item.Key.ToString() + "_Flower", item.Value.flowerStock);
        }
    }

    public void LoadData()
    {
        foreach (KeyValuePair<Flowers, InventoryItem> item in inventory)
        {
            if (PlayerPrefs.HasKey(item.Key.ToString() + "_Seed")) {
                item.Value.seedStock = PlayerPrefs.GetInt(item.Key.ToString() + "_Seed", item.Value.seedStock);
                item.Value.flowerStock = PlayerPrefs.GetInt(item.Key.ToString() + "_Flower", item.Value.flowerStock);
            }
            else
            {
                item.Value.seedStock = 0;
                item.Value.flowerStock = 0;
            }
        }
    }

    public void ResetData()
    {
        foreach (KeyValuePair<Flowers, InventoryItem> item in inventory)
        {
            item.Value.seedStock = 10;
            item.Value.flowerStock = 0;
        }
    }


    #endregion
}

