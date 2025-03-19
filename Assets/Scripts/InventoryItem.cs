using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Flowers
{
    Dandelion, Daisy, Poppy, Tulip, Rose, Lavender, PricklyPear, Sunflower, LilyValley
}

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/InventoryItem", order = 1)]
public class InventoryItem : ScriptableObject
{
    public Flowers itemName;
    public float seedPrice;
    public string description;
    public int seedStock;
    public int flowerStock;
    public int daysToGrow;
    public Sprite growing;
    public Sprite growingWatered;
    public Sprite harvest;
    public Sprite seedIcon;
    public Sprite flowerIcon;
}