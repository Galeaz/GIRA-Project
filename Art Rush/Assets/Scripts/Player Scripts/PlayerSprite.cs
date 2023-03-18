using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, Camera.main.transform.rotation.y, 0f);
    }
}
