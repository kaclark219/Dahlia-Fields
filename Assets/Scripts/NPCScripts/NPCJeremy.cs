using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro.EditorUtilities;
using UnityEngine;

public class NPCJeremy : NPC
{
    [Header("Flower Box Attributes")]
    [SerializeField] public TextAsset buyFlowerBox;
    public Vector3 workshopLocation;
    public int BoxCost = -40;

    private Story story;

    public override void Start()
    {
        base.Start();
        workshopLocation = GetComponentInParent<NPCManager>().coords["Jeremy11"];
    }

    public override void OnInteract()
    {
        plint.Interact();

        int trust = dialogueVariables.GetVariableState(npcName.ToString() + "Trust");

        if (transform.parent.transform.position == workshopLocation && numOfInteractions > 0)
        {
            story = ink.CreateStory(buyFlowerBox, this);
            story.BindExternalFunction("BuyFlowerbox", () => this.BuyFlowerbox());

            ink.DisplayNextLine();
            costsEnergy = false;
        }
        else if (isFeedDay && trust < trustRequired)
        {
            ink.StartStory(killText, this);
            costsEnergy = true;
            isFeedDay = false;
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

    public void BuyFlowerbox()
    {
        FlowerboxManager flowerboxManager = GameObject.Find("FlowerboxManager").GetComponent<FlowerboxManager>();
        if (playerData.ModifyMoney(BoxCost) && flowerboxManager.AddBox())
        {

            story.variablesState["BoughtFlowerbox"] = 1;
            Debug.Log("Player bought a flower box");
        }
        else
        {
            story.variablesState["BoughtFlowerbox"] = 0;
            Debug.Log("Player could not buy a flower box");
        }
    }
}
