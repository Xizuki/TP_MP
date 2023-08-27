using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMoveCamScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.position += transform.up * 10 *  Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow))
            transform.position += -transform.up * 10 * Time.deltaTime;
    }
}
