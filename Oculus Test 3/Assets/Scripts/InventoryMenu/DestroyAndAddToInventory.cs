using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyAndAddToInventory : MonoBehaviour
{
    public Pickup InventoryItemRef;
    //public bool CanAddToInventory;
    bool ItemWasAdded = false;
    //public Text ItemAddedText;
    public float Timer, spawnTimer, AddedTimer = 0;
    SoundEffects SoundFX;
    Renderer rend;
    Rigidbody rigid;
    public bool CanBeAdded = false;

    void Start()
    {
        //ItemAddedText = GameObject.Find("ItemAddedTextParent").GetComponentInChildren<Text>();
        SoundFX = GameObject.Find("SoundEffectsManager").GetComponent<SoundEffects>();
        rend = gameObject.GetComponentInChildren<Renderer>();
        rigid = gameObject.GetComponent<Rigidbody>();
        AddedTimer = 0;
    }

    void Update()
    {
        AddedTimer += Time.deltaTime;
        if (AddedTimer >= 10)
        {
            CanBeAdded = true;
        }

        if (ItemWasAdded)
        {
            //Wait 3 seconds for animation to end, then addtoinventory
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= 3)
            {
                Inventory.Instance.Add(InventoryItemRef);
                ItemWasAdded = false;
                spawnTimer = 0;
            }

            /*Timer += Time.deltaTime;
            if (Timer >= 5)
            {
                ItemAddedText.text = "";
                ItemWasAdded = false;
                Timer = 0;
            }
            else
            {
                ItemAddedText.text = InventoryItemRef.name + " was added to the inventory";
            }*/
        }
   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CanBeAdded)
        {
            if (this.GetComponent<OVRGrabbable>().isGrabbed == false)
            {
                if (other.gameObject.tag == "ChipCollider")
                {

                    ItemWasAdded = true;
                    rigid.isKinematic = true;
                    rigid.detectCollisions = false;
                    rigid.useGravity = false;
                    rigid.velocity = new Vector3(0, 0, 0);
                    rend.enabled = false;
                    //Play Animation
                    gameObject.GetComponentInChildren<SpawnEffect>().Despawn();
                    GameObject.Find("CustomHandRight").GetComponent<OVRGrabber>().m_grabbedObj = null;
                    //GameObject.Find("CustomHandLeft").GetComponent<OVRGrabber>().m_grabbedObj = null;
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
                }
            }
        }
    }
}
