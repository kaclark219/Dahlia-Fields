using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : InteractableObj
{
    [SerializeField] public GameObject uiScreen;
    [SerializeField] public InventoryManager inventoryManager;
    public Dictionary<string, int> mapValues;

    //slots
    [SerializeField] public Button[] slots;
    [SerializeField] public TextMeshProUGUI[] counts;
    [SerializeField] public Sprite[] flowerIcons;
    [SerializeField] public Sprite[] seedIcons;
    [SerializeField] public Image description;
    [SerializeField] public Sprite[] flowerDescriptions;
    [SerializeField] public Sprite[] seedDescriptions;
    [SerializeField] public Sprite blankDescription; 

    // Store button information (true = flower, false = seed)
    private Dictionary<Button, bool> isFlowerMap = new Dictionary<Button, bool>();
    // Store button IDs
    private Dictionary<Button, int> buttonIDMap = new Dictionary<Button, int>();

    public override void Start()
    {
        base.Start();
        uiScreen.SetActive(false);
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
            {"LilyValley", 8},
        };

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].gameObject.SetActive(false);

            // Add click listeners to each button
            int buttonIndex = i; // Need to create a local copy for the closure
            slots[i].onClick.AddListener(() => DisplayDescription(buttonIndex));
        }
    }

    public override void Update()
    {
        base.Update();
        if(Input.GetKeyDown(KeyCode.Escape))
        {   
            if(uiScreen.activeInHierarchy)
            {
                EndInteract();
            }
        }
    }

    public override void OnInteract()
    {
        base.OnInteract();
        SetUpView();
        uiScreen.SetActive(true);

        // If there's at least one item, display its description by default
        if (slots[0].gameObject.activeSelf)
        {
            DisplayDescription(0);
        }
    }

    public override void EndInteract()
    {
        base.EndInteract();
        isFlowerMap.Clear();
        buttonIDMap.Clear();

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].gameObject.SetActive(false);
        }
        uiScreen.SetActive(false);
    }

    public void DisplayDescription(int buttonIndex)
    {
        if (buttonIndex < 0 || buttonIndex >= slots.Length || !slots[buttonIndex].gameObject.activeSelf)
            return;

        Button clickedButton = slots[buttonIndex];

        if (isFlowerMap.TryGetValue(clickedButton, out bool isFlower) &&
            buttonIDMap.TryGetValue(clickedButton, out int flowerID))
        {
            if (isFlower)
            {
                // Display flower description
                if (flowerID < flowerDescriptions.Length)
                {
                    description.sprite = flowerDescriptions[flowerID];
                }
            }
            else
            {
                // Display seed description
                if (flowerID < seedDescriptions.Length)
                {
                    description.sprite = seedDescriptions[flowerID];
                }
            }
        }
    }

    public void SetUpView()
    {
        int i = 0;
        isFlowerMap.Clear();
        buttonIDMap.Clear();
        description.sprite = blankDescription; 

        foreach (string key in mapValues.Keys)
        {
            int id = mapValues[key];
            Flowers flower;
            Enum.TryParse(key, out flower);
            int flowerStock = inventoryManager.GetFlowerStock(flower);
            int seedStock = inventoryManager.GetSeedStock(flower);

            if (flowerStock > 0 && i < slots.Length)
            {
                slots[i].gameObject.SetActive(true);
                slots[i].GetComponent<Image>().sprite = flowerIcons[id];
                counts[i].text = flowerStock.ToString();

                // Store button info - this is a flower button
                isFlowerMap[slots[i]] = true;
                buttonIDMap[slots[i]] = id;

                i++;
            }

            if (seedStock > 0 && i < slots.Length)
            {
                slots[i].gameObject.SetActive(true);
                slots[i].GetComponent<Image>().sprite = seedIcons[id];
                counts[i].text = seedStock.ToString();

                // Store button info - this is a seed button
                isFlowerMap[slots[i]] = false;
                buttonIDMap[slots[i]] = id;

                i++;
            }
        }
    }
}