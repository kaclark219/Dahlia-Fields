using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [SerializeField] GameObject[] NPCs;
    Dictionary<string, Vector2> coords = new Dictionary<string, Vector2>();

    private void Awake()
    {
        string[] lines = Resources.Load<TextAsset>("NPClocations").ToString().Split("\n");
        for(int i = 1; i < lines.Length; i++){
            string[] info = lines[i].Split(",");
            coords.Add(info[0], new Vector2(int.Parse(info[1]), int.Parse(info[2]))); //If this line errors make sure the CSV doesn't have a blak line at the end
        }
    }

    void Update()
    {
        //foreach(GameObject npc in NPCs){
        //    npc.transform.position = coords[npc.name + day + stage];
        //}
    }

    public void MoveNPCs(int day, int stage)
    {
        Debug.Log("Moving NPCs to day " + day + " and time " + stage);
        foreach (GameObject npc in NPCs)
        {
            if (coords.ContainsKey(npc.name + day.ToString() + stage.ToString()))
            {
                npc.transform.position = coords[npc.name + day.ToString() + stage.ToString()];
            }
            else
            {
                npc.transform.position = coords[npc.name + "1" + stage.ToString()];
            }
        }
    }

    public void ResetDailyInteraction()
    {
        foreach (GameObject npc in NPCs)
        {
            if (npc.GetComponentInChildren<NPC>() == null) { continue; }
            npc.GetComponentInChildren<NPC>().dailyInteraction = false;
        }
    }

    #region SAVE_SYSTEM
    public void SaveData()
    {
        foreach (GameObject npc in NPCs)
        {
            if (npc.GetComponentInChildren<NPC>() == null) { continue; }
            npc.GetComponentInChildren<NPC>().SaveData();
        }
    }

    public void LoadData()
    {
        foreach (GameObject npc in NPCs)
        {
            if (npc.GetComponentInChildren<NPC>() == null) { continue; }
            npc.GetComponentInChildren<NPC>().LoadData();
        }
    }

    public void ResetData()
    {
        foreach (GameObject npc in NPCs)
        {
            if (npc.GetComponentInChildren<NPC>() == null) { continue; }
            npc.GetComponentInChildren<NPC>().ResetData();
        }
    }
    #endregion
}
