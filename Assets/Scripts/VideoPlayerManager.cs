using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject HUD;
    [SerializeField] private MusicManager musicManager;
    [SerializeField] private FadeInFadeOut transition;
    [Space]
    public VideoClip SleepClip;
    public VideoClip WakeUpClip;

    private RawImage image;
    private VideoPlayer videoPlayer;

    private Coroutine currCoroutine;
    private void Start()
    {
        image = GetComponent<RawImage>();
        image.enabled = false;
        videoPlayer = GetComponent<VideoPlayer>();
        transition = FindFirstObjectByType<FadeInFadeOut>();
    }

    private void Update()
    {
        if (currCoroutine != null && Input.GetKeyDown(KeyCode.Escape))
        {
            StopCoroutine(currCoroutine);
            EndVideo();
        }
    }

    public IEnumerator PlayNextDay(VideoClip cutscene, bool includeSleepAnimation)
    {
        
        if (includeSleepAnimation)
        {
            yield return StartVideo(SleepClip);
        }

        if (cutscene != null)
        {
            yield return StartVideo(cutscene);
        }


        yield return StartVideo(WakeUpClip);
    }

    public Coroutine StartVideo(VideoClip clip)
    {
        currCoroutine = StartCoroutine(PlayVideo(clip));
        return currCoroutine;
    }

    private IEnumerator PlayVideo(VideoClip clip)
    {
        HUD.SetActive(false);

        // pause music
        musicManager.PauseMusic();

        image.enabled = true;   
        image.color = Color.black;  // for smoother transition

        videoPlayer.clip = clip;
        float length = (float)clip.length;

        videoPlayer.Prepare();  // Prepare video and wait till it's done
        yield return new WaitUntil(() => videoPlayer.isPrepared == true);
        image.color = Color.white;
        videoPlayer.Play();

        yield return new WaitForSeconds(length);

        EndVideo();
    }

    private void EndVideo()
    {
        image.enabled = false;
        videoPlayer.Stop();
        videoPlayer.clip = null;

        HUD.SetActive(true);
        musicManager.ResumeMusic();

        currCoroutine = null;
    }
}
