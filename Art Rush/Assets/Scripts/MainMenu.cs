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
        singleplayer_Button.SetActive(true); //shows start button
        multiplayer_Button.SetActive(true); //shows start button
        restartButton.SetActive(false); //hides restart button
        continue_Button.SetActive(false); //hides exit button
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true); //activates menu
    }

    public void PlaySingleGame()
    {
        SceneManager.LoadScene("Singleplayer Game"); //loads game scene
    }
    /*
    public void PlayMultiplayerGame()
    {
        SceneManager.LoadScene("Multiplayer Game"); //loads game scene
        //function that calls for second player(?) ---------------------------------------- in progress
    }
    */
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
