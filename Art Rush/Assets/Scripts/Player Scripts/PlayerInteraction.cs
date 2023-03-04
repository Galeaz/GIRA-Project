using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    // Info for raycasting
    private Ray ray;
    private float max_dist = 4f;
    private RaycastHit hit;
    [SerializeField] LayerMask layers_to_hit;
    // Stores what the previous interaction key "interacted with"
    [SerializeField] private Interactable target;

    // Location for objects to go when picked up
    [SerializeReference]
    private Transform player_grab_loc;

    [SerializeReference]
    private Transform brush;
    // Stores the item the player is holding by reference to the transform
    [SerializeField] 
    public Transform item_held;
    // Keeps track if Item is held or not
    [SerializeField]
    private bool holding_item = false;

    public Color current_color;

    [SerializeField]
    private Graphic color_indicator; //UI brush color indicator


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
                // Chain of Ifs figures out what interactable it was
                // If interact with Item Spawner, should only be able to interact if empty hands
                if (target.tag == "Item Spawner" && holding_item == false)
                {
                    // Call Interact and set proper variables
                    target.Interact();
                    // item held stores the transform of the held item
                    item_held = player_grab_loc.GetChild(0);
                    
                    holding_item = true;
                }
                // If interact with Item Counter
                else if (target.tag == "Counter")
                {
                    // If already holding an item
                    if (holding_item == true)
                    {
                        target.Interact();
                        // If after the interact we see we aren't holding anything that means we placed the item on the counter
                        if (player_grab_loc.childCount == 0)
                        {
                            holding_item = false;
                            item_held = null;
                        }
                    }
                    // If holding NO item
                    else
                    {
                        target.Interact();
                        // If after the interact we see we ARE holding something that means we picked something up
                        if (player_grab_loc.childCount != 0)
                        {
                            holding_item = true;
                            item_held = player_grab_loc.GetChild(0);
                        }
                    }                  
                }
                // If interact with Trash Can
                else if (target.tag == "TrashCan")
                {
                    target.Interact();
                    holding_item = false;
                    item_held = null;
                }
                // If interact with Paint Can
                else if (target.tag == "Paint Bucket")
                {
                    target.Interact();
                    current_color = brush.GetChild(0).GetComponent<MeshRenderer>().material.color;
                    color_indicator.color = current_color; //changing UI color
                }
                // If interact with Sink
                else if (target.tag == "Sink")
                {
                    target.Interact();
                    current_color = brush.GetChild(0).GetComponent<MeshRenderer>().material.color;
                }
                // If interact with Customer
                else if (target.tag == "Customer")
                {
                    // If already holding an item
                    if (holding_item == true)
                    {
                        target.Interact();
                        // If after the interact we see we aren't holding anything that means we placed the item on the counter
                        if (player_grab_loc.childCount == 0)
                        {
                            holding_item = false;
                            item_held = null;
                        }
                    }
                    // If holding NO item
                    else
                    {
                        target.Interact();
                        // If after the interact we see we ARE holding something that means we picked something up
                        if (player_grab_loc.childCount != 0)
                        {
                            holding_item = true;
                            item_held = player_grab_loc.GetChild(0);
                        }
                    }
                }
                // If interact with Wandering Prop
                else if (target.tag == "WanderingProp")
                {
                    target.Interact();
                }
                else
                {
                    // Do Nothing, Not sure if it needs to do anything when no interactable
                    return;
                }
            }
        }

        else if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Q pressed");
            if (item_held != null)
            {
                item_held.GetComponent<MeshRenderer>().material.color = current_color;
            }
        }
    }

    // Perform a raycast in front of the player for a short distance
    void checkRayCastInFront()
    {
        ray = new Ray(transform.position, transform.forward);
        
        // Physics.Raycast returns true if there was a hit
        if (Physics.Raycast(ray, out hit, max_dist, layers_to_hit))
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
            }
            target = null;
        }
    }
    public void ClearHand()
    {
        holding_item = false;
        item_held = null;
    }
}
