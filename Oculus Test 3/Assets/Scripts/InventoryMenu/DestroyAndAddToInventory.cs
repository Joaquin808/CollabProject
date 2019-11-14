using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndAddToInventory : MonoBehaviour
{
    public Pickup InventoryItemRef;
    public bool CanAddToInventory;
    public GameObject LeftHand;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ChipCollider")
        {
            Inventory.Instance.Add(InventoryItemRef);
            OVRGrabber GrabbedObj = LeftHand.GetComponent<OVRGrabber>();
            GrabbedObj.m_grabbedObj = null;
            Debug.Log("Fack off");
            Destroy(gameObject);
        }

     }
}
