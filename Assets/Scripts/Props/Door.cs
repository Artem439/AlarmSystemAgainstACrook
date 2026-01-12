using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour
{
    private Animator _animator;
    
    private bool _isOpen;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Open()
    {
        if (_isOpen)
            return;

        _isOpen = true;
        _animator.SetBool("IsOpen", true);
    }

    private void Close()
    {
        if (!_isOpen)
            return;

        _isOpen = false;
        _animator.SetBool("IsOpen", false);
    }

    public void Toggle()
    {
        if (_isOpen)
            Close();
        else
            Open();
    }
}