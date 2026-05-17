using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawnManager : SpawnManager<EnemyBase>
{
    [SerializeField] private float _timeBetweenWaves = 10;
    private int _waveCounter = 0;

    private void Awake()
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            spawnPoint.InitiateSpawnerPools();
        }

        DefineWaves();
    }

    private void OnEnable()
    {
        StartCoroutine(SendWaves());
    }

    private IEnumerator SendWaves()
    {
        while (_waveCounter < 3) // test placement
        {
            foreach (var spawnPoint in _spawnPoints)
            {
                spawnPoint.SpawnWave(_waveCounter);
            }

            yield return new WaitForSeconds(_timeBetweenWaves);
            _waveCounter++;
        }
    }

    private void DefineWaves() // replace with WaveGenerator or proper external List
    {
        List<Wave> waveList1 = new List<Wave>(){new Wave(typeof(BasicEnemy).ToString(), 5),
                                                new Wave(typeof(BasicEnemy).ToString(), 0),
                                                new Wave(typeof(ToughEnemy).ToString(), 2)};

        List<Wave> waveList2 = new List<Wave>(){new Wave(typeof(BasicEnemy).ToString(), 2),
                                                new Wave(typeof(FastEnemy).ToString(), 5),
                                                new Wave(typeof(ToughEnemy).ToString(), 3)};

        waveList2[0].AddEnemiesInWave(typeof(ToughEnemy).ToString(), 1);

        _spawnPoints[0].SetWaveList(waveList1);
        _spawnPoints[1].SetWaveList(waveList2);
    }    
}