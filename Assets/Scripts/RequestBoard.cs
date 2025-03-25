using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestBoard : InteractableObj
{
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject[] requests;
    [SerializeField] DaySystem daySystem;
    [SerializeField] GameObject check1;
    [SerializeField] GameObject check2;
    int day;
    List<Request> requestList;

    void Start(){
        requestList = new List<Request>();
        day = daySystem.day;
        string[] lines = Resources.Load<TextAsset>("RequestBoard").ToString().Split("\n");
        for(int i = 1; i < lines.Length; i++){
            string[] info = lines[i].Split(",");
            requestList.Add(new Request(int.Parse(info[0]), info[1], getName(info[2]), int.Parse(info[3]), int.Parse(info[4]), info[5])); //If this line errors make sure the CSV doesn't have a blak line at the end
        }
    }

    public void ClickNote(int num){
        foreach(GameObject req in requests){
            req.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        text.SetActive(true);
        if(RequirementMet(num) == 1){
            check1.SetActive(true);
            check2.SetActive(false);
        }else if(RequirementMet(num) == 2){
            check1.SetActive(false);
            check2.SetActive(true);
        }else if(RequirementMet(num) == 3){
            check1.SetActive(true);
            check2.SetActive(true);
        }

    }

    private int RequirementMet(int num){
        return true;
    }

    private NPCName getName(string n){
        switch (name)
        {
            case "Gerald":
                return NPCName.Gerald:
            case "Sebastian":
                return NPCName.Sebastian:
            case "Charlie":
                return NPCName.Charlie:
            case "Megan":
                return NPCName.Megan:
            case "Ava":
                return NPCName.Ava:
            case "Bruce":
                return NPCName.Bruce:
            case "Maddie":
                return NPCName.Maddie:
            case "Poppy":
                return NPCName.Poppy:
            case "Linda":
                return NPCName.Linda:
            case "Jeremy":
                return NPCName.Jeremy:
            default:
                Debug.LogError($"Could not find name for {name}");
                return null;
        }
    }

    struct Request {
        public int day;
        public string flowerAmounts;
        public NPCName author;
        public int due;
        public int reward;
        public string trust;
    
        public Request(int d, string fa, NPCName a, int du, int r, string t) {
            day = d;
            flowerAmounts = fa;
            author = a;
            due = du;
            reward = r;
            trust = t;
        }
    }
}
