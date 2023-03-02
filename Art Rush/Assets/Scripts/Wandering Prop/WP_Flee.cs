using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WP_Flee : WPBaseState
{
    private Transform closest_player;
    // private Vector3 flee_vector;
    public override void EnterState(WPStateManager wp_manager, NavMeshAgent agent)
    {
        Debug.Log("In FLEE state");
        // closest_player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        // Vector3 flee_vector = closest_player.position - wp_manager.gameObject.transform.position;
        // agent.SetDestination(wp_manager.gameObject.transform.position - flee_vector);
    }

    public override void UpdateState(WPStateManager wp_manager, NavMeshAgent agent)
    {
        closest_player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        if (!PlayerInRange(wp_manager, closest_player))
        {
            wp_manager.SwitchState(wp_manager.idle_state);
        }
        else
        {
            Flee(closest_player, wp_manager, agent);
            // Debug.Log("Called Flee");
        }
        
    }

    bool PlayerInRange(WPStateManager wp_manager, Transform player)
    {
        bool ret_val = Vector3.Distance(wp_manager.gameObject.transform.position, player.position) < 10;
        return ret_val;       
    }

    void Flee(Transform player, WPStateManager wp_manager, NavMeshAgent agent)
    {
        Vector3 flee_vector = closest_player.position - wp_manager.gameObject.transform.position;

        Vector3 dest_vector = wp_manager.gameObject.transform.position - flee_vector;

        dest_vector.y = 0;        

        Debug.DrawRay(wp_manager.gameObject.transform.position, dest_vector, Color.red);
        Debug.DrawRay(wp_manager.gameObject.transform.position, flee_vector, Color.blue);
        Debug.DrawRay(wp_manager.gameObject.transform.position, -flee_vector, Color.yellow);
        agent.SetDestination(-flee_vector);
    }
}
