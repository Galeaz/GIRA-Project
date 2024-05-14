using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : Interactable
{
    // Stores what prop is being held on the Counter
    [SerializeReference]
    private Transform contained_prop;
    // Location where props are held
    [SerializeReference]
    private Transform spawn_loc;
    

    // Boolean to tell if Counter already has an item
    private bool is_holding;

    public override void Interact()
    {
        base.Interact();
        // If player is holding something and this counter is not holding anything
        if (player_grab_loc.childCount != 0 && is_holding == false)
        {
            PlaceProp(player_grab_loc.GetChild(0));
        }
        // If player has nothing and counter is holding something
        else if (player_grab_loc.childCount == 0 && is_holding == true)
        {
            PickUpProp();
        }
        // If neither of these conditions are met then nothing should happen
    }

    void PlaceProp(Transform prop)
    {
        // Store prop in class and set parent to held location
        contained_prop = prop;
        prop.SetParent(spawn_loc);
        prop.position = spawn_loc.position;
        // Change to true as it now holds an item
        is_holding = true;
    }

    void PickUpProp()
    {
        // Switch Parent to the player's grab area
        contained_prop.SetParent(player_grab_loc);
        contained_prop.position = player_grab_loc.position;
        // Reset internal values;
        is_holding = false;
        contained_prop = null;
    }

    // Public method to get the contained_prop
    public Transform GetContainedProp()
    {
        return contained_prop;
    }
}