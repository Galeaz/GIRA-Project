using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPatrol : MonoBehaviour
{
    GameObject player; // Player Object.

    NavMeshAgent agent; // To allow the AI to move around or patrol.

    [SerializeField] LayerMask groundLayer, playerLayer;


    // Patrol
    Vector3 destPoint;
    bool walkPointSet;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("MrClaw");
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (!walkPointSet) SearchForDest();
        if (walkPointSet) agent.SetDestination(destPoint);
        if (Vector3.Distance(transform.position, destPoint) < 3) walkPointSet = false;
    }

    void SearchForDest()
    {
        float Z = Random.Range(-13, 13);
        float X = Random.Range(-7, 7);

        destPoint = new Vector3(transform.position.x + X, transform.position.y, transform.position.z + Z);

        if (Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            walkPointSet = true;
        }
    }
}
