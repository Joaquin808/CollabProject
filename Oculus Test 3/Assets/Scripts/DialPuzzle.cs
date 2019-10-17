using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialPuzzle : MonoBehaviour
{
    public bool isLeft;
    Rigidbody rb;
    float x;
    public float solutionX;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        x = rb.transform.eulerAngles.x;
        print(x);
        if (solutionX == x)
        {

        }


        //in theory, if i divide the dial into 8 segments segment the first one would be between 22.5 and 337.5; as it would be the top 8th
        //2nd 8th would be between 22.5 and 67.5; 3rd: 67.5 and 112.5; 4th: 112.5 and 157.5; 5th: 157.5 and 202.5
        //6th: 202.5 and 247.5; 7th: 247.5 and 292.5; 8th: 292.5 and 337.5
    }
<<<<<<< HEAD

    void CheckRotation()
    {
        if(x >= 360)
        {
            x = x - 360.0f;
        }
        if(x < 0)
        {
            x = x + 360.0f;
        }
        //rb.transform.eulerAngles = new Vector3(x, 0, 0);
    }

    /*void OnBreak
    {

    }*/
=======
>>>>>>> beb2520484b69e8335dd8c35e77997590af7b617
}
