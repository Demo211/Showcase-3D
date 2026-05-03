using static System.Math;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    public void ExplodeAt(Vector3 explosionCenter, float explosionForce, float explosionRadius)
    {
        float minForceRatio = 0;

        Vector3 offset;
        float distanceToObjectFromExplosionCenter;
        float rangeBasedForceRatio;

        foreach (Collider obj in Physics.OverlapSphere(explosionCenter, explosionRadius))
        {
            if (obj.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            {
                offset = obj.transform.position - explosionCenter;

                distanceToObjectFromExplosionCenter = offset.magnitude;
                rangeBasedForceRatio = Max((explosionRadius - distanceToObjectFromExplosionCenter) / explosionRadius, minForceRatio);
                explosionForce = explosionForce * rangeBasedForceRatio;

                rigidbody.AddForce(offset * explosionForce);
            }
        }
    }
}

