using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Locking_Test : MonoBehaviour
{
    public GameObject puzzlePiece; //Controlled Puzzle Piece
    public GameObject puzzlePiece2;
    public GameObject puzzlePiece3;
    public GameObject puzzlePiece4;
    public GameObject puzzlePiece5;
    public GameObject puzzlePiece6;
    public GameObject puzzlePiece7;
    public GameObject puzzlePiece8;
    public GameObject puzzlePiece9;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var speed = 1800;
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

    //Test Function for Collisions
    private void OnTriggerEnter (Collider other)
    {

    }
}
