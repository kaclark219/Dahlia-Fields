using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlowerboxManager : MonoBehaviour
{
    [SerializeField] GameObject FlowerBoxUI;
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] TextMeshProUGUI[] counts;
    PlayerInteractor plint;
    public FlowerBox active;

    void Awake()
    {
        plint = GameObject.FindWithTag("Player").GetComponent<PlayerInteractor>();
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
        active = null;
    }

    public IEnumerator NextDayBox(){
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Flowerbox");
        foreach(var box in boxes){
            
            FlowerBox fb = box.GetComponent<FlowerBox>();
            //Debug.Log(fb);
            yield return new WaitUntil(() => fb != null);
            //Debug.Log("fao");
            StartCoroutine(fb.NextDayBox());
        }
    }

    public void Plant(string plantName){
        if(active != null){
            active.Plant(plantName);
        }
    }
}
