using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{

    [SerializeField]
    private JumpingPlayerScript jumpingPlayerScript;

    [Header("Trajectory")]
    [SerializeField]
    public LineRenderer lineRenderer;
    [SerializeField]
    public Transform releasePosition;
    //public Vector3 startPosition;
    //public Vector3 endPosition;
    private LayerMask collisionMask;

    BoxCollider playerCollider;

    [SerializeField]
    GameObject playerSize;
    GameObject instantiatedPlayerSize;
    PlayerSizeCheck playerSizeCheck;


    [Header("Display Controls")]
    [SerializeField]
    [Range(10, 100)]
    private int linePoints = 25;
    [SerializeField]
    [Range(0.01f, 0.25f)]
    private float timeBetweenPoints = 0.1f;

    void Start()
    {
        playerCollider = GetComponent<BoxCollider>();

    
    }


    private void FixedUpdate()
    {
        


        if (jumpingPlayerScript.isCharging == true)
        {

            // instantiatedPlayerSize.SetActive(true);
            TrajectoryProjection();
        }
        else
        {
            //  instantiatedPlayerSize.SetActive(false);
            lineRenderer.enabled = false;
        }

    }

     void TrajectoryProjection()
    {

        lineRenderer.enabled = true;
        lineRenderer.positionCount = Mathf.CeilToInt(linePoints / timeBetweenPoints) + 1;

        //float width = lineRenderer.startWidth;
        //lineRenderer.material.mainTextureScale = new Vector2(1f / width, 1.0f);

        Vector3 startPosition = releasePosition.transform.position; 

        Vector3 startVeloctiy = (jumpingPlayerScript.playerUI.jumpingVectorIndicator.transform.up.normalized * jumpingPlayerScript.rbJumpStrength * jumpingPlayerScript.NonLinearScaledValue(jumpingPlayerScript.jumpCharge, jumpingPlayerScript.jumpChargeScalar))/ jumpingPlayerScript.rb.mass;

        int i = 0;

        lineRenderer.SetPosition(i, startPosition);

 

        for (float time = 0; time<linePoints;time+=timeBetweenPoints)
        {
            i++;
            //i+=2;
            Vector3 point = startPosition + time * startVeloctiy;
            Vector3 additionalGravity =new Vector3(0, -jumpingPlayerScript.fallingGravityStrength * Time.deltaTime* 100,0);
            point.y = startPosition.y + startVeloctiy.y * time + ((Physics.gravity.y + additionalGravity.y)) / 2f * time * time;
            //point.y = startPosition.y + startVeloctiy.y * time + ((Physics.gravity.y )) / 2f * time * time;



            lineRenderer.SetPosition(i, point);

           
            //instantiatedPlayerSize = Instantiate(playerSize,point, Quaternion.identity);
            //playerSizeCheck = instantiatedPlayerSize.GetComponent<PlayerSizeCheck>();


            Vector3 lastPosition = lineRenderer.GetPosition(i - 1);

            
            if(Physics.BoxCast(point,new Vector3(playerCollider.size.x,playerCollider.size.y+playerCollider.center.y,playerCollider.size.z),Vector3.down,Quaternion.identity,10))
            {

                Debug.Log("Hit box!");
                return;
            }





            //if (playerSizeCheck.collided == true)
            //{
            //    Debug.Log("playersizecheck true");
            //    lineRenderer.SetPosition(i, lastPosition);
            //    lineRenderer.positionCount = i + 1;
            //    instantiatedPlayerSize.transform.position = lastPosition;
            //    return;
            //}
            //else
            //{
            //    Destroy(instantiatedPlayerSize);
            //}




            //if (Physics.Raycast(lastPosition, (point - lastPosition).normalized, out RaycastHit hit, (point - lastPosition).magnitude))

            //{

            //    Debug.Log("Hit Platform");
            //    lineRenderer.SetPosition(i, hit.point);
            //    lineRenderer.positionCount = i + 1;
            //    return;

            //}


            ////Stops the line if it touches object
            //if (Physics.Raycast(lastPosition, Vector3.up, out RaycastHit hitUp, playerCollider.size.y + playerCollider.center.y +0.3f, collisionMask))
            //{
            //    Debug.Log("Hit Up");
            //    lineRenderer.SetPosition(i, point);
            //    lineRenderer.positionCount = i + 1;
            //    return;

            //}

            //else if (Physics.Raycast(lastPosition, Vector3.left, out RaycastHit hitLeft, playerCollider.size.x + 0.3f))
            //{
            //    Debug.Log("Hit Left");

            //    Debug.Log("Thing hit:" + hitLeft.collider.gameObject.name);


            //    lineRenderer.SetPosition(i, point);
            //    lineRenderer.positionCount = i + 1;
            //    return;

            //}

            //else if (Physics.Raycast(lastPosition, Vector3.right, out RaycastHit hitRight, playerCollider.size.x + 0.3f))
            //{
            //    Debug.Log("Hit Right");
            //    lineRenderer.SetPosition(i, point);
            //    lineRenderer.positionCount = i + 1;
            //    return;

            //}



            ////Normal way
            // if (Physics.Raycast(lastPosition, (point - lastPosition).normalized, out RaycastHit hit, (point - lastPosition).magnitude))

            //{

            //    Debug.Log("Hit Platform");
            //    Debug.Log("Thing hit:" + hit.collider.gameObject.name);
            //    lineRenderer.SetPosition(i, hit.point);
            //    lineRenderer.positionCount = i + 1;
            //    return;

            //}
        }

    }

}
