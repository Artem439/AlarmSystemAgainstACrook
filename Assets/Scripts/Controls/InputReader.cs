using System;
using UnityEngine;

namespace Controls
{
    public class InputReader : MonoBehaviour
    {
        private const int NumberButtonPressed = 0;
    
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
    
        private const string MouseX = "Mouse X";
        private const string MouseY = "Mouse Y";
    
        private Vector3 _direction;
        private Vector2 _mouseLookDelta;
    
        public event Action<Vector3> Moved;
        public event Action<Vector2> Looked;
        public event Action MouseButtonClicked;
    
        private void Update()
        {
            _direction = new Vector3(Input.GetAxis(Horizontal), 0f, Input.GetAxis(Vertical));
            _mouseLookDelta = new Vector2(Input.GetAxis(MouseX), Input.GetAxis(MouseY));
        
            if(_direction.sqrMagnitude > 0f || _mouseLookDelta.sqrMagnitude > 0f)
            {
                Moved?.Invoke(_direction);
                Looked?.Invoke(_mouseLookDelta);
            }
        
            if (Input.GetMouseButtonDown(NumberButtonPressed))
                MouseButtonClicked?.Invoke();
        }
    }
}