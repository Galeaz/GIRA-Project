using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WP_Spawner : MonoBehaviour
{
    [SerializeReference]
    private GameObject toSpawnWanderingProp;

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
        else // (spawn_cooldown <= 0)
        {
            Instantiate(toSpawnWanderingProp, spawn_loc.position, spawn_loc.rotation);
            spawn_cooldown = Random.Range(15, 25);
        }
    }
}
