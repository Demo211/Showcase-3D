using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolTracker : MonoBehaviour
{
    private readonly Dictionary<string, TrackingPool<Spawnable>> _pools = new Dictionary<string, TrackingPool<Spawnable>>();

    private void Awake()
    {
    }

    public TrackingPool<Spawnable> GetPoolOfType(Spawnable type)
    {
        string key = type.GetType().ToString();
        TrackingPool<Spawnable> pool;

        if(!_pools.ContainsKey(key))
        { 
            pool = new TrackingPool<Spawnable>(type);
            _pools.Add(key, pool);            
        }
        else
        {
            pool = _pools[key];
        }

        return pool;
    }
}
