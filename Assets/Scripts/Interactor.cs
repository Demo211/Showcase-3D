using Unity.VisualScripting;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private Ray _ray;   
    private RaycastHit _hitInfo;
    private float _rayLength = 100f;

    private void Update()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(_ray.origin, _ray.direction.normalized*_rayLength);

        if (Physics.Raycast(_ray, out _hitInfo))
        {
            if (_hitInfo.transform.GetComponent<Replicator>() == null)
                return;

            if (Input.GetMouseButtonDown(0))
                Destroy(_hitInfo.collider.gameObject);
        }
    }

}
