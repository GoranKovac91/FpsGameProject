using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShoot : MonoBehaviour
{
   
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private ParticleSystem _projectile;  
    [SerializeField] RaycastHit hit;
    private void Awake()
    {
        _projectile.Pause();
    }


    private void Update()
    {
        if (Physics.SphereCast(_shootPosition.transform.position, 2.5f, _shootPosition.transform.forward * 10.0f, out hit))
        {
            if (hit.collider.tag!="Player")
            {
                return;
            }
           
                _projectile.Play();                   

        }
    }

}
