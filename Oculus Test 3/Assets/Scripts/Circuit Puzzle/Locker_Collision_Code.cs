using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker_Collision_Code : MonoBehaviour
{
    public GameObject panel;
    public GameObject locker;
    public GameObject baseLocker;
    public GameObject baseLocker2;
    public GameObject baseLocker3;
    public GameObject baseLocker4;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void onTriggerEnter(Collider other)
    {
        if (other.name == "Base Locker")
        {
            Debug.Log("That's not the right spot...");
        }
        if (other.tag == "Base Locker 2")
        {
            Debug.Log("That's not the right spot...");
        }
        if (other.tag == "Base Locker 3")
        {
            Debug.Log("That seems like it worked");
        }
        if (other.tag == "Base Locker 4")
        {
            Debug.Log("That's not the right spot...");
        }
    }
}
