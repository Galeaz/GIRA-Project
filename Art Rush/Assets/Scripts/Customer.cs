using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Customer : Interactable
{
    // Reference to player's grab area
    // [SerializeReference]
    //private Transform player_grab_loc;
    // Location where props are held
    [SerializeReference]
    private Transform customer_hold_loc;

    // Stores what prop is being held on the Counter
    [SerializeReference]
    private Transform contained_prop;

    // Boolean to tell if customer already has an item
    private bool is_holding;

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

    private Seats current_seat;

    public Color wanted_color;
    public Prop wanted_prop;

    private float wait_time = 0.0f;
    /* Ideas for variables
        - order
        - wait time
        - order is complete?
        -       
    */
    public override void Interact()
    {
        base.Interact();
        // If player is holding something and this counter is not holding anything
        if (player_grab_loc.childCount != 0 && is_holding == false)
        {
            string p = player_grab_loc.GetChild(0).tag;
            Color c = player_grab_loc.GetChild(0).GetComponent<MeshRenderer>().material.color;
            Debug.Log(p);
            if (p == wanted_prop.tag && c == wanted_color)
            {
                PlaceProp(player_grab_loc.GetChild(0));
                // gsm.addToScore(6);
            }
            // PlaceProp(player_grab_loc.GetChild(0));
        }
    }

    public void Start()
    {
        player_grab_loc = GameObject.FindGameObjectWithTag("Player").transform.GetChild(1);
        exit_loc = GameObject.FindGameObjectWithTag("Exit").transform;
        gsm = GameObject.FindGameObjectWithTag("GameStateManager").GetComponent<GameStateManager>();
        SetNewTargetLocation();
    }
    private void Update()
    {
        if (target_loc == null && findSeats().Count != 0)
        {
            SetNewTargetLocation();
            current_seat.setAvailability(false);
        }
        if (is_holding == true)
        {
            lifeTime -= Time.deltaTime;
        }
        else 
        {
            wait_time += Time.deltaTime;
        }

        if (lifeTime <= 0)
        {
            current_seat.setAvailability(true);
            gsm.addToScore(100 - wait_time);
            Destroy(gameObject);
        }
        else if (lifeTime <= 3.0f)
        {
            agent.SetDestination(exit_loc.position);
        }

        if (wait_time >= 50.0f)
        {
            current_seat.setAvailability(true);
            Destroy(gameObject);
        }
        else if (wait_time >= 47.0f)
        {
            agent.SetDestination(exit_loc.position);
        }

    }
    void PlaceProp(Transform prop)
    {
        // Store prop in class and set parent to held location
        contained_prop = prop;
        prop.SetParent(customer_hold_loc);
        prop.position = customer_hold_loc.position;
        // Change to true as it now holds an item
        is_holding = true;
    }

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

    void SetNewTargetLocation()
    {
        List<Seats> possible_seats = findSeats();
        if (possible_seats.Count != 0)
        {
            target_loc = possible_seats[0].GetComponentInChildren<Transform>().transform;
            current_seat = possible_seats[0];
            possible_seats[0].setAvailability(false);
            current_seat.setAvailability(false);
            agent.SetDestination(target_loc.position);
        }
    }

    public void setWantedColor(Color col)
    {
        wanted_color = col;
    }

    public void setWantedProp(Prop p)
    {
        wanted_prop = p;
    }
}
