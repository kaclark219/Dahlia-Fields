using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedInteractable : InteractableObj
{
    private DaySystem daySystem;
    private MusicManager musicManager;

    public override void Awake()
    {
        base.Awake();
        daySystem = GameObject.Find("GameManager").GetComponent<DaySystem>();
        musicManager = FindFirstObjectByType<MusicManager>();
    }
    public override void OnInteract()
    {
        daySystem.NextDay();
        //Suspend the music
        musicManager.fadeOut();
    }
}
