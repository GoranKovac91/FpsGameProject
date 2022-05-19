using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoost : MonoBehaviour
{
    [SerializeField] protected  int _value = 10;
  

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            PlayerInteractions playerInteractions = FindObjectOfType<PlayerInteractions>();
            playerInteractions.BoostHealth(_value);
            Destroy(gameObject);
            

        }
    }
}
