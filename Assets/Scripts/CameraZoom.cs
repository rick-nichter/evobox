using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float minFOV = 30f;
    public float maxFOV = 80f;
    public float sensitivity = 10f;
    public Camera mainCamera; 
    
    
    // Update is called once per frame
    void Update()
    {
        float FOV = mainCamera.fieldOfView;
        FOV += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        FOV = Mathf.Clamp(FOV, minFOV, maxFOV);
        mainCamera.fieldOfView = FOV; 
    }
}
