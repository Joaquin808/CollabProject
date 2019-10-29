using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateDoorScript : MonoBehaviour
{
    float liftSpeed = 0.5f;
    public GameObject LeftDoor;
    public GameObject RightDoor;
    Transform LeftDoorStartPosition;
    Transform RightDoorStartPosition;
    Vector3 RightDoorMoveDirection;// = Vector3.right;
    Vector3 LeftDoorMoveDirection;// = Vector3.left;
    public bool IsDoorOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        LeftDoorStartPosition = LeftDoor.transform;
        RightDoorStartPosition = RightDoor.transform;
    }
    
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!IsDoorOpen)
            {
                LeftDoor.transform.Rotate(new Vector3(0, -90, 0));
                RightDoor.transform.Rotate(new Vector3(0, 90, 0));
                IsDoorOpen = true;
            }
        }
        
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
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
