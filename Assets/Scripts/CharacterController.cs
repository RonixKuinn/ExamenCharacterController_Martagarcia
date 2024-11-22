using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private CharacterController _controller;
    private Animator _animator;
    private float _horizontal;
    private float _vertical;
    [SerializeField] private float _movementSpeed = 5; 

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        

        Movement();
        Gravity();
        Jump();

    }

    void Movement()
    {

    }

    void Jump()
    {

    }

    void Gravity()
    {

    }

    void GroundSensor()
    {

    }
}





















 
    /*
    ------------funciones---------------
    private CharacterController _controller;
    private Transform _camera;
    private Animator _animator;

    private float _horizontal;
    private float _vertical;
    [SerializeField] private float _movementSpeed = 5;

    private float _turnSmoothVelocity;
    [SerializeField] private float _turnSmoothTime = 0.1f;

    [SerializeField] private float _jumpHeight = 1;

    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private Vector3 _playerGravity;

    [SerializeField] LayerMask _groundLayer;
    [SerializeField] Transform _sensorPosition;
    [SerializeField] float _sensorRadius = 0.5f;

    ----------------codigo--------------------
    void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _camera = Camera.main.transform;
        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        if(Input.GetButtonDown("Jump") && IsGrouded())
        {
            Jump();
        }

        Movement();
       
        Gravity();
    }

    void Movement()
    {
        Vector3 direction = new Vector3(_horizontal, 0, _vertical);

        _animator.SetFloat("VelZ", direction.magnitude);
        _animator.SetFloat("VelX", 0);

        if(direction !=Vector3.zero)
        {
          float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
          float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
          transform.rotation = Quaternion.Euler(0, smoothAngle, 0);  

           Vector3 moveDirecion = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

          _controller.Move(moveDirecion * _movementSpeed * Time.deltaTime);

        }
    }

    void Gravity()
    {
        if(!IsGrouded())
        {
           _playerGravity.y += _gravity * Time.deltaTime;
        }
        else if(IsGrouded() && _playerGravity.y < 0)
        {
            _animator.SetBool("IsJumping", false);

            _playerGravity.y = -1;
        }
        _controller.Move(_playerGravity * Time.deltaTime);
    }

    void Jump()
    {
        _animator.SetBool("IsJumping", true);
        _playerGravity.y = Mathf.Sqrt(_jumpHeight * -2 * _gravity);
    }

    bool IsGrouded()
    {
        return Physics.CheckSphere(_sensorPosition.position, _sensorRadius, _groundLayer);
    }



    id MovimientoCutre()
    {
        Vector3 direction = new Vector3(_horizontal, 0, _vertical);

        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;



        _controller.Move(direction * _movementSpeed * Time.deltaTime)
    }
