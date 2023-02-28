using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : Prop
{
    [SerializeField]
    private PlayerInteraction player;
    [SerializeField]
    private Transform parent;
    private float lifeTime = 10.0f;
    private void Update()
    {
        parent = transform.parent;
        if (parent != null && parent.CompareTag("Player"))
        {
            player = parent.GetComponentInParent<PlayerInteraction>();
            lifeTime -= Time.deltaTime;
        }
        if (lifeTime <= 0)
        {
            player.ClearHand();
            Destroy(gameObject);
        }
        
    }

}
