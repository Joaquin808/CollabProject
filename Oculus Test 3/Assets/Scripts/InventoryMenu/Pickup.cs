using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Pickup", menuName = "InventoryItem/Pickup")]
public class Pickup : InventoryItem
{
    public GameObject ObjectToSpawn;
    public AudioSource JournalAudio;
    public String ObjectName;
    GameObject Object;

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
        Object = GameObject.Find(ObjectName);
        GravityControl grav = Object.GetComponent<GravityControl>();
        grav.UseGravity = false;
        Object.transform.position = new Vector3(watch.transform.position.x + 10f, watch.transform.position.y + 10f, watch.transform.position.z);
        Renderer rend = Object.GetComponentInChildren<Renderer>();
        rend.enabled = true;
        Rigidbody rigidBody = Object.GetComponent<Rigidbody>();
        rigidBody.detectCollisions = true;
        //GameObject spawned = Instantiate(ObjectToSpawn, watch.transform.position, Quaternion.identity);
        Inventory.Instance.Remove(this);
    }
}
