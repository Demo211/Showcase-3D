using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSplitter : MonoBehaviour
{
    [SerializeField] private Interactor _interactor;

    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    private Cube _targetCube;
    private Vector3 _targetCubeLocation;
    private float _explosionModifier;

    private void OnEnable()
    {
        _interactor.InteractingWithCube += SplitCube;
    }

    private void OnDisable()
    {
        _interactor.InteractingWithCube -= SplitCube;
    }

    private void SplitCube()
    {
        _targetCube = _interactor.InteractedObject;
        _targetCubeLocation = _targetCube.transform.position;
        _explosionModifier = _targetCube.transform.localScale.magnitude;

        _spawner.Spawn(_targetCubeLocation, _targetCube);
        Destroy(_targetCube);

        _exploder.SetExplosionParameters(_explosionModifier);
        _exploder.ExplodeAt(_targetCubeLocation);
    }
}
