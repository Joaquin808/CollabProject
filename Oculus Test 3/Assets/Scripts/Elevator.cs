using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    public GameObject playerRef;                //Reference to the Player GameObject
    public AudioSource elevatorSound;           //"travel" music
    public bool isEnabled = false;              //is elevator working
    public float elevatorTime = 5.0f;           //time for elevator to "travel"
    public bool playerOn = false;               //is player on elevator
    private int currentFloor = 0;               //0= bunker, 1=house
    private Vector3 bunkerPos;                  //Location of the Bunker Platform
    private Vector3 housePos;                   //Location of the House Platform


    // Start is called before the first frame update
    void Start()
    {
        //Set Location of both Platforms
        bunkerPos = this.transform.position;
        housePos = new Vector3(30, 22, 24);
        //housePos = GameObject.FindGameObjectWithTag("elevatorHouse").transform.position;
    }

    // Update is called once per frame	
    void Update()
    {
        if (isEnabled == true)
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
                    playerRef.transform.position = housePos;

                    //Determine where to move player
                    if (currentFloor == 0)
                    {
                        playerRef.transform.position = housePos;
                        //currentFloor = 1;
                    }
                    else
                    {
                        playerRef.transform.position = bunkerPos;
                        currentFloor = 0;
                    }
                }
            }
            else
            {
                elevatorTime = 5.0f;
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

}