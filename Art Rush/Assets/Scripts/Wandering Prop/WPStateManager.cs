using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WPStateManager : MonoBehaviour
{
    // Current State of wandering_prop
    WPBaseState current_state;
    // Initialize instances of the different states
    public WP_Wander wander_state = new WP_Wander();
    public WP_Idle idle_state = new WP_Idle();
    public WP_Flee flee_state = new WP_Flee();

    // Reference to NavAgent
    [SerializeReference]
    private NavMeshAgent agent;

    // Lifetime of wandering_prop
    private float lifetime = 10f;

    // Start is called before the first frame update
    void Start()    
    {
        // Always initialize to the idle state
        current_state = idle_state;
        // Perform start behaviors of idle
        idle_state.EnterState(this, agent);
    }

    // Update is called once per frame
    void Update()
    {
        // If wandering prop still has lifetime
        if (lifetime > 0)
        {
            // Decrement lifetime
            lifetime -= Time.deltaTime;

            // Call UpdateState, similar to Update() for monobehavior
            current_state.UpdateState(this, agent);
        }
        else
        {
            // Once lifetime is over destroy itself
            Destroy(gameObject);
        }
    }

    // Switch to given state
    public void SwitchState(WPBaseState new_state)
    {
        // Set variable
        current_state = new_state;
        // Perform start behavior
        current_state.EnterState(this, agent);
    }
}
