using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStateManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int total_score = 0;

    [SerializeField] 
    TextMeshProUGUI scoreText; //text to display the score

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
        scoreText.text = total_score.ToString(); // change tex in UI for score display
    }
}
