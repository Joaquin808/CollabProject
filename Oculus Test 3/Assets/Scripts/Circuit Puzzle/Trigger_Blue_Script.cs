using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Blue_Script : MonoBehaviour
{
    public GameObject puzzlePiece1;
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
        //GameObject puzzlePiece1 = GameObject.Find("puzzlePiece1");
        //GameObject puzzlePiece2 = GameObject.Find("puzzlePiece2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trigger 1")
        {
            Debug.Log("I'm currently working. #1");
        }
        if (other.tag == "Trigger 6")
        {
            Debug.Log("I'm currently working. #6");
            other.transform.parent = this.transform;
            puzzlePiece2.transform.parent = puzzlePiece1.transform;
            other.transform.localPosition = Vector3.zero;
            //puzzlePiece2.transform.localPosition = Vector3.zero;
            other.transform.localRotation = Quaternion.identity;
            puzzlePiece2.transform.localRotation = Quaternion.identity;
            puzzlePiece2.transform.localPosition = puzzlePiece1.GetComponent<PositionReferences>().GetNextPosition();
        }
        if (other.tag == "Trigger 10")
        {
            Debug.Log("I'm currently working. #10");
            other.transform.parent = this.transform;
            puzzlePiece3.transform.parent = puzzlePiece1.transform;
            other.transform.localPosition = Vector3.zero;
            //puzzlePiece3.transform.localPosition = Vector3.zero;
            other.transform.localRotation = Quaternion.identity;
            puzzlePiece3.transform.localRotation = Quaternion.identity;
            puzzlePiece3.transform.localPosition = puzzlePiece1.GetComponent<PositionReferences>().GetNextPosition();
        }
        if (other.tag == "Trigger 14")
        {
            Debug.Log("I'm currently working. #14");
            other.transform.parent = this.transform;
            puzzlePiece4.transform.parent = puzzlePiece1.transform;
            other.transform.localPosition = Vector3.zero;
            //puzzlePiece4.transform.localPosition = Vector3.zero;
            other.transform.localRotation = Quaternion.identity;
            puzzlePiece4.transform.localRotation = Quaternion.identity;
            puzzlePiece4.transform.localPosition = puzzlePiece1.GetComponent<PositionReferences>().GetNextPosition();
        }
        if (other.tag == "Trigger 18")
        {
            Debug.Log("I'm currently working. #18");
            other.transform.parent = this.transform;
            puzzlePiece5.transform.parent = puzzlePiece1.transform;
            other.transform.localPosition = Vector3.zero;
            //puzzlePiece5.transform.localPosition = Vector3.zero;
            other.transform.localRotation = Quaternion.identity;
            puzzlePiece5.transform.localRotation = Quaternion.identity;
            puzzlePiece5.transform.localPosition = puzzlePiece1.GetComponent<PositionReferences>().GetNextPosition();
        }
        if (other.tag == "Trigger 21")
        {
            Debug.Log("I'm currently working. #21");
            other.transform.parent = this.transform;
            puzzlePiece6.transform.parent = puzzlePiece1.transform;
            other.transform.localPosition = Vector3.zero;
            //puzzlePiece6.transform.localPosition = Vector3.zero;
            other.transform.localRotation = Quaternion.identity;
            puzzlePiece6.transform.localRotation = Quaternion.identity;
            puzzlePiece6.transform.localPosition = puzzlePiece1.GetComponent<PositionReferences>().GetNextPosition();
        }
        if (other.tag == "Trigger 26")
        {
            Debug.Log("I'm currently working. #26");
            other.transform.parent = this.transform;
            puzzlePiece7.transform.parent = puzzlePiece1.transform;
            other.transform.localPosition = Vector3.zero;
            //puzzlePiece7.transform.localPosition = Vector3.zero;
            other.transform.localRotation = Quaternion.identity;
            puzzlePiece7.transform.localRotation = Quaternion.identity;
            puzzlePiece7.transform.localPosition = puzzlePiece1.GetComponent<PositionReferences>().GetNextPosition();
        }
        if (other.tag == "Trigger 30")
        {
            Debug.Log("I'm currently working. #30");
            other.transform.parent = this.transform;
            puzzlePiece8.transform.parent = puzzlePiece1.transform;
            other.transform.localPosition = Vector3.zero;
            //puzzlePiece8.transform.localPosition = Vector3.zero;
            other.transform.localRotation = Quaternion.identity;
            puzzlePiece8.transform.localRotation = Quaternion.identity;
            puzzlePiece8.transform.localPosition = puzzlePiece1.GetComponent<PositionReferences>().GetNextPosition();
        }
        if (other.tag == "Trigger 33")
        {
            Debug.Log("I'm currently working. #33");
            other.transform.parent = this.transform;
            puzzlePiece9.transform.parent = puzzlePiece1.transform;
            other.transform.localPosition = Vector3.zero;
            //puzzlePiece9.transform.localPosition = Vector3.zero;
            other.transform.localRotation = Quaternion.identity;
            puzzlePiece9.transform.localRotation = Quaternion.identity;
            puzzlePiece9.transform.localPosition = puzzlePiece1.GetComponent<PositionReferences>().GetNextPosition();
        }
    }
}
