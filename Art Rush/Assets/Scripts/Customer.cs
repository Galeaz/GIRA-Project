using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Customer : Interactable
{
    // Transform where customer will hold objects
    [SerializeReference]
    private Transform customer_hold_loc;

    // Stores what prop is being held on the Counter
    [SerializeReference]
    private Transform contained_prop;

    // Boolean to tell if customer already has an item
    private bool is_holding;

    // Customer Lifetime
    private float lifeTime = 10.0f;

    // Reference to where the customer needs to go
    [SerializeReference]
    private Transform target_loc = null;

    // Exit transform
    private Transform exit_loc;

    // Reference to GameStateManager
    private GameStateManager gsm;

    // Navmesh reference
    [SerializeReference]
    private NavMeshAgent agent;

    // Seat customer is at
    private Seats current_seat;

    // Customer Order Variables
    public Color wanted_color;
    public Prop wanted_prop;

    // Time Customer has been waiting
    private float wait_time = 0.0f;
    
    public override void Interact()
    {
        base.Interact();
        // If player is holding something and Customer doesn't already have a prop
        if (player_grab_loc.childCount != 0 && is_holding == false)
        {
            // Get the name and color of the prop the player is trying to give
            string p = player_grab_loc.GetChild(0).tag;
            Color c = player_grab_loc.GetChild(0).GetComponent<MeshRenderer>().material.color;
            
            // If the prop is the correct order the Customer grabs it
            if (p == wanted_prop.tag && c == wanted_color)
            {
                PlaceProp(player_grab_loc.GetChild(0));             
            }
        }
    }

    public void Start()
    {
        // player_grab_loc = GameObject.FindGameObjectWithTag("Player").transform.GetChild(1);
        // Get the transform of the Exit and the GameStateManager
        exit_loc = GameObject.FindGameObjectWithTag("Exit").transform;
        gsm = GameObject.FindGameObjectWithTag("GameStateManager").GetComponent<GameStateManager>();

        // Try and find the Customer a Seat
        SetSeatLocation();
    }
    private void Update()
    {
        // Waiting for Seat State
        // If the customer has not found a seat yet try again until one becomes available
        if (target_loc == null && findSeats().Count != 0)
        {
            // Move the Customer to a Seat and change its availability
            SetSeatLocation();
            current_seat.setAvailability(false);
        }

        // Waiting for Order State
        // If customer got the order
        if (is_holding == true)
        {
            // Transition to Success Order State
            lifeTime -= Time.deltaTime;
        }
        // If still waiting for order
        else 
        {
            // Increase wait time
            wait_time += Time.deltaTime;
        }

        // If the Success Order state is done, reset seat -> increase score based on wait time -> destroy customer 
        if (lifeTime <= 0)
        { 
            current_seat.setAvailability(true);
            gsm.addToScore(100 - wait_time);
            Destroy(gameObject);
        }
        // Move customer toward exit before it gets destroyed
        else if (lifeTime <= 3.0f)
        {
            agent.SetDestination(exit_loc.position);
        }

        // If the Fail Order State is reached
        // Once a the order fails, reset seat and destroy customer
        if (wait_time >= 50.0f)
        {
            current_seat.setAvailability(true);
            Destroy(gameObject);
        }
        // Move the customer toward the exit before they get destroyed
        else if (wait_time >= 47.0f)
        {
            agent.SetDestination(exit_loc.position);
        }

    }
    // Function to help the Transfer of prop from player to customer
    // and change variables accordingly
    void PlaceProp(Transform prop)
    {
        // Store prop in class and set parent to held location
        contained_prop = prop;
        prop.SetParent(customer_hold_loc);
        prop.position = customer_hold_loc.position;
        // Change to true as it now holds an item
        is_holding = true;
    }

    // Function for Customer to know if there are available seats
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

    // Function to move Customer if there are available seats for the customer to go to
    void SetSeatLocation()
    {
        List<Seats> possible_seats = findSeats();
        if (possible_seats.Count != 0)
        {
            // Store where the customer needs to go and the seat object
            target_loc = possible_seats[0].GetComponentInChildren<Transform>().transform;
            current_seat = possible_seats[0];
            // possible_seats[0].setAvailability(false);

            // Change seat availability and make the customer move toward seat
            current_seat.setAvailability(false);
            agent.SetDestination(target_loc.position);
        }
    }

    // Set Functions for wanted_color and wanted_prop
    public void setWantedColor(Color col)
    {
        wanted_color = col;
    }
   
    public void setWantedProp(Prop p)
    {
        wanted_prop = p;
    }

    // Get Functions for wanted_color and wanted_prop
    public Color getWantedColor()
    {
        return wanted_color;
    }

    public string getWantedProp()
    {
        return wanted_prop.ToString();
    }

    public Sprite getPropSprite()
    {
        return GameObject.FindGameObjectWithTag("Props").GetComponent<Sprite>();
    }

    public Sprite getColorSprite()
    {
        return GameObject.FindGameObjectWithTag("Colors").GetComponent<Sprite>();
    }
}
