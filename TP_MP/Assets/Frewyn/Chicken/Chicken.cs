using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Chicken : MonoBehaviour
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
    private Quaternion flyingRotation = Quaternion.Euler(0,270,0); //Rotation chicken is at when flying
    [SerializeField]
    private Quaternion carryingRotation = Quaternion.Euler(0, 180, 0); //Rotation chicken is at when carrying 

    public GameObject chickenLegs; //Where the chicken legs are to make carrying look nice

    public bool abovePlayer = false; //Is above the player to start carrying?

    public bool isCarrying  = false; //Is the player being carried?
    public bool playerDowned = false;
    //[SerializeField]
    //private Vector3 playerVector;


    //[SerializeField]
    //private Vector3 startingVector;

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


    public GameObject startingPlatform; //Platform to carry to
    public GameObject exit; //Where to fly after carry finish


    void Start()
    {
  
        chickenRb= GetComponent<Rigidbody>();
        playerDowned = true;       
        
    }

    // Update is called once per frame
    void Update()
    {
   

       if(playerDowned==false) //If player has recovered, leave
       {
            ExitStage();
       }


        RunAnimationTrue(); //Enable running animation

        AbovePlatformCheck(); //Checks if above the platform to drop the player and make bird fly away

        if(!playerDowned)
        {
            player.GetComponent<JumpingPlayerScript>().rb.useGravity = true;
        }
        else
        {
            player.GetComponent<JumpingPlayerScript>().rb.useGravity = false;
            player.GetComponent<JumpingPlayerScript>().rb.velocity = Vector3.zero;
        }


        if (playerDowned == true && abovePlayer == true) //If player is down and chicken has reached the player
        {
            Carrying();
        }


        if (isCarrying == false && playerDowned == true) //If player is down and need to go to player
        {
            TravelToPlayer();


        }

        else if (isCarrying==true &&playerDowned == true) //Is player is being carried and is still down, take them to platform
        {
            TravelToPlatform();
        }


    }

    public void ExitStage() 
    {
        transform.rotation = Quaternion.Euler(0, 90, 0); //Make bird face location its facing
        transform.position = Vector3.MoveTowards(transform.position, exit.transform.position, speed * Time.deltaTime); //Move to the location
    }
    public void AbovePlatformCheck()
    {
        //If chicken at platform and player above platform
        if (Vector3.Distance(transform.position, startingPlatform.transform.position) < dropDistance && player.transform.position.y > startingPlatform.transform.position.y + dropDistancePlayer)
        {
            abovePlatform = true;
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

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(startingPlatform.transform.position.x, startingPlatform.transform.position.y + extraHeightPlatform, startingPlatform.transform.position.z), speed * Time.deltaTime);
        //Fly to the platform, y is a little higher so the bird goes above platform
    }

    public void Carrying()
    {
        //Begin carrying the player, only if they are downed
        transform.rotation = carryingRotation;
        isCarrying = true;
        player.transform.position = chickenLegs.transform.position;//new Vector3 (chickenLegs.transform.position.x,chickenLegs.transform.position.y-1,chickenLegs.transform.position.z);
    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            abovePlayer = true;

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

    public void Recover()
    {
            
    }

    public void PlayerHit()
    {

    }

}

