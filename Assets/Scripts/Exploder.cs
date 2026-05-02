using System.Collections;
using static System.Math;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionTime;
    [SerializeField] private float _baseExplosionForce;
    [SerializeField] private float _baseExplosionRadius;

    private Vector3 _explosionPosition;
    private float _explosionForce;
    private float _explosionRadius;

    public void ExplodeAt(Vector3 explosionCenter)
    {
        _explosionPosition = explosionCenter;

        StartCoroutine(DoExplosion(_explosionTime));
    }
    private IEnumerator DoExplosion(float _explosionTime)
    {
        ApplyForce(GetObjectsIRange());

        yield return new WaitForSeconds(_explosionTime);

    }

    private Collider[] GetObjectsIRange()
    {
        return Physics.OverlapSphere(_explosionPosition, _explosionRadius);
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
                offset = obj.transform.position - _explosionPosition;

                distanceToObjectFromExplosionCenter = offset.magnitude;
                rangeBasedForceRatio = Max((_explosionRadius - distanceToObjectFromExplosionCenter)/_explosionRadius, minForceRatio);
                explosionForce = _explosionForce * rangeBasedForceRatio;

                rigidbody.AddForce(offset * explosionForce);
            }
        }
    }

    public void SetExplosionParameters(float modifier)
    {
        _explosionForce = _baseExplosionForce/ modifier;
        _explosionRadius = _baseExplosionRadius/ modifier;
    }
}

