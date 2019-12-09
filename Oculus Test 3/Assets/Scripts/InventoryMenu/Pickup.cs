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
    LocationController LC;
    SoundEffects SoundFX;

    public override void Use()
    {
        LC = GameObject.Find("ObjectTeleportLocation").GetComponent<LocationController>();
        // prevents the spawning of objects if they will be colliding with any other object
        if (LC.CollidingWithAnything)
        {
            return;
        }

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
        grav.GravityTimer = 0.0f;
        grav.UseGravity = false;
        Vector3 offset = new Vector3(0, 50, 0);
        Object.transform.position = new Vector3(watch.transform.position.x, watch.transform.position.y, watch.transform.position.z);
        //Object.transform.position = Object.transform.position + offset;
        Renderer rend = Object.GetComponentInChildren<Renderer>();
        rend.enabled = true;
        Object.GetComponentInChildren<SpawnEffect>().Despawn();
        SoundFX = GameObject.Find("SoundEffectsManager").GetComponent<SoundEffects>();
        if (SoundFX.genAudio.clip != SoundFX.genSounds[21])
        {
            SoundFX.genAudio.Stop();
            SoundFX.genAudio.clip = SoundFX.genSounds[21];
            SoundFX.genAudio.Play();
        }
        else
        {
            SoundFX.genAudio.Play();
        }
        Rigidbody rigidBody = Object.GetComponent<Rigidbody>();
        rigidBody.detectCollisions = true;
        rigidBody.isKinematic = false;
        rigidBody.velocity = new Vector3(0, 0, 0);
        //GameObject spawned = Instantiate(ObjectToSpawn, watch.transform.position, Quaternion.identity);
        Inventory.Instance.Remove(this);
    }
}
