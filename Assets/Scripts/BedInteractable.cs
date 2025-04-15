using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BedInteractable : InteractableObj
{
    [SerializeField] private GameObject bedUI;
    [SerializeField] private TextMeshProUGUI description;

    private DaySystem daySystem;
    private SoundEffects effect; 

    public override void Start()
    {
        base.Start();
        bedUI.SetActive(false);
    }
    public override void Awake()
    {
        base.Awake();
        daySystem = GameObject.Find("GameManager").GetComponent<DaySystem>();
        effect = GameObject.Find("SoundEffectManager").GetComponent<SoundEffects>();
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (bedUI.activeInHierarchy)
            {
                EndInteract();
            }
        }
    }

    public override void OnInteract()
    {
        base.OnInteract();
        bedUI.SetActive(true);

        if (playerData.GetEnergy() > 0)
        {
            description.text = "You have energy left to spend today! \n Sleeping will end the day early.";
        }
        else
        {
            description.text = "You had a busy day today. Sleep to end the day and rest up.";
        }
    }

    public override void EndInteract()
    {   
        effect.PlayClose();
        base.EndInteract();
        bedUI.SetActive(false);
    }

    public void Sleep()
    {   
        effect.PlayUIClick();
        daySystem.NextDay();
        bedUI.SetActive(false);
    }
}
