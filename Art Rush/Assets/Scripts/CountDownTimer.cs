using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 10f; //time the level will have
    bool timerToggle = true; //keeping track if timer enabled
    
    public Behaviour timeOutCanvas;
    public AudioSource finishAudio;

    [SerializeField] TextMeshProUGUI countTimeText; //time text object

    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerToggle) //while time not 0 keeps counting
        {
            if (currentTime > 0) //while time != 0
            {
                currentTime -= Time.deltaTime; //countdown function
            }
            else //when time <= 0
            {
                timerToggle = false; //time run out
                endGame();
            }

            if (currentTime <= 10) //when player has less than 10 seconds left
            {
                countTimeText.color = Color.red; //changing text color to red
            }

            DisplayTime(currentTime);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0; //when the time runs out show 0
        }
        else if (timeToDisplay > 0)
        {
            timeToDisplay += 1; //this will make the time more accurate
        }

        //formating minutes and seconds for text
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        countTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void endGame()
    {
        Time.timeScale = 0;
        timeOutCanvas.enabled = true; //shows finish match banner
        currentTime = 0; //stops showing negative time
        finishAudio.Play(); //plays a small audio to indicate end of game

        //ADD COUROUTINE FOR CHANGE OF SCREEN
    }
}
