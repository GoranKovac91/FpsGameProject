using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperEnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private float _force = 20.0f;
    [SerializeField] private GameObject _bulletInstance;
    [SerializeField] private Rigidbody _bulletInstanceRigidBody;
    [SerializeField] RaycastHit hit;
    private void Update()
    {

        if (Physics.SphereCast(_shootPosition.transform.position, 2.5f, _shootPosition.transform.forward * 10.0f, out hit))
        {
            if (hit.collider.tag != "Player")
            {
                return;
            }
            _bulletInstance = Instantiate(_bulletPrefab, _shootPosition.position, Quaternion.identity);
            _bulletInstanceRigidBody = _bulletInstance.GetComponent<Rigidbody>();
            _bulletInstanceRigidBody.AddForce(_shootPosition.forward * _force, ForceMode.VelocityChange);
        }
    }
}
