using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperWeaponPickup : MonoBehaviour
{
    [SerializeField] private Transform _weaponHolder;
    [SerializeField] private Transform _weaponPosition;
    public SuperWeapon weapon;
    [SerializeField] private RottateArrTarget rottate;

    private void Awake()
    {
        weapon.enabled = false;
        rottate = GetComponent<RottateArrTarget>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            weapon.enabled = true;
            rottate.enabled = false;
            transform.SetParent(_weaponHolder);
            gameObject.transform.position = _weaponPosition.transform.position;
            gameObject.transform.rotation = _weaponPosition.localRotation;
        }

    }
}
