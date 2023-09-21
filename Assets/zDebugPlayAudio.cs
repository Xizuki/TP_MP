using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zDebugPlayAudio : MonoBehaviour
{
    public bool trigger = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(trigger)
        {
            trigger = false;
            GetComponent<AudioSource>().Play();
        }
    }
}
