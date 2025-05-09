using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDialogueInteractable : InteractableObj
{
    public TextAsset textAsset;
    public string DisplayName = "---";
    private InkManager inkManager;

    public override void Awake()
    {
        base.Awake();
        inkManager = GameObject.Find("InkManager").GetComponent<InkManager>();
    }

    public override void Start()
    {
        base.Start();
    }

    public override void OnInteract()
    {
        base.OnInteract();
        inkManager.StartStory(textAsset, this);
        inkManager.SetDialogueName(DisplayName);
    }

    public override void EndInteract()
    {
        base.EndInteract();
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
