using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoost : MonoBehaviour
{
    int health = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            PlayerInteractions playerInteractions = FindObjectOfType<PlayerInteractions>();
            playerInteractions.BoostHealth(health);
            Destroy(gameObject);
            

        }
    }
}
