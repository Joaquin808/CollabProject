using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOn : MonoBehaviour
{
    public int circuitsConnected;
    float moveSpeed = 0.025f;

    public AudioSource leverClick;
    public bool isBroken = true;
    bool isTriggered = false;
    public bool powerEnabled = false;
    bool isMoving;
    public Alerts AlertSystem;
    public GameObject button;
    SoundEffects soundFX;

    Vector3 moveDirection = Vector3.down;
    Vector3 startPos;
    Vector3 endPos;

    void Start()
    {
        leverClick.GetComponent<AudioSource>();
        startPos = this.transform.position;
        endPos = startPos - new Vector3(0, 0.05f, 0);
    }

    void Update()
    {
        if (isTriggered)
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

        //Move Button
        if (isMoving)
        {
            transform.Translate(moveDirection * Time.deltaTime * moveSpeed);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "IndexColliderRight" || other.gameObject.name == "IndexColliderLeft")
        {
            leverClick.Play(0);
            isTriggered = true;
            if (circuitsConnected >= 8)
            {
                //Lights come on
                isBroken = false;
                powerEnabled = true;
                AlertSystem.DeactivateAlert(0);
                Objectives ObjectiveScript = GameObject.Find("OVRPlayerController").GetComponent<Objectives>();
                if (ObjectiveScript.ObjectiveNumber == 4)
                {
                    ObjectiveScript.SetNextObjective();
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Wrench" || other.gameObject.name == "Wrench(Clone)")
        {
            leverClick.Play(0);
            isTriggered = false;
        }
    }
}
