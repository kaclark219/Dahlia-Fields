using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBox : InteractableObj
{
    private int CycleIndex = 0;
    private InventoryItem flowerPlanted; 
    bool WateredToday = false;
    bool planted = false; 

    [SerializedField] public InventoryManager inventoryManager;
    [SerializedField] public GameObject FlowerBoxUI;
    [SerializedField] public PlayerData player;

    [SerializedField] public GameObject plot1;
    [SerializedField] public GameObject plot2;
    [SerializedField] public GameObject plot3;
    [SerializedField] public GameObject plot4;
    [SerializedField] public GameObject plot5;

    private void Awake()
    {
       inventoryManager = GameObject.Find("Inventory").GetComponent<InventoryManager>();
       player =  GameObject.Find("Player").GetComponent<PlayerData>();
       FlowerBoxUI.SetActive(false);
    }

    public override void Start()
    {
        base.Start();
    }

    public override void OnInteract()
    {
        //if (true && PlantedFlower == "")
        //{
        //   Plant();
        //}
        //else if (true && daysToGrow[PlantedFlower] == CycleIndex && !WateredToday)
        //{
        //    StartCoroutine(Harvest());
        //}
        //else if (true && !WateredToday)
        //{ //Replace with (has enough energy)
        //    ;//Decrease energy
        //    StartCoroutine(Water());
        //}

        if (!planted)
        {
            OpenUI();
        }
        else if (!WateredToday && flowerPlanted.daysToGrow != CycleIndex) //not watered today and growth not completed
        {
            Water();
        }
        else if(flowerPlanted.daysToGrow == CycleIndex) //growth completed
        {
            Harvest();
        }
    }

    public void OpenUI()
    {
        FlowerBoxUI.SetActive(true);
    }

    public void Plant(string flower)
    {
        //Open UI and select a plant
        //return "Daisy"; //Placeholder
        if(inventoryManager.GetSeedStock(flower) >= 5)
        {
            FlowerBoxUI.SetActive(false);
            planted = true;
            flowerPlanted = inventoryManager.FindItem(flower);
            inventoryManager.SetSeedStock(flower, -5);
            player.ModifyEnergy(-5); 

            // set sprites 
            plot1.GetComponent<SpriteRenderer>().enabled = true;
            plot2.GetComponent<SpriteRenderer>().enabled = true;
            plot3.GetComponent<SpriteRenderer>().enabled = true;
            plot4.GetComponent<SpriteRenderer>().enabled = true;
            plot5.GetComponent<SpriteRenderer>().enabled = true;

            plot1.GetComponent<SpriteRenderer>().sprite = flowerPlanted.planted;
            plot2.GetComponent<SpriteRenderer>().sprite = flowerPlanted.planted;
            plot3.GetComponent<SpriteRenderer>().sprite = flowerPlanted.planted;
            plot4.GetComponent<SpriteRenderer>().sprite = flowerPlanted.planted;
            plot5.GetComponent<SpriteRenderer>().sprite = flowerPlanted.planted;

            Debug.Log("Plant");
        }
    }

    public void Water()
    {
        ////Water animation
        //plint.pm.canmove = false;
        //yield return new WaitForSeconds(1);
        //plint.pm.canmove = true;

        CycleIndex++;
        WateredToday = true;
        player.ModifyEnergy(-5);
        Debug.Log("Watered");
    }

    public void Harvest()
    {
        ////Harvest animation
        //plint.pm.canmove = false;
        //yield return new WaitForSeconds(1);
        //plint.pm.canmove = true;

        inventoryManager.SetFlowerStock(flowerPlanted.itemName, 5); 
        CycleIndex = 0;
        planted = false;
        player.ModifyEnergy(-5);
        plot1.GetComponent<SpriteRenderer>().enabled = false;
        plot2.GetComponent<SpriteRenderer>().enabled = false;
        plot3.GetComponent<SpriteRenderer>().enabled = false;
        plot4.GetComponent<SpriteRenderer>().enabled = false;
        plot5.GetComponent<SpriteRenderer>().enabled = false;
        Debug.Log("Harvested");
    }

    public void NextDayBox()
    {
        WateredToday = false;

        if (planted) {
            if (flowerPlanted.daysToGrow == CycleIndex)
            {
                plot1.GetComponent<SpriteRenderer>().sprite = flowerPlanted.harvest;
                plot2.GetComponent<SpriteRenderer>().sprite = flowerPlanted.harvest;
                plot3.GetComponent<SpriteRenderer>().sprite = flowerPlanted.harvest;
                plot4.GetComponent<SpriteRenderer>().sprite = flowerPlanted.harvest;
                plot5.GetComponent<SpriteRenderer>().sprite = flowerPlanted.harvest;
            } 
            else
            {
                plot1.GetComponent<SpriteRenderer>().sprite = flowerPlanted.growing;
                plot2.GetComponent<SpriteRenderer>().sprite = flowerPlanted.growing;
                plot3.GetComponent<SpriteRenderer>().sprite = flowerPlanted.growing;
                plot4.GetComponent<SpriteRenderer>().sprite = flowerPlanted.growing;
                plot5.GetComponent<SpriteRenderer>().sprite = flowerPlanted.growing;
            }
        }
        
    }
}
