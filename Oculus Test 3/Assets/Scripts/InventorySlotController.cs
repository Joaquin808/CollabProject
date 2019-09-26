using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotController : MonoBehaviour
{
    public InventoryItem Item;

    private void Start()
    {
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        Text DisplayText = transform.Find("Text").GetComponent<Text>();

        if (Item)
        {
            DisplayText.text = Item.Title;
        }
        else
        {
            DisplayText.text = "";
        }
    }

   public void Use()
   {
        if (Item)
        {
            Item.Use();
            Debug.Log("You clicked " + Item.Title);
        }
   }
}
