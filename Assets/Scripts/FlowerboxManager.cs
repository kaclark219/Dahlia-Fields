using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class FlowerboxManager : MonoBehaviour
{
    [SerializeField] private GameObject FlowerBoxUI;
    [SerializeField] TextMeshProUGUI[] counts;
    [SerializeField] public Image[] buttons; 
    [SerializeField] public Sprite[] baseSprites;
    [SerializeField] public Sprite[] selectedSprites;
    public Dictionary<string, int> mapValues;

    [Space]
    [SerializeField] private List<FlowerBox> FlowerBoxes; 
    [SerializeField] public GameObject exclaim;
    public FlowerBox ActiveBox;
    public string chosenFlower; 

    private InventoryManager inventoryManager;
    private PlayerInteractor plint;

    [SerializeField] private int numActiveBoxes = 2;
    private const string activeBoxesKey = "Active_Boxes";
    public bool openedBox = false;
    private SoundEffects effect; 
    

    void Awake()
    {
        plint = GameObject.FindWithTag("Player").GetComponent<PlayerInteractor>();
        inventoryManager = GameObject.Find("Inventory").GetComponent<InventoryManager>();
        effect = GameObject.Find("SoundEffectManager").GetComponent<SoundEffects>();
        mapValues = new Dictionary<string, int>()
        {
            {"Dandelion", 0},
            {"Daisy",  1},
            {"Poppy", 2},
            {"Tulip", 3},
            {"Rose", 4},
            {"Lavender", 5},
            {"PricklyPear", 6},
            {"Sunflower", 7},
            {"LilyValley", 8}
        };
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (FlowerBoxUI.activeInHierarchy && !exclaim.activeInHierarchy)
            {
                CloseUI();
            }
        }
    }

    public void OpenUI()
    {
        int i=0;
        foreach(var item in inventoryManager.inventory){
            counts[i].text = item.Value.seedStock.ToString();
            i++;
        }

        for(int j = 0; j < buttons.Length; j++)
        {
            buttons[j].sprite = baseSprites[j];
        }

        chosenFlower = " "; 

        FlowerBoxUI.SetActive(true);
    }

    public void CloseUI()
    {
        effect.PlayClose();
        FlowerBoxUI.SetActive(false);
        plint.EndInteract();
        ActiveBox = null;
    }

    public void NextDayBoxes()
    {
        UpdateVisibleBoxes();

        foreach (var box in FlowerBoxes)
        {
            if (box.transform.parent.gameObject.activeSelf)
            {
                box.NextDayBox();
            }
        }
    }

    public void SelectFlower(string flowerName)
    {
        effect.PlayUIClick();
        for (int j = 0; j < buttons.Length; j++)
        {
            buttons[j].sprite = baseSprites[j];
        }

        chosenFlower = flowerName;
        int id = mapValues[flowerName];
        buttons[id].sprite = selectedSprites[id]; 
    }

    public void Plant(){
        if(ActiveBox != null && chosenFlower != " "){
            Flowers flower;
            Enum.TryParse(chosenFlower, out flower);
            ActiveBox.Plant(flower);
        }
    }

    public bool AddBox()
    {
        if( numActiveBoxes == FlowerBoxes.Count)
        {
            return false;
        }
        numActiveBoxes++;
        return true;
    }

    private void UpdateVisibleBoxes()
    {
        int i = 0;
        foreach (FlowerBox box in FlowerBoxes)
        {
            if (i < numActiveBoxes)
            {
                box.transform.parent.gameObject.SetActive(true);
            }
            else
            {
                box.transform.parent.gameObject.SetActive(false);
            }
            i++;
        }
    }

    #region SAVE_SYSTEM
    public void SaveData()
    {
        foreach (FlowerBox box in FlowerBoxes)
        {
            if (box.transform.parent.gameObject.activeSelf)
            {
                box.SaveData();
            }
        }

        PlayerPrefs.SetInt(activeBoxesKey, numActiveBoxes);
        PlayerPrefs.SetInt("OpenedBox", openedBox ? 1 : 0);
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey(activeBoxesKey))
        {
            numActiveBoxes = PlayerPrefs.GetInt(activeBoxesKey);
        }
        else
        {
            numActiveBoxes = 2;
        }

        if (PlayerPrefs.HasKey("OpenedBox"))
        {
            openedBox = PlayerPrefs.GetInt("OpenedBox") == 1;
        }
        else
        {
            openedBox = false;
        }
        exclaim.SetActive(!openedBox);
        UpdateVisibleBoxes();

        foreach (FlowerBox box in FlowerBoxes)
        {
            if (box.transform.parent.gameObject.activeSelf) 
            {
                box.LoadData();
            }
        }
    }

    public void ResetData()
    {
        foreach (FlowerBox box in FlowerBoxes)
        {
            if (box.transform.parent.gameObject.activeSelf)
            {
                box.ResetData();
            }
        }
        openedBox = false;
        numActiveBoxes = 2;
        UpdateVisibleBoxes();
    }

    #endregion
}
