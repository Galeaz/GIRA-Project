using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orderUI : MonoBehaviour
{
    //seat counter
    private int seat = -1;

    //Order bubble UI
    [SerializeReference]
    public List<GameObject> orderBubble;

    // Props UI
    [SerializeReference]
    public List<GameObject> appleProp;
    [SerializeReference]
    public List<GameObject> duckProp;
    [SerializeReference]
    public List<GameObject> candleProp;
    [SerializeReference]
    public List<GameObject> iceProp;
    [SerializeReference]
    public List<GameObject> vaseProp;

    //Color UI
    [SerializeReference]
    public List<GameObject> blueColor;
    [SerializeReference]
    public List<GameObject> redColor;
    [SerializeReference]
    public List<GameObject> yellowColor;

    public static orderUI instance = null;

    private void Awake()
    {
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    public void showOrderUI(int seatNumber, int prop_wanted, int color_wanted)
    {
        orderBubble[seatNumber].GetComponent<SpriteRenderer>().enabled = true; //show proper number of order UI

        //selecting proper prop by seat or location
        switch (prop_wanted)
        {
            case 0:
                appleProp[seatNumber].GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 1:
                duckProp[seatNumber].GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 2:
                candleProp[seatNumber].GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 3:
                iceProp[seatNumber].GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 4:
                vaseProp[seatNumber].GetComponent<SpriteRenderer>().enabled = true;
                break;
            default:
                break;
        }

        //selecting proper color by seat or location
        switch (color_wanted)
        {
            case 0:
                blueColor[seatNumber].GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 1:
                redColor[seatNumber].GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 2:
                yellowColor[seatNumber].GetComponent<SpriteRenderer>().enabled = true;
                break;
            default:
                break;
        }
    }

    public void hideOrderUI(string seatNumber, string prop_wanted)
    {
        int seatingAt = 0;

        if (seatNumber == "Seat")
        {
            seatingAt = 0;
        }
        else if (seatNumber == "Seat (1)")
        {
            seatingAt = 1;
        }
        else if (seatNumber == "Seat (2)")
        {
            seatingAt = 2;
        }

        switch (seatingAt)
        {
            case 0:
                orderBubble[0].GetComponent<SpriteRenderer>().enabled = false; //disable proper number of order UI
                blueColor[0].GetComponent<SpriteRenderer>().enabled = false;
                redColor[0].GetComponent<SpriteRenderer>().enabled = false;
                yellowColor[0].GetComponent<SpriteRenderer>().enabled = false;
                break;
            case 1:
                orderBubble[2].GetComponent<SpriteRenderer>().enabled = false; //disable proper number of order UI
                blueColor[2].GetComponent<SpriteRenderer>().enabled = false;
                redColor[2].GetComponent<SpriteRenderer>().enabled = false;
                yellowColor[2].GetComponent<SpriteRenderer>().enabled = false;
                break;
            case 2:
                orderBubble[1].GetComponent<SpriteRenderer>().enabled = false; //disable proper number of order UI
                blueColor[1].GetComponent<SpriteRenderer>().enabled = false;
                redColor[1].GetComponent<SpriteRenderer>().enabled = false;
                yellowColor[1].GetComponent<SpriteRenderer>().enabled = false;
                break;
            default:
                break;
        }

        if (seatingAt == 1)
        {
            seatingAt++;
        }
        else if (seatingAt == 2)
        {
            seatingAt--;
        }
        
        switch (prop_wanted)
        {
            case "Prop (Prop)":
                appleProp[seatingAt].GetComponent<SpriteRenderer>().enabled = false;
                break;
            case "Prop 2 (Prop)":
                duckProp[seatingAt].GetComponent<SpriteRenderer>().enabled = false; 
                break;
            case "Candle (Candle)":
                candleProp[seatingAt].GetComponent<SpriteRenderer>().enabled = false; 
                break;
            case "Ice (Ice)":
                iceProp[seatingAt].GetComponent<SpriteRenderer>().enabled = false;
                break;
            case "Vase (Ice)":
                vaseProp[seatingAt].GetComponent<SpriteRenderer>().enabled = false; 
                break;
            default:
                break;
        }
    }

    public int seatTracker()
    {
        seat++;
        if (seat > 2)
        {
            seat = 0;
        }
        return seat;
    }
}
