using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class AlertTrigger : MonoBehaviour
{
    public event UnityAction ThiefCame;
    public event UnityAction ThiefLeft;

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
