using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateDoorScript : MonoBehaviour
{
    float moveSpeed = 0.5f;
    public GameObject LeftDoor;
    public GameObject RightDoor;
    Transform LeftDoorStartPosition;
    Transform RightDoorStartPosition;
    Vector3 RightDoorMoveDirection;// = Vector3.right;
    Vector3 LeftDoorMoveDirection;// = Vector3.left;
    public bool IsDoorOpen = false;
    public bool isLocked = true;

    // Start is called before the first frame update
    void Start()
    {
        LeftDoorStartPosition = LeftDoor.transform;
        RightDoorStartPosition = RightDoor.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Is the Power working? Enable door
        if (GameObject.Find("Power Puzzle Pieces").GetComponent<PowerOn>().powerEnabled == true)
        {
            isLocked = false;
        }
        else
        {
            //isLocked = true;
        }

        /*if (!IsDoorOpen)
        {
            LeftDoor.transform.Rotate(new Vector3(0, -90, 0));
            RightDoor.transform.Rotate(new Vector3(0, 90, 0));
            //IsDoorOpen = true;
        }
        else if (IsDoorOpen)
        {
            LeftDoor.transform.Rotate(new Vector3(0, 0, 0));
            RightDoor.transform.Rotate(new Vector3(0, 0, 0));
            //IsDoorOpen = false;
        }*/

        /*if (LeftDoor.transform.rotation.y != LeftDoorStartPosition.transform.rotation.y)
        {
            LeftDoorMoveDirection = new Vector3(0, -90, 0);
            Debug.Log("Left");
        }
        else if (LeftDoor.transform.rotation.y <= LeftDoorStartPosition.transform.rotation.y - 90)
        {
            LeftDoorMoveDirection = new Vector3(0, 90, 0);
            Debug.Log("Right");
        }*/

        //LeftDoor.transform.Rotate(LeftDoorMoveDirection, Space.World);
        //Debug.Log(LeftDoor.transform.rotation.y);

        /*if (RightDoor.transform.rotation.y >= RightDoorStartPosition.rotation.x)
        {
            RightDoorMoveDirection = Vector3.right;
        }
        else if (RightDoor.transform.rotation.y <= RightDoorStartPosition.rotation.x - 5.5)
        {
            LeftDoorMoveDirection = Vector3.left;
        }

        RightDoor.transform.Translate(RightDoorMoveDirection * Time.deltaTime * liftSpeed);*/

    }

    void OnTriggerEnter(Collider other)
    {
        if (isLocked == false)
        {
            if (other.gameObject.tag == "Player" || other.gameObject.name == "Dog")
            {
                if (!IsDoorOpen)
                {
                    LeftDoor.transform.Rotate(new Vector3(0, -90, 0));
                    RightDoor.transform.Rotate(new Vector3(0, 90, 0));
                    IsDoorOpen = true;
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (isLocked == false)
        {
            if (other.gameObject.tag == "Player" || other.gameObject.name == "Dog")
            {
                if (IsDoorOpen)
                {
                    LeftDoor.transform.Rotate(new Vector3(0, 90, 0));
                    RightDoor.transform.Rotate(new Vector3(0, -90, 0));
                    IsDoorOpen = false;
                }
            }
        }

    }
}
