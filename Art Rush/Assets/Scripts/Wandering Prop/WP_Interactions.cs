using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WP_Interactions : Interactable
{
    // Reference to GameStateManager
    private GameStateManager gsm;
    public override void Interact()
    {
        base.Interact();
        // Once interacted with add to score and, destroy itself
        gsm.addToScore(100);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get the Gamestatemanager
        gsm = GameObject.FindGameObjectWithTag("GameStateManager").GetComponent<GameStateManager>();
    }
}
