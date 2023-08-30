using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPowerup : MonoBehaviour
{
    public static bool stopwatch;
    public static bool shield;
    public GameObject stopwatchVfx;
    public GameObject stopwatchFilter;
    // Start is called before the first frame update
    void Start()
    {
        stopwatchVfx = GameObject.FindGameObjectWithTag("StopWatchVFX");
        if(stopwatchVfx != null )
            stopwatchVfx.SetActive(false);

        stopwatchFilter = GameObject.FindGameObjectWithTag("StopWatchFilter");
        if (stopwatchFilter != null)
            stopwatchFilter.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (stopwatch == true)
        {
            StartCoroutine(PickUpStopwatch());

        }
    }

    IEnumerator PickUpStopwatch()
    {
        stopwatchVfx.SetActive(true);
        yield return new WaitForSeconds(1.25f);
        stopwatchVfx.SetActive(false);
        stopwatch = false;
    }
}
