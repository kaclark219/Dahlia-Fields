using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedInteractable : InteractableObj
{
    private DaySystem daySystem;

    private void Awake()
    {
        daySystem = GameObject.Find("GameManager").GetComponent<DaySystem>();
    }
    public override void OnInteract()
    {
        base.OnInteract();
        daySystem.NextDay();
        EndInteract();

    }

    public override void EndInteract()
    {
        base.EndInteract();
    }
}
