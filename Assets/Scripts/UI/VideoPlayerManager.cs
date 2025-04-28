using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject HUD;
    [SerializeField] private FadeInFadeOut transition;
    [Space]
    public VideoClip SleepClip;
    public VideoClip WakeUpClip;
    [Space]
    public VideoClip MorningToAfternoon;
    public VideoClip AfternoonToEvening;

    private RawImage image;
    private VideoPlayer videoPlayer;

    private void Awake()
    {
        image = GetComponent<RawImage>();
        videoPlayer = GetComponent<VideoPlayer>();
        transition = FindFirstObjectByType<FadeInFadeOut>();
    }
    public IEnumerator PlayNextDay(VideoClip cutscene, bool startingGame)
    {
        HUD.SetActive(false);

        if (!startingGame)
        {
            yield return StartCoroutine(PrepareVideo(SleepClip));
            yield return StartCoroutine(PlayVideo());
            yield return new WaitForSeconds(1f);
        }
        else
        {
            yield return new WaitForSeconds(2f);
        }

        if (cutscene != null)
        {
            yield return StartCoroutine(PrepareVideo(cutscene));
            yield return StartCoroutine(PlayVideo());
            yield return new WaitForSeconds(1f);
        }

        yield return StartCoroutine(PrepareVideo(WakeUpClip));
        yield return StartCoroutine(PlayVideo());

        HUD.SetActive(true);
    }

    public IEnumerator PlayKillScene(VideoClip clip)
    {
        yield return StartCoroutine(PrepareVideo(clip));
        yield return StartCoroutine(PlayVideo());
        yield return new WaitForSeconds(3f);
        yield return StartCoroutine(PrepareVideo(WakeUpClip));
        yield return StartCoroutine(PlayVideo());
    }

    public IEnumerator PlayTimeChange(int time)
    {
        VideoClip clip = time == 2 ? MorningToAfternoon : AfternoonToEvening;   
        yield return StartCoroutine(PrepareVideo(clip));
        yield return StartCoroutine(PlayVideo());
    }

    public IEnumerator PrepareVideo(VideoClip clip)
    {
        videoPlayer.clip = clip;
        videoPlayer.Prepare(); 
        yield return new WaitUntil(() => videoPlayer.isPrepared);
    }

    public IEnumerator PlayVideo()
    {
        image.enabled = true;
        videoPlayer.Play();
        while (videoPlayer.isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                videoPlayer.Stop();
                break;
            }
            yield return null;
        }
        videoPlayer.clip = null;
        image.enabled = false;
        videoPlayer.Stop();
        videoPlayer.targetTexture.Release();
    }
}
