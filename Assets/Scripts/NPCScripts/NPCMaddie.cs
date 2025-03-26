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
        //if (transform.parent.transform.position == seedLocation && numOfInteractions > 0)
        //{
            story = ink.CreateStory(buySeedText, this);
        Debug.Log("Maddie story created");
            story.BindExternalFunction("OpenSeedUI", ()=> this.OpenSeedUI());
        Debug.Log("Maddie bind");
        ink.DisplayNextLine();
        //}

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
    }
    
}
