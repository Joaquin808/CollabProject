using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealFanScript : MonoBehaviour
{
    
    Renderer rend;
    BrokenFanScript bfscrp;

    public GameObject brokeFan;
    public bool fanIn;

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
            if (other.gameObject.name == "Welder" && other.gameObject.name == "ReplaceBlade")
            {
                rend.enabled = true;
                if (other.gameObject.name == "ReplaceBlade")
                {
                    Destroy(other.gameObject);
                    fanIn = true;
                }
            }
        }
    }
}
