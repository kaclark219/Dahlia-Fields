using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowImageInteractable : InteractableObj
{
    [SerializeField] private GameObject UI;

    public override void Start()
    {
        base.Start();
        UI.SetActive(false);
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (UI.activeInHierarchy)
            {
                EndInteract(); 
            }
        }
    }

    public override void OnInteract()
    {
        base.OnInteract();
        UI.SetActive(true);
    }

    public override void EndInteract()
    {
        base.EndInteract();
        UI.SetActive(false);
    }
}
