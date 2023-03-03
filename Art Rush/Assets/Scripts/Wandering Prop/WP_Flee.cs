using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WP_Flee : WPBaseState
{
    // Player reference holder
    private Transform closest_player;

    // private Vector3 flee_vector;
    public override void EnterState(WPStateManager wp_manager, NavMeshAgent agent)
    {
        // Debug.Log("In FLEE state");

        // Stop behavior of Previous state
        agent.SetDestination(wp_manager.gameObject.transform.position);
    }

    public override void UpdateState(WPStateManager wp_manager, NavMeshAgent agent)
    {
        // Find Player
        closest_player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        // If Player is NOT within range of the WanderingProp
        if (!PlayerInRange(wp_manager, closest_player))
        {
            // Switch to Idle state
            wp_manager.SwitchState(wp_manager.idle_state);
        }
        else
        {
            // Call the Flee behavior
            Flee(closest_player, wp_manager, agent);
            // Debug.Log("Called Flee");
        }
        
    }
    // Function to check if Player is within some distance of the WanderingProp
    bool PlayerInRange(WPStateManager wp_manager, Transform player)
    {
        bool ret_val = Vector3.Distance(wp_manager.gameObject.transform.position, player.position) < 10;
        return ret_val;       
    }

    // Flee behavior function
    void Flee(Transform player, WPStateManager wp_manager, NavMeshAgent agent)
    {
        // Calculate vector between player and wandering_prop
        Vector3 flee_vector = closest_player.position - wp_manager.gameObject.transform.position;

        // Vector3 dest_vector = wp_manager.gameObject.transform.position - flee_vector;
        // dest_vector.y = 0;        

        //Debug.DrawRay(wp_manager.gameObject.transform.position, dest_vector, Color.red);
        //Debug.DrawRay(wp_manager.gameObject.transform.position, flee_vector, Color.blue);
        //Debug.DrawRay(wp_manager.gameObject.transform.position, -flee_vector, Color.yellow);

        // Set wandering_prop to run in the direction opposite of the calculated vector
        agent.SetDestination(-flee_vector);
    }
}
