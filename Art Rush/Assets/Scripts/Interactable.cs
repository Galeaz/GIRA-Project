using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool istarget = false;
    private Transform player;

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
