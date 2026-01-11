using System;
using UnityEngine;
using UnityEngine.Animations;

public class InputReader : MonoBehaviour
{
    private const int NumberButton = 0;
    
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    
    private const string InputX = "Mouse X";
    private const string InputY = "Mouse Y";
    
    private Vector3 _direction;
    private Vector2 _mouseLookDelta;
    
    public event Action<Vector3> Moved;
    public event Action<Vector2> Looked;
    public event Action MouseButtonClicked;
    
    private void Update()
    {
        _direction = new Vector3(Input.GetAxis(Horizontal), 0f, Input.GetAxis(Vertical));
        _mouseLookDelta = new Vector2(Input.GetAxis(InputX), Input.GetAxis(InputY));
        
        if(_direction.sqrMagnitude > 0f || _mouseLookDelta.sqrMagnitude > 0f)
        {
            Moved?.Invoke(_direction);
            Looked?.Invoke(_mouseLookDelta);
        }
        
        if (Input.GetMouseButtonDown(NumberButton))
            MouseButtonClicked?.Invoke();
    }
}