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

    // Start is called before the first frame update
    void Start()
    {
        Inventory.SetActive(false);
        IsActive = false;
    }

    void Update()
    {
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.TransformDirection(Vector3.forward), out Hit, 10000))
        {
            Debug.DrawLine(PlayerCamera.transform.position, PlayerCamera.transform.TransformDirection(Vector3.forward) * 10000, Color.white, 2.5f);
            if (Hit.collider.tag == "InventoryCollider")
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
        }
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
