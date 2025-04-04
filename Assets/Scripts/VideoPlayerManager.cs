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
        // Disable player
        playerMovement.canmove = false;
        playerInteractor.canInteract = false;
        HUD.SetActive(false);

        // pause music
        musicManager.PauseMusic();

        isPlaying = true;

        StartCoroutine(LoadVideo(clip));
    }

    private IEnumerator LoadVideo(VideoClip clip)
    {
        image.enabled = true;
        image.color = Color.black;

        videoPlayer.clip = clip;
        length = (float)clip.length;

        videoPlayer.Prepare();
        yield return new WaitUntil(() => videoPlayer.isPrepared == true);
        image.color = Color.white;
        videoPlayer.Play();

        StartCoroutine(WaitClipToEnd());
    }

    public void EndVideo()
    {
        image.enabled = false;
        playerMovement.canmove=true;
        playerInteractor.canInteract=true;
        videoPlayer.clip = null;
        HUD.SetActive(true);
        musicManager.ResumeMusic();

        isPlaying = false;
    }

    private IEnumerator WaitClipToEnd()
    {
        yield return new WaitForSeconds(length);
        EndVideo();
    }
}
