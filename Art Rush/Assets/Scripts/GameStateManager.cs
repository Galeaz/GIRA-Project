using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStateManager : MonoBehaviour
{

    // Start is called before the first frame update
    public int total_score = 0;

    [SerializeField] 
    TextMeshProUGUI scoreTextGame; //text to display the score in game UI
    [SerializeField]
    TextMeshProUGUI scoreTextWin; //text to display the score in win screen
    [SerializeField]
    TextMeshProUGUI scoreTextLose; //text to display the score in lose screen

    public List<Seats> findSeats()
    {
        List<GameObject> all_seats = new List<GameObject>(GameObject.FindGameObjectsWithTag("Seat"));
        List<Seats> available_seats = new List<Seats>();

        foreach (GameObject seat in all_seats)
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

    public int numCustomers()
    {
        List<GameObject> all_customers = new List<GameObject>(GameObject.FindGameObjectsWithTag("Customer"));
        return all_customers.Count;
    }

    public void addToScore(float score)
    {
        total_score += Mathf.FloorToInt(score);
        scoreTextGame.text = total_score.ToString(); // change text in UI for score display
        scoreTextLose.text = total_score.ToString(); // change text in win screen
        scoreTextWin.text = total_score.ToString(); // change text in lose screen
    }
}
