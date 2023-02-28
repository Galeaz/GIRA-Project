using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    //singleton
    public static PauseMenu instance;

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

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
