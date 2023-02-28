using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seats : MonoBehaviour
{
    public bool isAvailable = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool getAvailability()
    {
        return isAvailable;
    }

    public void setAvailability(bool b)
    {
        isAvailable = b;
    }
}
