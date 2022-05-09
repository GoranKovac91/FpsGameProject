using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MustDestroyObject : MonoBehaviour
{
    public UnityEvent OnDestroy=new UnityEvent();
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private int _health = 200;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void TakeDamage(int value)
    {
        _health -= value;
        if (_health==0)
        {
            _rb.AddExplosionForce(100, transform.position, 20);
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            OnDestroy.Invoke();
            Destroy(gameObject, 2.0f);
        }
    }
}
