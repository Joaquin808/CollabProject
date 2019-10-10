using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectVisibility : MonoBehaviour
{
    List<string> collisionList = new List<string>();
    bool isVisible = false;
    Renderer rend;
    public string String;

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

    /*
    //void PrintList()
    {
        for (int i = 0; i < collisionList.Count; i++)
        {
            print(collisionList[i]);
        }
    }
    */
    void OnTriggerEnter(Collider collision)
    {
        if (!collisionList.Contains(collision.gameObject.tag))
        {
            collisionList.Add(collision.gameObject.tag);
        }

        if (collisionList.Contains(String) && collisionList.Contains("Welder"))
        {
           
            isVisible = true;
            collisionList.Remove(String);
            collisionList.Remove("Welder");
            if (collision.gameObject.tag == String)
            {
                Destroy(collision.gameObject);
            }
        }

        // PrintList();
        /** if (this.gameObject.tag == "Pipe_Curved")
         {

             if (collisionList.Contains("gPipe_Curved") && collisionList.Contains("Welder"))
             {
                 isVisible = true;
                 collisionList.Remove("gPipe_Curved");
                 collisionList.Remove("Welder");
                 if (collision.gameObject.tag == "gPipe_Curved")
                 {
                     Destroy(collision.gameObject);
                 }
             }
         }
         if (this.gameObject.tag == "Pipe_Straight")
         {
             if (collisionList.Contains("gPipe_Straight") && collisionList.Contains("Welder"))
             {
                 isVisible = true;
                 collisionList.Remove("gPipe_Straight");
                 collisionList.Remove("Welder");
                 if (collision.gameObject.tag == "gPipe_Straight")
                 {
                     Destroy(collision.gameObject);
                 }
             }
         }
         if (this.gameObject.tag == "Pipe_Crooked")
         {
             if (collisionList.Contains("gPipe_Crooked") && collisionList.Contains("Welder"))
             {
                 isVisible = true;
                 collisionList.Remove("gPipe_Crooked");
                 collisionList.Remove("Welder");
                 if (collision.gameObject.tag == "gPipe_Crooked")
                 {
                     Destroy(collision.gameObject);
                 }
             }
         }
         if (this.gameObject.tag == "Pipe_Half")
         {
             if (collisionList.Contains("gPipe_Half") && collisionList.Contains("Welder"))
             {
                 isVisible = true;
                 collisionList.Remove("gPipe_Half");
                 collisionList.Remove("Welder");
                 if (collision.gameObject.tag == "gPipe_Half")
                 {
                     Destroy(collision.gameObject);
                 }
             }
             //  PrintList();
         }**/
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == String)
        {
            collisionList.Remove(String);

        }

        if (collision.gameObject.tag == "Welder")
        {
            collisionList.Remove("Welder");
        }

    }

}
