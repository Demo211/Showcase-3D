using UnityEngine;
using UnityEngine.Events;

public class Interactor : MonoBehaviour
{
    [SerializeField] private KeyCode _interactionKey = KeyCode.Mouse0;
    [SerializeField] private Camera _camera;
    private Ray _ray;
    private float _rayLength = 100f;

    public event UnityAction<Cube> InteractingWithCube;

    private void Update()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(_ray.origin, _ray.direction.normalized*_rayLength);

        if (Physics.Raycast(_ray, out RaycastHit hitInfo))
        {
            if (hitInfo.transform.GetComponent<Cube>() == null)
                return;

            if (Input.GetKeyDown(_interactionKey))
            {
                hitInfo.transform.TryGetComponent<Cube>(out Cube InteractedObject);
                InteractingWithCube?.Invoke(InteractedObject);
            }
        }
    }
}
