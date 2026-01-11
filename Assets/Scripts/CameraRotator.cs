using System;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class CameraRotator : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 2.0f;
    [SerializeField] private float _maxYAngle = 90.0f;
    
    private InputReader _inputReader;
    
    private float _rotationX = 0.0f;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _inputReader.Looked += Rotate;
    }

    private void OnDisable()
    {
        _inputReader.Looked -= Rotate;
    }

    private void Rotate(Vector2 input )
    {
        float inputX = input.x;
        float inputY = input.y;
        
        transform.parent.Rotate(Vector3.up * inputX * _sensitivity);
        
        _rotationX -= inputY * _sensitivity;
        
        _rotationX = Mathf.Clamp(_rotationX, -_maxYAngle, _maxYAngle);
        
        transform.localRotation = Quaternion.Euler(_rotationX, 0.0f, 0.0f);
    }
}