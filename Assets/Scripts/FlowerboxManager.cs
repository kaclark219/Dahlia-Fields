using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class FlowerboxManager : MonoBehaviour
{
    [SerializeField] private GameObject FlowerBoxUI;
    [SerializeField] TextMeshProUGUI[] counts;
    [SerializeField] private List<FlowerBox> FlowerBoxes; 
    public FlowerBox ActiveBox;

    private InventoryManager inventoryManager;
    private PlayerInteractor plint;

    void Awake()
    {
        plint = GameObject.FindWithTag("Player").GetComponent<PlayerInteractor>();
        inventoryManager = GameObject.Find("Inventory").GetComponent<InventoryManager>();
    }

    public void OpenUI()
    {
        int i=0;
        foreach(var item in inventoryManager.inventory){
            counts[i].text = item.Value.seedStock.ToString();
            i++;
        }
        FlowerBoxUI.SetActive(true);
    }

    public void CloseUI()
    {
        FlowerBoxUI.SetActive(false);
        plint.EndInteract();
        ActiveBox = null;
    }

    public void NextDayBoxes(){
        //GameObject[] boxes = GameObject.FindGameObjectsWithTag("Flowerbox");
        foreach(var box in FlowerBoxes)
        {
            
            FlowerBox fb = box.GetComponent<FlowerBox>();
            //Debug.Log(fb);
            //yield return new WaitUntil(() => fb != null);
            //Debug.Log("fao");
            //StartCoroutine(fb.NextDayBox());
            fb.NextDayBox();
        }
    }

    public void Plant(string plantName){
        if(ActiveBox != null){
            Flowers flower;
            Enum.TryParse(plantName, out flower);
            ActiveBox.Plant(flower);
        }
    }

    #region SAVE_SYSTEM
    public void SaveData()
    {

    }

    public void LoadData()
    {

    }

    public void ResetData()
    {

    }

    #endregion
}
