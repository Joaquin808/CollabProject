﻿using System.Collections;
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
    public bool isMoving;
    public Alerts AlertSystem;
    public GameObject panel, door;
    SoundEffects soundFX;

    Vector3 moveDirection = Vector3.down;
    Vector3 startPos;
    Vector3 endPos;

    void Start()
    {
        leverClick.GetComponent<AudioSource>();
        startPos = this.transform.localPosition;
        endPos = startPos - new Vector3(0, 0.5f, 0);
    }

    void Update()
    {
        if (isTriggered)
        {
            if (this.transform.localPosition.y > endPos.y)
            {
                moveDirection = Vector3.down;
                isMoving = true;
            }
            else
            {
                this.transform.localPosition = endPos;
                isMoving = false;
            }
        }
        else
        {
            if (this.transform.localPosition.y < startPos.y)
            {
                moveDirection = Vector3.up;
                isMoving = true;
            }
            else
            {
                this.transform.localPosition = startPos;
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
        Objectives ObjectiveScript = GameObject.Find("OVRPlayerController").GetComponent<Objectives>();
        if (other.gameObject.name == "Index Finger Left" || other.gameObject.name == "Index Finger Right")
        {
            leverClick.Play(0);
            isTriggered = true;
            if (circuitsConnected >= 8 && ObjectiveScript.ObjectiveNumber == 1)
            {
                //Lights come on
                isBroken = false;
                powerEnabled = true;
                AlertSystem.DeactivateAlert(0);
                door.GetComponent<SlidingDoor>().isLocked = false;
                ObjectiveScript.SetNextObjective();
            }
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.gameObject.name == "Index Finger Left" || other.gameObject.name == "Index Finger Right")
        {
            isTriggered = false;
        }
    }


}
