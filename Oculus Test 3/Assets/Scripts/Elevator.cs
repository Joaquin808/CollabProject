using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    public GameObject playerRef;                //Reference to the Player GameObject
    public AudioSource elevatorSound;           //"travel" music
    public bool isEnabled = false;              //is elevator working
    public bool isLocked = false;
    public float elevatorTime = 5.0f;           //time for elevator to "travel"
    public bool playerOn = false;               //is player on elevator
    public float lockTime = 3.0f;               //Time on landing to lock elevator
    private int currentFloor = 0;               //0= bunker, 1=house
    private Vector3 bunkerPos;                  //Location of the Bunker Platform
    private Vector3 elevatorHousePos;
    private Vector3 housePos;                   //Location of the House Platform


    // Start is called before the first frame update
    void Start()
    {
        //Set Location of both Platforms
        bunkerPos = this.transform.position;
        elevatorHousePos = new Vector3 (0,0,0);
        housePos = elevatorHousePos + new Vector3(0,1,0);
    }

    // Update is called once per frame	
    void Update()
    {
        if (isEnabled == true)
        {
            if (isLocked == false)
            {
                if (playerOn == true)
                {
                    //If elevator "traveling"
                    if (elevatorTime > 0)
                    {
                        if (!elevatorSound.isPlaying)
                        {
                            elevatorSound.Play();
                        }
                        elevatorTime -= Time.deltaTime;
                    }
                    //If elevator done "traveling"
                    else if (elevatorTime <= 0)
                    {
                        elevatorSound.Stop();
                        elevatorTime = 5.0f;

                        //Determine where to move player
                        if (currentFloor == 0)
                        {
                            playerRef.transform.position = housePos;
                            this.transform.position = elevatorHousePos;
                            currentFloor = 1;
                            lockElevator();
                        }
                        else
                        {
                            playerRef.transform.position = bunkerPos;
                            this.transform.position = bunkerPos;
                            currentFloor = 0;
                            lockElevator();
                        }
                    }
                }
                else
                {
                    elevatorTime = 5.0f;
                }
            }
        }
    }

    //When player enters elevator
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerOn = true;
        }
    }

    //When player leaves elevator
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerOn = false;
        }
    }

    void lockElevator()
    {
        if (lockTime > 0)
        {
            isLocked = true;
            lockTime -= Time.deltaTime;
        } else if (lockTime <= 0)
        {
            isLocked = false;
            lockTime = 3.0f;
        }
    }

}