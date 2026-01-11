using System;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    public Action<Collider> PlayerEntered;
    public Action<Collider> PlayerOut;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>())
        {
            PlayerEntered?.Invoke(other);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>())
        {
            PlayerOut?.Invoke(other);
        }
    }
}