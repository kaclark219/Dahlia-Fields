using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : InteractableObj
{
    [Header("NPC Attributes")]
    [SerializeField] public NPCName npcName;
    [SerializeField] public List<TextAsset> textAssets;
    [SerializeField] public TextAsset fuckOffText;
    [Space]
    public bool dailyInteraction;
    public int numOfInteractions;

    // Public variables inherited by child classes but hidden in Unity inspector
    [HideInInspector] public PlayerData playerData;
    [HideInInspector] public InkManager ink;

    [HideInInspector] public bool costsEnergy;
    [HideInInspector] public string npcKey;

    private void Awake()
    {
        base.Awake();
        playerData = GameObject.Find("Player").GetComponent<PlayerData>();
        ink = GameObject.Find("InkManager").GetComponent<InkManager>();
        npcKey = npcName.ToString();
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
        base.OnInteract();
        if (textAssets.Count <= numOfInteractions || dailyInteraction)
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
        base.EndInteract();
        if (costsEnergy)
        {
            playerData.ModifyEnergy(-5); // Decrease player energy
        }
    }

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
}
