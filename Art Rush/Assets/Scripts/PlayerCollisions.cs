using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    // [SerializeReference]
    // private PlayerMovement movement;

    void OnCollisionEnter (Collision collisionInfo)
    {     
        if (collisionInfo.collider.tag == "Counter")
        {
            Debug.Log("We are touching a Counter");
        }

        if (collisionInfo.collider.tag == "Item Spawner")
        {
            Debug.Log("We are touching a Item Spawner");
        }
    }
}
