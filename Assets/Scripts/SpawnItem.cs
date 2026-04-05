using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private GameObject _ItemToSpawn;

    private Vector3 _spawnPoint => this.transform.position;

    private void OnEnable()
    {
        _counter.CounterChanged += Spawn;
    }

    private void OnDisable()
    {
        _counter.CounterChanged -= Spawn;
    }
    
    private void Spawn()
    {
        Instantiate(_ItemToSpawn, _spawnPoint, Quaternion.identity);
    }
}
