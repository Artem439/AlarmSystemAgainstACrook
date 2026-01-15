using Controls;
using UnityEngine;

namespace PlayerMovement
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(InputReader))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 3;
    
        private CharacterController _characterController;
        private InputReader _inputReader;
    
        private Vector3 _velocity;
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
            ApplyGravity();
        
            Move();
        }
    
        private void OnMove(Vector3 direction)
        {
            _direction = direction;
        }

        private void Move()
        {
            Vector3 moveDirection = transform.TransformDirection(_direction) * _moveSpeed;

            _characterController.Move((moveDirection + _velocity) * Time.deltaTime);
        }

        private void ApplyGravity()
        {
            _velocity.y += Physics.gravity.y  * Time.deltaTime;
        }
    }
}