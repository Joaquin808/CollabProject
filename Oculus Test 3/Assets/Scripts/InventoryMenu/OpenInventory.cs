using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenInventory : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject InventoryCollider;
    public bool IsActive = false;
    public GameObject JournalCanvas;
    public GameObject PlayerCamera;
    RaycastHit Hit;
    public GameObject LeftHand;

    // use this example code for tooltips for the pickupable items
    /*void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        public Ray ray;
        if (Physics.Raycast(ray, out hit, 100))     //Raycast Event
            {
                Debug.DrawLine(ray.origin, hit.point);

                var selection = hit.transform;
        Renderer rend = selection.GetComponent<Renderer>();


                if (selection.CompareTag(tag: "Grabable"))      //Outline WIP
                {
                    //var selectionRenderer = selection.GetComponent<Renderer>();

                    //if (selectionRenderer != null)
                    {
                        //selectionRenderer.material = outline;
                    }

                    //_selection = selection;
                }*/

        // Start is called before the first frame update
        void Start()
    {
        Inventory.SetActive(false);
        IsActive = false;
    }

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Three))
        {
            Inventory.SetActive(true);
            IsActive = true;
            JournalCanvas.SetActive(true);
        }
        else
        {
            Inventory.SetActive(false);
            IsActive = false;
            JournalCanvas.SetActive(false);
        }
        
        /*if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.TransformDirection(Vector3.forward), out Hit, 10000))
        {
            Debug.DrawLine(PlayerCamera.transform.position, PlayerCamera.transform.TransformDirection(Vector3.forward) * 10000, Color.white, 2.5f);
            //Debug.Log("Rotation: " + LeftHand.transform.rotation.z);
            if (Hit.collider.tag == "InventoryCollider") //&& LeftHand.transform.rotation.z >= -30 && LeftHand.transform.rotation.z <= -70)
            {
                Inventory.SetActive(true);
                IsActive = true;
                JournalCanvas.SetActive(true);
            }
            else
            {
                Inventory.SetActive(false);
                IsActive = false;
                JournalCanvas.SetActive(false);
            }
        }*/
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == InventoryCollider)
        {
            Inventory.SetActive(true);
            IsActive = true;
            JournalCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == InventoryCollider)
        {
            Inventory.SetActive(false);
            IsActive = false;
            JournalCanvas.SetActive(false);
        }
    }*/
}
