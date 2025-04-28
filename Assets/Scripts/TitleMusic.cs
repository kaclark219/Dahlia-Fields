using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TitleMusic : MonoBehaviour
{
    [SerializeField] AudioSource speaker1;
    [SerializeField] AudioSource speaker2;
    [SerializeField] AudioClip title;
    private bool primarySpeaker = true;

    private float volume = 0.5f;
    private Coroutine coroutine = null;

    // Start is called before the first frame update
    void Start()
    {
        fadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        if(primarySpeaker){
            if(speaker1.time >= 88){
                speaker2.clip = title;
                speaker2.time = 0;
                speaker2.Play();
                primarySpeaker = false;
            }
        }else{
            if(speaker2.time >= 88){
                speaker1.clip = title;
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

    public void StopMusic()
    {
        speaker1.Stop();
        speaker2.Stop();
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
        speaker1.time = 0;
        speaker2.time = 0;
        speaker1.clip = title;
        primarySpeaker = true;
        speaker1.Play();
    }
}
