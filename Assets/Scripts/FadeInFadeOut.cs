using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FadeInFadeOut : MonoBehaviour
{
    [SerializeField] public Image image;
    public Coroutine coroutine;

    private float alpha = 0f;
    private float defaultSpeed = 1.2f;

    private void Awake()
    {
        image = image ? image : GetComponent<Image>();
        image.enabled = false;
    }

    // inBetween is invoced in between the fade in, fade out transition
    // at End is invoced at the end
    public void StartTransition(UnityAction inBetween, UnityAction atEnd)
    {
        if (coroutine != null) { StopCoroutine(coroutine); }

        image.enabled = true;
        coroutine = StartCoroutine(FadeInFadeOutCoroutine(inBetween, atEnd));
    }

    public void FadeIn()
    {
        if (coroutine != null) { StopCoroutine(coroutine); }
        image.enabled = true;
        coroutine = StartCoroutine(FadeInCoroutine(defaultSpeed));
    }

    public void FadeOut()
    {
        if (coroutine != null) { StopCoroutine(coroutine); }
        image.enabled = true;
        coroutine = StartCoroutine(FadeOutCoroutine(defaultSpeed));
    }

    public void FadeIn(float speed)
    {
        if (coroutine != null) { StopCoroutine(coroutine); }
        image.enabled = true;
        coroutine = StartCoroutine(FadeInCoroutine(speed));
    }

    public void FadeOut(float speed)
    {
        if (coroutine != null) { StopCoroutine(coroutine); }
        image.enabled = true;
        coroutine = StartCoroutine(FadeOutCoroutine(speed));
    }

    // Basic transition for basic functions to be called in between the transition and at the end
    private IEnumerator FadeInFadeOutCoroutine(UnityAction inBetween, UnityAction atEnd)
    {
        yield return null;

        for (float i = 0; i < 1.2f; i += Time.deltaTime)
        {
            alpha = Mathf.Lerp(0f, 1f, i / 1.2f);
            image.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        inBetween?.Invoke();
        yield return new WaitForSeconds(.5f);

        for (float i = 0; i < 1.2f; i += Time.deltaTime)
        {
            alpha = Mathf.Lerp(1f, 0f, i / 1.2f);
            image.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        atEnd?.Invoke();
        yield return null;

        coroutine = null;
        image.enabled = false;
    }


    // For more complicated transitions, where complex functions need to be called in between 
    private IEnumerator FadeInCoroutine(float speed)
    {
        image.color = new Color(0, 0, 0, 0);

        yield return null;

        for (float i = 0; i < speed; i += Time.deltaTime)
        {
            alpha = Mathf.Lerp(0f, 1f, i / 1.2f);
            image.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        coroutine = null;
        image.color = new Color(0, 0, 0, 1);

    }

    private IEnumerator FadeOutCoroutine(float speed)
    {
        image.color = new Color(0, 0, 0, 1.0f);

        yield return null;

        for (float i = 0; i < speed; i += Time.deltaTime)
        {
            alpha = Mathf.Lerp(1f, 0f, i / 1.2f);
            image.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        coroutine = null;
        image.enabled = false;
    }

}
