using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : InteractableObj
{
    [Space]
    [SerializeField] public NPCName npcName;
    [SerializeField] public List<TextAsset> textAssets;
    [SerializeField] public TextAsset fuckOffText;
    [Space]
    public PlayerData playerData;
    public SpriteRenderer sr;
    public InkManager ink;
    public PlayerMovement pm;
    [Space]
    public bool dailyInteraction;
    public int numOfInteractions;
    public bool costsEnergy;
    [Space]
    public string npcKey;

    private void Awake()
    {
        pm = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        sr = GetComponentInParent<SpriteRenderer>();
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
        if(active){
            if(pm.rb.position.y > transform.position.y){
                sr.sortingOrder = 4;
            }else{
                sr.sortingOrder = 2;
            }
        }
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
