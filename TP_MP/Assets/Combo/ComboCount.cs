using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComboCount : MonoBehaviour
{

    public static int combo;
    public TMP_Text comboTxt;
    public ParticleSystem ringLight;

    // Start is called before the first frame update
    void Start()
    {
        ringLight.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        comboTxt.text = combo + " Combo";

        if (combo <= 1)
        {
            ringLight.Play();
            ringLight.startColor = Color.gray;
            ringLight.maxParticles = 1;
            
        }
        if (combo <= 9 && combo >= 2)
        {
            ringLight.startColor = Color.white;
            ringLight.maxParticles = 1;
        }
        if (combo >= 10 && combo <= 19)
        {
            comboTxt.color = Color.yellow;
            ringLight.startColor = Color.yellow;
            ringLight.maxParticles = 2;
        }
        if (combo >= 20 && combo <= 29)
        {
            comboTxt.color = Color.green;
            ringLight.startColor = Color.green;
            ringLight.maxParticles = 3;
        }
        if (combo >= 30 && combo <= 35)
        {
            comboTxt.color = Color.cyan;
            ringLight.startColor = Color.cyan;
            ringLight.maxParticles = 5;
        }
        if (combo >= 36 && combo <= 39 )
        {
            comboTxt.color = Color.cyan;
            ringLight.startColor = Color.cyan;
            ringLight.maxParticles = 5;
            comboTxt.fontSize = combo;
        }
        if (combo >= 40)
        {
            comboTxt.color = Color.cyan;
            ringLight.startColor = Color.cyan;
            ringLight.maxParticles = 7;
            comboTxt.fontSize = combo;

            if (comboTxt.fontSize >= 45)
            {
                comboTxt.fontSize = 45;
            }

        }




    }
}
