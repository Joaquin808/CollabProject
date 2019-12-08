using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealFanScript : MonoBehaviour
{

    Renderer rend;
    BrokenFanScript bfscrp;

    public GameObject brokeFan;
    public bool fanIn;

    List<string> collisionList = new List<string>();
    string blade1 = "ReplaceBlade1", blade2 = "ReplaceBlade2", blade3 = "ReplaceBlade3";
    private GameObject destroyedFan;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        rend.enabled = false;
        bfscrp = brokeFan.gameObject.GetComponent<BrokenFanScript>();
        fanIn = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (bfscrp.removed)
        {




            if (!collisionList.Contains(other.gameObject.name))
            {
                collisionList.Add(other.gameObject.name);
            }

            if (collisionList.Contains(blade1) && collisionList.Contains("Welder"))
            {
                rend.enabled = true;
                collisionList.Remove(blade1);
                collisionList.Remove("Welder");
                destroyedFan = GameObject.Find(blade1);
                destroyedFan.GetComponent<Renderer>().enabled = false;
                destroyedFan.GetComponent<Rigidbody>().detectCollisions = false;
                fanIn = true;
            }
            if (collisionList.Contains(blade2) && collisionList.Contains("Welder"))
            {
                rend.enabled = true;
                collisionList.Remove(blade2);
                collisionList.Remove("Welder");
                destroyedFan = GameObject.Find(blade2);
                destroyedFan.GetComponent<Renderer>().enabled = false;
                destroyedFan.GetComponent<Rigidbody>().detectCollisions = false;
                fanIn = true;
            }
            if (collisionList.Contains(blade3) && collisionList.Contains("Welder"))
            {
                rend.enabled = true;
                collisionList.Remove(blade3);
                collisionList.Remove("Welder");
                destroyedFan = GameObject.Find(blade3);
                destroyedFan.GetComponent<Renderer>().enabled = false;
                destroyedFan.GetComponent<Rigidbody>().detectCollisions = false;
                fanIn = true;
            }

        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "ReplaceBlade")
        {
            collisionList.Remove("ReplaceBlade");

        }

        if (collision.gameObject.tag == "Welder")
        {
            collisionList.Remove("Welder");
        }

    }
}
