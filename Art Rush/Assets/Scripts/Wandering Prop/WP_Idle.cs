using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WP_Idle : WPBaseState
{
    private float idle_time = 2.0f;
    private Transform closest_player;
    public override void EnterState(WPStateManager wp_manager, NavMeshAgent agent)
    {
        Debug.Log("In IDLE state");
    }

    public override void UpdateState(WPStateManager wp_manager, NavMeshAgent agent)
    {
        closest_player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        if (PlayerInRange(wp_manager, closest_player))
        {
            wp_manager.SwitchState(wp_manager.flee_state);
        }
        // If still idling
        else if (idle_time > 0.0f)
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

    bool PlayerInRange(WPStateManager wp_manager, Transform player)
    {
        bool ret_val = Vector3.Distance(wp_manager.gameObject.transform.position, player.position) < 5;
        // Debug.Log(ret_val);
        return ret_val;
    }
}
