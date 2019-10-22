using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotController : MonoBehaviour
{
    public InventoryItem Item;
    public AudioSource InventoryPing;

    private void Start()
    {
        UpdateInfo();
        InventoryPing = GetComponent<AudioSource>();
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
            DisplayText.text = "Null";
        }
    }

   public void Use()
   {
        if (Item)
        {
            Item.Use();
            InventoryPing.Play(0);
        }
   }
}
