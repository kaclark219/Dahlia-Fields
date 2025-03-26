using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioSource speaker1;
    [SerializeField] AudioSource speaker2;
    [SerializeField] AudioClip morning;
    [SerializeField] AudioClip afternoon;
    [SerializeField] AudioClip evening;
    private bool primarySpeaker = true;
    [SerializeField] DaySystem daysystem;

    void Start(){
        speaker1.clip = morning;
        primarySpeaker = true;
        speaker1.Play();
    }

    void Update(){  
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
            }else if(daysystem.day%3 == 3 && speaker1.time >= 104){
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
            }else if(daysystem.day%3 == 3 && speaker2.time >= 104){
                speaker1.clip = evening;
                speaker1.time = 0;
                speaker1.Play();
                primarySpeaker = true;
            }
        }
    }

    // TODO: able to pause and unpause music for playing Cutscene audio
    public void PauseMusic()
    {
    }

    public void ResumeMusic()
    {
    }
}
