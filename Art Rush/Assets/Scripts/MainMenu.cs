using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    //singleton
    public static MainMenu instance;

    public GameObject singleplayer_Button;
    public GameObject multiplayer_Button;
    public GameObject restartButton;
    public GameObject continue_Button;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true); //activates menu
    }

    public void PlaySingleGame()
    {
        SceneManager.LoadScene("Singleplayer Game"); //loads game scene  CHANGE THE NAME TO Singleplayer Game
    }
    
    public void PlayMultiplayerGame()
    {
        SceneManager.LoadScene("Multiplayer Game"); //loads game scene
    }
    
    public void QuitGame()
    {
        Application.Quit(); //closes game
    }

    public void Options()
    {
        SceneManager.LoadScene("Settings Menu"); //opens secondary menu for settings
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits"); //opens secondary menu for team credits
    }

    public void ShowMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); //opens secondary menu for settings
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenu"); //opens secondary menu for settings
    }
}
