using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class PlayerControls2 : MonoBehaviour
{
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _speed = 2.5f;
    [SerializeField] private float _jumpForce = 2.0f;
    private CharacterController _characterController;
    [SerializeField] private string _verticalMovement = "Vertical";
    [SerializeField] private string _horizontalMovement = "Horizontal";
    [SerializeField] public bool FireWeapons { get; private set; }
    [SerializeField]
    public static event Action OnFire = delegate { };
    public LayerMask GroundLayerMask;
    public Transform GroundCheck;

    [SerializeField] private bool _isGrounded = false;

    private Vector3 _velocity;

    private void Awake()
    {
    
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _isGrounded = Physics.Linecast(transform.position, GroundCheck.position, GroundLayerMask);

        if (_isGrounded && _velocity.y < 0.0f)
        {
            _velocity.y = -2.0f;
        }

        float horizontalMovement = Input.GetAxisRaw(_horizontalMovement);
        float verticalMovement = Input.GetAxisRaw(_verticalMovement);

        Vector3 Movement = new Vector3(horizontalMovement, 0.0f, verticalMovement);
        Movement.Normalize();
        Movement *= _speed;

        Movement = transform.transform.TransformDirection(Movement);

        _characterController.Move(Movement * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jumpForce * -2.0f * _gravity);
        }
        if (Input.GetKey(KeyCode.R)&&_isGrounded==false)
        {
            _gravity = -1.5f;
        }

        _velocity.y += _gravity * Time.deltaTime;

        _characterController.Move(_velocity * Time.deltaTime);
        FireWeapons = Input.GetButtonDown("Fire1");
        if (FireWeapons)
        {
            OnFire();
        }

      
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, GroundCheck.transform.position);
    }
}
