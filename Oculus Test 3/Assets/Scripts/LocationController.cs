using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationController : MonoBehaviour
{
    public Transform cameraTransform;
    public float distanceFromCamera;

    void Update()
    {
        Vector3 resultingPosition = cameraTransform.position + cameraTransform.forward * distanceFromCamera;
        transform.position = new Vector3(resultingPosition.x, transform.position.y, resultingPosition.z);
    }
}
