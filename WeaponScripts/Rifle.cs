using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rifle : MonoBehaviour
{
    [SerializeField] protected virtual int damage { get; set; }
    [SerializeField] protected virtual float range { get; set; }
    [SerializeField] protected virtual int _bullets { get; set; }
    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private GameObject _impactEffect;
    [SerializeField] private AudioSource _weaponAudio;
    private Animator _animator;
    [SerializeField] private GameObject _shootPosition;
    [SerializeField] protected virtual int _impactForce { get; set; }
    [SerializeField] protected virtual int _bulletsToReload { get; set; }
    [SerializeField] private LayerMask _ignoreLayer;

    private void Awake()
    {
        _weaponAudio = GetComponent<AudioSource>();
        _animator = GetComponentInParent<Animator>();
        _bulletsToReload = 20;
         damage = 10;
         range = 100.0f;
        _impactForce = 500;
        _bullets = 20;

    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && _bullets>=1)
        {
            Shoot();
           
        }
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
    public virtual void Shoot()
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
    public virtual  void Reload(int value)
    {
        _bulletsToReload += value;
    }
   
    private void OnDrawGizmos()
    {
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(_shootPosition.transform.position, _shootPosition.transform.forward * range);
    }

}
