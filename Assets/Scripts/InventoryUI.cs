using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : InteractableObj
{
    [SerializedField] public Canvas uiScreen;
    [SerializedField] public InventoryManager inventoryManager;
    public bool flowers = false;
    public bool seeds = false; 

    public override void Start()
    {
        base.Start();
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
    }

    public void SetUpSeeds()
    {   
        flowers = false;
        seeds = true;
    }

    public void SetUpView(string name)
    {
        if(flowers)
        {

        } 
        
        if(seeds)
        {

        }
    }


}
