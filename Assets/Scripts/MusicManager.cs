using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

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

    [SerializeField] Slider volumeSlider;
    private float volume = 0.5f;
    private Coroutine coroutine = null;

    // void Start(){
    //     fadeIn();
    // }

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
        coroutine = StartCoroutine(Fade());
    }

    private IEnumerator Fade(){
        for(int i = 0; i < 100; i++){
            yield return new WaitForSeconds(.01f);
            speaker1.volume -= volume / 100.0f;
            speaker2.volume = speaker1.volume;
        }
        speaker1.Stop();
        speaker2.Stop();
        coroutine = null;
    }

    public void fadeIn()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        speaker1.volume = volume;
        speaker2.volume = volume;
        speaker1.time = 70;
        speaker2.time = 70;
        if (daysystem.day % 3 == 1) {
            speaker1.clip = morning;
        } else if (daysystem.day % 3 == 2) {
            speaker1.clip = afternoon;
        } else {
            speaker1.clip = evening;
        }
        primarySpeaker = true;
        speaker1.Play();
    }

    public void VolumeControl()
    {
        float value = volumeSlider.value;
        volume = value;
    }

    // TODO: Save player's volume setting
}
