using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Temperature Puzzle, Slider Mechanics

public class TemperatureSlider : MonoBehaviour
{
    private bool isStopped;
    public bool puzzleComplete = false;
    bool SolvedFirstTime;

    float x, y, z;
    //float maxNeedleRotation = 0f;
    public float correctValue1, correctValue2;
    float stoppedValue;
    public float speed;

    int alertType = 3;

    private Renderer sliderRenderer;
    public SliderPuzzleBreak sliderBreak;
    public GameObject slider; //Used to call gameobject used for sliding puzzle
    public GameObject lever, leverSwitch; //Used to call for Lever gameobject to stop slider
    public GameObject needle; //Used to call needle for visual aspect of puzzle

    Vector3 pos1, pos2, rotation;
    public AudioSource leverClick; //Used to get audio source for lever click
    public Alerts alerts;

    // Start is called before the first frame update
    void Start()
    {
        x = slider.transform.localPosition.x;
        y = slider.transform.localPosition.y;
        z = slider.transform.localPosition.z;
        pos1 = new Vector3(x + 145, y, z);  //Gets max position of object for slider
        pos2 = new Vector3(x, y, z); //Gets min position for sliding object
        rotation = new Vector3(0, 0, -40);

        leverClick.GetComponent<AudioSource>();

        //GameObject statusAlert = GameObject.Find("Inventory/MenuCanvas"); //GameObject to access Alerts script
        //alerts = statusAlert.GetComponent<Alerts>();

    }

    // Update is called once per frame
    void Update()
    {
        BarMovement();
    }

    //Sets up movement for sliding bar
    void BarMovement() 
    {
        if (isStopped == false)
        {
            slider.transform.localPosition = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
        }


    }
   
    //Detects if lever is triggered to stop slider
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Lever")
        {
            leverClick.Play(0);
            stoppedValue = slider.transform.localPosition.x;
            Objectives ObjectiveScript = GameObject.Find("OVRPlayerController").GetComponent<Objectives>();
            if (ObjectiveScript.ObjectiveNumber == 11 || SolvedFirstTime)
            {
                if (stoppedValue >= correctValue2 && stoppedValue <= correctValue1)
                {
                    isStopped = true;
                    sliderBreak.puzzleCompleteCheck++;
                    needle.transform.Rotate(rotation, Space.Self);
                    leverSwitch.GetComponent<Rigidbody>().isKinematic = true;
                }
                else
                {
                    Debug.Log("Incorrect value");
                }
            }
           
            //Use to check if lever is working
        }
    }
}
