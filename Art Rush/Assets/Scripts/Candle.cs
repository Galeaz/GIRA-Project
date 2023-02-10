using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : Prop
{
    private float lifeTime = 10.0f;
    private void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        
    }

}
