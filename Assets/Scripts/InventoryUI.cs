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
    
    [SerializeField] public Canvas uiScreen;
    [SerializeField] public InventoryManager inventoryManager;
    private InventoryItem item; 
    public bool flowers = false;
    public bool seeds = false;

    //view elements
    [SerializeField] public GameObject view; 
    [SerializeField] public TextMeshProUGUI viewName;
    [SerializeField] public TextMeshProUGUI viewStock;
    [SerializeField] public TextMeshProUGUI viewDescription;
    [SerializeField] public Image viewIcon;

    //slots
    [SerializeField] public Image[] iconSlots = new Image[9];
    [SerializeField] public TextMeshProUGUI[] amounts = new TextMeshProUGUI[9];

    public override void Start()
    {
        base.Start();
        view.SetActive(false);
        uiScreen.enabled = false;

    }

    public override void OnInteract()
    {   
        base.OnInteract();
        SetUpFlowers();
        uiScreen.enabled = true;
    }

    public override void EndInteract()
    {
        base.EndInteract();
        uiScreen.enabled = false;
    }

    public void SetUpFlowers()
    {
        seeds = false;
        flowers = true;
        view.SetActive(false);
        int count = 0; 
        foreach (var item in inventoryManager.inventory)
        {
            iconSlots[count].sprite = item.Value.flowerIcon;
            amounts[count].text = item.Value.flowerStock.ToString();
            count++;
        }
    }

    public void SetUpSeeds()
    {   
        flowers = false;
        seeds = true;
        view.SetActive(false);
        int count = 0;
        foreach (var i in inventoryManager.inventory)
        {
            iconSlots[count].sprite = i.Value.seedIcon;
            amounts[count].text = i.Value.seedStock.ToString();
            count++;
        }
    }

    public void SetUpView(string name)
    {
        view.SetActive(true);
        Flowers flower;
        Enum.TryParse(name, out flower);
        item = inventoryManager.inventory[flower];
        
        if(flowers)
        {
            viewName.text = item.itemName.ToString();
            viewDescription.text = item.description;
            viewIcon.sprite = item.flowerIcon;
            viewStock.text = item.flowerStock.ToString(); 
        } 
        
        if(seeds)
        {
            viewName.text = item.itemName + " Seeds";
            viewDescription.text = item.daysToGrow.ToString() + " Days to Grow";
            viewIcon.sprite = item.seedIcon;
            viewStock.text = item.seedStock.ToString();
        }
    }

}
