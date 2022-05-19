using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;



public class ZombieScript : Enemy
{
    [SerializeField] private bool isDead = false;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _target;
    private Rigidbody _rigidBody;
    public GameObject healthBoosterPrefab;
    [SerializeField] private GameObject _bulletPickupPrefab;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody>();
        _navMesh = GetComponent<NavMeshAgent>();
       
    } 
    private void Start()
    {
        MainTrigger mainTrigger = GetComponentInParent<MainTrigger>();
        _rigidBody.constraints = RigidbodyConstraints.FreezeRotationX;
        _rigidBody.isKinematic = true;
        mainTrigger.OnPlayerEnter.AddListener(Attack);
    }
   
    public override void TakeDamage(int value)
    {
        if (isDead)
        {         
            return;
        }
        _health -= value;

        if (_health <=0 )
        {  
            isDead = true;
            _rigidBody.isKinematic = false;
            Destroy(_navMesh);
            Invoke("CreateBooster", 2.0f * Time.deltaTime);
            _animator.SetBool("IsDead", true);
            Destroy(gameObject,2.0f);   
        }
    }
  
    public override void Attack()
    {
        if (_health<=0)
        {
            return;
           
        }
       
        _navMesh.SetDestination(_target.position);
        _navMesh.speed = _speed;
        _animator.SetBool("IsAttacking", true);
          
    }
    public void Idle()
    {
        _animator.SetBool("IsNormal", true);
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Zombie")
        {
            _rigidBody.isKinematic = true;
          
        }
        if (collision.gameObject.tag == "Player")
        {
            
            PlayerInteractions playerInteractions = FindObjectOfType<PlayerInteractions>();
            playerInteractions.TakeDamage(_damage);
        }
       
    }
 
    public void CreateBooster()
    {
        Instantiate(healthBoosterPrefab, transform.position + Vector3.up, Quaternion.identity);
        Instantiate(_bulletPickupPrefab, transform.position + Vector3.up, Quaternion.identity);
    }
    
  


}
