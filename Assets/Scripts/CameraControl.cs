using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform cameraPoint;


    // Update is called once per frame
    void Update()
    {
        this.transform.position = cameraPoint.position;
        this.transform.rotation = cameraPoint.rotation;
    }
}
