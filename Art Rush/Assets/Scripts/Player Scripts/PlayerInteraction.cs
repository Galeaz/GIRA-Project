using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerInteraction : MonoBehaviour
{
    public Counter counter; // Cesar added

    // Cesar Added
    public Slider mySlider;
    private bool castRequest, castSuccess, castInProgress;
    public float castTime = 1;
    private float castStartTime;
    // Cesar Added


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

    [SerializeField]
    private int playerNum;
    private string playerInteract;
    private string playerPaint;

    [SerializeReference]
    private Transform brush;
    // Stores the item the player is holding by reference to the transform
    [SerializeField] 
    public Transform item_held;
    // Keeps track if Item is held or not
    [SerializeField]
    private bool holding_item = false;
    //shows the current color of the brush
    [SerializeField]
    private Graphic color_indicator; //UI brush color indicator

    public Color current_color;

    private void Start()
    {
        playerInteract = "Interact" + playerNum;
        playerPaint = "Paint" + playerNum; 
    }

    private void Update()
    {
        // Draws ray in scene editor just to visualize the raycasting
        Debug.DrawRay(transform.position, transform.forward, Color.red);

        // If player presses the Interact "E" key
        if (Input.GetButtonDown(playerInteract))
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
                else if (target.tag == "Counter" || target.tag == "painting counter")
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
        // If players presses the paint button "q".
        else if (Input.GetButtonDown(playerPaint))
        {
            castTime = 2f;
            if (!castInProgress)
            {
                StartCoroutine(Cast());
            }
        }

        if (castRequest)
        {
            ProgressSlider();

            if (Input.GetButtonUp(playerPaint))
            {
                CastFail();
            }
        }
    }

    private IEnumerator Cast()
    {
        // Do a raycast in front of player
        checkRayCastInFront();

        // If the function above returned an interactable
        if (target != null)
        {
            if (target.tag == "painting counter" && counter.GetContainedProp() != null)
            {
                castInProgress = true;

                RequestCast();

                yield return new WaitUntil(() => castRequest == false);

                // Only if the interactable is the Painting Counter Object.
                // Whatever object is in the counter, is painted with the brush color in hand.
                if (castSuccess)
                {
                    item_held = counter.GetContainedProp();
                    item_held.GetComponent<MeshRenderer>().material.color = current_color;
                    item_held.GetComponent<MeshRenderer>().material.color = current_color; //ERASED .GetChild(0) after item_held
                }
                else
                {
                    Debug.Log("Painting was unsuccessful");
                }
            }
            mySlider.value = 0;
            castInProgress = false;
        }
    }

    private void RequestCast()
    {
        castRequest = true;
        castSuccess = true;
        mySlider.value = 0;
        castStartTime = Time.time;
        Invoke("CastSuccess", castTime);
    }

    private void CastSuccess()
    {
        castRequest = false;
        castSuccess = true;
    }

    private void CastFail()
    {
        castRequest = false;
        castSuccess = false;
        CancelInvoke("CastSuccess");
    }

    private void ProgressSlider()
    {
        float timePassed = Time.time - castStartTime;
        float percentComplete = timePassed / castTime;
        mySlider.value = percentComplete;
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

            // Created this variable to be able to retrieve the object that is placed on the "counter" it is on.
            counter = hit.collider.GetComponent<Counter>();

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
