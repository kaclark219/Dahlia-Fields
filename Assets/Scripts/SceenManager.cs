using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] GameObject main_menu;
    [SerializeField] GameObject title_screen;
    [SerializeField] GameObject credits_screen;
    public TMP_InputField name_input;
    public string player_name = " "; 
    public string game_scene = " ";

    private const string nameKey = "PLAYER_NAME";
    private const string newGameKey = "NEW_GAME";   // tells the GlobalStateManager on load if its a new game 

    // Start is called before the first frame update
    void Start()
    {   
        name_input.onValueChanged.AddListener(UpdateUserInput);
        title_screen.SetActive(false);  
        credits_screen.SetActive(false);    
    }

    //Go to Title Screen
    public void ToTitle()
    {
        main_menu.SetActive(false);
        title_screen.SetActive(true);
    }

    public void ToCredits()
    {
        //main_menu.SetActive(false); 
        //credits_screen.SetActive(true); 
    }
  
    //Go to Main Page 
    public void MainPage()
    {
        credits_screen.SetActive(false);
        main_menu.SetActive(true);

    }

    //Load Saved Game
    public void LoadGame()
    {
        PlayerPrefs.SetInt(newGameKey, 0);  // 0 => not a new game
        SceneManager.LoadScene(game_scene);

    }

    //Quit Application
    public void Quit()
    {
        Application.Quit();
    }

    //Start New Game
    public void NewGame()
    {
        //GameObject tag_finder = GameObject.FindWithTag("Player_Name"); ;
        //tag_finder.name = player_name; 
        //DontDestroyOnLoad(tag_finder);
        Debug.Log(player_name);
        PlayerPrefs.SetString(nameKey, player_name);
        PlayerPrefs.SetInt(newGameKey, 0);  // 1 => is a new game
        SceneManager.LoadScene(game_scene);
    }

    //Set Player Name
    void UpdateUserInput(string input)
    {
        player_name = input; // Store the input text
        //Debug.Log("User Input: " + player_name);
    }


}
