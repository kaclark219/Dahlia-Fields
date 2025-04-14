using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUI : MonoBehaviour
{
    [SerializeField] GameObject UI;

    private DaySystem daySystem;

    private void Awake()
    {
        daySystem = FindFirstObjectByType<DaySystem>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            UI.SetActive(!UI.activeSelf);
            if (UI.activeSelf)
            {
                daySystem.playCutscenes = false;
            }
        }
    }
}
