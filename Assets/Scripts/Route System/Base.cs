using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Base : MonoBehaviour
{
    [SerializeField] private int _health;

    private void OnCollisionEnter(Collision collision)
    {
        if (TryGetComponent<Enemy>(out Enemy enemy))
        {
            Debug.Log("enemy collision");
            _health--;
            enemy.gameObject.SetActive(false);
        }
    }
}
