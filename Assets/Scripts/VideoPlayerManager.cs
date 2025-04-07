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

    private RawImage image;
    private VideoPlayer videoPlayer;
    private float length;
    private void Start()
    {
        image = GetComponent<RawImage>();
        videoPlayer = GetComponent<VideoPlayer>();
        transition = FindFirstObjectByType<FadeInFadeOut>();
    }
    public IEnumerator PlayNextDay(VideoClip cutscene, bool includeSleepAnimation)
    {
        HUD.SetActive(false);
        image.enabled =true;

        if (includeSleepAnimation)
        {
            yield return StartCoroutine(transition.FadeIn(3));

            yield return StartCoroutine(PrepareVideo(SleepClip));
            yield return StartCoroutine(PlayVideo());
        }

        if (cutscene != null)
        {
            yield return StartCoroutine(PrepareVideo(cutscene));
            yield return StartCoroutine(PlayVideo());
        }

        yield return StartCoroutine(PrepareVideo(WakeUpClip));
        yield return StartCoroutine(PlayVideo());

        yield return StartCoroutine(transition.FadeOut(3));

        HUD.SetActive(true);
        image.enabled = false;
    }

    public IEnumerator PrepareVideo(VideoClip clip)
    {
        image.enabled=true;
        image.color = Color.black;
        videoPlayer.clip = clip;
        length = (float)clip.length;
        videoPlayer.Prepare();  // Prepare video and wait till it's done
        yield return new WaitUntil(() => videoPlayer.isPrepared == true);
        image.color = Color.white;
    }

    private IEnumerator PlayVideo()
    {
        videoPlayer.Play();
        yield return new WaitForSeconds(length);
        videoPlayer.clip = null;
        image.enabled = false;
    }
}
