using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Temperature Puzzle, Slider Mechanics

public class TemperatureSlider : MonoBehaviour
{
    public bool isStopped;
    public GameObject slider; //Used to call gameobject used for sliding puzzle
    float x, z;
    Vector3 pos1, pos2;
    public float correctValue1, correctValue2;
    float stoppedValue;
    private Renderer sliderRenderer;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        x = slider.transform.position.x;
        z = slider.transform.position.z;
        pos1 = new Vector3(x, 0, z);  //Gets position of object for slider
        pos2 = new Vector3(x, -1, z); //Gets second position for sliding object
        sliderRenderer = slider.GetComponent<Renderer>();
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
   
    //Detects if button is pushed to stop slider
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Button")
        {
            stoppedValue = slider.transform.position.y;
            if (stoppedValue >= correctValue1 && stoppedValue <= correctValue2)
            {
                isStopped = true;
                sliderRenderer.material.SetColor("_Color", Color.green);
            }else
            {
                Debug.Log("Incorrect value");
            }
        }
    }
}
