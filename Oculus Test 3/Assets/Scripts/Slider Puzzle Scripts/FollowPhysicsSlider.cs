using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPhysicsSlider : MonoBehaviour
{
    public Transform target;
    Rigidbody rb;
    //Transform trans;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(target.transform.position); //Allows handle to follow position of grabbable handle
                                                    //trans.position = target.transform.position;
    }
}
