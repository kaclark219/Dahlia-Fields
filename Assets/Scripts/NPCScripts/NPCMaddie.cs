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
        ink.StartCreatedStory();
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
    }

    public void CloseSeedUI()
    {   
       
        SeedStoreUI.GetComponent<SeedStore>().CloseSeedStore();

        if (SeedStoreUI.GetComponent<SeedStore>().p)
        {
            story.variablesState["BoughtSeeds"] = 1;

        }
        else
        {
            story.variablesState["BoughtSeeds"] = 0;
        }
        SeedStoreUI.GetComponent<SeedStore>().p = false; 

        ink.EnableUI();
        EndInteract();
    }
    
}
