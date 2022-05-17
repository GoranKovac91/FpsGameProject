using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Rifle : MonoBehaviour
{
    [SerializeField] public int damage;
    [SerializeField] public float range;
    [SerializeField] public  static int _bullets=20; 
    [SerializeField] public ParticleSystem _muzzleFlash;
    [SerializeField] public GameObject _impactEffect;
    [SerializeField] public AudioSource _weaponAudio;
    [SerializeField] public GameObject _shootPosition;
    [SerializeField] public int _impactForce;
    [SerializeField] public static int _bulletsToReload;
    [SerializeField] public LayerMask _ignoreLayer;
  
   

    public  void Awake()
    {
        _weaponAudio = GetComponent<AudioSource>();
        PlayerControls2.OnFire += Shoot;
       
    }
    public  void Update()
    {
        //if (Input.GetButtonDown("Fire1") && _bullets>=1)
        //{
        //    Debug.Log("Shooting");
        //    Shoot();
           
        //}
        if (Input.GetKeyDown(KeyCode.R) && _bulletsToReload > 0 &&_bullets <=0)
        {
          
            if (_bulletsToReload + _bullets < 20 )
            {
                _bullets += _bulletsToReload;
                _bulletsToReload -= _bullets;

            }
            else if (_bulletsToReload + _bullets >= 20)
            {
                _bullets = 20;
                _bulletsToReload -= 20;
            }
            
           
        }
    }
    private void Shoot()
    {
       
        _muzzleFlash.Play();
        _weaponAudio.Play();
        RaycastHit hit;

            if (Physics.Raycast(_shootPosition.transform.position, _shootPosition.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);
                MeshAgent meshAgent = hit.transform.GetComponent<MeshAgent>();
                ZombieScript zombieScript = hit.transform.GetComponent<ZombieScript>();
                MustDestroyObject mustDestroy = hit.transform.GetComponent<MustDestroyObject>();
                if (meshAgent != null )
                {
                    meshAgent.TakeDamage(damage);
                //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                //hit.rigidbody.AddForceAtPosition(ray.direction * _impactForce, hit.point);

            }
                if (zombieScript != null && hit.rigidbody != null)
                {
                   
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                
                    hit.rigidbody.AddForceAtPosition(ray.direction * _impactForce, hit.point);
                    zombieScript.TakeDamage(damage);
                }
                if (mustDestroy!=null)
                {
                mustDestroy.TakeDamage(damage);
                }

                GameObject impactGO = Instantiate(_impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

                Destroy(impactGO, 1.0f);
                _bullets--;
                GameManager gameManager = FindObjectOfType<GameManager>();
                gameManager.UpdateBullets(_bullets, _bulletsToReload);
            }

        
    }
    public void Reload(int value)
    {
        _bulletsToReload += value;
    }
   
    private void OnDrawGizmos()
    {
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(_shootPosition.transform.position, _shootPosition.transform.forward * range);
    }

}
