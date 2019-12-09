using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    Vector3 moveDirection = Vector3.down;   //Door starts up
    float moveSpeed = 6f;
    bool isOpen = false;                    //door starts closed
    bool isMoving = false;                  //is door in motion
    public bool isLocked = false;           //Is Key Owned by Player
    Vector3 startPos;
    Vector3 endPos;
    SoundEffects soundFX;

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
        endPos = startPos - new Vector3(0, 5, 0);

        soundFX = GameObject.Find("SoundEffectsManager").GetComponent<SoundEffects>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocked)
        {
            //Lever Activated Bunker Door lock open
            if(this.gameObject.name == "BunkerPowerDoor") {
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

            //All  Basic Doors
            if (isOpen)
            {
                if (this.transform.position.y > endPos.y)
                {
                    moveDirection = Vector3.down;
                    isMoving = true;
                    if (soundFX.genAudio.clip != soundFX.genSounds[5])
                    {
                        soundFX.genAudio.Stop();
                        soundFX.genAudio.clip = soundFX.genSounds[5];
                        soundFX.genAudio.Play();

                    }
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
                    if (soundFX.genAudio.clip != soundFX.genSounds[4])
                    {
                        soundFX.genAudio.Stop();
                        soundFX.genAudio.clip = soundFX.genSounds[4];
                        soundFX.genAudio.Play();
                        
                    }
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
                //Debug.Log("Moving:" + isMoving);
                transform.Translate(moveDirection * Time.deltaTime * moveSpeed);
            }

        }
    }

    //Player Detection Trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isOpen = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isOpen = false;
        }
    }

}
