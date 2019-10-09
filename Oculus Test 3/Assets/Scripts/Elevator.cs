using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
	
	Vector3 moveDirection = Vector3.up;	//elevator starts down
	float liftSpeed = 5;
	Vector3 startPos;
	
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= 30) {
			moveDirection = Vector3.down;
		} else if (transform.position.y <= startPos.y) {
			moveDirection = Vector3.up;
		}
		
		transform.Translate (moveDirection * Time.deltaTime * liftSpeed);
			
    }
}
