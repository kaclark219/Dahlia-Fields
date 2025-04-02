using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingNoteInteractable : ShowImageInteractable
{
    private DaySystem daySystem;

    public override void Awake()
    {
        base.Awake();
        daySystem = FindFirstObjectByType<DaySystem>();
    }

    public override void Update()
    {
        base.Update();
        if (daySystem.day != 1)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }

}
