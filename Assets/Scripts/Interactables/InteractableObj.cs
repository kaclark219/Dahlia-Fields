using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObj : MonoBehaviour
{
    [Header("Intractable Object")]
    [SerializeField] public GameObject Popup;
    public bool active = false;

    [HideInInspector] public PlayerInteractor plint;
    [HideInInspector] public float frame = 0;
    [HideInInspector] public SpriteRenderer sr;
    [HideInInspector] public PlayerMovement pm;
    [HideInInspector] public PlayerData playerData;


    public virtual void Awake(){
        pm = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        playerData = GameObject.Find("Player").GetComponent< PlayerData>(); 
        sr = GetComponentInParent<SpriteRenderer>();
    }

    public virtual void Start()
    {
        if (Popup) { Popup.SetActive(false); }
        plint = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerInteractor>();
    }

    virtual protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.gameObject.GetComponent<PlayerInteractor>().canInteract && !plint.list.Contains(this))
        {
            plint.list.Add(this);
        }
    }
    virtual protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && plint.list.Contains(this))
        {
            plint.list.Remove(this);
            active = false;
        }
    }

    public virtual void Update()
    {
        if (active){
            if (Popup) { Popup.SetActive(true); }
            if(Input.GetKeyDown(KeyCode.E) && plint.canInteract){
                OnInteract();
            }
        }else{
            if (Popup) { Popup.SetActive(false); }
            // if(sr.sortingOrder != 6){sr.sortingOrder=6;}
        }

        if(pm.rb.position.y > transform.position.y){
            sr.sortingOrder = 6;
        }else{
            sr.sortingOrder = 3;
        }
    }

    public virtual void OnInteract(){
        plint.Interact();
    }
    public virtual void EndInteract(){
        plint.EndInteract();
    }
}
