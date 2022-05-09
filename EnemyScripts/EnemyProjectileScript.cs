using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileScript : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
 
  
 
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInteractions playerInteractions = FindObjectOfType<PlayerInteractions>();
            playerInteractions.TakeDamage(_damage);

        }
    }
}
