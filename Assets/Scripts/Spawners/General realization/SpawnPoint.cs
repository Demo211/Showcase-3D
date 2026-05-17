using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpawnPoint<T> :MonoBehaviour, ISpawn where T: MonoBehaviour, ISpawnable
{
    [SerializeField] protected Spawner<T> _spawner;
    [SerializeField] protected List<T> _possibleTypes;
    [SerializeField] protected List<Wave> _waveList;

    public void InitiateSpawnerPools()
    {
        _spawner.InitiatePools(_possibleTypes);
    }

    public void SetWaveList(List<Wave> waveList)
    {
        _waveList = waveList;
    }

    public void SpawnWave(int waveID)
    {
        _spawner.Spawn(_waveList[waveID]);
    }

    public void Spawn(T entity)
    {
        _spawner.Spawn(entity);
    }
}
