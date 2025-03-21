using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;

public class NPCGerald : NPC
{
    [Header("Tonic Attributes")]
    [SerializeField] public TextAsset buyTonicText;
    public Vector3 clinicLocation;

    private Story story;
    public override void OnInteract()
    {
        plint.Interact();
        if (transform.parent.transform.position == clinicLocation && numOfInteractions > 0)
        {
            story = ink.CreateStory(buyTonicText, this);
            story.BindExternalFunction("BuyTonic", () => this.BuyTonic());

            ink.DisplayNextLine();
            costsEnergy = false;
        }
        else if (textAssets.Count <= numOfInteractions || dailyInteraction)
        {
            ink.StartStory(fuckOffText, this);
            costsEnergy = false;
        }
        else
        {
            ink.StartStory(textAssets[numOfInteractions], this);
            dailyInteraction = true;
            numOfInteractions++;
            costsEnergy = true;
        }
    }

    public override void EndInteract()
    {
        plint.EndInteract();
        if (costsEnergy)
        {
            playerData.ModifyEnergy(-5); // Decrease player energy
        }
    }

    public void BuyTonic()
    {
        PlayerData playerData = GameObject.Find("Player").GetComponent<PlayerData>();
        if (playerData.ModifyMoney(-25))
        {
            story.variablesState["BoughtTonic"] = 1;
            playerData.ModifyEnergy(10);
            Debug.Log("Player Bought Tonic");
        }
        else
        {
            story.variablesState["BoughtTonic"] = 0;
            Debug.Log("Player could not buy tonic");
        }
    }
}
