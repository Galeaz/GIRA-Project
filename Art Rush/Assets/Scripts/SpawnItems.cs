using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    [SerializeReference]
    private Object propPrefab;
    //[SerializeReference]
    //private PlayerMovement movement;
    public bool interacted_with;
    public void SpawnProp()
    {
        Instantiate(propPrefab, transform);
    }

    private void Update()
    {
        //if (interacted_with == true)
        //{
        //    SpawnProp();
        //    interacted_with = false;
        //}
    }
}
