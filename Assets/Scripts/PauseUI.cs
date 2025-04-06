using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    [SerializeField] GameObject pause_ui;
    public string sceneName = "Prototype_Menu";

    private void Start()
    {
        pause_ui.SetActive(false);
    }

    public void ToMain()
    {
        SceneManager.LoadScene(sceneName);
    }

}
