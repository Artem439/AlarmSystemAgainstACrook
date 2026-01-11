using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(InputReader))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3;
    
    private CharacterController _characterController;
    private InputReader _inputReader;
    
    private float _verticalVelocity;
    
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _inputReader.Moved += Move;
    }

    private void OnDisable()
    {
        _inputReader.Moved -= Move;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Move(Vector3 input)
    {
        float horizontal = input.x;
        float vertical = input.y;

        Vector3 move = transform.forward * vertical + transform.right * horizontal;

        _verticalVelocity -= 9.81f * Time.deltaTime;
        
        move.y = _verticalVelocity;

        _characterController.Move(move * _moveSpeed * Time.deltaTime);
    }
}