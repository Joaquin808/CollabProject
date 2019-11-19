using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndAddToInventory : MonoBehaviour
{
    public Pickup InventoryItemRef;
    //public bool CanAddToInventory;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ChipCollider")
        {
            Inventory.Instance.Add(InventoryItemRef);
            Renderer rend = gameObject.GetComponentInChildren<Renderer>();
            rend.enabled = false;
            Rigidbody rigid = gameObject.GetComponent<Rigidbody>();
            rigid.detectCollisions = false;
        }
    }
}
