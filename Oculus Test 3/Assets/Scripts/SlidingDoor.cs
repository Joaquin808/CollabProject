using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    Vector3 moveDirection = Vector3.down;   //Door starts up
    float moveSpeed = 5;
    bool isOpen = false;                    //door starts closed
    bool isMoving = false;                  //is door in motion
    Vector3 startPos;
    Vector3 endPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
        endPos = startPos - new Vector3(0, 20, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            if (this.transform.position.y > endPos.y)
            {
                moveDirection = Vector3.down;
                isMoving = true;
            }
            else
            {
                this.transform.position = endPos;
                isMoving = false;
            }
        }
        else
        {
            if (this.transform.position.y < startPos.y)
            {
                moveDirection = Vector3.up;
                isMoving = true;
            }
            else
            {
                this.transform.position = startPos;
                isMoving = false;
            }
        }

        //Move Door
        if (isMoving)
        {
            transform.Translate(moveDirection * Time.deltaTime * moveSpeed);
        }

    }

    //Player Detection Trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            isOpen = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "player")
        {
            isOpen = false;
        }
    }

}
