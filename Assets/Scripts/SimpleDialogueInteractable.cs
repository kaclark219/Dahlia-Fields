using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDialogueInteractable : InteractableObj
{
    public TextAsset textAsset;
    private InkManager inkManager;

    private void Awake()
    {
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
    }

    public override void EndInteract()
    {
        base.EndInteract();
    }
}
