using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : Interactable
{
    // Reference to player's grab area
    [SerializeReference]
    private Transform player_grab_loc;

    public override void Interact()
    {
        base.Interact();
        // If there is an object in the players grab area, destroy it
        DestroyHeldItem();
    }

    void DestroyHeldItem()
    {
        // If player is holding something
        if (player_grab_loc.childCount != 0)
        {
            Destroy(player_grab_loc.GetChild(0).gameObject);
        }
    }
}
