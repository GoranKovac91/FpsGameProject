using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
   
    public int _health;
    public NavMeshAgent _navMesh;
    public float _speed;
    public float _damage;
    public abstract void TakeDamage(int value);
    public abstract void Attack();
   
       
}
