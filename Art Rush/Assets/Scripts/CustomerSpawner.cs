using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    // Reference to Prefab to spawn
    [SerializeReference]
    private GameObject toSpawnCustomer;
    // Reference to the Spawner's tranform 
    [SerializeReference]
    private Transform spawn_loc;

    // Customer spawn cooldown
    private float spawn_cooldown = 7.0f;

    // Reference to GameStateManager
    [SerializeReference]
    private GameStateManager gm;

    //[SerializeReference]
    //private orderUI OUIinst;

    // Limit of Customers active in game
    public int customer_limit;

    // List of possible materials and props a customer's order can have
    public List<Material> possible_materials;
    public List<Prop> possible_props;

    //Props
    [SerializeField]
    private Sprite appleProp;
    [SerializeField]
    private Sprite duckProp;
    [SerializeField]
    private Sprite candleProp;
    [SerializeField]
    private Sprite iceProp;
    [SerializeField]
    private Sprite vaseProp;

    //Colors
    [SerializeField]
    private Sprite blueColor;
    [SerializeField]
    private Sprite redColor;
    [SerializeField]
    private Sprite yellowColor;

    public enum PropType
    {
        Apple,
        Duck,
        Candle,
        Ice,
        Vase
    }

    public enum ColorType
    {
        Blue,
        Red,
        Yellow
    }

    private Transform customerTransform;

    // Update is called once per frame
    void Update()
    {
        // If we are on a cooldown and we won't exceed the customer limit if we were to spawn one
        if (spawn_cooldown > 0 && gm.numCustomers() < customer_limit)
        {
            spawn_cooldown -= Time.deltaTime;
        }
        // If we can spawn a customer
        else if (spawn_cooldown <= 0 && gm.numCustomers() < customer_limit)
        {
            // Instatiate Customer
            GameObject just_spawned = Instantiate(toSpawnCustomer, spawn_loc.position, spawn_loc.rotation);
            // Randomly generate what material and prop the customer wants
            int randomNumCol = Random.Range(0, possible_materials.Count);
            int randomNumProp = Random.Range(0, possible_props.Count);

            just_spawned.GetComponent<MeshRenderer>().material.color = possible_materials[randomNumCol].color;
            // Get the Customer Script from the just spawned customer and set its variables to the randomly generated one prior
            Customer customer_js = just_spawned.GetComponent<Customer>();

            customerTransform = just_spawned.transform;
            

            customer_js.setWantedColor(possible_materials[randomNumCol].color);
            customer_js.setWantedProp(possible_props[randomNumProp]);
            //display order UI
            showOrderUI(randomNumProp, randomNumCol); // needs prop and color
            // Reset Cooldown
            spawn_cooldown = 7.0f;
        } 
        else
        {
            // Reset Cooldown
            spawn_cooldown = 7.0f;
        }
    }

    public void showOrderUI(int prop_wanted, int color_wanted)
    {
        //selecting proper prop
        switch (prop_wanted)
        {
            case 0:
                customerTransform.GetChild(1).GetChild(1).GetComponent<SpriteRenderer>().sprite = appleProp;
                break;
            case 1:
                customerTransform.GetChild(1).GetChild(1).GetComponent<SpriteRenderer>().sprite = duckProp;
                break;
            case 2:
                customerTransform.GetChild(1).GetChild(1).GetComponent<SpriteRenderer>().sprite = candleProp;
                break;
            case 3:
                customerTransform.GetChild(1).GetChild(1).GetComponent<SpriteRenderer>().sprite = iceProp;
                break;
            case 4:
                customerTransform.GetChild(1).GetChild(1).GetComponent<SpriteRenderer>().sprite = vaseProp;
                break;
            default:
                Debug.Log("PROP ERROR: GIVING APPLE");
                break;
        }

        //selecting proper color
        switch (color_wanted)
        {
            case 0:
                customerTransform.GetChild(1).GetChild(2).GetComponent<SpriteRenderer>().sprite = blueColor;
                break;
            case 1:
                customerTransform.GetChild(1).GetChild(2).GetComponent<SpriteRenderer>().sprite = redColor;
                break;
            case 2:
                customerTransform.GetChild(1).GetChild(2).GetComponent<SpriteRenderer>().sprite = yellowColor;
                break;
            default:
                Debug.Log("COLOR ERROR: GIVING BLUE");
                break;
        }
    }
}
