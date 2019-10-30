using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

	public GameObject playerRef;                //Reference to the Player GameObject
	public AudioSource elevatorSound;			//"travel" music
	public bool isEnabled = false;				//is elevator working
	public float waitTime = 5.0f;				//time for player to leave landing
	public float elevatorTime = 5.0f;			//time for elevator to "travel"
	private bool isWait = false;				//is player at landing
	private bool playerOn = false;				//is player on elevator
	private int currentFloor = 0;				//0= bunker, 1=house
	private Vector3 moveDirection = Vector3.up; //elevator starts down
    private Vector3 bunkerPos;                  //Location of the Bunker Platform
	private Vector3 housePos;                   //Location of the House Platform


    // Start is called before the first frame update
    void Start()
    {
        //Set Location of both Platforms
        bunkerPos = transform.position;
		housePos = bunkerPos + new Vector3(0,25,0);
    }
	
    // Update is called once per frame	
    void Update() 
	{
		if (isEnabled == true){
			if (playerOn == true){
				//If Elevator is waiting at Landing
				if (isWait == true)
				{
					//If time remaining
					if (waitTime > 0)
					{
						waitTime -= Time.deltaTime;
					}
					//if time end
					else if (waitTime <= 0)
					{
						isWait = false;
						waitTime = 5.0f;
					}
				} 
				//If not waiting at landing
				else if (isWait == false)
				{
					//If elevator "traveling"
					if (elevatorTime > 0)
					{
						if(!elevatorSound.isPlaying)
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
							currentFloor == 1;
						} 
						else 
						{
							playerRef.transform.position = bunkerPos;
							currentFloor == 0;
						}
						
						isWait = true;
					}
				}
			}
		}
	}

	//When player enters elevator
	void OnTriggerEnter(Collision other) {
		if (other.gameObject.tag == "Player")
		{
			playerOn == true;
		}
	}
	
	//When player leaves elevator
	void OnTriggerExit(Collision other) {
		if (other.gameObject.tag == "Player")
		{
			playerOn == false;
		}
	}

}