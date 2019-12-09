using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PutOnHelmet : MonoBehaviour
{
    public GameObject helmet;
    public bool isHelmetOn;
    public GameObject helmetPP;
    // Start is called before the first frame update
    void Start()
    {
        helmetPP = GameObject.Find("SpaceHelmet_PP");
    }

   void OnTriggerEnter(Collider other)
    {
       if(other.gameObject == helmet)
        {
            isHelmetOn = true;
            helmetPP.GetComponent<PostProcessLayer>().enabled = true;
            Destroy(other.gameObject);
        }
    }
}
