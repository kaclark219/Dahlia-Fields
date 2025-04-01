using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedInteractable : InteractableObj
{
    private DaySystem daySystem;

    public override void Awake()
    {
        base.Awake();
        daySystem = GameObject.Find("GameManager").GetComponent<DaySystem>();
    }
    public override void OnInteract()
    {
        daySystem.NextDay();

    }
}
