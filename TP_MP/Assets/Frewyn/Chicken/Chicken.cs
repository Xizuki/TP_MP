using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Chicken : MonoBehaviour
{
    //This class is meant to control the recovery mechanic. It is meant to control the chicken such that when the player gets hit and starts falling
    //The chicken will take the player back to the lowest platform of whatever section they are on.


    public Animator anim; //Chicken animator

    [SerializeField]
    private GameObject player;
    [SerializeField] 
    private GameObject chicken;
    [SerializeField]
    private Rigidbody chickenRb;

    [SerializeField]
    private Quaternion flyingRotation = Quaternion.Euler(0,270,0);
    [SerializeField]
    private Quaternion carryingRotation = Quaternion.Euler(0, 180, 0);

    public GameObject chickenLegs;

    public bool abovePlayer = false;

    public bool isCarrying  = false;
    [SerializeField]
    private Vector3 playerVector;

    public GameObject startingPlatform;
    [SerializeField]
    private Vector3 startingVector;

    [SerializeField]
    private bool abovePlatform = false;

    public bool playerDowned = false;

    public GameObject exit;


    void Start()
    {
  
        chickenRb= GetComponent<Rigidbody>();
        playerDowned = true;
        
        
    }

    // Update is called once per frame
    void Update()
    {
   

       if(playerDowned==false)
       {
            ExitStage();

       }


        RunAnimationTrue();

        AbovePlatformCheck();

        if (playerDowned == true && abovePlayer == true)
        {
            Carrying();
        }


        if (isCarrying == false && playerDowned == true)
        {
            TravelToPlayer();


        }

        else if (isCarrying==true &&playerDowned == true)
        {
            TravelToPlatform();
        }


    }

    public void ExitStage()
    {
        transform.rotation = Quaternion.Euler(0, 90, 0);
        transform.position = Vector3.MoveTowards(transform.position, exit.transform.position, 10 * Time.deltaTime);
    }
    public void AbovePlatformCheck()
    {
        //If chicken at platform and player above platform
        if (Vector3.Distance(transform.position, startingPlatform.transform.position) < 6f && player.transform.position.y > startingPlatform.transform.position.y + 3f)
        {
            abovePlatform = true;
            playerDowned = false; //Player will no longer be downed once carried to that point
            isCarrying = false;
        }
    }


    public void TravelToPlayer()
    {
        //If not already carrying and the player is downed, move to the player
        playerVector = player.transform.position - chicken.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, playerVector, 10 * Time.deltaTime);

        
    }
    public void TravelToPlatform()
    {

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(startingPlatform.transform.position.x, startingPlatform.transform.position.y + 5, startingPlatform.transform.position.z), 10 * Time.deltaTime);

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

