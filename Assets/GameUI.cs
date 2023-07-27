using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Image sliderFill;
    public Image sliderFill2;
    public float timer = 10f;
    public PowerUpScript powerUpScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (powerUpScript.isActivated == true)
        {
            sliderFill.fillAmount = 1;
            sliderFill.fillAmount = timer / 10;
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 10;
            }
        }
    }
}
