using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public string itemName;
    public float seedPrice;
    public string description;
    public int seedStock;
    public int flowerStock;
    public int daysToGrow;
    public Sprite growing;
    public Sprite harvest;

    public InventoryItem(string name, float cost, string desc, int amtS, int amtF, int days, Sprite g, Sprite h)
    {
        itemName = name;
        seedPrice = cost;
        description = desc;
        seedStock = amtS;
        flowerStock = amtF;
        daysToGrow = days;
        growing = g;
        harvest = h;
    }
}

public class InventoryManager : MonoBehaviour
{
    [SerializeField] public Sprite dandelionGrowing;
    [SerializeField] public Sprite dandelionHarvest;

    [SerializeField] public Sprite daisyGrowing;
    [SerializeField] public Sprite daisyHarvest;

    [SerializeField] public Sprite poppyGrowing;
    [SerializeField] public Sprite poppyHarvest;

    [SerializeField] public Sprite tulipGrowing;
    [SerializeField] public Sprite tulipHarvest;

    [SerializeField] public Sprite roseGrowing;
    [SerializeField] public Sprite roseHarvest;

    [SerializeField] public Sprite lavenderGrowing;
    [SerializeField] public Sprite lavenderHarvest;

    [SerializeField] public Sprite pearGrowing;
    [SerializeField] public Sprite pearHarvest;

    [SerializeField] public Sprite sunflowerGrowing;
    [SerializeField] public Sprite sunflowerHarvest;

    [SerializeField] public Sprite lilyGrowing;
    [SerializeField] public Sprite lilyHarvest;

    public Dictionary<string, InventoryItem> inventory = new Dictionary<string, InventoryItem>();

    // Start is called before the first frame update
    void Start()
    {
        inventory.Add("Dandelion", new InventoryItem("Dandelion", 12.0f, "Ava favorite", 0, 0, 2,
            dandelionGrowing, dandelionHarvest));

        inventory.Add("Daisy", new InventoryItem("Daisy", 24.0f, "Bruce favorite", 0, 0, 3, 
            daisyGrowing, daisyHarvest));

        inventory.Add("Poppy", new InventoryItem("Poppy", 36.0f, "Linda favorite", 0, 0, 3,
            poppyGrowing, poppyHarvest));

        inventory.Add("Tulip", new InventoryItem("Tulip", 48.0f, "Megan favorite", 0, 0, 4,
            tulipGrowing, tulipHarvest));

        inventory.Add("Rose", new InventoryItem("Rose", 60.0f, "Charlie favorite", 0, 0, 4,
            roseGrowing, roseHarvest));

        inventory.Add("Lavender", new InventoryItem("Lavender", 72.0f, "Gerald favorite", 0, 0, 5,
            lavenderGrowing, lavenderHarvest));

        inventory.Add("PricklyPear", new InventoryItem("PricklyPear", 84.0f, "Jermey favorite", 0, 0, 6,
            pearGrowing, pearHarvest));

        inventory.Add("Sunflower", new InventoryItem("Sunflower", 96.0f, "Sebastian favorite", 0, 0, 7,
            sunflowerGrowing, sunflowerHarvest));

        inventory.Add("LilyValley", new InventoryItem("LilyValley", 108.0f, "Poppy favorite", 0, 0, 7,
            lilyGrowing, lilyHarvest));

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

