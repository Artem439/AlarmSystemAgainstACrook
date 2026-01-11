using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 2.0f;
    [SerializeField] private float _maxYAngle = 90.0f;
    
    private float _rotationX = 0.0f;

    private void Update()
    {
        float inputX = Input.GetAxis("Mouse X");
        float inputY = Input.GetAxis("Mouse Y");
        
        transform.parent.Rotate(Vector3.up * inputX * _sensitivity);
        
        _rotationX -= inputY * _sensitivity;
        
        _rotationX = Mathf.Clamp(_rotationX, -_maxYAngle, _maxYAngle);
        
        transform.localRotation = Quaternion.Euler(_rotationX, 0.0f, 0.0f);
    }
}