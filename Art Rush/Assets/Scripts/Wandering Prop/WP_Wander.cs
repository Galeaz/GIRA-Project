using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WP_Wander : WPBaseState
{
    // Time that we will stay in wander for
    private float wander_time = 8.0f;
    // Variable to store closest_player later
    private Transform closest_player;
    // Initialize Vector for later
    private Vector3 wander_target = Vector3.zero;

    // Values to use later to manipulate Wander behavior
    float wanderRadius = 10;
    float wanderDistance = 10;
    float wanderJitter = 0.5f;

    public override void EnterState(WPStateManager wp_manager, NavMeshAgent agent)
    {
        // Debug.Log("In WANDER state");

        // Reset wander_time and target everytime we enter this state
        wander_time = 5.0f;
        wander_target = Vector3.zero;
        // Override previous SetDestination if there was one
        agent.SetDestination(wp_manager.gameObject.transform.position);
    }

    public override void UpdateState(WPStateManager wp_manager, NavMeshAgent agent)
    {
        // Get reference to Player gameobject
        closest_player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        // If Player is within range of the WanderingProp
        if (PlayerInRange(wp_manager, closest_player))
        {
            // Switch to Flee
            wp_manager.SwitchState(wp_manager.flee_state);
        }
        // If we need to still wander
        else if (wander_time > 0.0f)
        {
            // Decrement wander_time
            wander_time -= Time.deltaTime;

            // Wander Behavior
            wander_target += new Vector3(Random.Range(-1.0f, 1.0f) * wanderJitter, 0, Random.Range(-1.0f, 1.0f) * wanderJitter);

            wander_target.Normalize();
            wander_target *= wanderRadius;

            Vector3 targetLocal = wander_target + new Vector3(0, 0, wanderDistance);
            Vector3 targetWorld = wp_manager.gameObject.transform.InverseTransformVector(targetLocal);

            agent.SetDestination(targetWorld);
        }
        // If we are done wandering
        else
        {
            // Switch to Idle state
            wp_manager.SwitchState(wp_manager.idle_state);
        }
    }

    // Function to check if Player is within some distance of the WanderingProp
    bool PlayerInRange(WPStateManager wp_manager, Transform player)
    {
        bool ret_val = Vector3.Distance(wp_manager.gameObject.transform.position, player.position) < 10;        
        return ret_val;      
    }
}
