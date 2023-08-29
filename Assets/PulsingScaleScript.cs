using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsingScaleScript : MonoBehaviour
{
    public float scaleAmount = 1.0f;
    public float scaleSpeed = 1.0f;

    private Vector3 initialScale;
    private float timeElapsed = 0.0f;

    public bool isNested;

    public float offset;
    public float pause;
    private void Start()
    {
        initialScale = transform.localScale;
    }

    private void Update()
    {
        if (isNested) { return; }

        // Increment the time elapsed
        timeElapsed += Time.deltaTime * scaleSpeed;

        // Calculate the scaling factor using the cosine function
        float scale = Mathf.Cos(timeElapsed+ offset) * scaleAmount;

        // Apply the scaling to the GameObject's local scale
        transform.localScale = initialScale + Vector3.one * scale;
    }

    public void NestedUpdate()
    {

        // Increment the time elapsed
        timeElapsed += Time.deltaTime * scaleSpeed;

        // Calculate the scaling factor using the cosine function
        float scale = Mathf.Cos(timeElapsed + offset) * scaleAmount;

        // Apply the scaling to the GameObject's local scale
        transform.localScale = initialScale + Vector3.one * scale;

    }
}
