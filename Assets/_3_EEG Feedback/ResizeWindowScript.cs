using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeWindowScript : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Screen.SetResolution(800, 600, false);

        Application.quitting += SetNextStartingResolution;
    }

    void SetNextStartingResolution()
    {
        Screen.SetResolution(800, 600, false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnDisable()
    {
        Screen.SetResolution(800, 600, false);
    }
    private void OnApplicationQuit()
    {
        Screen.SetResolution(800, 600, false);
    }
}
