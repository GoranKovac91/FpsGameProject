using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperWeapon : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private float _force=20.0f;
    [SerializeField] private AudioSource _weaponAudio;
    [SerializeField] private GameObject _bulletInstance;
    [SerializeField] private Rigidbody _bulletInstanceRigidBody;
    [SerializeField] private Transform newparent;

 

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            CreateProjectile();
            Invoke("LaunchProjectile", 2.0f);                                                                                                 
        }
    }
    public void CreateProjectile()
    {
        
        _weaponAudio.Play();
         _bulletInstance = Instantiate(_bulletPrefab, _shootPosition.position, Quaternion.identity);
         _bulletInstanceRigidBody = _bulletInstance.GetComponent<Rigidbody>();
        _bulletInstanceRigidBody.isKinematic = true;
        _bulletInstance.transform.parent = newparent.transform;
    }
    public void LaunchProjectile()
    {
        _bulletInstance.transform.parent = null;
         _bulletInstanceRigidBody = _bulletInstance.GetComponent<Rigidbody>();
        _bulletInstanceRigidBody.isKinematic = false;
        _bulletInstanceRigidBody.AddForce(_shootPosition.forward * _force, ForceMode.VelocityChange);
    }
   
}
