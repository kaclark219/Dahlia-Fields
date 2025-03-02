using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    [SerializeField] GameObject pause_button;
    [SerializeField] GameObject pause_ui;
    public string menu_scene = "Nandni_Menu";

    private void Start()
    {
        pause_ui.SetActive(false);
    }

    public void OpenPause()
    {
        pause_button.SetActive(false);
        pause_ui.SetActive(true);
    }

    public void Resume()
    {
        pause_ui.SetActive(false);
        pause_button.SetActive(true);
    }

    public void ToMain()
    {
        SceneManager.LoadScene("Nandni_Menu");
    }

    public void SaveGame()
    {

    }
}
