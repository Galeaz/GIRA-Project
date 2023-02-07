using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestingMenu : MonoBehaviour
{
    //singleton
    public static TestingMenu instance;

    public GameObject restartButton;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true); //activates menu
    }

    public void ShowMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); //change scene to main menu
    }

    public void QuitGame()
    {
        Application.Quit(); //closes game
    }

    public void RestartGame(int gamemode)
    {
        if (MainMenu.instance.gameMode == 1)
        {
            SceneManager.LoadScene("Singleplayer Game"); //re-opens singleplayer game
        }
        else if (MainMenu.instance.gameMode == 2)
        {
            SceneManager.LoadScene("Multiplayer Game"); //re-opens multiplayer game
        }
        else
        {
            print("ERROR: No game mode code recorded.");
            SceneManager.LoadScene("MainMenu"); //in case for some error there is no game code kicks you out to the main menu
        }
    }
}
