using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountDownTimer : MonoBehaviour
{
    float currentTime = 0f;
    bool timerToggle = true; //keeping track if timer enabled
    bool aiSpawned = false; //track if AI characters have been spawned

    [SerializeField] float startingTime; //time the level will have
    [SerializeField] int required_score; //scored needed to win


    public Behaviour timeOutCanvas; //finish banner canvas
    public Behaviour winCanvas; //win screen canvas
    public Behaviour loseCanvas; //lose screen canvas
    public AudioSource finishAudio; //audio indicator of level end

    [SerializeField] TextMeshProUGUI countTimeText; //time text object
    [SerializeField] TextMeshProUGUI requiredScoreTextGame; //score required for game screen
    [SerializeField] TextMeshProUGUI requiredScoreTextWinScreen; //score required for win screen
    [SerializeField] TextMeshProUGUI requiredScoreTextLoseScreen; //score required for lose screen
    [SerializeField] TextMeshProUGUI scoreTextGame; //score text object

    [SerializeField] ChildSpawner spawner; // Reference to the ChildSpawner script

    void Start()
    {
        currentTime = startingTime; //set level time
        requiredScoreTextGame.GetComponent<TMPro.TextMeshProUGUI>().text = required_score.ToString();
        requiredScoreTextWinScreen.GetComponent<TMPro.TextMeshProUGUI>().text = required_score.ToString();
        requiredScoreTextLoseScreen.GetComponent<TMPro.TextMeshProUGUI>().text = required_score.ToString();
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

            if (currentTime <= 10 && !aiSpawned) //when player has less than 10 seconds left and AI has not been spawned
            {
                countTimeText.color = Color.red; //changing text color to red
                spawner.SpawnAICharacters(); //spawn AI characters
                aiSpawned = true; //ensure AI characters are only spawned once
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
        timeOutCanvas.enabled = true; //shows finish match banner
        currentTime = 0; //stops showing negative time
        finishAudio.Play(); //plays a small audio to indicate end of game
        int total_score = int.Parse(scoreTextGame.GetComponent<TMPro.TextMeshProUGUI>().text);
        StartCoroutine(WaitAndContinue(4f, total_score, required_score)); //will show finish banner with specified time
    }

    private IEnumerator WaitAndContinue(float waitTime, int score, int requiredScore)
    {
        Time.timeScale = 0; //pauses game
        yield return new WaitForSecondsRealtime(waitTime); //will wait to call function that shows canvas

        StartCoroutine(showScoreScreen("MainMenu", 5f, score, requiredScore)); //call win or lose function to show canvas with coroutine
    }

    private IEnumerator showScoreScreen(string sceneName, float waitTime, int score, int requiredScore)
    {
        if (score >= requiredScore)
        {
            winCanvas.enabled = true;
        }
        else
        {
            loseCanvas.enabled = true;
        }
        yield return new WaitForSecondsRealtime(waitTime); //will wait to change scene

        SceneManager.LoadScene(sceneName); //loads scene
    }
}
