using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XizukiMethods.Data;
using XizukiMethods.GameObjects;

public class Xi_Manager_AsyncVariables : MonoBehaviour
{
    public static Xi_Manager_AsyncVariables instance;

    public event Action<float> Timer;
    public event Action<string,float> variable;
    // Start is called before the first frame update
    void Start()
    {
        Timer += TimerFunc;
        Xi_Helper_GameObjects.MonoInitialization<Xi_Manager_AsyncVariables>(ref instance, this);
    }

    public void TimerFunc(float timer)
    {
        timer += Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
