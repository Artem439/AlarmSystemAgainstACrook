using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(InputReader))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3;
    
    private CharacterController _characterController;
    private InputReader _inputReader;
    
    private float _verticalVelocity;
    private Vector3 _direction;
    
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _inputReader.Moved += OnMove;
    }

    private void OnDisable()
    {
        _inputReader.Moved -= OnMove;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Move();
    }

    private void OnMove(Vector3 input)
    {
        float horizontal = input.x;
        float vertical = input.y;

        _direction = transform.forward * vertical + transform.right * horizontal;
    }

    private void Move()
    {
        _verticalVelocity -= 9.81f * Time.deltaTime;
        
        _direction.y = _verticalVelocity;

        _characterController.Move(_direction * _moveSpeed * Time.deltaTime);
    }
}