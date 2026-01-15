using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(IInteractable))]
public class Raycaster : MonoBehaviour
{
    [SerializeField] private float _maxDistance = 1f;
    
    private Camera _camera;
    
    private InputReader _inputReader;
    private IInteractable _interactable;

    private void OnValidate()
    {
        if (_maxDistance < 0f)
            _maxDistance = 1f;
    }
    
    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _interactable = GetComponent<IInteractable>();
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
            _interactable.Interact();
        }
    }
}