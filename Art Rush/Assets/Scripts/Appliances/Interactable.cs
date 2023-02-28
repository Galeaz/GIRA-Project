using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool istarget = false;
    protected Transform player;
    // Reference of where to players "Grab" area
    protected Transform player_grab_loc;    //FOR ANTHONY
                                            // I moved player_grab_loc to here and made it protected to keep it encapsulated but also shared with children. Since every interactable 
                                            // was making a new variable and I didnt want each havig to have the same line of code to check for the location.

    // Template function for future child Interactables to override
    public virtual void Interact()
    {
        // If player is targetting it print out console message
        if (istarget)
        {
            Debug.Log(player.name + " targeted " + this.name);
        }
        // This only happens when the player presses "E" that is not interacting with the same object
        else
        {
            Debug.Log(this.name + "was detargeted");
        }
        player_grab_loc = player.transform.Find("GrabLocation");
    }

    // Player calls this function to set proper values when they are targetting this instance
    public void Ontarget(Transform player_transform)
    {
        istarget = true;
        player = player_transform;
    }

    // Player calls this function to set proper values when NOT targetting this instance
    public void Offtarget()
    {
        istarget = false;
    }
}
