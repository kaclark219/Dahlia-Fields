using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FlowerBox : InteractableObj
{
    [Header("Flower Box Attributes")]
    public string BoxNumber;
    public bool planted = false;
    public bool WateredToday = false;
    public int CycleIndex = 0;
    public int spriteInd = 0;

    [SerializeField] public Sprite[] sprites;

    private string boxKey;
    private InventoryItem flowerPlanted;

    private SpriteRenderer sr;
    private FlowerboxManager fman;
    private InventoryManager inventoryManager;
    private PlayerData player;

    private void Awake()
    {
       inventoryManager = GameObject.Find("Inventory").GetComponent<InventoryManager>();
       player =  GameObject.Find("Player").GetComponent<PlayerData>();
       sr = GetComponentInParent<SpriteRenderer>();
       fman = GetComponentInParent<FlowerboxManager>();
       boxKey = "Box" + BoxNumber;
    }

    public override void Start()
    {
        base.Start();
    }

    public override void OnInteract()
    {
        base.OnInteract();
        if (!planted)
        {
            base.OnInteract();
            fman.OpenUI();
            fman.ActiveBox = this;
        }
        else if (!WateredToday && flowerPlanted.daysToGrow != CycleIndex) //not watered today and growth not completed
        {
            base.OnInteract();
            Water();
        }
        else if(flowerPlanted.daysToGrow == CycleIndex && !WateredToday) //growth completed
        {
            base.OnInteract();
            Harvest();
        }else if(WateredToday){
            base.EndInteract();
        }
    }

    public void Plant(Flowers flower)
    {
        //Open UI and select a plant
        if(inventoryManager.GetSeedStock(flower) >= 5)
        {
            fman.CloseUI();
            planted = true;
            flowerPlanted = inventoryManager.FindItem(flower);
            inventoryManager.SetSeedStock(flower, -5);
            player.ModifyEnergy(-5);

            //uncomment once sprites available ===> can access sprites from inventory
            sprites[5] = flowerPlanted.growing;
            sprites[6] = flowerPlanted.growingWatered;
            sprites[7] = flowerPlanted.harvest;

            sr.sprite = sprites[1];
            spriteInd = 1;
            EndInteract();
            Debug.Log("Planted " + flower);
        }
    }

    public void Water()
    {
        ////Water animation
        //plint.pm.canmove = false;
        //yield return new WaitForSeconds(1);
        //plint.pm.canmove = true;

        WateredToday = true;
        player.ModifyEnergy(-5);
        
        sr.sprite = sprites[++spriteInd];

        EndInteract();
        Debug.Log("Watered box " + BoxNumber);
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

        //uncomment once sprites available
        sprites[5] = null;
        sprites[6] = null;
        sprites[7] = null;

        sr.sprite = sprites[0];
        spriteInd = 0;

        EndInteract();
        Debug.Log("Harvested box " + BoxNumber);
    }

    public void NextDayBox()
    {
        if(WateredToday && planted){   // if watered and planted, plant grows
            WateredToday = false;
            CycleIndex++;
        }

        UpdateSprite(); // update sprite based on growth
    }

    private void UpdateSprite()
    {
        if (planted)
        { 
            if (flowerPlanted.daysToGrow == CycleIndex)
            {
                sr.sprite = sprites[7];
                spriteInd = 7;
            }
            else if (flowerPlanted.daysToGrow / 2 < CycleIndex)
            {
                spriteInd = 5;
                sr.sprite = sprites[5];
            }
            else
            {
                sr.sprite = sprites[3];
                spriteInd = 3;
            }
        }
        else
        {
            sr.sprite = sprites[0];
            spriteInd = 0;
        }
        
    }

    #region SAVE_SYSTEM
    public void SaveData()
    {
        if (planted)
        {
            PlayerPrefs.SetString(boxKey, flowerPlanted.itemName.ToString());
            PlayerPrefs.SetInt(boxKey + "_Planted", planted ? 1 : 0);
            PlayerPrefs.SetInt(boxKey + "_Cycle", CycleIndex);
            PlayerPrefs.SetInt(boxKey + "_Sprite", spriteInd);
        }
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey(boxKey))
        {
            Flowers flower;
            Enum.TryParse(PlayerPrefs.GetString(boxKey), out flower);
            flowerPlanted = inventoryManager.inventory[flower];

            planted = PlayerPrefs.GetInt(boxKey + "_Planted") == 1 ? true : false;
            CycleIndex = PlayerPrefs.GetInt(boxKey + "_Cycle");
            spriteInd = PlayerPrefs.GetInt(boxKey + "_Sprite");

            sprites[5] = flowerPlanted.growing;
            sprites[6] = flowerPlanted.growingWatered;
            sprites[7] = flowerPlanted.harvest;

            UpdateSprite();
        }
        else 
        {
            ResetData();
        }
    }

    public void ResetData()
    {
        flowerPlanted = null;
        planted = false;
        WateredToday = false;
        CycleIndex = 0;
        spriteInd = 0;

        UpdateSprite();
    }

    #endregion
}
