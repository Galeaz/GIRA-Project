using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : Prop
{
    [SerializeField]
    private float speedModifier = 20.0f;
    //Reference to the playermovement class to have access to its functions
    [SerializeField]
    private PlayerMovement player; 
    //Reference for the parent object of this object
    [SerializeField]
    private Transform parent;
    // Some way to check when the player is holding the object. While holding, increase their speed in PlayerMovement
    private void Update()
    {
        parent = transform.parent;
        if (parent != null && parent.CompareTag("Player"))
        {
            UpdateSpeed(speedModifier);
        }
        else
        {
            //Debug.Log("Player is no longer holding."); JUST FOR TESTING
        }
    }
    private void UpdateSpeed(float speed)
    {
        player.ChangeSpeed(speed);
    }

}
