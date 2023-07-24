using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]
public class Chicken2 : MonoBehaviour
{
    //This class is meant to control the recovery mechanic. It is meant to control the chicken such that when the player gets hit and starts falling
    //The chicken will take the player back to the lowest platform of whatever section they are on.


    public Animator anim; //Chicken animator

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject chicken;

    private Rigidbody chickenRb;

    [SerializeField]
    private Quaternion flyingRotation = Quaternion.Euler(0, 270, 0); //Rotation chicken is at when flying
    [SerializeField]
    private Quaternion carryingRotation = Quaternion.Euler(0, 180, 0); //Rotation chicken is at when carrying 

    public GameObject chickenLegs; //Where the chicken legs are to make carrying look nice

    [SerializeField]
    private bool checkPointCreated;
    public GameObject checkPoint;

    [SerializeField]
    private bool exitPointCreated;
    public GameObject exitPoint;
    public int exitOffSet = 50;//How far exit point should be generated

    public bool abovePlayer = false; //Is above the player to start carrying?

    public bool isCarrying = false; //Is the player being carried?
    public bool playerDowned = false;


    [SerializeField]
    private float speed = 10f; //Speed chicken flies


    [SerializeField]
    private float dropDistance = 6f; //How much higher than the platform chicken needs to be to drop
    [SerializeField]
    private float dropDistancePlayer = 3f; //How much higher than the platform player needs to be to drop

    [SerializeField]
    private float extraHeightPlatform = 5f; // How much higher above the platform chicken should fly

    [SerializeField]
    private bool abovePlatform = false; //At the starting platform to drop player?
    [SerializeField]
    private bool atExitPoint = false; //At the exit? Used to destroy chicken


    public GameObject startingPlatform; //Platform to carry to



    void Start()
    {

        chickenRb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerDowned = true;

    }


    void Update()
    {


        if (playerDowned == false) //If player has recovered, leave
        {
            ExitStage();
        }


        RunAnimationTrue(); //Enable running animation

        AbovePlatformCheck(); //Checks if above the platform to drop the player and make bird fly away

        if (!playerDowned)
        {
            player.GetComponent<JumpingPlayerScript>().rb.useGravity = true;
        }
        else
        {
            player.GetComponent<JumpingPlayerScript>().rb.useGravity = false;
            player.GetComponent<JumpingPlayerScript>().rb.velocity = Vector3.zero;
        }

    }

    private void FixedUpdate()
    {
        if (playerDowned == true && abovePlayer == true) //If player is down and chicken has reached the player
        {
            Carrying();
        }

        if (isCarrying == false && playerDowned == true) //If player is down and need to go to player
        {
            TravelToPlayer();
        }

        else if (isCarrying == true && playerDowned == true) //Is player is being carried and is still down, take them to platform
        {
            TravelToPlatform();
        }

    }

    public void ExitStage()
    {
        transform.rotation = Quaternion.Euler(0, 90, 0); //Make bird face location its facing
     
        //Decides where the exit point should be
        Vector3 exitPointPosition = new Vector3(exitPoint.transform.position.x + exitOffSet, exitPoint.transform.position.y, exitPoint.transform.position.z);

        if (exitPointCreated == false) //If exit point has not already been generated
        {
            Instantiate(exitPoint, exitPointPosition, Quaternion.identity);//Genereates a checkpoint above the platform the chicken will move to
            exitPointCreated = true;
        }
        transform.position = Vector3.MoveTowards(transform.position, exitPointPosition, speed * Time.deltaTime);//Start moving to exit point

    }
    public void AbovePlatformCheck()
    {

        //If chicken at platform and player abov    e platform
        if (abovePlatform == true)
        {
            //abovePlatform = true;
            playerDowned = false; //Player will no longer be downed once carried to that point
            isCarrying = false;
        }
    }


    public void TravelToPlayer()
    {
        //If not already carrying and the player is downed, move to the player
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);


    }
    public void TravelToPlatform()
    {
        //Determines how far above the platform the chicken should travel to
        Vector3 abovePlatformPosition = new Vector3(startingPlatform.transform.position.x, startingPlatform.transform.position.y + extraHeightPlatform, startingPlatform.transform.position.z);
        
        if (checkPointCreated == false)//If a checkpoint has not been created
        {
            Instantiate(checkPoint, abovePlatformPosition, Quaternion.identity);//Genereates a checkpoint above the platform the chicken will move to
            checkPointCreated = true;
        }

        //Fly to the platform, y is a little higher so the bird goes above platform
        transform.position = Vector3.MoveTowards(transform.position, abovePlatformPosition, speed * Time.deltaTime);
        
    }

    public void Carrying()
    {
        //Begin carrying the player, only if they are downed
        transform.rotation = carryingRotation; //Changes rotation to carrying rotation
        isCarrying = true;
        player.transform.position = chickenLegs.transform.position;
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            abovePlayer = true;

        }

        if (other.CompareTag("Checkpoint")) //Checks if chicken at platform
        {
            abovePlatform = true;
        }

        if (other.CompareTag("ExitPoint")) //Checks if chicken at platform
        {
            atExitPoint = true;
            Destroy(gameObject);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            abovePlayer = false;

        }

    }

    public void RunAnimationTrue()
    {
        anim.SetBool("Run", true);

    }

    public void RunAnimationFalse()
    {
        anim.SetBool("Run", false);

    }


}

