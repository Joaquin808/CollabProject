using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Temperature Puzzle, Slider Mechanics

public class TemperatureSlider : MonoBehaviour
{
    private bool isStopped;
    public bool puzzleComplete = false;

    float x, z;
    public float correctValue1, correctValue2;
    float stoppedValue;
    public float speed;

    int TypeofAlert;

    //public string leverName;

    private Renderer sliderRenderer;
    public GameObject slider; //Used to call gameobject used for sliding puzzle
    public GameObject handle; //Call to Handle gameobject to check if switch is down
    Vector3 pos1, pos2;
    public Alerts alerts; //call to alerts script


    // Start is called before the first frame update
    void Start()
    {
        x = slider.transform.position.x;
        z = slider.transform.position.z;
        pos1 = new Vector3(x, 1, z);  //Gets max position of object for slider
        pos2 = new Vector3(x, 0, z); //Gets min position for sliding object
        sliderRenderer = slider.GetComponent<Renderer>();

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
            slider.transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
        }

    }
   
    //Detects if lever is triggered to stop slider
    void OnTriggerEnter(Collider other)
    {

        if (other)
        {
            stoppedValue = slider.transform.position.y;
            if (stoppedValue >= correctValue1 && stoppedValue <= correctValue2)
            {
                isStopped = true;
                sliderRenderer.material.SetColor("_Color", Color.green);
                alerts.IsAlertActive = false;
            }
            else
            {
                Debug.Log("Incorrect value");
            }
            //Use to check if lever is working
        }
    }


}
