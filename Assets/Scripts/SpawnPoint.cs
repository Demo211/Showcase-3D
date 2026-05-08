using System.Collections;
using UnityEngine;
using static Utils;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private float _minRange; 
    [SerializeField] private float _maxRange;

    [SerializeField] private float _timeBetweenSpawns;

    [SerializeField] private Spawnable _prefab;
    [SerializeField] private PoolTracker _poolTracker;

    private TrackingPool<Spawnable> _pool;
    private Enemy _spawnedPrefab;

    private void Awake()
    {
        _pool = _poolTracker.GetPoolOfType(_prefab);
    }

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (this.enabled)
        {
            yield return new WaitForSeconds(_timeBetweenSpawns);
            _spawnedPrefab = (Enemy)_pool.Get();

            Vector3 offset = GetUnitsSpawnPoint();
            _spawnedPrefab.transform.position = transform.position + offset;
            _spawnedPrefab.transform.forward = offset.normalized;
            _spawnedPrefab.gameObject.SetActive(true);
        }
    }
    private Vector3 GetUnitsSpawnPoint()
    {
        return new Vector3(GetRandomFloatInRange(_minRange, _maxRange) * GetRandomFloat(), 0, GetRandomFloatInRange(_minRange, _maxRange)* GetRandomFloat());
    }
}
