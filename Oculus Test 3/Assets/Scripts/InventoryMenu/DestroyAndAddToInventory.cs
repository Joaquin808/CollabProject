using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndAddToInventory : MonoBehaviour
{
    public Pickup InventoryItemRef;
    public bool CanAddToInventory;
    public OVRGrabber grabbebObj;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ChipCollider")
        {
            Inventory.Instance.Add(InventoryItemRef);
            //Destroy(gameObject);
            grabbedObj.m_grabbedObj = null;
            Debug.Log("Fack off");
            if (InventoryItemRef.ItemType == "Journal")
            {
                Inventory.Instance.Add(InventoryItemRef);
                //Destroy(gameObject);
                Debug.Log("Fack off");
                return;
            }
        }

        }
}
