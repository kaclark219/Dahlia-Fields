using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlowerBox : InteractableObj
{
    private int CycleIndex = 0;
    private InventoryItem flowerPlanted; 
    bool WateredToday = false;
    bool planted = false; 
    SpriteRenderer sr;
    int spriteInd = 0;

    [SerializeField] public InventoryManager inventoryManager;
    [SerializeField] public GameObject FlowerBoxUI;
    [SerializeField] public PlayerData player;

    [SerializeField] public Sprite[] sprites;
    [SerializeField] public TextMeshProUGUI[] counts; 


    private void Awake()
    {
       inventoryManager = GameObject.Find("Inventory").GetComponent<InventoryManager>();
       player =  GameObject.Find("Player").GetComponent<PlayerData>();
       FlowerBoxUI.SetActive(false);
       sr = GetComponentInParent<SpriteRenderer>();
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
        int i = 0; 
        foreach (var item in inventoryManager.inventory)
        {
            counts[i].text = item.Value.seedStock.ToString();
            i++;
        }
        FlowerBoxUI.SetActive(true);
    }

    public void Plant(string flower)
    {
        //Open UI and select a plant
        //return "Daisy"; //Placeholder
        Debug.Log(inventoryManager.GetSeedStock(flower) >= 5);
        if(inventoryManager.GetSeedStock(flower) >= 5)
        {
            FlowerBoxUI.SetActive(false);
            planted = true;
            flowerPlanted = inventoryManager.FindItem(flower);
            inventoryManager.SetSeedStock(flower, -5);
            player.ModifyEnergy(-5); 

            //uncomment once sprites available
            //sprites[5] = Resources.Load<Sprite>("Flowerbox/");
            //sprites[6] = Resources.Load<Sprite>("Flowerbox/");
            //sprites[7] = Resources.Load<Sprite>("Flowerbox/");
            sr.sprite = sprites[1];
            spriteInd = 1;

            Debug.Log("Plant");
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

        //uncomment once sprites available
        //sprites[5] = null;
        //sprites[6] = null;
        //sprites[7] = null;

        sr.sprite = sprites[0];
        spriteInd = 0;

        Debug.Log("Harvested");
    }

    public IEnumerator NextDayBox()
    {
        yield return new WaitUntil(() => sr != null);

        if(WateredToday){
            WateredToday = false;
            CycleIndex++;
        }
        sr.sprite = sprites[0];
        spriteInd = 0;

        if (planted) {
            sr.sprite = sprites[3];
            spriteInd = 3;

            if (flowerPlanted.daysToGrow == CycleIndex)
            {
                sr.sprite = sprites[7];
                spriteInd = 7;
            } 
            else if(flowerPlanted.daysToGrow/2 >= CycleIndex)
            {
                spriteInd = 5;
                sr.sprite = sprites[5];
            }
        }
        
    }
}
