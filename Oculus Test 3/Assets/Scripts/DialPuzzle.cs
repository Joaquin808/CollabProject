using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialPuzzle : MonoBehaviour
{
    public bool isLeft;
    Rigidbody rb;
    float currentX, intialX;
    public int sineHeight, sineWidth, solutionOne, solutionTwo;
    int sineX;
    //public float solutionX1, solutionX2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        intialX = rb.transform.eulerAngles.x;
        sineX = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentX = rb.transform.eulerAngles.x;
        IncreasingOrDecreasing();
        //CheckSolution(solutionOne, solutionTwo); 
        //Check comments down in other functions 
    }

    void IncreasingOrDecreasing()
    {

        if (currentX > intialX + .5f)
        {
            sineX = sineX - 1;
        }
        if (currentX < intialX - .5f)
        {
            sineX = sineX + 1;
        }
        //Checls if the left bool is true
        CheckLeft();
        intialX = currentX;
    }

    void CheckLeft()
    {
        //If true it will make sineHeight equal to the value of sineX
        if (isLeft)
        {
            sineHeight = sineX;
        }
        else
        {
            sineWidth = sineX;
        }
    }
    //This should probably be used for the actual sine wave script
   /* void CheckSolution(int x, int y)
    {
        if (sineHeight == x && sineWidth == y)
        {

        }
    }*/

    void OnBreak()
    {
        rb.transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
