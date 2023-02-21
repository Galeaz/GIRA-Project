using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject Pause_Button;
    public GameObject Resume_Button;

    public Behaviour gameStartCanvas; //canvas start banner

    void Start()
    {
        PauseGame(); //starts with game paused to avoid player from moving
        StartCoroutine(ShowBannerAndContinue(2f)); //will disable start canvas banner after specified time
    }

    private IEnumerator ShowBannerAndContinue(float waitTime)
    {
        gameStartCanvas.enabled = true; //shows start match banner
        yield return new WaitForSecondsRealtime(waitTime); //will wait to disable canvas banner

        gameStartCanvas.enabled = false; //disables start match banner
        ResumeGame(); //resume game to play
    }
    
    public void PauseGame()
    {
        Time.timeScale = 0; //stops the game
    }
    public void ResumeGame()
    {
        Time.timeScale = 1; //resumes game
    }
}
