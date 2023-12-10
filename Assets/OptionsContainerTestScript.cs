using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsContainerTestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindObjectsOfType<OptionsContainerTestScript>().Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        foreach (Transform child in transform)
        {
            // Apply DontDestroyOnLoad to each child
            DontDestroyOnLoad(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
