using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Tutorial : MonoBehaviour
{
    private FlowerboxManager flowerManager;
    private RequestBoard requestboard;
    [SerializeField] private GameObject img;
    [SerializeField] private GameObject button;
    [SerializeField] private Sprite pic;
    private int page = 0;
    private bool finished = false;
    public float voffset = 0.0f;

    void Awake(){
        flowerManager = GameObject.Find("FlowerboxManager").GetComponent<FlowerboxManager>();
        requestboard = FindFirstObjectByType<RequestBoard>();
    }

    public void FlowerBoxTutorial(){
        StartCoroutine(fbt());
    }

    public void RequestBoardTutorial(){
        StartCoroutine(rbt());
    }

    private IEnumerator fbt(){
        img.SetActive(true);
        img.GetComponent<Image>().sprite = pic;
        button.SetActive(true);

        yield return new WaitUntil(() => finished);

        button.SetActive(false);
        flowerManager.openedBox = true;
        flowerManager.exclaim.SetActive(false);
        img.SetActive(false);
    }

    private IEnumerator rbt(){
        img.SetActive(true);
        img.GetComponent<Image>().sprite = pic;
        button.SetActive(true);

        yield return new WaitUntil(() => finished);

        button.SetActive(false);
        requestboard.openedBoard = true;
        requestboard.exclaim.SetActive(false);
        img.SetActive(false);
    }

    void Update(){
        transform.position = new Vector2(transform.position.x, Mathf.Sin(Time.time * 2f) *0.2f + voffset);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (img.activeInHierarchy)
            {
                finished = true;
            }
        }
    }

    public void FinishTutorial(){
        finished = true;
    }
}