using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    [SerializeField] GameObject pause_ui;

    private void Start()
    {
        pause_ui.SetActive(false);
    }

    public void ToMain()
    {
        SceneManager.LoadScene(0);
    }

}
