using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using static Utils;

public class Spawner<T> : MonoBehaviour where T : MonoBehaviour, ISpawnable
{
    [SerializeField] protected PoolTracker _poolTracker;
    [SerializeField] protected float _minRange;
    [SerializeField] protected float _maxRange;

    [SerializeField] protected float _timeBetweenSpawns;

    [SerializeField] protected Waypoint[] _route;  // должен быть сгенерирован отдельным скриптом 

    protected Dictionary<string, TrackingPool<T>> _trackedPools = new Dictionary<string, TrackingPool<T>>();

    virtual protected IEnumerator SpawnUnit(T entity)
    {
        var spawnedEntity = _trackedPools[entity.GetType().ToString()].Get();

        spawnedEntity.transform.position = transform.position + GetUnitsSpawnPoint();
        spawnedEntity.GetComponent<WaypointFollower>().SetRoute(_route); 
        spawnedEntity.gameObject.SetActive(true);

        yield return new WaitForSeconds(_timeBetweenSpawns);
    }

    private IEnumerator SpawnWave(Wave wave)
    {
        foreach (KeyValuePair<string, int> TypeAmountPair in wave.Setup)
        {
            string spawnedType = TypeAmountPair.Key;

            for (int i = 0; i < TypeAmountPair.Value; i++)
            {
                var spawnedEntity = _trackedPools[spawnedType].Get();

                spawnedEntity.transform.position = transform.position + GetUnitsSpawnPoint();
                spawnedEntity.GetComponent<WaypointFollower>().SetRoute(_route);
                spawnedEntity.gameObject.SetActive(true);

                
                yield return new WaitForSeconds(_timeBetweenSpawns);
            }
        }
    }

    protected Vector3 GetUnitsSpawnPoint()
    {
        return new Vector3(GetRandomFloatInRange(_minRange, _maxRange) * GetRandomFloat(), 0, GetRandomFloatInRange(_minRange, _maxRange) * GetRandomFloat());
    }

    public void Spawn(T entity)
    {
        StartCoroutine(SpawnUnit(entity));
    }

    public void Spawn(Wave wave)
    {
        StartCoroutine(SpawnWave(wave));
    }

    public void InitiatePools(List<T> entities)
    {
        foreach (var entity in entities)
        {
            _trackedPools.Add(entity.GetType().ToString(), _poolTracker.GetPoolOfType(entity));
        }
    }
}
