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
        closest_player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        Vector3 flee_vector = closest_player.position - wp_manager.gameObject.transform.position;
        agent.SetDestination(wp_manager.gameObject.transform.position - flee_vector);
    }

    public override void UpdateState(WPStateManager wp_manager, NavMeshAgent agent)
    {
        closest_player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        while (PlayerInRange(wp_manager, closest_player))
        {
            Flee(closest_player, wp_manager, agent);
        }

        wp_manager.SwitchState(wp_manager.idle_state);
    }

    bool PlayerInRange(WPStateManager wp_manager, Transform player)
    {
        bool ret_val = Vector3.Distance(wp_manager.gameObject.transform.position, player.position) < 5;
        Debug.Log(ret_val);
        return ret_val;
    }

    void Flee(Transform player, WPStateManager wp_manager, NavMeshAgent agent)
    {
        Vector3 flee_vector = closest_player.position - wp_manager.gameObject.transform.position;
        agent.SetDestination(wp_manager.gameObject.transform.position - flee_vector);
    }
}
