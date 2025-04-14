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
    [SerializeField] public TextMeshProUGUI price;

    [Space]
    [SerializeField] public GameObject[] slots;
    [SerializeField] public Image[] cartItems;
    [SerializeField] public TextMeshProUGUI[] counts;
    [SerializeField] public Button[] clears; 
    public Dictionary<int, int> cartMap;

    [Space]
    [SerializeField] public Sprite[] fbackgrounds;
    [SerializeField] public Sprite[] cartIcons;
    [SerializeField] public Image background;

    [Space]
    [SerializeField] public Sprite[] statements;
    [SerializeField] public Image maddie;

    [Space]
    [SerializeField] public GameObject broke;

    [Space]
    [SerializeField] public InventoryManager inventory;

    public bool ifDelivery = false;
    public bool delivered = false;
    public bool p = false;

    private InventoryItem chosenFlower; 
    public Dictionary<string, int> mapValues;
    private int id = 10;

    public int[] cart = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public int[] purchase = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public int[] delivery = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    [SerializeField] GameObject signal;
    public float voffset = 0.0f;

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
            {"LilyValley", 8}
        };

        cartMap = new Dictionary<int, int>()
        {
            {0, 10},
            {1, 10},
            {2, 10},
            {3, 10},
            {4, 10}
        };

        signal.SetActive(false);
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

    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(notCollect.activeInHierarchy)
            {
                notCollect.SetActive(false);
                EndInteract();
            }

            if (Collect.activeInHierarchy)
            {
                Collect.SetActive(false);
                EndInteract();
            }
        }

        if(signal.activeInHierarchy)
        {
            signal.transform.position = new Vector2(signal.transform.position.x, Mathf.Sin(Time.time * 2f) * 0.2f + voffset);
        }
    }

    public void ClearButton(int i)
    {
        if (purchase[i] == 0)
        {
            // Store the current price to adjust it
            int currentPrice = int.Parse(price.text);

            // Calculate price reduction
            Flowers flower;
            foreach (var pair in mapValues)
            {
                if (pair.Value == i)
                {
                    Enum.TryParse(pair.Key, out flower);
                    InventoryItem item = inventory.FindItem(flower);
                    currentPrice -= (cart[i] / 5) * (int)item.seedPrice;
                    break;
                }
            }

            // Reset cart count for this item
            cart[i] = 0;

            // Update the price display
            price.text = currentPrice.ToString();

            int temp = id;
            id = i;
            SetUpCart(2);
            id = temp;
        }

    }

    public void OpenSeedStore()
    {
        storeCanvas.SetActive(true);  
    }

    public void CloseSeedStore()
    {
        storeCanvas.SetActive(false);

        int sets = 0;

        for (int i = 0; i < cart.Length; i++)
        {
            cart[i] = 0;            
        }

        for (int i = 0; i < 5; i++)
        {
            if (cartMap[i] < 10)
            {
                //sets = purchase[cartMap[i]] / 5;
                sets = 0; 
                counts[i].text = sets.ToString();

                if (sets == 0)
                {
                    id = cartMap[i];
                    SetUpCart(2); 
                }
            } 
        }

        

        sets = 0;
        price.text = sets.ToString();
        //backCount.text = sets.ToString();

        broke.SetActive(false);
        //change maddie statement to delivery 
        maddie.sprite = statements[0];
        id = 10;
        background.sprite = fbackgrounds[9];
    }

    private void SetUpCart(int version)
    {
        if (version == 1) // Add new item to cart
        {
            for (int i = 0; i < 5; i++)
            {
                if (cartMap[i] == 10)
                {
                    int slotIndex = i;
                    int itemId = id;

                    cartMap[i] = id;
                    slots[i].SetActive(true);
                    cartItems[i].sprite = cartIcons[id];
                    counts[i].text = "0";

                    // Remove any existing listeners to prevent duplicates
                    clears[i].onClick.RemoveAllListeners();

                    // Add listener with the correct ID captured in a local variable
                    clears[i].onClick.AddListener(() => ClearButton(itemId));

                    return;
                }
            }
        }
        else if (version == 2) // Remove item from cart
        {
            bool moveup = false;

            for (int i = 0; i < 5; i++)
            {
                if (cartMap[i] == id)
                {
                    moveup = true;

                    if (i + 1 == 5) // Last slot
                    {
                        cartMap[i] = 10;
                        slots[i].SetActive(false);
                        counts[i].text = "0";
                        clears[i].onClick.RemoveAllListeners();
                    }
                }
                else if (moveup)
                {
                    // Move items up in the cart
                    int nextItemId = cartMap[i];
                    cartMap[i - 1] = nextItemId;
                    cartItems[i - 1].sprite = cartItems[i].sprite;
                    counts[i - 1].text = counts[i].text;

                    // Update button listeners
                    clears[i - 1].onClick.RemoveAllListeners();

                    if (cartMap[i] == 10)
                    {
                        slots[i - 1].SetActive(false);
                        cartMap[i - 1] = 10;
                        counts[i - 1].text = "0";
                        clears[i - 1].onClick.RemoveAllListeners();

                        slots[i].SetActive(false);
                        cartMap[i] = 10;
                        counts[i].text = "0";
                        clears[i].onClick.RemoveAllListeners();
                    } 
                    else
                    {
                        int capturedId = nextItemId;
                        clears[i - 1].onClick.AddListener(() => ClearButton(capturedId));

                        // Check if count is 0, and if so, hide this slot too
                        if (cart[nextItemId] == 0)
                        {
                            slots[i - 1].SetActive(false);
                            cartMap[i - 1] = 10;
                            counts[i - 1].text = "0";
                            clears[i - 1].onClick.RemoveAllListeners();
                        }
                    }

                    if (i + 1 == 5)
                    {
                        slots[i].SetActive(false);
                        cartMap[i] = 10;
                        counts[i].text = "0";
                        clears[i].onClick.RemoveAllListeners();
                    }
                }
                else if (i + 1 == 5)
                {
                    slots[i].SetActive(false);
                    cartMap[i] = 10;
                    counts[i].text = "0";
                    clears[i].onClick.RemoveAllListeners();
                }
            }
        }
        else // Clear entire cart
        {
            for (int i = 0; i < 5; i++)
            {
                cartMap[i] = 10;
                slots[i].SetActive(false);
                counts[i].text = "0";
                clears[i].onClick.RemoveAllListeners();
            }
        }

        // Additional check to hide any slot with zero count
        for (int i = 0; i < 5; i++)
        {
            int itemId = cartMap[i];
            if (itemId != 10 && cart[itemId] == 0)
            {
                slots[i].SetActive(false);
                cartMap[i] = 10;
                clears[i].onClick.RemoveAllListeners();
            }
        }
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

            //counts[i].text = sets.ToString();

        }
        price.text = sets.ToString();
        id = 10;
        SetUpCart(0);
        background.sprite = fbackgrounds[9];

    }

    public void AddToPurchase()
    {
        int a = 0;
        int pr = 0;

        if (id < 10)
        {
            if (cartMap.ContainsValue(10) && !cartMap.ContainsValue(id))
            {
                SetUpCart(1);
            }

            for(int key = 0; key < 5; key++)
            {
                if (cartMap[key] == id)
                {
                    cart[id] += 5;
                    a = int.Parse(counts[key].text) + 5;
                    counts[key].text = a.ToString();

                    pr = int.Parse(price.text) + (int)chosenFlower.seedPrice;
                    price.text = pr.ToString();

                    return;
                }
            }

        }
            
    }

    public void SubtractFromPurchase()
    {
        int a = 0;
        int pr = 0;

        if (id < 10)
        {
            if (cart[id] > 0)
            {

                for (int key = 0; key < 5; key++)
                {
                    if (cartMap[key] == id)
                    {
                        cart[id] -= 5;
                        a = int.Parse(counts[key].text) - 5;
                        counts[key].text = a.ToString();

                        pr = int.Parse(price.text) - (int)chosenFlower.seedPrice;
                        price.text = pr.ToString();

                        if (a == 0)
                        {
                            SetUpCart(2);
                        }


                        return;
                    }
                }
            }

        }

    }

    public bool Purchase()
    {
        int priceOfCart = int.Parse(price.text);

        if (priceOfCart == 0)
        {
            return true; 
        }

        if (playerData.ModifyMoney(priceOfCart * -1))
        {
            int j = 0;
            price.text = j.ToString();

            background.sprite = fbackgrounds[9];
            id = 10;

            for (int i = 0; i < cart.Length; i++)
            {
                purchase[i] += cart[i];
            }

            ifDelivery = true;

            p = true;

            return true;
        }
        else
        {
            broke.SetActive(true);
            //change maddie statment 
            maddie.sprite = statements[2];
        }
        

        return false;
    }

    public void ChooseFlower(string name)
    {

        broke.SetActive(false);
        //change maddie statement to purchase
        maddie.sprite = statements[1]; 

        Flowers flower;
        Enum.TryParse(name, out flower);
        chosenFlower = inventory.FindItem(flower);

        id = mapValues[name]; 
        background.sprite = fbackgrounds[id];
        //backCount.text = counts[id].text;
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

                int stock = delivery[temp];
                

                if(stock < 0)
                {
                    stock *= -1; 
                }
                //Debug.Log("Stock: " + stock);

                inventory.SetSeedStock(flower, stock);
            }

            for (int i = 0; i < delivery.Length; i++)
            {
                delivery[i] = 0;
            }

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
        PlayerPrefs.SetInt("Delivered", delivered ? 1 : 0);
        if (delivered)
        {
            foreach (string key in mapValues.Keys)
            {
                int i = mapValues[key];

                Flowers flower;
                Enum.TryParse(key, out flower);

                PlayerPrefs.SetInt("Delivery_" + i, delivery[i]);
            }
        }

        PlayerPrefs.SetInt("IfDelivery", ifDelivery ? 1 : 0);
        if (ifDelivery)
        {
            foreach (string key in mapValues.Keys)
            {
                int i = mapValues[key];

                Flowers flower;
                Enum.TryParse(key, out flower);

                PlayerPrefs.SetInt("Purchase_" + i, purchase[i]);
            }
        }
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey("Delivered"))
        {
            delivered = PlayerPrefs.GetInt("Delivered") == 1 ? true : false;
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
            if (ifDelivery)
            {
                for (int i = 0; i < purchase.Length; i++)
                {
                    purchase[i] = PlayerPrefs.GetInt("Purchase_" + i);
                }
                signal.SetActive(true);
            }
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
        ifDelivery = false;
        for (int i = 0; i < purchase.Length; i++)
        {
            purchase[i] = 0;
        }
        Delivery();
    }

    #endregion

}
