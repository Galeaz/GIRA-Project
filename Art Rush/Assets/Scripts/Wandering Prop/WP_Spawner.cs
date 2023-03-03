using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WP_Spawner : MonoBehaviour
{
    // Prefab to spawn
    [SerializeReference]
    private GameObject toSpawnWanderingProp;
    // Reference to where the wandering prop should spawn
    [SerializeReference]
    private Transform spawn_loc;

    // Spawn cooldown
    private float spawn_cooldown = 10.0f;

    // Update is called once per frame
    void Update()
    {
        // If we are on cooldown
        if (spawn_cooldown > 0)
        {
            spawn_cooldown -= Time.deltaTime;
        }
        else // (spawn_cooldown <= 0)
        {
            // Spawn Wandering prop and reset cooldown
            Instantiate(toSpawnWanderingProp, spawn_loc.position, spawn_loc.rotation);
            spawn_cooldown = Random.Range(15, 25);
        }
    }
}
