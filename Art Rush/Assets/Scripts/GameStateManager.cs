using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStateManager : MonoBehaviour
{
    // Game Score Tracker
    public int total_score = 0;

    [SerializeField] 
    TextMeshProUGUI scoreText; //text to display the score

    // Function to return all available seats in the game
    public List<Seats> findSeats()
    {
        // Get all Seat tagged objects
        List<GameObject> all_seats = new List<GameObject>(GameObject.FindGameObjectsWithTag("Seat"));
        // Create return list of available seat objects
        List<Seats> available_seats = new List<Seats>();

        // For all seats in the game if it is available add it into the return list
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

    // Function to return number of customers in the game
    public int numCustomers()
    {
        List<GameObject> all_customers = new List<GameObject>(GameObject.FindGameObjectsWithTag("Customer"));
        return all_customers.Count;
    }

    // Function to increase score
    public void addToScore(float score)
    {
        total_score += Mathf.FloorToInt(score);
        scoreText.text = total_score.ToString(); // change tex in UI for score display
    }
}
