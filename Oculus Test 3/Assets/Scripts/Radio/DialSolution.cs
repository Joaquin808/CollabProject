using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialSolution : MonoBehaviour
{
    public GameObject lDial;
    public GameObject rDial;
    public float solutionHeight, solutionWidth;
    float height, width;
    bool varLock;
    
    // Start is called before the first frame update
    void Start()
    {
        float height = lDial.GetComponent<DialPuzzle>().sineHeight;
        float width = rDial.GetComponent<DialPuzzle>().sineWidth;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(height == 40 && width == 0)
        {
            varLock = true;
        }
        else
        {
            varLock = false;
        }
        lDial.GetComponent<Rigidbody>().freezeRotation = varLock;
        rDial.GetComponent<Rigidbody>().freezeRotation = varLock;
    }
}
