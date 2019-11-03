using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialPuzzle : MonoBehaviour
{
    public bool isLeft;
    Rigidbody rb;
    float currentX, intialX;
    public LineRenderer line;
    public float sineHeight, sineWidth;
    float sineX;
    Vector3[] positions = new Vector3[12];
    Vector3[] intialPositions;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        intialX = rb.transform.eulerAngles.x;
        sineX = 0;
        int x = line.positionCount;
        intialPositions = new Vector3[x];
        for(int i = 0; i < 11; i++)
        {
            intialPositions[i] = line.GetPosition(i);//this sets the intial positions for each position in the line renderer
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentX = rb.transform.eulerAngles.x;
        IncreasingOrDecreasing();
    }

    void IncreasingOrDecreasing()
    {
        //determines whether or not the dial is turning to increase or decrease the wave
        if (currentX > intialX + .5f && sineX > -40)
        {
            sineX = sineX - 5;
        }
        if (currentX < intialX - .5f && sineX < 40)
        {
            sineX = sineX + 5;
        }
        CheckLeft();
        intialX = currentX;
    }

    void CheckLeft()//checks if it is the left dial, duh
    {
        if (isLeft)
        {
            sineHeight = sineX;
        }
        else
        {
            sineWidth = sineX - (sineX/2);
        }
    }

    void ChangeWave()
    {
        for (int i = 1; i < 10; i++)
        {
            //Setting intial positions is going to keep it always as that array, this means for the x it is adding onto what it itially was so that it doesn't go beyond a certain boundry
            if (i % 2 == 0)
            {
                positions[i] = new Vector3(intialPositions[i].x - sineWidth, -sineHeight, 0);
            }
            else
            {
                positions[i] = new Vector3(intialPositions[i].x + sineWidth, sineHeight, 0);
            }
        }
        line.SetPositions(positions);
    }

    void OnBreak()
    {
        rb.transform.eulerAngles = new Vector3(0, 0, 0);
        sineX = Random.Range(-40, 40);
        CheckLeft();
        ChangeWave();
    }
}
