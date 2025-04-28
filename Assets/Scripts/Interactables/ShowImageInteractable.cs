using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowImageInteractable : InteractableObj
{
    [SerializeField] private GameObject UI;
    private SoundEffects effect;

    public override void Awake()
    {
        base.Awake();
        effect = GameObject.Find("SoundEffectManager").GetComponent<SoundEffects>();

    }

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
        effect.PlayMail(); 
        base.OnInteract();
        UI.SetActive(true);
    }

    public override void EndInteract()
    {   
        effect.PlayClose();
        base.EndInteract();
        UI.SetActive(false);
    }
}
