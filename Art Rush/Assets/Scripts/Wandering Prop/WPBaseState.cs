using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Abstract class for all concrete classes to derive from
public abstract class WPBaseState
{
    // Function to perform behaviors when states changes
    public abstract void EnterState(WPStateManager wp_manager, NavMeshAgent agent);

    // Function to perform behaviors that should constently update, like Update()
    public abstract void UpdateState(WPStateManager wp_manager, NavMeshAgent agent);

}
