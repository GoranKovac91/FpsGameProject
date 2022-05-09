using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RottateArrTarget : MonoBehaviour
{
    
    [SerializeField] private GameObject _target;
    [SerializeField] private Vector3 _axis;
    [SerializeField] private float _speed;


    
    void Update()
    {
        transform.RotateAround(_target.transform.position,_axis,_speed*Time.deltaTime);
    }
   
}
