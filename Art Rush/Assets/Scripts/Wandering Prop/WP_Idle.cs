using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WP_Idle : WPBaseState
{
    // Time we stay in Idle state
    private float idle_time = 2.0f;
    // Player reference holder
    private Transform closest_player;
    public override void EnterState(WPStateManager wp_manager, NavMeshAgent agent)
    {
        // Debug.Log("In IDLE state");

        // Stop behavior of Previous state
        agent.SetDestination(wp_manager.gameObject.transform.position);
    }

    public override void UpdateState(WPStateManager wp_manager, NavMeshAgent agent)
    {
        // Find Player
        closest_player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        // If Player is within range of the WanderingProp
        if (PlayerInRange(wp_manager, closest_player))
        {
            // Switch to Flee
            wp_manager.SwitchState(wp_manager.flee_state);
        }
        // If still idling
        else if (idle_time > 0.0f)
        {
            // Decrement idle_time
            idle_time -= Time.deltaTime;
        }
        // If we are done idling
        else
        {
            // Reset Idle time and switch states to Wander
            idle_time = 5.0f;
            wp_manager.SwitchState(wp_manager.wander_state);
        }
    }

    // Function to check if Player is within some distance of the WanderingProp
    bool PlayerInRange(WPStateManager wp_manager, Transform player)
    {
        bool ret_val = Vector3.Distance(wp_manager.gameObject.transform.position, player.position) < 10;        
        return ret_val;        
    }
}
