using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperWeaponProjectile : MonoBehaviour
{     
    [SerializeField] private int _damage = 500;
    [SerializeField] public Transform _newparent;
   
  
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Zombie")
        {
            ZombieScript zombieScript = FindObjectOfType<ZombieScript>();  
            zombieScript.TakeDamage(_damage);
            Destroy(gameObject, 3.5f);
            other.gameObject.transform.SetParent(_newparent, false);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Enemy")
        {
            MeshAgent meshAgent = FindObjectOfType<MeshAgent>();
            meshAgent.TakeDamage(_damage);
            Destroy(gameObject, 3.5f);
            other.gameObject.transform.SetParent(_newparent, false);
           
        }
    }
}
