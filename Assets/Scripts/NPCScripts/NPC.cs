using System.Collections.Generic;
using UnityEngine;

public class NPC : InteractableObj
{
    [Header("NPC Attributes")]
    [SerializeField] public NPCName npcName;
    [SerializeField] public List<TextAsset> textAssets;
    [Space]
    public bool dailyInteraction;
    public int numOfInteractions;
    [SerializeField] public TextAsset fuckOffText;
    [Space]
    public bool isFeedDay = false;
    public int trustRequired = 0;
    [SerializeField] public TextAsset killText;
    [SerializeField] public RuntimeAnimatorController[] animations;

    [HideInInspector] Map map;

    // Public variables inherited by child classes but hidden in Unity inspector
    [HideInInspector] public InkManager ink;
    [HideInInspector] public DialogueVariables dialogueVariables;   

    [HideInInspector] public bool costsEnergy;
    [HideInInspector] public string npcKey;

    public override void Awake()
    {
        base.Awake();
        playerData = GameObject.Find("Player").GetComponent<PlayerData>();
        ink = GameObject.Find("InkManager").GetComponent<InkManager>();
        dialogueVariables = GameObject.Find("InkManager").GetComponent<DialogueVariables>();
        npcKey = npcName.ToString();
        map = GameObject.Find("Map").GetComponent<Map>();
    }
    public override void Start()
    {
        base.Start();
        dailyInteraction = false;
        costsEnergy = false;
    }

    public override void Update(){
        base.Update();
    }

    public override void OnInteract()
    {
        if (!playerData.CheckEnergy(5)) { return; }

        base.OnInteract();

        map.log(npcKey + "_Found");

        int trust = dialogueVariables.GetVariableState(npcName.ToString() + "Trust");

        if (textAssets.Count <= numOfInteractions || dailyInteraction)
        {
            ink.StartStory(fuckOffText, this);
            costsEnergy = false;
        }
        else if(isFeedDay && trust >= trustRequired) 
        {
            ink.StartStory(killText, this);
            costsEnergy = true;
            isFeedDay = false;
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
        base.EndInteract();
        if (costsEnergy)
        {
            playerData.ModifyEnergy(-5); // Decrease player energy
        }
    }

    #region SAVE_SYSTEM
    public void SaveData()
    {
        PlayerPrefs.SetInt(npcKey, numOfInteractions);
    }
    public void LoadData()
    {
        if (PlayerPrefs.HasKey(npcKey))
        {
            numOfInteractions = PlayerPrefs.GetInt(npcKey);
        }
        else
        {
            numOfInteractions = 0;
        }
    }
    public void ResetData()
    {
        numOfInteractions = 0;
    }
    #endregion
}
