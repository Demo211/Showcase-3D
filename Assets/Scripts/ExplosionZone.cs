using System.Collections;
using UnityEngine;

public class ExplosionZone : MonoBehaviour
{
    [SerializeField] private float _explosionTime;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private ParticleSystem _explosionVisuals;

    private void Awake()
    {
        StartCoroutine(DoExplosion(_explosionTime));
    }

    private IEnumerator DoExplosion(float _explosionTime)
    {
        ApplyForce(GetPushableObjects());
        yield return new WaitForSeconds(_explosionTime);
        Destroy(this.gameObject);
    }

    private Collider[] GetPushableObjects()
    {
        return Physics.OverlapSphere(transform.position, _explosionRadius);
    }

    private void ApplyForce(Collider[] objects)
    {
        Vector3 offset;
        float distanceToObjectFromExplosionCenter;
        float ExplosionForce;

        foreach (Collider obj in objects)
        {
            if (obj.GetComponent<Rigidbody>() != null)
            {
                offset = obj.ClosestPoint(this.transform.position) - this.transform.position;

                distanceToObjectFromExplosionCenter = offset.magnitude;
                ExplosionForce = _explosionForce* (_explosionRadius/distanceToObjectFromExplosionCenter);
                obj.attachedRigidbody.AddForce(offset * ExplosionForce);
            }
        }
    }

    public void SetExplosionParameters(float ExplosionForceModifier,  float ExplosionRadiusModifier)
    {
        _explosionForce *= ExplosionForceModifier;
        _explosionRadius *= ExplosionRadiusModifier;
        _explosionVisuals.startSize = _explosionRadius;
    }
}

