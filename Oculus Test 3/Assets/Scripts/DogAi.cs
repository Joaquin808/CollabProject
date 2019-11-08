using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class DogAi : MonoBehaviour
{

    public enum DogState { IDLE, WALK, RUN, CRAWL, GRAB, DROP };    //All possible states for dog 
    public DogState CurrentState = DogState.IDLE;   //Current state of dog
    public Transform dogMouth;                      //Reference to Mouth Bone
    public GameObject bone;                         //Reference to Bone
    public Animator anim;                           //Reference to Animator Component
    public NavMeshAgent agent;                      //Reference to NavMesh Agent Component
    public GameObject playerRef;                    //Reference to Player
    public bool boneHeld = true;					//Is Bone Attached
    public bool boneHeldPlayer = false;             //Is Bone Held by Player
    public float boneResetTime = 10.0f;             //Time on ground to reset Bone

    private int animState = 0;                      //AnimState Controller
    private float walkSpeed = 2.5f;                 //WalkSpeed
    private float runDistance = 10f;                //Distance to Run instead of Walk
    private float runSpeed;                         //RunSpeed based on WalkSpeed
    private float crawlSpeed;		                //CrawlSpeed based on WalkSpeed
    private Vector3 boneLocation;                   //Bone Location
    private Vector3 playerLocation;                 //Player Location

    void Start()
    {
        boneLocation = bone.transform.position;             //Set Bone Location
        playerLocation = playerRef.transform.position;      //Set Player Location
        runSpeed = walkSpeed * 2;
        crawlSpeed = walkSpeed / 2;
        boneHeld = true;
        AttachBone();                               //Force Bone to Start in DogMouth
    }

    void Update()
    {
        //Update Player & Bone Location
        boneLocation = bone.transform.position;
        playerLocation = playerRef.transform.position;

        //Bone Location to dog if boneHeld
        if (boneHeld == true)
        {
            AttachBone();
        } else
        {
            Drop();
        }


        //If bone NOT held && NOT Player held
        if (boneHeld == false && boneHeldPlayer == false)
        {
            //Bone Reset Timer 
            boneResetTime -= Time.deltaTime;
            if (boneResetTime <= 0.0f)
            {
                boneHeldPlayer = true;
                bone.GetComponent<DestroyAndAddToInventory>().CanAddToInventory = true;
                boneResetTime = 10.0f;
            }
            else
            {
                bone.GetComponent<DestroyAndAddToInventory>().CanAddToInventory = false;
            }

            //If near bone grab bone
            if (Vector3.Distance(this.transform.position, boneLocation) <= agent.stoppingDistance && boneHeldPlayer == false)
            {
                CurrentState = DogState.GRAB;
            }
            else
            {
                //Goto bone
                RunOrWalk();
            }

        //If bone held by PLAYER
        }
        else if (boneHeldPlayer == true)
        {
            CurrentState = DogState.IDLE;

        //If bone held
        }
        else
        {
            //If near player drop bone
            if (Vector3.Distance(this.transform.position, playerLocation) <= agent.stoppingDistance)
            {
                CurrentState = DogState.DROP;
            }
            else
            {
                //Goto player
                RunOrWalk();
            }
        }

        //Check Current State
        switch (CurrentState)
        {
            case DogState.IDLE:
                Idle();
                break;
            case DogState.RUN:
                Run();
                break;
            case DogState.WALK:
                Walk();
                break;
            case DogState.CRAWL:
                Crawl();
                break;
            case DogState.GRAB:
                Grab();
                break;
            case DogState.DROP:
                Drop();
                break;
            default:
                Idle();
                break;
        }
    }

    //Move Dog to Bone
    void MoveTo()
    {
        //Switch Move Target between Bone & Player
        if (boneHeld == false)
        {
            agent.SetDestination(boneLocation);
        }
        else
        {
            agent.SetDestination(playerLocation);
        }
    }

    //Idle State
    void Idle()
    {
        animState = 0;
        anim.SetInteger("AnimState", animState);

        agent.isStopped = true;
        agent.ResetPath();
    }

    //Run or Walk
    void RunOrWalk()
    {
        if (agent.remainingDistance >= runDistance)
        {
            CurrentState = DogState.RUN;
        }
        else if (agent.remainingDistance < runDistance)
        {
            CurrentState = DogState.WALK;
        }
    }

    //Run State
    void Run()
    {
        //Set Animation & MoveTo
        animState = 2;
        anim.SetInteger("AnimState", animState);

        agent.speed = runSpeed;
        MoveTo();
    }

    //Walk State
    void Walk()
    {
        //Set Animation & MoveTo
        animState = 1;
        anim.SetInteger("AnimState", animState);

        agent.speed = walkSpeed;
        MoveTo();
    }

    //Crawl State
    void Crawl()
    {
        //Set Animation & MoveTo
        animState = 3;
        anim.SetInteger("AnimState", animState);

        agent.speed = crawlSpeed;
        MoveTo();
    }

    //Grab State
    void Grab()
    {
        //Set Animation
        animState = 4;
        anim.SetInteger("AnimState", animState);

        //Attach Bone to DogMouth
        AttachBone();
    }

    void AttachBone()
    {
        //Attach Bone to DogMouth
        bone.transform.parent = dogMouth;
        bone.transform.localPosition = Vector3.zero;
        bone.transform.localRotation = Quaternion.identity;
        bone.GetComponent<Rigidbody>().useGravity = false;

        //Mark Bone as Held
        boneHeld = true;
        MoveTo();
    }

    void Drop()
    {
        animState = 5;
        anim.SetInteger("AnimState", animState);

        agent.isStopped = true;
        agent.ResetPath();
        bone.transform.parent = null;
        boneHeld = false;
        bone.GetComponent<Rigidbody>().useGravity = true;
        //bone.GetComponent<Rigidbody>().velocity = Vector3.zero;
        boneHeldPlayer = true;
    }

    //Crawl Back Trigger
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "CrouchWall")
        {
            CurrentState = DogState.CRAWL;
        }
    }

    //Crawl Back Trigger Exit
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "CrouchWall")
        {
            RunOrWalk();
        }
    }

}