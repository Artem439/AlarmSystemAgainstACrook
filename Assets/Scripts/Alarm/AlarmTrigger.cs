using System;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    public event Action<Collider> PlayerEntered;
    public event Action<Collider> PlayerOut;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Crook>(out _))
            PlayerEntered?.Invoke(null);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Crook>(out _))
            PlayerOut?.Invoke(null);
    }
}