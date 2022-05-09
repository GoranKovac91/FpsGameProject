using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPickup : MonoBehaviour
{
    private int _bulletCount = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            Rifle rifle = FindObjectOfType<Rifle>();
            rifle.Reload(_bulletCount);
            Destroy(gameObject);
        }
    }
}
