using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBox : InteractableObj
{
    private int CycleIndex = 0;
    private InventoryItem flowerPlanted; 
    bool WateredToday = false;
    bool planted = false; 
    SpriteRenderer sr;
    int spriteInd = 0;
    FlowerboxManager fman;

    [SerializeField] public InventoryManager inventoryManager;
    [SerializeField] public PlayerData player;

    [SerializeField] public Sprite[] sprites;


    private void Awake()
    {
       inventoryManager = GameObject.Find("Inventory").GetComponent<InventoryManager>();
       player =  GameObject.Find("Player").GetComponent<PlayerData>();
       sr = GetComponentInParent<SpriteRenderer>();
       fman = GetComponentInParent<FlowerboxManager>();
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
            fman.active = this;
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

    public void Plant(string flower)
    {
        //Open UI and select a plant
        //return "Daisy"; //Placeholder
        Debug.Log(inventoryManager.GetSeedStock(flower) >= 5);
        if(inventoryManager.GetSeedStock(flower) >= 5)
        {
            fman.CloseUI();
            planted = true;
            flowerPlanted = inventoryManager.FindItem(flower);
            inventoryManager.SetSeedStock(flower, -5);
            player.ModifyEnergy(-5); 

            //uncomment once sprites available
            sprites[5] = Resources.Load<Sprite>("Flowerbox/" + flower + "_growing");
            sprites[6] = Resources.Load<Sprite>("Flowerbox/" + flower + "_growing+watered");
            sprites[7] = Resources.Load<Sprite>("Flowerbox/" + flower + "_final");
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
        sprites[5] = null;
        sprites[6] = null;
        sprites[7] = null;

        sr.sprite = sprites[0];
        spriteInd = 0;

        EndInteract();
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
            else if(flowerPlanted.daysToGrow/2 < CycleIndex)
            {
                spriteInd = 5;
                sr.sprite = sprites[5];
            }
        }
        
    }
}
