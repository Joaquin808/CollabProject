using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//skybox updater && Sleep System

//MISSING SCREEN FADE && DAY 1 & 7 COMPLETION TRIGGERES
//REQUIRES 7 MATERIALS && 1 GameObject IN SCENE

public class DayNightSystem : MonoBehaviour
{
	public float currentTime = 0f;			//current currentTime
	public float dayLength = 600f;			//DayLength = 10 minutes
	public float currentSleep = 0f;			//current sleepTime
	public float sleepTime = 120f;			//TimeToSleep = 2 minutes
	public int dayCount = 1;				//current Day
	public bool dayOneComplete = false;		//Day 1 Complete trigger
	public bool daySevenComplete = false;	//Day 7 Complete trigger
	public bool endOfDay = false;			//day end trigger
	public bool canDayPass = true;			//skybox updater trigger
	public GameObject awakeMarker;			//location to "awake" player
	private GameObject playerRef;			//player object reference
	
	//Skybox References
    public Material skyOne;					//skybox 1 mins 0-2
    public Material skyTwo;					//skybox 2 mins 2-4
    public Material skyThree;				//skybox 3 mins 4-6
    public Material skyFour;				//skybox 4 mins 6-8
    public Material skyFive;				//skybox 5 mins 8-9
	public Material skySix;					//skybox 6 mins 9-10
	public Material skySeven;				//skybox 7 mins 10+
	
	void start() {
		//Get a reference to the Player
		playerRef = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update() {
		
		//Can Time Pass?
		if (canDayPass == true) {
			currentTime += Time.deltaTime;	//UpdateTime
			dayCycle();						//Skybox Updater
		}
	
		//EndOfDayTrigger
		if (dayCount == 1) {
			if (dayOneComplete == true) {	//If Day 1 Objectives have been completed
				endOfDay = true;
				canDayPass = false;		
			}
		} else if (2 <= dayCount  && dayCount <=6 ) {
			if (currentTime >= dayLength) {	//If Time exceeds DayLength on days 2-6
				endOfDay = true;
				canDayPass = false;	
			}
		} else if (dayCount == 7) {
			if (daySevenComplete == true) { //If Day 7 Objectives have been completed
				endOfDay = true;
				canDayPass = false;		
			}
		}
		
	}
	
	//Player Collision With Bed to Trigger Day End sequence
	void OnCollisionEnter(Collision col){
        if(endOfDay == true) {
            if (col.gameObject.tag == "Player")
            {
                //fade black
                playerRef.transform.position = awakeMarker.transform.position + new Vector3(0f, 0f, 2f);  //set player position to 2 units above the marker
                playerRef.transform.rotation = awakeMarker.transform.rotation;                           //set player rotation to match the marker
                currentTime = 0f;
                dayCount++;
                canDayPass = true;
                endOfDay = false;
                //fade back in
            }
		}
	}

    //Change Skybox and UpdateEnvironment
    void dayCycle()
    {
        //Changes at 2-4-6-8-9-10 minutes
        if (currentTime < dayLength * 2 / 10)
        { //Minutes 0-2
            if (RenderSettings.skybox != skyOne)
            {
                RenderSettings.skybox = skyOne;
                DynamicGI.UpdateEnvironment();
            }
            else if (dayLength * 2 / 10 <= currentTime && currentTime <= dayLength * 4 / 10)
            { //Minutes 2-4
                if (RenderSettings.skybox != skyTwo)
                {
                    RenderSettings.skybox = skyTwo;
                    DynamicGI.UpdateEnvironment();
                }
            }
            else if (dayLength * 4 / 10 <= currentTime && currentTime <= dayLength * 6 / 10)
            { //Minutes 4-6
                if (RenderSettings.skybox != skyThree)
                {
                    RenderSettings.skybox = skyThree;
                    DynamicGI.UpdateEnvironment();
                }
            }
            else if (dayLength * 6 / 10 <= currentTime && currentTime <= dayLength * 8 / 10)
            { //Minutes 6-8
                if (RenderSettings.skybox != skyFour)
                {
                    RenderSettings.skybox = skyFour;
                    DynamicGI.UpdateEnvironment();
                }
            }
            else if (dayLength * 8 / 10 <= currentTime && currentTime <= dayLength * 9 / 10)
            { //Minutes 8-9
                if (RenderSettings.skybox != skyFive)
                {
                    RenderSettings.skybox = skyFive;
                    DynamicGI.UpdateEnvironment();
                }
            }
            else if (dayLength * 9 / 10 <= currentTime && currentTime <= dayLength)
            {       //Minutes 9-10
                if (RenderSettings.skybox != skySix)
                {
                    RenderSettings.skybox = skySix;
                    DynamicGI.UpdateEnvironment();
                }
            }
            else if (currentTime >= dayLength)
            {                                           //Minutes 10+
                if (RenderSettings.skybox != skySeven)
                {
                    RenderSettings.skybox = skySeven;
                    DynamicGI.UpdateEnvironment();
                }
            }
        }
    }
}