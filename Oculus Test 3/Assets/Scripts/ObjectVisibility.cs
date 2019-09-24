using UnityEngine;
using System.Collections;

public class ObjectVisibility : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GetComponent<Renderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        GetComponent<Renderer>().enabled = false;
    }
}