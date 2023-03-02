using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WP_Idle : WPBaseState
{
    private float idle_time = 5.0f;
    public override void EnterState(WPStateManager wp_manager, NavMeshAgent agent)
    {
        Debug.Log("In IDLE state");
    }

    public override void UpdateState(WPStateManager wp_manager, NavMeshAgent agent)
    {
        // If still idling
        if (idle_time > 0.0f)
        {
            idle_time -= Time.deltaTime;
        }
        // If we are done idling
        else
        {
            idle_time = 5.0f;
            wp_manager.SwitchState(wp_manager.wander_state);
        }
    }
}
