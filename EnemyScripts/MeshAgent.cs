using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeshAgent : Enemy,IDamagable
{
	public int StartingWaypointIndex = 0;
	public List<Transform> Waypoints;
	private NavMeshAgent _navMeshAgent;
	private int _waypointIndex;
	public GameObject shootPosition;
	private RaycastHit hit;
	public Animator animator;
	private AudioSource _enemyAudio;
	[SerializeField] private CapsuleCollider _collider;
	[SerializeField] private Transform _target;

    private void Awake()
	{
	
		_navMesh = GetComponent<NavMeshAgent>();
		_waypointIndex = StartingWaypointIndex;
		_navMesh.SetDestination(Waypoints[_waypointIndex].position);
		_navMesh.speed = _speed ;
		animator = GetComponent<Animator>();
		_enemyAudio = GetComponent<AudioSource>();
		_collider = GetComponent<CapsuleCollider>();
			
	}
	private void Start()
	{
		_navMesh.speed = _speed;
	}


	private void Update()
	{
		if (_health<=0)
		{
		
			return;			
		}
		Attack();
		NavMesh();

	}


	public void NavMesh()
	{
		if (_health<=0)
		{
			return;
		}

		if (_navMesh.remainingDistance <= 0.7f)
		{
			_waypointIndex++;

			if (_waypointIndex >= Waypoints.Count)
			{
				_waypointIndex = 0;
			}

			_navMesh.SetDestination(Waypoints[_waypointIndex].position);
		}
	}
	public override void  Attack()
    {
		if (Physics.SphereCast(shootPosition.transform.position, 2.5f, shootPosition.transform.forward * 20.0f, out hit))
		{
			if (hit.collider.tag != "Player")
			{
				return;
			}
			_enemyAudio.Play();
			_navMesh.speed = _speed * 2.0f;
			animator.SetBool("IsPlayer", true);
			_navMesh.ResetPath();
			_navMesh.SetDestination(_target.position);
			if (_navMesh.remainingDistance <= Mathf.Epsilon)
			{
				animator.SetBool("IsPunching", true);
			}
		}
	}
	public override void TakeDamage(int value)
	{
		
		_health -= value;
		Debug.Log("Taking damage");
		if (_health <= 0)
		{
			_navMesh.isStopped = true;
			_enemyAudio.enabled = false; ;
			animator.SetBool("IsDead", true);
			_collider.enabled = false;
			Destroy(gameObject, 5f);
			Destroy(transform.parent.gameObject,5.0f);
			
		}
	}
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
	    Gizmos.DrawLine(shootPosition.transform.position, shootPosition.transform.forward * 10.0f); 
		Gizmos.DrawWireSphere(shootPosition.transform.forward * 20.0f, 2.5f) ;
		
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (_health<=0)
		{
			return;
		}
		if (collision.gameObject.tag == "Player")
		{
			PlayerInteractions playerInteractions = FindObjectOfType<PlayerInteractions>();
			playerInteractions.TakeDamage(_damage);
		}
	}

    public void DamageAmmount(int damage)
    {
		TakeDamage(damage);
    }
}
