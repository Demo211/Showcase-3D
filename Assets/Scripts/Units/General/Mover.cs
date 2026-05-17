using UnityEngine;

[RequireComponent(typeof(IMoving))]
public class Mover: MonoBehaviour
{
    [SerializeField] protected float _speed;

    private void Update()
    {
        transform.Translate(transform.forward * _speed * Time.deltaTime);
    }
}
