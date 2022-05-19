using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPickup : HealthBoost
{
 
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            Rifle rifle = FindObjectOfType<Rifle>();
            rifle.Reload(_value);
            Destroy(gameObject);
        }
    }
}
