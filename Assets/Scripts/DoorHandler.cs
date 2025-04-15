using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class DoorHandler : InteractableObj
{
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject location;
    public bool isexit;
    private FadeInFadeOut transition;
    private SoundEffects effect; 
    float alpha = 0f; 

    public override void Awake()
    {
        base.Awake();
        transition = FindObjectOfType<FadeInFadeOut>();
        effect = GameObject.Find("SoundEffectManager").GetComponent<SoundEffects>();
        player = GameObject.Find("Player");
    }

    public override void Start()
    {
        base.Start();
    }

    public override void OnInteract()
    {
        base.OnInteract();
        effect.PlayDoor();
        StartCoroutine(transition.FullTransition(TeleportPlayer, base.EndInteract));
    }

    private void TeleportPlayer()
    {
        player.transform.position = new Vector2(location.transform.position.x, location.transform.position.y + (isexit ? -1 : 1));
    }

    override public void Update(){
        if (active){
            if (Popup) { Popup.SetActive(true); }
            if(Input.GetKeyDown(KeyCode.E) && plint.canInteract){
                OnInteract();
            }
        }else{
            if (Popup) { Popup.SetActive(false); }
        }
    }
}
