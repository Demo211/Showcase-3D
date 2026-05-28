using UnityEngine;
using System;

[RequireComponent(typeof(Collider))]
public class AlertTrigger : MonoBehaviour
{
    public event Action ThiefCame;
    public event Action ThiefLeft;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Thief>(out Thief thief))
            ThiefCame?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Thief>(out Thief thief))
            ThiefLeft?.Invoke();
    }
}
