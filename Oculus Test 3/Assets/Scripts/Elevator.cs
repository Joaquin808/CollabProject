using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public bool canMove = false;

    private Vector3 moveDirection = Vector3.up; //elevator starts down
    private float liftSpeed = 5;
    private Vector3 startPos;
    private Vector3 stopPos = new Vector3(0, 23, 0);
    public bool isWait = true;
    public float waitTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Is Elevator Enabled
        if (canMove == true)
        {
            //If Elevator is Waiting at Landing
            if (isWait == true)
            {
                if (waitTime > 0)
                {
                    waitTime -= Time.deltaTime;
                }
                else if (waitTime <= 0)
                {
                    isWait = false;
                    waitTime = 3.0f;
                }

            }
            //If Elevator is NOT Waiting at landing
            else if (isWait == false)
            {
                if (transform.position.y > stopPos.y)
                {
                    moveDirection = Vector3.down;
                }
                else if (transform.position.y < startPos.y)
                {
                    moveDirection = Vector3.up;
                    
                }
                else if (transform.position.y == startPos.y)
                {
                    isWait = true;
                }
                else if (transform.position.y == stopPos.y)
                {
                    isWait = true;
                }

                transform.Translate(moveDirection * Time.deltaTime * liftSpeed);
            }

        }

    }
}
