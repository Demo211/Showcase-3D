using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover: MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate( Vector3.forward * _speed * Time.deltaTime);
    }
}
