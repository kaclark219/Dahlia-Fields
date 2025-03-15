using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;

public class NPCJeremy : NPC
{
    [Header("Flower Box Attributes")]
    [SerializeField] public TextAsset buyFlowerBox;
    public Vector3 workshopLocation;

    private Story story;
    public override void OnInteract()
    {
        plint.Interact();
        if (transform.parent.transform.position == workshopLocation && numOfInteractions > 0)
        {
            story = ink.CreateStory(buyFlowerBox, this);
            story.BindExternalFunction("BuyBox", () => this.BuyTonic());

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
            story.variablesState["BoughtBox"] = 1;
            // access Flowerbox Manager

            Debug.Log("Player bought a flower box");
        }
        else
        {
            story.variablesState["BoughtBox"] = 0;
            Debug.Log("Player could not buy a flower box");
        }
    }
}
