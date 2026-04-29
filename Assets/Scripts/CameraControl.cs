using UnityEngine;

public class CameraControl : MonoBehaviour
{

    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _zoomSpeed;

    [SerializeField] private KeyCode _zoomKey = KeyCode.Q;
    [SerializeField] private KeyCode _unzoomKey = KeyCode.E;
    [SerializeField] private KeyCode _resteKey = KeyCode.R;

    private float _mouseXMovement;
    private float _mouseYMovement;
    private float _eulerX = 0;
    private float _eulerY = 0;
    private int angleLimiter = 360;

    private float _horizontalRotation => Input.GetAxis("Mouse X");
    private float _verticalRotation => -Input.GetAxis("Mouse Y");

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    private void Update()
    {
        _mouseXMovement = _horizontalRotation * _rotationSpeed * Time.deltaTime;
        _mouseYMovement = _verticalRotation  * _rotationSpeed * Time.deltaTime;

        _eulerX = (transform.rotation.eulerAngles.x + _mouseYMovement) % angleLimiter;
        _eulerY = (transform.rotation.eulerAngles.y + _mouseXMovement) % angleLimiter;

        transform.rotation = Quaternion.Euler(_eulerX, _eulerY, 0);

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if(Input.GetKey(_zoomKey))
        {
            transform.Translate(Vector3.forward * _zoomSpeed * Time.deltaTime);
        }

        if(Input.GetKey(_unzoomKey))
        {
            transform.Translate(Vector3.back * _zoomSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(_resteKey))
        {
            transform.localPosition = Vector3.zero;
        }
    }
}
