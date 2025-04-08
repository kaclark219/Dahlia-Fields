using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [SerializeField] public List<GameObject> NPCs = new List<GameObject>();
    public Dictionary<string, Vector3> coords = new Dictionary<string, Vector3>();

    private DaySystem daySystem;
    private void Awake()
    {
        daySystem = GameObject.Find("GameManager").GetComponent<DaySystem>();
        string[] lines = Resources.Load<TextAsset>("NPClocations").ToString().Split("\n");
        for(int i = 1; i < lines.Length; i++){
            string[] info = lines[i].Split(",");
            coords.Add(info[0], new Vector3(int.Parse(info[1]), int.Parse(info[2]), int.Parse(info[3]))); //If this line errors make sure the CSV doesn't have a blank line at the end
        }
    }
    public void MoveNPCs(int day, int stage)
    {
        Debug.Log("Moving NPCs to day " + day + " and time " + stage);
        day = day%3;
        if(day == 0){
            day = 3;
        }
        foreach (GameObject npc in NPCs)
        {
            if (coords.ContainsKey(npc.name + day.ToString() + stage.ToString()))
            {
                npc.transform.position = new Vector2(coords[npc.name + day.ToString() + stage.ToString()].x, coords[npc.name + day.ToString() + stage.ToString()].y);
                npc.GetComponent<Animator>().runtimeAnimatorController = npc.GetComponentInChildren<NPC>().animations[(int) coords[npc.name + day.ToString() + stage.ToString()].z];
            }
            else
            {
                Debug.LogError($"Sprite missing for " + npc.name + day.ToString() + stage.ToString());
            }
        }
    }

    public NPC GetNPC(NPCName name)
    {
        foreach (GameObject npc in NPCs)
        {
            if (npc.activeSelf && npc.GetComponentInChildren<NPC>() != null && npc.GetComponentInChildren<NPC>().npcName == name)
            {
                return npc.GetComponentInChildren<NPC>();
            }
        }
        return null;
    }

    public void ResetDailyInteraction()
    {
        foreach (GameObject npc in NPCs)
        {
            if (!npc.activeSelf ||  npc.GetComponentInChildren<NPC>() == null) { continue; }
            npc.GetComponentInChildren<NPC>().dailyInteraction = false;
        }
    }
                                                                                                                                                                                                                                                    
    public void NextDay(int day, bool isFeedDay)
    {
        MoveNPCs(day, 1);

        foreach (GameObject npc in NPCs)
        {
            if (!npc.activeSelf || npc.GetComponentInChildren<NPC>() != null)
            {
                npc.GetComponentInChildren<NPC>().isFeedDay = isFeedDay;
            }
        }
    }

    public void KillNPC(string name)
    {
        NPCName npcName;
        Enum.TryParse(name, out npcName);
        // Remove npc
        foreach (GameObject npc in NPCs)
        {
            if (npc.GetComponentInChildren<NPC>().npcName == npcName)
            {
                npc.SetActive(false);

                // TODO: start town suspicion task for next day

                break;
            }
        }

        // Skip to next day
        daySystem.npcKilled = true;
        daySystem.NextDay();
    }

    #region SAVE_SYSTEM
    public void SaveData()
    {
        foreach (GameObject npc in NPCs)
        {
            if (npc.GetComponentInChildren<NPC>() == null) { continue; }
            if (npc.activeSelf) { 
                npc.GetComponentInChildren<NPC>().SaveData();
            }
            PlayerPrefs.SetInt(npc.name, npc.activeSelf ? 1: 0);
        }
    }

    public void LoadData()
    {
        foreach (GameObject npc in NPCs)
        {
            if (PlayerPrefs.HasKey(npc.name) && PlayerPrefs.GetInt(npc.name) == 0)
            {
                npc.SetActive(false);
            }
            else
            {
                npc.SetActive(true);
            }

            if (npc.GetComponentInChildren<NPC>() == null) { continue; }
            
            npc.GetComponentInChildren<NPC>().LoadData();
        }
    }

    public void ResetData()
    {
        foreach (GameObject npc in NPCs)
        {
            npc.SetActive(true);
            if (npc.GetComponentInChildren<NPC>() == null) { continue; }
            npc.GetComponentInChildren<NPC>().ResetData();
        }
    }
    #endregion
}
