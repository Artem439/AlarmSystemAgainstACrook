using System;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    public event Action<Collider> PlayerEntered;
    public event Action<Collider> PlayerOut;

    private void OnTriggerEnter(Collider other)
    {
        PlayerEntered?.Invoke(other);
    }
    
    private void OnTriggerExit(Collider other)
    {
        PlayerOut?.Invoke(other);
    }
}