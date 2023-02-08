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
        SceneManager.LoadScene("Singleplayer Game"); //loads singleplayer game scene
    }
    
    public void PlayMultiplayerGame()
    {
        
        SceneManager.LoadScene("Multiplayer Game"); //loads multiplayer game scene
    }
    
    public void QuitGame()
    {
        Application.Quit(); //closes game
    }
}
