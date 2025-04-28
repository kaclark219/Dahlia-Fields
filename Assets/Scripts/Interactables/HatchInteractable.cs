using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchInteractable : InteractableObj
{
    public string DisplayName = "---";
    public TextAsset day1;
    public TextAsset day2to3;
    public TextAsset day5to6;
    public TextAsset beforeFeedDay;
    public TextAsset feedDay;
    public TextAsset afterFeedDay;
    public AudioClip laugh;



    private InkManager inkManager;
    private DaySystem daySystem;
    private AudioSource audioSource;
    private bool wasFeedDay = false;

    public override void Awake()
    {
        base.Awake();
        inkManager = GameObject.Find("InkManager").GetComponent<InkManager>();
        daySystem = FindFirstObjectByType<DaySystem>();
        audioSource = GetComponent<AudioSource>();
    }

    public override void Start()
    {
        base.Start();
    }

    public override void OnInteract()
    {
        base.OnInteract();
        int day = daySystem.day;
        if (daySystem.isFeedDay)
        {
            inkManager.StartStory(feedDay, this);
            inkManager.SetDialogueName(DisplayName);
            wasFeedDay = true;
        }
        else if (wasFeedDay)
        {
            wasFeedDay = false;
            inkManager.StartStory(afterFeedDay, this);
            inkManager.SetDialogueName(DisplayName);
        }
        else if (day == 7 || day == 13 || day == 18 || day == 22 || day == 25)
        {
            inkManager.StartStory(beforeFeedDay, this);
            inkManager.SetDialogueName(DisplayName);
        }
        else if (day == 1)
        {
            inkManager.StartStory(day1, this);
            inkManager.SetDialogueName(DisplayName);
        }
        else if (day == 2 || day == 3)
        {
            inkManager.StartStory(day2to3, this);
            inkManager.SetDialogueName(DisplayName);
        }
        else if (day == 5 || day == 6)
        {
            inkManager.StartStory(day5to6, this);
            inkManager.SetDialogueName(DisplayName);
        }
        else
        {
            audioSource.clip = laugh;
            audioSource.Play();
            EndInteract();
        }

    }

    public override void EndInteract()
    {
        base.EndInteract();
    }

}
