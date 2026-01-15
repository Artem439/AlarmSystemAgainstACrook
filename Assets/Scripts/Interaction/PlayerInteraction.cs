using Controls;
using Interaction.Interfaces;
using UnityEngine;

namespace Interaction
{
    [RequireComponent(typeof(InputReader))]
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private float _maxDistance = 1f;
    
        private Camera _camera;
    
        private InputReader _inputReader;

        private void OnValidate()
        {
            if (_maxDistance < 0f)
                _maxDistance = 1f;
        }
    
        private void Awake()
        {
            _inputReader = GetComponent<InputReader>();
            _camera = Camera.main;
        }
    
        private void OnEnable()
        {
            _inputReader.MouseButtonClicked += HandleInput;
        }

        private void OnDisable()
        {
            _inputReader.MouseButtonClicked -= HandleInput;
        }

        private void HandleInput()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        
            if (Physics.Raycast(ray, out RaycastHit hit, _maxDistance))
            {
                if (hit.collider.TryGetComponent(out IInteractable interactable))
                {
                    interactable.Interact();
                }
            }
        }
    }
}