using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadder : MonoBehaviour
{
    bool CanClimb = false;
    public float speed;
    GameObject goPlayer;
    Rigidbody rbPlayer;
    OVRPlayerController playControl;
    float GravityMod = 0.379f;

    Vector2 primaryAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

    // Start is called before the first frame update
    void Start()
    {
        goPlayer = GameObject.FindGameObjectWithTag("Player");
        rbPlayer = goPlayer.GetComponent<Rigidbody>();
        playControl = goPlayer.GetComponent<OVRPlayerController>();
        GravityMod = playControl.GravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //if (CanClimb == true)
        //{
            //if (primaryAxis.y > 0)
            //{
                goPlayer.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed);
            //}
            if (primaryAxis.y < 0)
            {
                goPlayer.transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
            }
        //}
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("It makes it this far.");
            CanClimb = true;
            // rbPlayer.useGravity = false;
            GravityMod = 0;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            CanClimb = false;
            // rbPlayer.useGravity = true;
            GravityMod = 0.379f;
        }
    }
}
