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

    public GameObject options_Button;
    public GameObject credits_Button;
    public GameObject quit_Button;

    public int gameMode; //data used in restart buttton for single or multi player scene reload

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true); //activates menu
        gameMode = 0;
    }

    public void PlaySingleGame()
    {
        SceneManager.LoadScene("Singleplayer Game"); //loads singleplayer game scene
        gameMode = 1; //one player
    }
    
    public void PlayMultiplayerGame()
    {
        
        SceneManager.LoadScene("Multiplayer Game"); //loads multiplayer game scene
        gameMode = 2; //two players
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
}
