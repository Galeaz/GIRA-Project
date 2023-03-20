using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject Pause_Button;
    public GameObject Resume_Button;

    public Behaviour gameStartCanvas; //canvas start banner
    public float startTime;

    void Start()
    {
        PauseGame(); //starts with game paused to avoid player from moving
        StartCoroutine(ShowBannerAndContinue(startTime)); //will disable start canvas banner after specified time
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

    public List<Seats> findSeats()
    {
        List<GameObject> all_seats = new List<GameObject>(GameObject.FindGameObjectsWithTag("Seat"));
        List<Seats> available_seats = new List<Seats>();

        foreach(GameObject seat in all_seats)
        {
            Seats s = seat.GetComponent<Seats>();
            if (s.getAvailability() == true)
            {
                available_seats.Add(s);

            }
        }

        // return available_seats;
        return available_seats;
    }
}
