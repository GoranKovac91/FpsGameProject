using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Rifle
{
    protected override int _impactForce { get => base._impactForce; set => base._impactForce = 200; }
    protected override float range { get => base.range; set => base.range = 50.0f; }
    protected override int damage { get => base.damage; set => base.damage = 5; }
    protected override int _bullets { get => base._bullets; set => base._bullets = 40; }
    protected override int _bulletsToReload { get => base._bulletsToReload; set => base._bulletsToReload = 40; }


    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private GameObject _impactEffect;
    [SerializeField] private AudioSource _weaponAudio;
    private Animator _animator;
    [SerializeField] private GameObject _shootPosition;
   

    

    private void Awake()
    {
        _weaponAudio = GetComponent<AudioSource>();
        _animator = GetComponentInParent<Animator>();
      

    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && _bullets >= 1)
        {
            Shoot();

        }
        if (Input.GetKeyDown(KeyCode.R) && _bulletsToReload > 0 && _bullets <= 0)
        {

            if (_bulletsToReload + _bullets < 40)
            {
                _bullets += _bulletsToReload;
                _bulletsToReload -= _bullets;

            }
            else if (_bulletsToReload + _bullets >= 40)
            {
                _bullets = 20;
                _bulletsToReload -= 40;
            }


        }


    }
    public void Shoot()
    {

        _muzzleFlash.Play();
        _weaponAudio.Play();
        RaycastHit hit;

        if (Physics.Raycast(_shootPosition.transform.position, _shootPosition.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            MeshAgent meshAgent = hit.transform.GetComponent<MeshAgent>();
            ZombieScript zombieScript = hit.transform.GetComponent<ZombieScript>();
            if (meshAgent != null)
            {
                meshAgent.TakeDamage(damage);

            }
            if (zombieScript != null && hit.rigidbody != null)
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                hit.rigidbody.AddForceAtPosition(ray.direction * _impactForce, hit.point);
                zombieScript.TakeDamage(damage);


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
