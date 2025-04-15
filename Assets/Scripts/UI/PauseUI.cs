using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    [SerializeField] GameObject pause_ui;
    public string sceneName = "Prototype_Menu";

    private PlayerInteractor interactor;
    private MusicManager manager;
    private void Start()
    {
        pause_ui.SetActive(false);
        interactor = FindFirstObjectByType<PlayerInteractor>();
        manager = FindFirstObjectByType<MusicManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause_ui.activeInHierarchy)
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        if (interactor.canInteract)
        {
            pause_ui.SetActive(true);
            interactor.Interact();
            manager.fadeOut();
        }
    }

    public void Resume()
    {
        pause_ui.SetActive(false);
        interactor.EndInteract();
        manager.fadeIn();
    }

    public void ToMain()
    {
        SceneManager.LoadScene(sceneName);
    }

}
