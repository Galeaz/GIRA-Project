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
        // If there is an object in the players grab area, destroy it
        gsm.addToScore(100);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        gsm = GameObject.FindGameObjectWithTag("GameStateManager").GetComponent<GameStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
