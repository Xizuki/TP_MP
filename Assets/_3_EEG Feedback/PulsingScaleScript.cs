using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XizukiMethods.Math;

public class PulsingScaleScript : MonoBehaviour
{
    public float scaleAmount = 1.0f;
    public float scaleSpeed = 1.0f;

    public Vector3 initialScale;
    public float timeElapsed = 0.0f;

    public float offset;
    private void Start()
    {
        initialScale = transform.localScale;
    }
    public bool hasStarted, stoppingStarted, forceStop;


    private void Update()
    {
        if (!hasStarted) { return; }

        // Increment the time elapsed
        timeElapsed += Time.deltaTime * scaleSpeed;

        // Calculate the scaling factor using the cosine function
        float scale = Mathf.Cos(timeElapsed + offset) * scaleAmount;

        // Apply the scaling to the GameObject's local scale
        transform.localScale = initialScale + Vector3.one * scale;

        if (!stoppingStarted && !forceStop) { return; }


        if (XizukiMethods.Math.Xi_Helper_Math.EstimatedEqual(transform.localScale, initialScale, EstimatedEqualType.PercentageRange, 0.025f))
        {
            transform.localScale = initialScale;
            hasStarted = false;
            timeElapsed = 0.0f;
        }

        if(forceStop)
        {
            transform.localScale = initialScale;
            hasStarted = false;
            timeElapsed = 0.0f;
            forceStop = false;
        }
    }

 
    public void StartVFX()
    {
        if(hasStarted) { return ; }
        hasStarted = true;
        timeElapsed = 0;
    }

}
