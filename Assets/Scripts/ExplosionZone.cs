using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionZone : MonoBehaviour
{
    [SerializeField] private float _explosionTime;
    [SerializeField] private Animation _animation;
    [SerializeField] private float _explosionForce;

    private float _spawnTime;

    private void Awake()
    {
        Instantiate(_animation, this.transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if (Time.time - _spawnTime >= _explosionTime)
        {
            Destroy(this);
        }
    }

    

}

