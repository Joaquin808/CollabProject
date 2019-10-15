using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Pickup", menuName = "InventoryItem/Pickup")]
public class Pickup : InventoryItem
{
    public GameObject ObjectToSpawn;
    public GameObject InventoryPanelJournals;

    public override void Use()
    {
        base.Use();
        if (ItemType == "Journal")
        {
            GameObject JournalContentPanel = GameObject.Find("JournalContent");
            GameObject JournalCanvas = GameObject.FindGameObjectWithTag("JournalCanvas");
            GameObject spawn = Instantiate(ObjectToSpawn, JournalCanvas.transform);
            foreach (GameObject Child in JournalContentPanel.transform)
            {
                if (Child.gameObject.tag != "JournalEntry")
                {
                    Child.SetActive(false);

                }
            }
            // play journal entry sound
            return;
        }
        GameObject watch = GameObject.FindGameObjectWithTag("Watch");
        GameObject spawned = Instantiate(ObjectToSpawn, watch.transform.position, Quaternion.identity);
        Inventory.Instance.Remove(this);
    }
}
