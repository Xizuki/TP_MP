using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PulseVfx : MonoBehaviour
{
    public GameObject playersVfx;
    public float duration;
    public Image profileRing;
    public Color color;
    public Color initialColor;
    public Color finalColor;
    public static bool playerPulse;
    // Start is called before the first frame update
    void Start()
    {
        playersVfx.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (playerPulse)
        { 
            duration += 5f * Time.deltaTime;
            playersVfx.SetActive(true);
            profileRing.color = color;
            //profileRing.SetActive(true);

        }
        else if (playerPulse != true) 
        {
            duration -= 5f * Time.deltaTime;
            playersVfx.SetActive(false);
            profileRing.color = color;
            //profileRing.SetActive(false);
        }

        color = Color.Lerp(initialColor, finalColor, duration);

        if (duration < 0)
        {
            duration = 0;
        }
        else if (duration > 1)
        {
            duration = 1;
        }

    }
}
