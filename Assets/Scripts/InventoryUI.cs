using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : InteractableObj
{
    
    [SerializeField] public GameObject uiScreen;
    [SerializeField] public InventoryManager inventory;

    public Dictionary<string, int> mapValues;

    //slots
    [SerializeField] public TextMeshProUGUI[] flowerAmounts = new TextMeshProUGUI[9];
    [SerializeField] public TextMeshProUGUI[] seedAmounts = new TextMeshProUGUI[9];

    public override void Start()
    {
        base.Start();
        uiScreen.SetActive(false);

        mapValues = new Dictionary<string, int>()
        {
            {"Dandelion", 0},
            {"Daisy",  1},
            {"Poppy", 2},
            {"Tulip", 3},
            {"Rose", 4},
            {"Lavender", 5},
            {"PricklyPear", 6},
            {"Sunflower", 7},
            {"LilyValley", 8},
        };

    }

    public override void OnInteract()
    {   
        base.OnInteract();
        SetUpView();
        uiScreen.SetActive(true);
    }

    public override void EndInteract()
    {
        base.EndInteract();
        uiScreen.SetActive(false);
    }

    public void SetUpView()
    {
        foreach (string key in mapValues.Keys)
        {
            int id = mapValues[key];

            Flowers flower;
            Enum.TryParse(key, out flower);

            flowerAmounts[id].text = inventory.GetFlowerStock(flower).ToString();
            seedAmounts[id].text = inventory.GetSeedStock(flower).ToString();
        }
    }

}
