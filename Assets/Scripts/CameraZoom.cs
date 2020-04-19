using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float minFOV = 30f;
    public float maxFOV = 80f;
    public float sensitivity = 20f;
    public Camera mainCamera;
    public float cameraMoveDistance;

    private Vector3 previousMousePosition;
    private Vector3 cameraStartPosition;
    
    void Start()
    {
        cameraStartPosition = mainCamera.transform.position;
    }

    void Update()
    {
        Move();
        float FOV = mainCamera.fieldOfView;
        FOV -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        FOV = Mathf.Clamp(FOV, minFOV, maxFOV);
        mainCamera.fieldOfView = FOV;
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            previousMousePosition = Input.mousePosition;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector3 mousePositionDiff = Input.mousePosition - previousMousePosition;
            previousMousePosition = Input.mousePosition;
            mousePositionDiff.z = mousePositionDiff.y;
            mousePositionDiff.y = 0;
            mousePositionDiff /= 100;
            Vector3 newCameraPos = mainCamera.transform.position - mousePositionDiff;

            newCameraPos.x = Mathf.Clamp(newCameraPos.x, cameraStartPosition.x - cameraMoveDistance, cameraStartPosition.x + cameraMoveDistance);
            newCameraPos.z = Mathf.Clamp(newCameraPos.z, cameraStartPosition.z - cameraMoveDistance, cameraStartPosition.z + cameraMoveDistance);

            mainCamera.transform.position = newCameraPos;
        }
    }
}
