using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : Prop
{
    [SerializeField]
    private float speedModifier;
    //Reference to the playermovement class to have access to its functions
    [SerializeField]
    private PlayerMovement player;
    //Reference for the parent object of this object
    [SerializeField]
    private Transform parent;
    // Some way to check when the player is holding the object. While holding, decrease their speed in PlayerMovement and maybe add some slippery-ness to the ground
    private void Update()
    {
        parent = transform.parent;
        if (parent != null && parent.CompareTag("Player"))
        {
            player = parent.GetComponentInParent<PlayerMovement>();

            UpdateSpeed(speedModifier);
        }
        else
        {
            UpdateSpeed(15f);
        }
    }
    private void UpdateSpeed(float speed)
    {
        player.ChangeSpeed(speed);
    }
}
