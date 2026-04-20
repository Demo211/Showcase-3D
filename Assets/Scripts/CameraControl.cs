using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerarotation : MonoBehaviour
{

    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _zoomSpeed;
    private float X, Y, Z;
    private float eulerX = 0, eulerY = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        X = Input.GetAxis("Mouse X") * _rotationSpeed * Time.deltaTime;
        Y = -Input.GetAxis("Mouse Y") * _rotationSpeed * Time.deltaTime;
        eulerX = (transform.rotation.eulerAngles.x + Y) % 360;
        eulerY = (transform.rotation.eulerAngles.y + X) % 360;
        transform.rotation = Quaternion.Euler(eulerX, eulerY, 0);

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if(Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.forward * _zoomSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.E))
        {
            transform.Translate(Vector3.back * _zoomSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.localPosition = Vector3.zero;
        }
    }
}
