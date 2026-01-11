using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3;
    
    private CharacterController _characterController;
    
    private float _verticalVelocity;
    
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * vertical + transform.right * horizontal;

        _verticalVelocity -= 9.81f * Time.deltaTime;
        
        move.y = _verticalVelocity;

        _characterController.Move(move * _moveSpeed * Time.deltaTime);
    }
}