using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayerInteractor : MonoBehaviour
{
    // Logic when interacting with stuff that'll affect player data
    public List<InteractableObj> list = new List<InteractableObj>();
    public PlayerMovement pm;
    public bool canInteract = true;
    [SerializeField] GameObject map;

    private Rigidbody2D rb;
    private InteractableObj closest;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pm = GetComponent<PlayerMovement>();
    }

    void Update(){
        if (list.Count > 0){
            closest = list[0];
            closest.active = false;
            float closestdistance = Vector2.Distance(closest.gameObject.transform.position, rb.position);
            for(int i = 1; i < list.Count; i++){
                list[i].active = false;
                float distance = Vector2.Distance(list[i].gameObject.transform.position, rb.position);
                if(distance < closestdistance){
                    closest = list[i];
                    closestdistance = distance;
                }
            }
            
            closest.active = true;
            closest.frame = Time.time;
        }

        if(Input.GetKeyDown(KeyCode.M) && canInteract){
            map.GetComponent<Map>().open();
            map.SetActive(true);
        }else if(Input.GetKeyDown(KeyCode.M) && !canInteract && map.activeSelf){
            map.GetComponent<Map>().close();
        }
    }

    public void Interact()
    {
        pm.canmove = false;
        canInteract = false;
    }

    public void EndInteract()
    {
        pm.canmove = true;
        canInteract = true;
    }

    public void Plant(Flowers plant){
        if(closest is FlowerBox){
            (closest as FlowerBox).Plant(plant);
        }
    }
}
