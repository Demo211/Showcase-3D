using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolTracker : MonoBehaviour
{
    private readonly Dictionary<string, TrackingPool<MonoBehaviour>> _pools = new Dictionary<string, TrackingPool<MonoBehaviour>>();

    private void Awake()
    {
    }

    public TrackingPool<MonoBehaviour> GetPoolOfType(MonoBehaviour type)
    {
        string key = type.GetType().ToString();
        TrackingPool<MonoBehaviour> pool;

        if(!_pools.ContainsKey(key))
        { 
            pool = new TrackingPool<MonoBehaviour>(type);
            _pools.Add(key, pool);            
        }
        else
        {
            pool = _pools[key];
        }

        Debug.Log(key);
        return pool;
    }
}
