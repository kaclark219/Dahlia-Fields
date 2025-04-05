using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioSource speaker1;
    [SerializeField] AudioSource speaker2;
    [SerializeField] AudioClip morning;
    [SerializeField] AudioClip afternoon;
    [SerializeField] AudioClip evening;
    private bool primarySpeaker = true;
    [SerializeField] DaySystem daysystem;
    public float thisTime;

    void Start(){
        fadeIn();
    }

    void Update(){  
        thisTime = speaker1.time;
        if(primarySpeaker){
            if(daysystem.day%3 == 1 && speaker1.time >= 80){
                speaker2.clip = morning;
                speaker2.time = 6;
                speaker2.Play();
                primarySpeaker = false;
            }else if(daysystem.day%3 == 2 && speaker1.time >= 84){
                speaker2.clip = afternoon;
                speaker2.time = 0;
                speaker2.Play();
                primarySpeaker = false;
            }else if(daysystem.day%3 == 0 && speaker1.time >= 105){
                speaker2.clip = evening;
                speaker2.time = 0;
                speaker2.Play();
                primarySpeaker = false;
            }
        }else{
            if(daysystem.day%3 == 1 && speaker2.time >= 80){
                speaker1.clip = morning;
                speaker1.time = 6;
                speaker1.Play();
                primarySpeaker = true;
            }else if(daysystem.day%3 == 2 && speaker2.time >= 84){
                speaker1.clip = afternoon;
                speaker1.time = 0;
                speaker1.Play();
                primarySpeaker = true;
            }else if(daysystem.day%3 == 0 && speaker2.time >= 105){
                speaker1.clip = evening;
                speaker1.time = 0;
                speaker1.Play();
                primarySpeaker = true;
            }
        }
    }

    public void fadeOut()
    {
        while(speaker1.volume > 0){
            speaker1.volume = Math.Max(speaker1.volume - Time.deltaTime*.01f, 0f);
            speaker2.volume = speaker1.volume;
        }
        speaker1.Stop();
        speaker2.Stop();
    }

    public void fadeIn()
    {
        speaker1.volume = .5f;
        speaker2.volume = .5f;
        speaker1.time = 70;
        speaker2.time = 70;
        if(daysystem.day%3 == 1){
            speaker1.clip = morning;
        }else if(daysystem.day%3 == 2){
            speaker1.clip = afternoon;
        }else{
            speaker1.clip = evening;
        }
        primarySpeaker = true;
        speaker1.Play();
    }
}
