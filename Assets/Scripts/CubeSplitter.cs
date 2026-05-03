using UnityEngine;
using static Utils;

public class CubeSplitter : MonoBehaviour
{
    [SerializeField] private Interactor _interactor;

    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private MinMaxPair _amountOfDescendants = new MinMaxPair(2, 6);


    [SerializeField] private Exploder _exploder;
    [SerializeField] private float _baseExplosionForce;
    [SerializeField] private float _baseExplosionRadius;

    private Cube _targetCube;
    private Vector3 _targetCubeLocation;

    private void OnEnable()
    {
        _interactor.InteractingWithCube += SplitCube;
    }

    private void OnDisable()
    {
        _interactor.InteractingWithCube -= SplitCube;
    }

    private void SplitCube(Cube target)
    {
        _targetCube = target;
        _targetCubeLocation = _targetCube.transform.position;

        SpawnChilds();

        Destroy(_targetCube.gameObject);

        Explode();
    }

    private void SpawnChilds()
    {
        if (IsProcessed(_targetCube.ChanceToReplicate))
        {
            Vector3 antiFloorClipProtection = new Vector3(0, _targetCube.transform.localScale.y / 2, 0);
            int childsAmount = GetRandomNumber(_amountOfDescendants.Min, _amountOfDescendants.Max);

            for (int i = 0; i < childsAmount; i++)
            {
                _spawner.SpawnCube(_targetCubeLocation+antiFloorClipProtection, _targetCube.ChanceToReplicate, _targetCube.transform.localScale);
            }
        }
    }

    private void Explode()
    {
        float explosionModifier = _targetCube.transform.localScale.magnitude; 
        float explosionForce = _baseExplosionForce / explosionModifier;
        float explosionRadius = _baseExplosionRadius / explosionModifier;

        _exploder.ExplodeAt(_targetCubeLocation, explosionForce, explosionRadius);
    }
}

