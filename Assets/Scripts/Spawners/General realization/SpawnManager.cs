using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager<T>:MonoBehaviour where T: MonoBehaviour, ISpawn
{ 
    [SerializeField] protected List<T> _spawnPoints = new List<T>();

}
