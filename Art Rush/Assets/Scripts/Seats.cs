using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seats : MonoBehaviour
{
    // Track is Seat object is taken by a customer
    public bool isAvailable = true;

    // Get and Set for isAvailable
    public bool getAvailability()
    {
        return isAvailable;
    }

    public void setAvailability(bool b)
    {
        isAvailable = b;
    }
}
