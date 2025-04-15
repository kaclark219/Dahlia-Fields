using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffects : MonoBehaviour
{
    [SerializeField] private AudioClip door;
    [SerializeField] private AudioClip chestOpen;
    [SerializeField] private AudioClip chestClose;
    [SerializeField] private AudioClip mailbox;
    [SerializeField] private AudioClip noMail;
    [SerializeField] private AudioClip planting;
    [SerializeField] private AudioClip watering;
    [SerializeField] private AudioClip harvesting;
    [SerializeField] private AudioClip purchase;
    [SerializeField] private AudioClip requestComplete;
    [SerializeField] private AudioClip walking;
    [SerializeField] private AudioClip uiClick;
    [SerializeField] private AudioClip close; 

    [SerializeField] private AudioSource speaker;

    [SerializeField] Slider volumeSlider;
    private float volume = 0.5f;

    public void VolumeControl(float value)
    {
        value = volumeSlider.value;
        speaker.volume = value;
    }

    public void PlayDoor()
    {
        speaker.clip = door;
        speaker.Play();
    }

    public void PlayChestOpen()
    {
        speaker.clip = chestOpen;
        speaker.Play();
    }

    public void PlayChestClose()
    {
        speaker.clip = chestClose;
        speaker.Play();
    }

    public void PlayMail()
    {
        speaker.clip = mailbox;
        speaker.Play();
    }

    public void PlayNoMail()
    {
        speaker.clip = noMail;
        speaker.Play();
    }

    public void PlayPlant()
    {
        speaker.clip = planting;
        speaker.Play();
    }

    public void PlayWater()
    {
        speaker.clip = watering;
        speaker.Play();
    }

    public void PlayHarvest()
    {
        speaker.clip = harvesting;
        speaker.Play();
    }

    public void PlayPurchase()
    {
        speaker.clip = purchase;
        speaker.Play();
    }

    public void PlayRequest()
    {
        speaker.clip = requestComplete;
        speaker.Play();
    }
    
    public void PlayWalking()
    {
        speaker.clip = walking;
        speaker.Play();
    }

    public void PlayUIClick()
    {
        speaker.clip = uiClick;
        speaker.Play();
    }

    public void PlayClose()
    {
        speaker.clip = close;
        speaker.Play();
    }

}
