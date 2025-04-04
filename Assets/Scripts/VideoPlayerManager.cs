using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerInteractor playerInteractor;
    [SerializeField] private GameObject HUD;
    [SerializeField] private MusicManager musicManager;

    public bool isPlaying = false;
    private float length;
    private RawImage image;

    private void Start()
    {
        image = GetComponent<RawImage>();
        image.enabled = false;
    }
    public void StartVideo(VideoClip clip)
    {
        image.enabled = true;
        videoPlayer.clip = clip;
        length = (float)clip.length;
        videoPlayer.Prepare();
        videoPlayer.Play();

        // Disable player
        playerMovement.canmove = false;
        playerInteractor.canInteract = false;
        HUD.SetActive(false);

        // pause music
        // musicManager.PauseMusic();

        isPlaying = true;
        StartCoroutine(WaitClipToEnd());
    }   

    public void EndVideo()
    {
        image.enabled = false;
        playerMovement.canmove=true;
        playerInteractor.canInteract=true;
        HUD.SetActive(true);
        // musicManager.ResumeMusic();

        isPlaying = false;
    }

    private IEnumerator WaitClipToEnd()
    {
        yield return new WaitForSeconds(length);
        EndVideo();
    }
}
