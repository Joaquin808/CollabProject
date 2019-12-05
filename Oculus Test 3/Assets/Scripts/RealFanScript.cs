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
            // if (other.gameObject.name == "Welder" && other.gameObject.name == "ReplaceBlade")
            // {



            if (!collisionList.Contains(other.gameObject.name))
            {
                collisionList.Add(other.gameObject.name);
            }

            if (collisionList.Contains("ReplaceBlade") && collisionList.Contains("Welder"))
            {
                rend.enabled = true;
                collisionList.Remove("ReplaceBlade");
                collisionList.Remove("Wrench");
                destroyedFan = GameObject.Find("ReplaceBlade");
                Destroy(destroyedFan);




            }
            // }
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
