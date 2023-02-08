using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // Info for raycasting
    private Ray ray;
    private float max_dist = 2f;
    private RaycastHit hit;
    // Stores what the previous interaction key "interacted with"
    [SerializeField] private Interactable target;

    private void Update()
    {
        // Draws ray in scene editor just to visualize the raycasting
        Debug.DrawRay(transform.position, transform.forward, Color.red);

        // If player presses the Interact "E" key
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Do a raycast in front of player
            checkRayCastInFront();
            // If the function above returned an interactable
            if (target != null)
            {
                // Complete the "Interaction", Interaction is a function in the Interactable class that get overridden to do the right interactions
                target.Interact();
            }

        }
    }

    // Perform a raycast in front of the player for a short distance
    void checkRayCastInFront()
    {
        ray = new Ray(transform.position, transform.forward);
        
        // Physics.Raycast returns true if there was a hit
        if (Physics.Raycast(ray, out hit, max_dist))
        {
            // Print out what was hit
            Debug.Log(hit.collider.gameObject.name + " was hit");
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            // Do only if the object hit was an Interactable
            if (interactable != null)
            {
                // If there was a previous target stored and its not equal to the new one
                // Detarget it using the Interactable.Offtarget()
                if (target != null && target != interactable)
                { 
                    target.Offtarget();
                    target.Interact();
                }
                
                // Set target to the new interactable in front of the player
                // and change the internal values of the target
                target = interactable;
                target.Ontarget(transform);
            }
            // If the object hit was not an interactable detarget and change values
            else 
            {
                if (target != null)
                {
                    target.Offtarget();
                    target.Interact(); // Interact() is here just to show that the interactable is properly detargeted or targeted
                }
                target = null; 
            }
        }
        // If no object was hit with raycast reset target
        else
        {
            // If there was a previous interactable detarget it
            if (target != null)
            {
                target.Offtarget();
                target.Interact();
            }
            target = null;
        }
    }
}
