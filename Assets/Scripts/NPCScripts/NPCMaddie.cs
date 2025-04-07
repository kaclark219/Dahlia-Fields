using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;

public class NPCMaddie : NPC
{
    [Space]
    [SerializeField] public TextAsset buySeedText;

    [Space]
    [SerializeField] public GameObject SeedStoreUI; 

    public Vector3 seedLocation;

    private Story story;

    //OpenedUI VAR
    public override void OnInteract()
    {
        plint.Interact();
        story = ink.CreateStory(buySeedText, this);
        story.BindExternalFunction("OpenSeedUI", ()=> this.OpenSeedUI());
        ink.DisplayNextLine();
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Escape))
        {   
            if(SeedStoreUI.GetComponent<SeedStore>().storeCanvas.activeInHierarchy)
            {
                CloseSeedUI();
            }
        }
    }

    public override void EndInteract()
    {
        plint.EndInteract();
    }

    public void OpenSeedUI()
    {
        ink.DisableUI();
        SeedStoreUI.GetComponent<SeedStore>().OpenSeedStore();
    }

    public void PurchaseClose()
    {
        if (SeedStoreUI.GetComponent<SeedStore>().Purchase())
        {
            CloseSeedUI();
        }
        EndInteract();
    }

    public void CloseSeedUI()
    {   
       
        SeedStoreUI.GetComponent<SeedStore>().CloseSeedStore();

        if (SeedStoreUI.GetComponent<SeedStore>().ifDelivery)
        {
            story.variablesState["BoughtSeeds"] = 1;

        }
        else
        {
            story.variablesState["BoughtSeeds"] = 0;
        }

        ink.EnableUI();
        EndInteract();
    }
    
}
