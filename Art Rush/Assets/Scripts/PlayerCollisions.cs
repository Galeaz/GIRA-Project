using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeReference]
    private PlayerMovement movement;

    void OnCollisionEnter (Collision collisionInfo)
    {     
        if (collisionInfo.collider.tag == "Counter")
        {
            // (collisionInfo.
            Debug.Log("We are touching a Counter");
            // movement.touching = collisionInfo.;
        }

        if (collisionInfo.collider.tag == "Item Spawner")
        {
            Debug.Log("We are touching a Item Spawner");
            // movement.touching = collisionInfo.gameObject;
        }
    }
}
