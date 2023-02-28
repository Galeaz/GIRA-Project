using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Interactable
{
    // Stores what prop/object we are spawning
    [SerializeReference]
    private GameObject toSpawnProp;
    // Reference to where to spawn props
    [SerializeReference]
    private Transform spawn_loc;
    // Reference of where to move object when item is spawned
    [SerializeReference]
    private Transform player_grab_loc;

    public override void Interact()
    {
        // Do Normal Interact fucntions
        base.Interact();
        // Call Spawn Prop
        SpawnProp();
    }

    void SpawnProp()
    {
        // Creat a new instance of the prop
        GameObject new_prop = Instantiate(toSpawnProp, spawn_loc.position, spawn_loc.rotation);
        // Make it Immobile (I think this can be removed later as we aren't using it rigidbody for anything)
        new_prop.GetComponent<Rigidbody>().isKinematic = true;
        // Setup its position and Make the Player's grab area its parent
        new_prop.transform.position = player_grab_loc.position;
        new_prop.transform.SetParent(player_grab_loc);
    }
}
