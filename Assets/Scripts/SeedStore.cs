using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SeedStore : InteractableObj
{
    [SerializeField] public GameObject storeCanvas;
    [SerializeField] public GameObject notCollect;
    [SerializeField] public GameObject Collect;

    [Space]
    [SerializeField] public TextMeshProUGUI[] counts;
    [SerializeField] public TextMeshProUGUI price;
    [SerializeField] public TextMeshProUGUI backCount;

    [Space]
    [SerializeField] public Sprite[] fbackgrounds;
    [SerializeField] public Image background;

    [Space]
    [SerializeField] public GameObject broke;

    [Space]
    [SerializeField] public InventoryManager inventory;

    public bool ifDelivery = false;
    public bool delivered = false;
    public bool pickedUp = false;

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
        storeCanvas.SetActive(false);
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
    }

    public override void EndInteract()
    {
        base.EndInteract();
    }

    public void OpenSeedStore()
    {
        storeCanvas.SetActive(true);  
    }

    public void CloseSeedStore()
    {
        storeCanvas.SetActive(false);

        int sets = 0;

        for (int i = 0; i < purchase.Length; i++)
        {
            cart[i] = purchase[i];
            sets = purchase[i] / 5;
            counts[i].text = sets.ToString();
            
        }

        sets = 0;
        price.text = sets.ToString();
        backCount.text = sets.ToString();
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

        pickedUp = false;

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
            backCount.text = counts[id].text;
        }
            
    }

    public void SubtractFromPurchase()
    {
        //subtract chosen flower
        //update price
        if (id < 10)
        {
            if (cart[id] > purchase[id])
            {
                cart[id] -= 5;
                int amount = int.Parse(counts[id].text) - 1;
                counts[id].text = amount.ToString();

                int p = int.Parse(price.text) - (int)chosenFlower.seedPrice;
                price.text = p.ToString();
                backCount.text = counts[id].text;
            }

        }

    }

    public bool Purchase()
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

            return true; 
        } 
        else
        {
            broke.SetActive(true);
        }

        return false;
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
        backCount.text = counts[id].text;
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

            pickedUp = true;
            delivered = false;
            signal.SetActive(false);
            Collect.SetActive(true); 

        } else
        {
            notCollect.SetActive(true); 
        }
              
    }

    #region SAVE_SYSTEM
    public void SaveData()
    {
        PlayerPrefs.SetInt("Delivery", delivered ? 1 : 0);
        PlayerPrefs.SetInt("IfDelivery", ifDelivery? 1 : 0);
        if (delivered)
        {
            foreach (string key in mapValues.Keys)
            {
                int i = mapValues[key];

                Flowers flower;
                Enum.TryParse(key, out flower);

                PlayerPrefs.SetInt("Delivery_" + i, delivery[i]);

                inventory.inventory[flower].seedStock -= delivery[i];
            }
        }
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey("Delivery"))
        {
            delivered = PlayerPrefs.GetInt("Delivery") == 1 ? true : false;
            if (delivered)
            {
                for (int i = 0; i < delivery.Length; i++)
                {
                    delivery[i] = PlayerPrefs.GetInt("Delivery_" + i);
                }
                signal.SetActive(true);
            }
        }
        else
        {
            delivered = false;
        }
        if (PlayerPrefs.HasKey("IfDelivery"))
        {
            ifDelivery = PlayerPrefs.GetInt("IfDelivery") == 1 ? true : false;
        }
        else
        {
            ifDelivery = false;
        }
        Delivery();
    }

    public void ResetData()
    {
        delivered = false;
        for (int i = 0; i < delivery.Length; i++)
        {
            delivery[i] = 0;
        }
        Delivery();
    }

    #endregion

}
