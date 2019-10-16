using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Pickup", menuName = "InventoryItem/Pickup")]
public class Pickup : InventoryItem
{
    public GameObject ObjectToSpawn;
    public AudioSource JournalAudio;

    public override void Use()
    {
        base.Use();
        if (ItemType == "Journal")
        {
            GameObject JournalCanvas = GameObject.FindGameObjectWithTag("JournalCanvas");
            GameObject spawn = Instantiate(ObjectToSpawn, JournalCanvas.transform);
            // play journal entry sound
            //JournalAudio.GetComponent<AudioSource>();
            //JournalAudio.Play(0);
            return;
        }
        GameObject watch = GameObject.FindGameObjectWithTag("Watch");
        GameObject spawned = Instantiate(ObjectToSpawn, watch.transform.position, Quaternion.identity);
        Inventory.Instance.Remove(this);
    }
}
