using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class WPBaseState
{
    public abstract void EnterState(WPStateManager wp_manager, NavMeshAgent agent);

    public abstract void UpdateState(WPStateManager wp_manager, NavMeshAgent agent);

}
