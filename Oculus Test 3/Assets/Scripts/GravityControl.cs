using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityControl : MonoBehaviour
{
    float GravityTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        GravityTimer += Time.deltaTime;

        // gives player enough time to grab the object before gravity is enabled and the object falls to the floor
        if (GravityTimer >= 5f)
        {
            GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
