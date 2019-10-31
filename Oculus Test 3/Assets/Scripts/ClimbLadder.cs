using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadder : MonoBehaviour
{
    bool CanClimb = false;
    public float speed;
    GameObject goPlayer;
    Rigidbody rbPlayer;

    // Start is called before the first frame update
    void Start()
    {
        goPlayer = GameObject.FindGameObjectWithTag("Player");
        rbPlayer = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanClimb == true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                goPlayer.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                goPlayer.transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            CanClimb = true;
            rbPlayer.useGravity = false;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            CanClimb = false;
            rbPlayer.useGravity = true;
        }
    }
}
