using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WP_Wander : WPBaseState
{
    private float wander_time = 5.0f;
    // [SerializeReference]
    private Transform test_transform;
    public override void EnterState(WPStateManager wp_manager, NavMeshAgent agent)
    {
        Debug.Log("In WANDER state");
        //test_transform = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        //agent.SetDestination(test_transform.position);
    }

    public override void UpdateState(WPStateManager wp_manager, NavMeshAgent agent)
    {
        // If still idling
        if (wander_time > 0.0f)
        {
            wander_time -= Time.deltaTime;
            //agent.SetDestination(test_transform.position);
        }
        // If we are done idling
        else
        {
            wander_time = 5.0f;
            wp_manager.SwitchState(wp_manager.idle_state);
        }
    }
}
