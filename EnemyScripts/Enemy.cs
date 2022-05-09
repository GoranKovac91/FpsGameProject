using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    protected virtual int _health { get; set; }

    protected NavMeshAgent _navMesh;
    protected virtual float _speed { get; set; }
    protected virtual float _damage { get; set; }
    public abstract void TakeDamage(int value);
    public abstract void Attack();
   
    



       
}
