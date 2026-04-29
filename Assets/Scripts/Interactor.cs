using System;
using UnityEngine;
using UnityEngine.Events;

public class Interactor : MonoBehaviour
{
    [SerializeField] private KeyCode _interactionKey = KeyCode.Mouse0;
    [SerializeField] private Camera _camera;
    private Ray _ray;   
    private RaycastHit _hitInfo;
    private float _rayLength = 100f;

    [NonSerialized] public Cube InteractedObject;

    public event UnityAction SpawningCube;
    public event UnityAction ExplodingCube;


    private void Update()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(_ray.origin, _ray.direction.normalized*_rayLength);

        if (Physics.Raycast(_ray, out _hitInfo))
        {
            if (_hitInfo.transform.GetComponent<Cube>() == null)
                return;

            if (Input.GetKeyDown(_interactionKey))
            {
                _hitInfo.transform.TryGetComponent<Cube>(out InteractedObject);
                SpawningCube?.Invoke();
                ExplodingCube?.Invoke();
            }
        }
    }

}
