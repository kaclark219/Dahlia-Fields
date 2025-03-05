using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    [SerializeField] GameObject pause_ui;
    public string menu_scene = "Prototype_Menu";

    private void Start()
    {
        pause_ui.SetActive(false);
    }

    public void OpenPause()
    {
        pause_ui.SetActive(true);
    }

    public void Resume()
    {
        pause_ui.SetActive(false);
    }

    public void ToMain()
    {
        SceneManager.LoadScene(menu_scene);
    }

    public void SaveGame()
    {

    }
}
