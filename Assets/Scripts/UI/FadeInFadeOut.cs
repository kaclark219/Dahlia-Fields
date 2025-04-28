using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FadeInFadeOut : MonoBehaviour
{
    private Image image;

    private float alpha = 0f;
    private float defaultSpeed = 1.2f;

    private void Awake()
    {
        image = image ? image : GetComponent<Image>();
        image.enabled = true;
        image.color = new Color(0,0,0,1.0f);
    }

    public void BlackScreen()
    {
        image.enabled=true;
        image.color = new Color(0, 0, 0, 1.0f);
    }

    // Basic transition for basic functions to be called in between the transition and at the end
    public IEnumerator FullTransition(UnityAction inBetween, UnityAction atEnd)
    {
        image.enabled=true;
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

        image.enabled = false;
    }


    // For more complicated transitions, where complex functions need to be called in between 
    public IEnumerator FadeIn()
    {
        image.enabled = true;

        image.color = new Color(0, 0, 0, 0);

        yield return null;

        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            alpha = Mathf.Lerp(0f, 1f, i);
            image.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        image.color = Color.black;
    }

    public IEnumerator FadeOut()
    {
        image.enabled = true;

        image.color = new Color(0, 0, 0, 1.0f);

        yield return null;

        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            alpha = Mathf.Lerp(1f, 0f, i);
            image.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        image.enabled = false;
    }

}
