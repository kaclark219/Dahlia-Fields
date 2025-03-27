using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEditor.Purchasing;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SeedStore : InteractableObj
{
    [SerializeField] public Canvas storeCanvas;

    [Space]
    [SerializeField] public TextMeshProUGUI[] counts;
    [SerializeField] public TextMeshProUGUI price;

    [Space]
    [SerializeField] public Sprite[] fbackgrounds;
    [SerializeField] public Image background;

    [Space]
    [SerializeField] public GameObject broke;

    [Space]
    [SerializeField] public InventoryManager inventory;

    public bool ifDelivery = false;
    public bool delivered = false;  

    private InventoryItem chosenFlower; 
    public Dictionary<string, int> mapValues;
    private int id = 10;
    private int paid = 0; 
    public int[] cart = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public int[] purchase = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public int[] delivery = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    [SerializeField] GameObject signal; 

    public override void Awake()
    {
        base.Awake();
        inventory = GameObject.Find("Inventory").GetComponent<InventoryManager>();
    }

    public override void Start()
    {   
        base.Start();
        storeCanvas.enabled = false;
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
        PickUpDelivery();
        base.EndInteract();
    }

    public void OpenSeedStore()
    {
        storeCanvas.enabled = true; 
    }

    public void CloseSeedStore()
    {
        storeCanvas.enabled = false;

        int sets = 0;

        for (int i = 0; i < purchase.Length; i++)
        {
            cart[i] = purchase[i];
            sets = purchase[i] / 5;
            counts[i].text = sets.ToString();
            
        }

        sets = 0;
        price.text = sets.ToString();
        broke.SetActive(false);
    }

    public void Delivery()
    {   

        if (ifDelivery)
        {
            for (int i = 0; i < purchase.Length; i++)
            {
                delivery[i] = purchase[i];              
            }

            delivered = true;
            ifDelivery = false;
            signal.SetActive(true);
        } 

        int sets = 0;
        for (int i = 0; i < purchase.Length; i++)
        {

            cart[i] = 0;
            purchase[i] = 0;

            counts[i].text = sets.ToString();

        }
        price.text = sets.ToString();
        id = 10;
        background.sprite = fbackgrounds[9];
    }

    public void AddToPurchase()
    {
        //add chosen flower
        //update price
        if (id < 10)
        {
            cart[id] += 5;
            int amount = int.Parse(counts[id].text) + 1;
            counts[id].text = amount.ToString();

            int p = int.Parse(price.text) + (int)chosenFlower.seedPrice;
            price.text = p.ToString();
        }
            
    }

    public void SubtractFromPurchase()
    {
        //subtract chosen flower
        //update price
        if (id < 10)
        {
            if (cart[id] > 0)
            {
                cart[id] -= 5;
                int amount = int.Parse(counts[id].text) - 1;
                counts[id].text = amount.ToString();

                int p = int.Parse(price.text) - (int)chosenFlower.seedPrice;
                price.text = p.ToString();
            }

        }

    }

    public void Purchase()
    {
        if(playerData.ModifyMoney(-1 * int.Parse(price.text)))
        {
            int j = 0;
            price.text = j.ToString();

            background.sprite = fbackgrounds[9];
            id = 10;

            for (int i = 0; i < cart.Length; i++)
            {
                purchase[i] = cart[i];
            }

            ifDelivery = true;
        } 
        else
        {
            broke.SetActive(true);
        }
    }

    public void ChooseFlower(string name)
    {
        //choose flower
        //change background
        broke.SetActive(false);
        Flowers flower;
        Enum.TryParse(name, out flower);
        chosenFlower = inventory.FindItem(flower);

        id = mapValues[name]; 
        background.sprite = fbackgrounds[id]; 
    }

    public void PickUpDelivery()
    {
        if(delivered)
        {
            foreach (string key in mapValues.Keys)
            {
                int temp = mapValues[key];

                Flowers flower;
                Enum.TryParse(key, out flower);

                inventory.SetSeedStock(flower, delivery[temp]);
            }

            for (int i = 0; i < delivery.Length; i++)
            {
                delivery[i] = 0;
            }

            delivered = false;
            signal.SetActive(false);
        } 
              
    }

}
