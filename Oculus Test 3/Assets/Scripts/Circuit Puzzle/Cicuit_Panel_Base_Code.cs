using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cicuit_Panel_Base_Code : MonoBehaviour
{
    public GameObject circuitPanel;
    public GameObject baseLocker;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 position = this.transform.position;
            position.x = position.x - 10;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 position = this.transform.position;
            position.x = position.x + 10;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 position = this.transform.position;
            position.z = position.z + 10;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 position = this.transform.position;
            position.z = position.z - 10;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void onTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Base Locker")
        {
            Debug.Log("That seems to fit");
            this.transform.position = other.transform.position;
        }
    }
}
