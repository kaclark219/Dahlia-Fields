using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject PauseUI;
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject DialogUI;
    [SerializeField] private GameObject InventoryUI;
    [Space]
    [SerializeField] private PlayerMovement PlayerMovement;
    [SerializeField] private PlayerInteractor PlayerInteractor;

    private void Start()
    {
        OpenMainMenu();
    }

    public void OpenMainMenu()
    {
        MainMenu.SetActive(true);
        HUD.SetActive(false);
        DialogUI.SetActive(false);
        PauseUI.SetActive(false);
        InventoryUI.SetActive(false);
        DisablePlayer();
    }

    public void StartGame()
    {
        MainMenu.SetActive(false);
        HUD.SetActive(true);
        EnablePlayer();
    }


    public void OpenDialogue()
    {
        DialogUI.SetActive(true);
        DisablePlayer();
    }

    public void CloseDialogue()
    {
        DialogUI.SetActive(false);
        EnablePlayer();
    }

    public void OpenPause()
    {
        PauseUI.SetActive(true);
        DisablePlayer();
    }

    public void ClosePause()
    {
        PauseUI.SetActive(false);
        EnablePlayer();
    }

    public void OpenInventory()
    {
        InventoryUI.SetActive(true);
        DisablePlayer();
    }

    public void CloseInventory()
    {
        InventoryUI.SetActive(false);
        EnablePlayer();
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    private void EnablePlayer()
    {
        PlayerMovement.enabled = true;
        PlayerInteractor.enabled = true;
    }
    private void DisablePlayer()
    {
        PlayerMovement.enabled = false;
        PlayerInteractor.enabled = false;
    }

}
