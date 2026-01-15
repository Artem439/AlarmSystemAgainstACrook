using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour
{
    private Animator _animator;
    
    private bool _isOpen;
    
    private readonly int IsOpen = Animator.StringToHash(nameof(IsOpen));

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        _isOpen = !_isOpen;
        _animator.SetBool(IsOpen, _isOpen);
    }
}