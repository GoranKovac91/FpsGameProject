using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float _gravity = 9.81f;
    [SerializeField] private float _speed = 2.5f;
    [SerializeField] private float _jumpForce = 50.0f;
    private CharacterController _characterController;
    [SerializeField] private string _verticalMovement = "Vertical";
    [SerializeField] private string _horizontalMovement = "Horizontal";
    [SerializeField] private float _directionY;
   // private Animator _animator;
    public Transform jumpRay;
  
    

 

    private void Awake()
    {
      //  _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }



    private void Update()
    {
       
        Physics.Raycast(jumpRay.transform.position,jumpRay.transform.up*-1,out RaycastHit hitInfo,10.0f);
        float horizontalMovement = Input.GetAxisRaw(_horizontalMovement);
        float verticalMovement = Input.GetAxisRaw(_verticalMovement);
        Vector3 Movement = new Vector3(horizontalMovement, 0.0f, verticalMovement);
        if (Input.GetButtonDown("Jump") && hitInfo.transform.tag=="Floor")
        {
            _directionY = _jumpForce;
            Debug.Log("Jumping");
        }
        Movement.Normalize();
        Movement *= _speed;
     
        Movement = transform.transform.TransformDirection(Movement);
        _directionY -= _gravity;
        Movement.y = _directionY;
       
        _characterController.Move(Movement * Time.deltaTime);
     
        //if (Input.GetButton(_horizontalMovement)||Input.GetButton(_verticalMovement))
        //{
        //    _animator.SetBool("IsMoving", true);
        //}
        //if (Input.GetButtonUp(_horizontalMovement) || Input.GetButtonUp(_verticalMovement))
        //{
        //    _animator.SetBool("IsMoving", false);
        //}
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(jumpRay.transform.position,jumpRay.transform.position*50 );
    }



}
