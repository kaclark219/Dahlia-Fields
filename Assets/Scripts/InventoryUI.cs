using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : InteractableObj
{
    [SerializedField] public Canvas uiScreen;
    [SerializedField] public InventoryManager inventoryManager;
    private InventoryItem item; 
    public bool flowers = false;
    public bool seeds = false;

    //view elements
    [SerializedField] public GameObject view; 
    [SerializedField] public TextMeshProUGUI viewName;
    [SerializedField] public TextMeshProUGUI viewStock;
    [SerializedField] public TextMeshProUGUI viewDescription;
    [SerializedField] public GameObject viewIcon;

    //slots
    [SerializedField] public Image[] iconSlots = new Image[9];
    [SerializedField] public TextMeshProUGUI[] amounts = new TextMeshProUGUI[9];

    public override void Start()
    {
        base.Start();
        view.SetActive(false);
        uiScreen.enabled = false;
        

    }

    public override void OnInteract()
    {   
        SetUpFlowers();
        uiScreen.enabled = true;
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
        foreach (var item in inventoryManager.inventory)
        {
            iconSlots[count].sprite = item.Value.seedIcon;
            amounts[count].text = item.Value.seedStock.ToString();
            count++;
        }
    }

    public void SetUpView(string name)
    {
        view.SetActive(true); 
        if(flowers)
        {

        } 
        
        if(seeds)
        {

        }
    }


}
