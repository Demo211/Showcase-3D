using System.Collections;
using static System.Math;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private Interactor _interactor;

    [SerializeField] private float _explosionTime;
    [SerializeField] private float _baseExplosionForce;
    [SerializeField] private float _baseExplosionRadius;

    private Cube _destroyedCube;
    private Vector3 _explosionCenter;


    private float _explosionForce;
    private float _explosionRadius;

    private void OnEnable()
    {
        _interactor.ExplodingCube += Explode;
    }

    private void OnDisable()
    {
        _interactor.ExplodingCube -= Explode;
    }

    private void Explode()
    {
        _destroyedCube = _interactor.InteractedObject;
        _explosionCenter = _destroyedCube.transform.position;
        SetExplosionParameters();
        Destroy(_destroyedCube);

        StartCoroutine(DoExplosion(_explosionTime));
    }
    private IEnumerator DoExplosion(float _explosionTime)
    {
        ApplyForce(GetObjectsIRange());

        yield return new WaitForSeconds(_explosionTime);

    }

    private Collider[] GetObjectsIRange()
    {
        return Physics.OverlapSphere(_explosionCenter, _explosionRadius);
    }

    private void ApplyForce(Collider[] objects)
    {
        Vector3 offset;
        float distanceToObjectFromExplosionCenter;
        float explosionForce;

        float minForceRatio = 0;
        float rangeBasedForceRatio;


        foreach (Collider obj in objects)
        {
            if (obj.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            {
                offset = obj.transform.position - _explosionCenter;

                distanceToObjectFromExplosionCenter = offset.magnitude;
                rangeBasedForceRatio = Max((_explosionRadius - distanceToObjectFromExplosionCenter)/_explosionRadius, minForceRatio);
                explosionForce = _explosionForce * rangeBasedForceRatio;

                rigidbody.AddForce(offset * explosionForce);
            }
        }
    }

    public void SetExplosionParameters()
    {
        float modifier = _destroyedCube.transform.localScale.magnitude;

        _explosionForce = _baseExplosionForce/ modifier;
        _explosionRadius = _baseExplosionRadius/ modifier;
    }
}

