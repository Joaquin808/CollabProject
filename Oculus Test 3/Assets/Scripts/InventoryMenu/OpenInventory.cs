using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenInventory : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject InventoryCollider;
    public bool IsActive = false;

    // Start is called before the first frame update
    void Start()
    {
        Inventory.SetActive(false);
        IsActive = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == InventoryCollider)
        {
            Inventory.SetActive(true);
            IsActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == InventoryCollider)
        {
            Inventory.SetActive(false);
            IsActive = false;
        }
    }
}
