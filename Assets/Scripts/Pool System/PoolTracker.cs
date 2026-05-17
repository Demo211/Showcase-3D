using System.Collections.Generic;
using UnityEngine;

public class PoolTracker : MonoBehaviour
{
    private readonly Dictionary<string, IPool> _pools = new Dictionary<string, IPool>();

    public TrackingPool<T> GetPoolOfType<T>(T prefab) where T : MonoBehaviour, ISpawnable
    {
        string key = prefab.GetType().ToString();
        IPool pool;

        if(!_pools.ContainsKey(key))
        { 
            pool = new TrackingPool<T>(prefab);
            _pools.Add(key, pool);            
        }
        else
        {
            pool = _pools[key];
        }

        return (TrackingPool<T>)pool;
    }
}

public interface IPool
{
    
}