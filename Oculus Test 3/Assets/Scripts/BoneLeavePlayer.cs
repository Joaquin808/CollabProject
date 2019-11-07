using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneLeavePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Hand")
        {
            GameObject.Find("Dog").GetComponent<DogAi>().boneHeldPlayer = false;
        }
    }
}
