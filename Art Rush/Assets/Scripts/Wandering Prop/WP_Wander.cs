using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WP_Wander : WPBaseState
{
    private float wander_time = 8.0f;
    // [SerializeReference]
    private Transform closest_player;

    private Vector3 wander_target = Vector3.zero;

    float wanderRadius = 10;
    float wanderDistance = 10;
    float wanderJitter = 0.5f;

    public override void EnterState(WPStateManager wp_manager, NavMeshAgent agent)
    {
        Debug.Log("In WANDER state");
        wander_time = 5.0f;
        wander_target = Vector3.zero;
    }

    public override void UpdateState(WPStateManager wp_manager, NavMeshAgent agent)
    {
        closest_player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        // If still idling
        if (PlayerInRange(wp_manager, closest_player))
        {
            wp_manager.SwitchState(wp_manager.flee_state);
        }
        else if (wander_time > 0.0f)
        {
            wander_time -= Time.deltaTime;
            wander_target += new Vector3(Random.Range(-1.0f, 1.0f) * wanderJitter, 0, Random.Range(-1.0f, 1.0f) * wanderJitter);

            wander_target.Normalize();
            wander_target *= wanderRadius;

            Vector3 targetLocal = wander_target + new Vector3(0, 0, wanderDistance);
            Vector3 targetWorld = wp_manager.gameObject.transform.InverseTransformVector(targetLocal);

            // Debug.Log(targetWorld);
            agent.SetDestination(targetWorld);
        }
        // If we are done idling
        else
        {
            wp_manager.SwitchState(wp_manager.idle_state);
        }
    }

    bool PlayerInRange(WPStateManager wp_manager, Transform player)
    {
        bool ret_val = Vector3.Distance(wp_manager.gameObject.transform.position, player.position) < 5;
        // Debug.Log(ret_val);
        return ret_val;
    }
}
