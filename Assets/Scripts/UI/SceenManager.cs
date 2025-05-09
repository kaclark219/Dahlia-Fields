using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ScreenManager : MonoBehaviour
{
    public enum Panel { Main, Credits, Name, Confirm};

    [SerializeField] GameObject main_menu;
    [SerializeField] GameObject name_screen;
    [SerializeField] GameObject credits_screen;
    [SerializeField] GameObject new_game_confirm;
    [SerializeField] GameObject LoadGameButton;
    [SerializeField] TitleMusic titlemusic;
    [Space]
    public TMP_InputField name_input;
    public string player_name = " "; 
    public string game_scene = " ";
    [Space]
    public bool hasSave = false;
    private const string nameKey = "PLAYER_NAME";
    private const string newGameKey = "NEW_GAME";   // tells the GlobalStateManager on load if its a new game 

    // Start is called before the first frame update
    void Start()
    {   
        name_input.onValueChanged.AddListener(UpdateUserInput);
        MainPage();
    }

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey(nameKey))
        {
            hasSave = true;
        }
        else
        {
            LoadGameButton.GetComponent<Button>().enabled = false;
            LoadGameButton.GetComponent<Image>().color = Color.grey;
            hasSave = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainPage();
        }
    }

    //Go to Title Screen
    public void ToName()
    {
        new_game_confirm.SetActive(false);
        name_screen.SetActive(true);
    }

    public void ToCredits()
    {
        credits_screen.SetActive(true);
    }

    public void ToNewGame()
    {
        if (hasSave)
        {
            new_game_confirm.SetActive(true);
        }
        else
        {
            ToName();
        }
    }
  
    //Go to Main Page 
    public void MainPage()
    {
        name_screen.SetActive(false);
        credits_screen.SetActive(false);
        new_game_confirm.SetActive(false);
    }

    //Load Saved Game
    public void LoadGame()
    {
        if (hasSave)
        {
            titlemusic.fadeOut();
            PlayerPrefs.SetInt(newGameKey, 0);  // 0 => not a new game
            //SceneManager.LoadScene(game_scene);
            StartCoroutine(LoadYourAsyncScene());
        }
    }

    //Quit Application
    public void Quit()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        //Debug.Log(player_name);
        titlemusic.fadeOut();
        PlayerPrefs.DeleteKey(nameKey);
        PlayerPrefs.SetString(nameKey, player_name);
        PlayerPrefs.SetInt(newGameKey, 1);  // 1 => is a new game
        //SceneManager.LoadScene(game_scene);
        StartCoroutine(LoadYourAsyncScene());
        new_game_confirm.SetActive(false);
    }

    //Set Player Name
    void UpdateUserInput(string input)
    {
        player_name = input; // Store the input text
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(game_scene);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
