using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperEnemyProjectile : MonoBehaviour
{
    [SerializeField] private float _damage = 0.1f;
    
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInteractions playerInteractions = FindObjectOfType<PlayerInteractions>();
            playerInteractions.TakeDamage(_damage);

        }
    }
}
