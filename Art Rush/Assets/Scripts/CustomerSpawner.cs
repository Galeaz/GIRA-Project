using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeReference]
    private GameObject toSpawnCustomer;

    [SerializeReference]
    private Transform spawn_loc;

    private float spawn_cooldown = 7.0f;

    [SerializeReference]
    private GameStateManager gm;

    public int customer_limit;

    public List<Material> possible_materials;
    public List<Prop> possible_props;

    // Update is called once per frame
    void Update()
    {
        if (spawn_cooldown > 0 && gm.numCustomers() < customer_limit)
        {
            spawn_cooldown -= Time.deltaTime;
        }
        else if (spawn_cooldown <= 0 && gm.numCustomers() < customer_limit)
        {
            GameObject just_spawned = Instantiate(toSpawnCustomer, spawn_loc.position, spawn_loc.rotation);
            int randomNumCol = Random.Range(0, possible_materials.Count);
            int randomNumProp = Random.Range(0, possible_props.Count);

            just_spawned.GetComponent<MeshRenderer>().material.color = possible_materials[randomNumCol].color;
            Customer customer_js = just_spawned.GetComponent<Customer>();

            customer_js.setWantedColor(possible_materials[randomNumCol].color);
            customer_js.setWantedProp(possible_props[randomNumProp]);

            spawn_cooldown = 7.0f;
        }
        else
        {
            spawn_cooldown = 7.0f;
        }
    }
}
