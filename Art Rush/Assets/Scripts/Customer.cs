using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Customer : Interactable
{
    // Reference to player's grab area
    [SerializeReference]
    private Transform player_grab_loc;
    // Location where props are held
    [SerializeReference]
    private Transform customer_hold_loc;

    // Stores what prop is being held on the Counter
    [SerializeReference]
    private Transform contained_prop;

    // Boolean to tell if Counter already has an item
    private bool is_holding;

    private float lifeTime = 10.0f;

    [SerializeReference]
    private Transform target_loc;

    [SerializeReference]
    private NavMeshAgent agent;

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
            PlaceProp(player_grab_loc.GetChild(0));
        }
    }

    public void Start()
    {
        agent.SetDestination(target_loc.position);
    }
    private void Update()
    {
        if (is_holding == true)
        {
            lifeTime -= Time.deltaTime;
        }

        if (lifeTime <= 0)
        {
            Destroy(gameObject);
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
}
