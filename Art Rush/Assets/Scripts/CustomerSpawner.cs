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

    // Reference to orderUI
    [SerializeReference]
    private orderUI oUI;

    // Limit of Customers active in game
    public int customer_limit;

    // List of possible materials and props a customer's order can have
    public List<Material> possible_materials;
    public List<Prop> possible_props;

    //--------------------------------------------------------------------------------------------------------
    public static CustomerSpawner _inst;
    public static CustomerSpawner inst
    {
        get
        {
            if (_inst == null) 
            {
                _inst = Instantiate(Resources.Load<CustomerSpawner>("Customer Spawner"));
            }
            return _inst;
        }
    }

    public Transform publicFieldOrderBubble;
    //--------------------------------------------------------------------------------------------------------

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
            Transform customerTransform = just_spawned.GetComponent<Transform>();

            customer_js.setWantedColor(possible_materials[randomNumCol].color);
            customer_js.setWantedProp(possible_props[randomNumProp]);
            //display order UI
            //OrderBubble.Create(customerTransform, new Vector3(3, 3), OrderBubble.PropType.Apple, OrderBubble.ColorType.Blue);
            oUI.showOrderUI(oUI.seatTracker(), randomNumProp, randomNumCol); // needs seat location, prop and color
            // Reset Cooldown
            spawn_cooldown = 7.0f;
        } 
        else
        {
            // Reset Cooldown
            spawn_cooldown = 7.0f;
        }
    }
}
