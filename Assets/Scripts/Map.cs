using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] PlayerInteractor plint;

    Dictionary<string, bool> talked;

    public void open(){
        Debug.Log(plint);
        plint.canInteract = false;
    }

    public void close(){
        plint.canInteract = true;
        this.transform.gameObject.SetActive(false);
    }

    public void log(string npc){
        
    }

    public void nextDay(){
        talked.Clear();
    }
}
