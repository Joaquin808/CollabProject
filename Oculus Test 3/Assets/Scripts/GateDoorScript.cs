using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateDoorScript : MonoBehaviour
{
    float liftSpeed = 5;
    public GameObject LeftDoor;
    public GameObject RightDoor;
    Transform LeftDoorStartPosition;
    Transform RightDoorStartPosition;
    Vector3 RightDoorMoveDirection;// = Vector3.right;
    Vector3 LeftDoorMoveDirection;// = Vector3.left;

    // Start is called before the first frame update
    void Start()
    {
        LeftDoorStartPosition = LeftDoor.transform;
        RightDoorStartPosition = RightDoor.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (LeftDoor.transform.rotation.y >= LeftDoorStartPosition.transform.rotation.y)
        {
            LeftDoorMoveDirection = new Vector3(0, -6, 0);
            Debug.Log("Left");
        }
        else if (LeftDoor.transform.rotation.y <= - 0.5)
        {
            LeftDoorMoveDirection = Vector3.right;
            Debug.Log("Right");
        }

        LeftDoor.transform.Rotate(LeftDoorMoveDirection,Space.World);
        //Debug.Log(LeftDoor.transform.rotation.y);

        if (RightDoor.transform.rotation.y >= RightDoorStartPosition.rotation.x)
        {
            RightDoorMoveDirection = Vector3.right;
        }
        else if (RightDoor.transform.rotation.y <= RightDoorStartPosition.rotation.x - 5.5)
        {
            LeftDoorMoveDirection = Vector3.left;
        }

        RightDoor.transform.Translate(RightDoorMoveDirection * Time.deltaTime * liftSpeed);

    }
    /*
    void OnTriggerEnter(Collider collision)
    {
        if (transform.position.x >= LeftDoorStartPosition.x)
        {
            LeftDoorMoveDirection = Vector3.left;
        }

        transform.Translate(LeftDoorMoveDirection * Time.deltaTime * liftSpeed);
    }

    void OnTriggerExit(Collider collision)
    {
        if (transform.position.y <= LeftDoorStartPosition.x - 5.5)
        {
            LeftDoorMoveDirection = Vector3.right;
        }

        transform.Translate(LeftDoorMoveDirection * Time.deltaTime * liftSpeed);
    }*/
}
