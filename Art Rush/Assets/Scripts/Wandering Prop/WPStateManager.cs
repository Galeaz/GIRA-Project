using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WPStateManager : MonoBehaviour
{
    WPBaseState current_state;
    public WP_Wander wander_state = new WP_Wander();
    public WP_Idle idle_state = new WP_Idle();
    public WP_Flee flee_state = new WP_Flee();

    [SerializeReference]
    private NavMeshAgent agent;

    private float lifetime = 10f;

    // Start is called before the first frame update
    void Start()    
    {
        current_state = idle_state;

        idle_state.EnterState(this, agent);
    }

    // Update is called once per frame
    void Update()
    {
        if (lifetime > 0)
        {
            lifetime -= Time.deltaTime;
            current_state.UpdateState(this, agent);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SwitchState(WPBaseState new_state)
    {
        current_state = new_state;

        current_state.EnterState(this, agent);
    }
}
