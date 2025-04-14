using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class RequestBoard : InteractableObj
{
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject[] requests;
    [SerializeField] DaySystem daySystem;
    [SerializeField] GameObject check1;
    [SerializeField] GameObject check2;
    [SerializeField] GameObject complete;
    [SerializeField] InventoryManager inventory;
    [SerializeField] DialogueVariables dvar;
    [SerializeField] GameObject remaining;
    [SerializeField] public GameObject exclaim;
    int day;
    Dictionary<GameObject, Request> requestList;
    public bool openedBoard = false;
    private SoundEffects effect;

    public override void Awake()
    {
        base.Awake();
        effect = GameObject.Find("SoundEffectManager").GetComponent<SoundEffects>();
    }

    public override void Start()
    {
        base.Start();
        requestList = new Dictionary<GameObject, Request>();
        string[] lines = Resources.Load<TextAsset>("RequestBoard").ToString().Split("\n");
        for (int i = 1; i < lines.Length; i++)
        {
            string[] info = lines[i].Split(",");
            requestList.Add(requests[i - 1], new Request(int.Parse(info[0]), info[1], getName(info[2]), int.Parse(info[3]), int.Parse(info[4]), info[5], int.Parse(info[6]))); //If this line errors make sure the CSV doesn't have a blak line at the end
        }
        Refresh();
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvas.activeInHierarchy && !exclaim.activeInHierarchy)
            {
                CloseBoard();
            }
        }
    }

    private void Refresh(){
        day = daySystem.day;
        foreach (GameObject req in requests)
        {
            req.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        check1.SetActive(false);
        check2.SetActive(false);
        complete.SetActive(false);

        foreach (GameObject req in requests)
        {
            if (isDay(requestList[req]) && requestList[req].completed == 0)
            {
                req.SetActive(true);
            }
            else
            {
                req.SetActive(false);
            }
        }

        remaining.SetActive(false);
    }

    private bool isDay(Request request)
    {
        return (day >= request.day && day <= request.due);
    }

    private void LoseFlowers(GameObject request){
        Request req = requestList[request];
        string[] needs = req.flowerAmounts.Split(" + ");
        Flowers first = GetFlowers(needs[0].Split(" (x")[0]);
        int firstAmount = int.Parse(needs[0].Split(" (x")[1].Split(")")[0]); //This is optimal I swear
        if (inventory.GetFlowerStock(first) >= firstAmount)
        {
            inventory.SetFlowerStock(first, -1 * firstAmount);
        }else{
            Debug.LogError("Not enough " + first);
        }

        if (needs.Length > 1)
        {
            Flowers second = GetFlowers(needs[1].Split(" (x")[0]);
            int secondAmount = int.Parse(needs[1].Split(" (x")[1].Split(")")[0]);
            if (inventory.GetFlowerStock(second) >= secondAmount)
            {
                inventory.SetFlowerStock(second, -1 * secondAmount);
            }else{
                Debug.LogError("Not enough " + second);
            }
        }
    }
    
    private void GainTrust(GameObject request){
        playerData.ModifyMoney(requestList[request].reward);
        string[] trusts = requestList[request].trust.Split("; ");
        foreach (string people in trusts){
            string[] statement = people.Split(" Trust ");
            dvar.AddTrust(statement[1], int.Parse(statement[0]));
        }
    }
    
    private void MarkComplete(GameObject request){
        Request temp = requestList[request];
        temp.completed = 1;
        requestList[request] = temp;
        Refresh();
    }

    private int RequirementMet(GameObject text)
    {
        int result = 0;
        Request req = requestList[text.transform.parent.gameObject];
        string[] needs = req.flowerAmounts.Split(" + ");
        Flowers first = GetFlowers(needs[0].Split(" (x")[0]);
        int firstAmount = int.Parse(needs[0].Split(" (x")[1].Split(")")[0]); //This is optimal I swear
        if (inventory.GetFlowerStock(first) >= firstAmount)
        {
            result += 1;
        }

        if (needs.Length > 1)
        {
            Flowers second = GetFlowers(needs[1].Split(" (x")[0]);
            int secondAmount = int.Parse(needs[1].Split(" (x")[1].Split(")")[0]);
            if (inventory.GetFlowerStock(second) >= secondAmount)
            {
                result += 2;
            }
        }
        return result;
    }

    public int numRequests(GameObject text){
        Request req = requestList[text.transform.parent.gameObject];
        string[] needs = req.flowerAmounts.Split(" + ");
        return needs.Length;
    }

    private NPCName getName(string n)
    {
        switch (n)
        {
            case "Gerald":
                return NPCName.Gerald;
            case "Sebastian":
                return NPCName.Sebastian;
            case "Charlie":
                return NPCName.Charlie;
            case "Megan":
                return NPCName.Megan;
            case "Ava":
                return NPCName.Ava;
            case "Bruce":
                return NPCName.Bruce;
            case "Maddie":
                return NPCName.Maddie;
            case "Poppy":
                return NPCName.Poppy;
            case "Linda":
                return NPCName.Linda;
            case "Jeremy":
                return NPCName.Jeremy;
            default:
                Debug.LogError($"Could not find name for {name}");
                return NPCName.Sebastian;
        }
    }

    private Flowers GetFlowers(string n)
    {
        switch (n)
        {
            case "Dandelion":
                return Flowers.Dandelion;
            case "Daisy":
                return Flowers.Daisy;
            case "Poppy":
                return Flowers.Poppy;
            case "Tulip":
                return Flowers.Tulip;
            case "Rose":
                return Flowers.Rose;
            case "Lavender":
                return Flowers.Lavender;
            case "PricklyPear":
                return Flowers.PricklyPear;
            case "Sunflower":
                return Flowers.Sunflower;
            case "LilyValley":
                return Flowers.LilyValley;
            default:
                Debug.LogError($"Could not find name for {n}");
                return Flowers.Dandelion;
        }
    }

    public void ClickNote(GameObject text)
    {
        foreach (GameObject req in requests)
        {
            req.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        text.SetActive(true);
        check1.SetActive(false);
        check2.SetActive(false);
        if (RequirementMet(text) == 1)
        {
            check1.SetActive(true);
            check2.SetActive(false);
        }
        else if (RequirementMet(text) == 2)
        {
            check1.SetActive(false);
            check2.SetActive(true);
        }
        else if (RequirementMet(text) == 3)
        {
            check1.SetActive(true);
            check2.SetActive(true);
        }

        if((RequirementMet(text) == 1 && numRequests(text) == 1) || (RequirementMet(text) == 3 && numRequests(text) == 2)){
            complete.SetActive(true);
        }else{
            complete.SetActive(false);
        }

        Request req1 = requestList[text.transform.parent.gameObject];
        remaining.SetActive(true);
        remaining.GetComponent<TMPro.TextMeshProUGUI>().text = "" + (req1.due - day + 1);
        if((req1.due - day + 1) == 1){
            remaining.GetComponent<TMPro.TextMeshProUGUI>().color = Color.red;
        }else if((req1.due - day + 1) == 2){
            remaining.GetComponent<TMPro.TextMeshProUGUI>().color = Color.yellow;
        }else{
            remaining.GetComponent<TMPro.TextMeshProUGUI>().color = Color.green;
        }
    }

    public void PlaceOrder(){
        foreach (GameObject req in requests){
            if(req.transform.GetChild(0).gameObject.activeSelf){
                effect.PlayRequest(); 
                LoseFlowers(req);
                GainTrust(req);
                MarkComplete(req);
            }
        }
    }

    public void CloseBoard(){
        canvas.SetActive(false);
        EndInteract();
    }

    override public void OnInteract(){
        base.OnInteract();
        if(exclaim.activeSelf){
            exclaim.GetComponent<Tutorial>().RequestBoardTutorial();
        }
        canvas.SetActive(true);
        Refresh();
    }

    struct Request
    {
        public int day;
        public string flowerAmounts;
        public NPCName author;
        public int due;
        public int reward;
        public string trust;
        public int completed;

        public Request(int d, string fa, NPCName a, int du, int r, string t, int c)
        {
            day = d;
            flowerAmounts = fa;
            author = a;
            due = du;
            reward = r;
            trust = t;
            completed = c;
        }
    }


    #region SAVE_SYSTEM

    public void SaveData()
    {
        foreach (KeyValuePair<GameObject, Request> req in requestList)
        {
            string key = req.Value.author.ToString() + "_" + req.Value.day + "_" + "Request";
            PlayerPrefs.SetInt(key, req.Value.completed);
        }

        PlayerPrefs.SetInt("OpenedBoard", openedBoard ? 1 : 0);
    }

    private IEnumerator Load(){
        yield return new WaitUntil(() => (requestList != null && requestList.Count == 13));

        List<GameObject> keys = new List<GameObject>(requestList.Keys);
        foreach (GameObject key in keys)
        {
            Request req = requestList[key]; 
            string prefKey = req.author.ToString() + "_" + req.day + "_" + "Request";

            if (PlayerPrefs.HasKey(prefKey))
            {
                req.completed = PlayerPrefs.GetInt(prefKey);
                requestList[key] = req; 
            }
        }

        if (PlayerPrefs.HasKey("OpenedBoard"))
        {
            openedBoard = PlayerPrefs.GetInt("OpenedBoard") == 1;
        }
        else
        {
            openedBoard = false;
        }
        exclaim.SetActive(!openedBoard);
    }

    public void LoadData()
    {
        StartCoroutine(Load());
    }

    public void ResetData()
    {
        if (requestList == null) { return; }
        requestList.Clear();
        string[] lines = Resources.Load<TextAsset>("RequestBoard").ToString().Split("\n");
        for (int i = 1; i < lines.Length; i++)
        {
            string[] info = lines[i].Split(",");
            requestList.Add(requests[i - 1], new Request(int.Parse(info[0]), info[1], getName(info[2]), int.Parse(info[3]), int.Parse(info[4]), info[5], int.Parse(info[6]))); //If this line errors make sure the CSV doesn't have a blak line at the end
        }
        Refresh();

        openedBoard = false;
        exclaim.SetActive(true);
    }
    #endregion
}
