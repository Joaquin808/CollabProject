using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectVisibility : MonoBehaviour
{
    List<string> collisionList = new List<string>();

    // Use this for initialization
    void Start()
    {
        
        GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collisionList.Contains(collision.gameObject.tag))
        {
            collisionList.Add(collision.gameObject.tag);
        }
      
        if (collisionList.Contains("GhostPipe") && collisionList.Contains("Tool"))
            { 
            GetComponent<Renderer>().enabled = true;
            collisionList.Remove("GhostPipe");
            collisionList.Remove("Tool");
            if (collision.gameObject.tag == "GhostPipe")
                {
                Destroy(collision.gameObject);
                }
            }
        }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "GhostPipe")
        {
            collisionList.Remove("GhostPipe");

        }

       if (collision.gameObject.tag == "Tool")
        {
            collisionList.Remove("Tool");
        }
    }
     
}

