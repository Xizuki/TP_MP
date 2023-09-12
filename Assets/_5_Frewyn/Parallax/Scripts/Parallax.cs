using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    //https://www.youtube.com/watch?v=TccZzs1kJQM
    //https://www.youtube.com/watch?v=zit45k6CUMk


    private float startPosition;// Starting position of whatever this script attached to, likely background image

    [SerializeField]
    private GameObject mainCamera;

    [SerializeField]
    private float parallaxEffect; //How much 'parallax' for each item

    float length; //Length of the sprite

    void Start()
    {
        startPosition = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.y; //Uses sprite renderer to get the length of sprite
    }

  
    void Update()
    {
        float temp = (mainCamera.transform.position.y * (1-parallaxEffect));

        float distance = (mainCamera.transform.position.y * parallaxEffect);

        transform.position = new Vector3(transform.position.x, startPosition + distance, transform.position.z);

        if(temp> startPosition + length)
        {
            startPosition += length;

        }
        else if ( temp<startPosition - length) 
        { 

            startPosition-= length; 
        
        }
        
    }
}
