using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeReference]
    private GameObject toSpawnCustomer;

    [SerializeReference]
    private Transform spawn_loc;

    private float spawn_cooldown = 10.0f;
    // Update is called once per frame
    void Update()
    {
        if (spawn_cooldown > 0)
        {
            spawn_cooldown -= Time.deltaTime;
        }
        else if (spawn_cooldown <= 0)
        {
            Instantiate(toSpawnCustomer, spawn_loc.position, spawn_loc.rotation);
            spawn_cooldown = 10.0f;
        }
    }
}
