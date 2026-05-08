using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrackingPool<T> where T : Spawnable 
{
    private T _prefab;
    private List<T> _objects;

    public TrackingPool(T prefab)
    {
        _prefab = prefab;
        _objects = new List<T>();
    }

    public T Get()
    {
        T entity = _objects.FirstOrDefault(x  => x.gameObject.activeSelf == false);

        if( entity == null )
        {
            return Create();
        }

        return entity;
    }

    private T Create()
    {
        T entity = GameObject.Instantiate(_prefab);
        _objects.Add(entity);
        return entity;
    }
}

