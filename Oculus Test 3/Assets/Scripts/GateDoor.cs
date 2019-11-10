using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateDoor : MonoBehaviour
{
    float liftSpeed = 5;
    public GameObject LeftDoor;
    public GameObject RightDoor;
    Vector3 LeftDoorStartPosition;
    Vector3 RightDoorStartPosition;
    Vector3 RightDoorMoveDirection = Vector3.right;
    Vector3 LeftDoorMoveDirection = Vector3.left;

    // Start is called before the first frame update
    void Start()
    {
        LeftDoorStartPosition = LeftDoor.transform.position;
        RightDoorStartPosition = RightDoor.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= LeftDoorStartPosition.x)
        {
            LeftDoorMoveDirection = Vector3.left;
        }
        else if (transform.position.y <= LeftDoorStartPosition.x - 5.5)
        {
            LeftDoorMoveDirection = Vector3.right;
        }

        LeftDoor.transform.Translate(LeftDoorMoveDirection * Time.deltaTime * liftSpeed);

        if (transform.position.x >= RightDoorStartPosition.x)
        {
            RightDoorMoveDirection = Vector3.right;
        }
        else if (transform.position.y <= RightDoorStartPosition.x - 5.5)
        {
            LeftDoorMoveDirection = Vector3.left;
        }

        RightDoor.transform.Translate(RightDoorMoveDirection * Time.deltaTime * liftSpeed);

    }

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
    }
}
