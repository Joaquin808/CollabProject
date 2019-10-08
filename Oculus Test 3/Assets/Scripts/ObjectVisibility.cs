using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectVisibility : MonoBehaviour
{
    List<string> collisionList = new List<string>();
    bool isVisible = false;
    Renderer rend;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rend.enabled = isVisible;


    }


    void PrintList()
    {
        for (int i = 0; i < collisionList.Count; i++)
        {
            print(collisionList[i]);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (!collisionList.Contains(collision.gameObject.tag))
        {
            collisionList.Add(collision.gameObject.tag);
        }
        PrintList();

        if (collisionList.Contains("GhostPipe") && collisionList.Contains("Tool"))
        {
            isVisible = true;
            collisionList.Remove("GhostPipe");
            collisionList.Remove("Tool");
            if (collision.gameObject.tag == "GhostPipe")
            {
                Destroy(collision.gameObject);
            }
        }
        PrintList();
    }

    void OnTriggerExit(Collider collision)
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

