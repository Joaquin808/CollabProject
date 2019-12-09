using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationController : MonoBehaviour
{
    public Transform cameraTransform;
    public float distanceFromCamera;
    public bool CollidingWithAnything = false;

    void Update()
    {
        Vector3 resultingPosition = cameraTransform.position + cameraTransform.forward * distanceFromCamera;
        transform.position = new Vector3(resultingPosition.x, transform.position.y, resultingPosition.z);
    }

    void OnCollisionEnter(Collision other)
    {
        print("colliding with " + other);
        CollidingWithAnything = true;
    }

    void OnCollisionExit(Collision other)
    {
        CollidingWithAnything = false;
    }

}
