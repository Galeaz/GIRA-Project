using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    //Basic Fields for all props
    [SerializeField]
    private string propName;
    //Prefab of the object is currently in the toSpawnProp inside ItemSpawner. This may have to change later.

    //Will be used later for UI elements to tell the player what they are holding, will include sprites later when art is finished.
    public string GetName()
    {
        return propName;
    }
}
