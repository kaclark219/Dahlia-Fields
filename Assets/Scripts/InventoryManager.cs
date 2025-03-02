using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public string itemName;
    public float seedPrice;
    public float flowerValue;
    public string description;
    public int seedStock;
    public int flowerStock;
    public int daysToGrow;
    public Sprite planted;
    public Sprite growing;
    public Sprite harvest;

    public InventoryItem(string name, float cost, float value, string desc, int amtS, int amtF, int days, 
        Sprite p, Sprite g, Sprite h)
    {
        itemName = name;
        seedPrice = cost;
        flowerValue = value;
        description = desc;
        seedStock = amtS;
        flowerStock = amtF;
        daysToGrow = days;
        planted = p;
        growing = g;
        harvest = h;
    }
}

public class InventoryManager : MonoBehaviour
{
    [SerializeField] public GameObject dandelionPlanted;
    [SerializeField] public GameObject dandelionGrowing;
    [SerializeField] public GameObject dandelionHarvest;

    [SerializeField] public GameObject daisyPlanted;
    [SerializeField] public GameObject daisyGrowing;
    [SerializeField] public GameObject daisyHarvest;

    public Dictionary<string, InventoryItem> inventory = new Dictionary<string, InventoryItem>();

    // Start is called before the first frame update
    void Start()
    {
        inventory.Add("Dandelion", new InventoryItem("Dandelion", 12.0f, 5.0f, "Ava favorite", 10, 0, 2,
            dandelionPlanted.GetComponent<SpriteRenderer>().sprite, dandelionGrowing.GetComponent<SpriteRenderer>().sprite, dandelionHarvest.GetComponent<SpriteRenderer>().sprite));

        inventory.Add("Daisy", new InventoryItem("Daisy", 24.0f, 10.0f, "Bruce favorite", 5, 0, 3, 
            daisyPlanted.GetComponent<SpriteRenderer>().sprite, daisyGrowing.GetComponent<SpriteRenderer>().sprite, daisyHarvest.GetComponent<SpriteRenderer>().sprite));

    }

    //Use to get attributes of inventory item, but do not modifiy attributes this returns (read only) 
    public InventoryItem FindItem(string itemName)
    {
        if (inventory.ContainsKey(itemName))
            return inventory[itemName];
        return null;
    }

    //Use to edit inventory
    public int GetSeedStock(string itemName)
    {
        if (inventory.ContainsKey(itemName))
            return inventory[itemName].seedStock;
        return 0;
    }

    public void SetSeedStock(string itemName, int newStock)
    {
        if (inventory.ContainsKey(itemName))
            inventory[itemName].seedStock += newStock;
    }

    public int GetFlowerStock(string itemName)
    {
        if (inventory.ContainsKey(itemName))
            return inventory[itemName].flowerStock;
        return 0;
    }

    public void SetFlowerStock(string itemName, int newStock)
    {
        if (inventory.ContainsKey(itemName))
            inventory[itemName].flowerStock += newStock;
    }
}

