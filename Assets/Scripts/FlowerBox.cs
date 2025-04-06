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
    [SerializeField] private GameObject exclaim;

    private string boxKey;
    private InventoryItem flowerPlanted;

    private FlowerboxManager fman;
    private InventoryManager inventoryManager;

    public override void Awake()
    {
       base.Awake();
       inventoryManager = GameObject.Find("Inventory").GetComponent<InventoryManager>();
       fman = GetComponentInParent<FlowerboxManager>();
       boxKey = "Box" + BoxNumber;
    }

    public override void Start()
    {
        base.Start();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.gameObject.GetComponent<PlayerInteractor>().enabled && !WateredToday)
        {
            plint.list.Add(this);
        }
    }
    protected override void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(plint.list.Contains(this)){
                plint.list.Remove(this);
            }
            active = false;
        }
    }

    public override void OnInteract()
    {
        if(exclaim.activeSelf){
            exclaim.GetComponent<Tutorial>().FlowerBoxTutorial();
        }

        if (!playerData.CheckEnergy(5)) { return; }

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
            playerData.ModifyEnergy(-5);

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
        playerData.ModifyEnergy(-5);
        active = false;
        plint.list.Remove(this);
        
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
        playerData.ModifyEnergy(-5);

        //uncomment once sprites available
        sprites[5] = null;
        sprites[6] = null;
        sprites[7] = null;

        sr.sprite = sprites[0];
        spriteInd = 0;

        UpdateSprite();

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
            }else if(CycleIndex == 0){
                sr.sprite = sprites[1];
                spriteInd = 1;
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
        }
        else
        {
            PlayerPrefs.SetString(boxKey, "None");
        }
        PlayerPrefs.SetInt(boxKey + "_Planted", planted ? 1 : 0);
        PlayerPrefs.SetInt(boxKey + "_Cycle", CycleIndex);
        PlayerPrefs.SetInt(boxKey + "_Sprite", spriteInd);
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey(boxKey))
        {
            string flowerName = PlayerPrefs.GetString(boxKey);
            if (flowerName != "None")
            {
                Flowers flower;
                Enum.TryParse(flowerName, out flower);
                flowerPlanted = inventoryManager.inventory[flower];
            }

            planted = PlayerPrefs.GetInt(boxKey + "_Planted") == 1 ? true : false;
            CycleIndex = PlayerPrefs.GetInt(boxKey + "_Cycle");
            spriteInd = PlayerPrefs.GetInt(boxKey + "_Sprite");

            if (planted)
            {
                sprites[5] = flowerPlanted.growing;
                sprites[6] = flowerPlanted.growingWatered;
                sprites[7] = flowerPlanted.harvest;
            }
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
