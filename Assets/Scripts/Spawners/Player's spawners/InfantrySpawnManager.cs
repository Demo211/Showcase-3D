using UnityEngine;

public class InfantrySpawnManager: SpawnManager<Barraks>
{
    private void Awake()
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            spawnPoint.InitiateSpawnerPools();
        }
    }

    private void Update()
    {
        foreach(var barrack in _spawnPoints)
        {
            if ((barrack.HaveUnitsReady)&&(barrack.NeedMoreOnField))
            {
                barrack.Spawn();
            }
        }
    }
}
