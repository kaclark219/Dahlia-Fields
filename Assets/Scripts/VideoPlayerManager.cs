using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerInteractor playerInteractor;
    [SerializeField] private GameObject HUD;
    [SerializeField] private MusicManager musicManager;

    private float length;

    private void Awake()
    {
        musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();
    }
    public void StartVideo(VideoClip clip)
    {
        videoPlayer.gameObject.SetActive(true);
        videoPlayer.clip = clip;
        length = (float)clip.length;
        videoPlayer.Play();

        // Disable player
        playerMovement.canmove = false;
        playerInteractor.canInteract = false;
        HUD.SetActive(false);

        // pause music
        musicManager.PauseMusic();

        StartCoroutine(WaitClipToEnd());
    }   

    public void EndVideo()
    {
        videoPlayer.gameObject.SetActive(false);
        playerMovement.canmove=true;
        playerInteractor.canInteract=true;
        HUD.SetActive(true);
        musicManager.ResumeMusic();
    }

    private IEnumerator WaitClipToEnd()
    {
        yield return new WaitForSeconds(length);
        EndVideo();
    }
}
