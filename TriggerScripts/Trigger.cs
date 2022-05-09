using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

           ZombieScript zombieScript = GetComponentInParent<ZombieScript>();
            zombieScript.Attack();
            
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
     {

            ZombieScript zombieScript = GetComponentInParent<ZombieScript>();
           zombieScript.Attack();

       }
    }
    
}
