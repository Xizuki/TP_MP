using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComboCount : MonoBehaviour
{

    public static int combo;// adjusted to not be static in order to work in end screen...Frewyn
    public TMP_Text comboTxt;
    public ParticleSystem ringLight;
    public ParticleSystem lightning;
    public ParticleSystem preLightning;
    public ParticleSystem light;
    public ParticleSystem lightb;
    public ParticleSystem stara;
    public ParticleSystem starb;
    public GameObject starHit;
    public GameObject starbHit;
    public bool highCombo;
    public static bool hit;
    List<ParticleSystem> particles = new List<ParticleSystem>();

    // Start is called before the first frame update
    void Start()
    {
        ringLight.Pause();
        lightning.Pause();
        preLightning.Pause();
        starHit.SetActive(false);
        hit = false;
        particles.Add(light);
        particles.Add(lightb);
        particles.Add(stara);
        particles.Add(starb);

        StartCoroutine(ComboReset());
    }

    void ComboUp()
    {
        if (hit == true)
        {
            StartCoroutine(ComboVfx());
            hit = false;
        }
        else if (hit == false)
        {
            StopCoroutine(ComboVfx());
        }
    }

    IEnumerator ComboVfx()
    {
        starHit.SetActive(true);
        if (highCombo == true)
        {
            starbHit.SetActive(true);
            
        }
        yield return new WaitForSeconds(0.55f);
        starHit.SetActive(false);
        starbHit.SetActive(false);
    }

    IEnumerator ComboReset() //Reset the score as player will likely gain a score for free at the beginning
    {
        yield return new WaitForSeconds(0.05f);
        comboTxt.text = "0 Combo";
        combo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ComboUp();
        comboTxt.text = combo + " Combo";

        if (combo <= 1)
        {
            comboTxt.color = Color.white;
            ringLight.Play();
            ringLight.startColor = Color.gray;
            particles[particles.Count - 1].startColor = Color.gray;
            ringLight.maxParticles = 1;
            highCombo = false;

        }
        if (combo <= 9 && combo >= 2)
        {
            comboTxt.color = Color.white;
            ringLight.startColor = Color.white;
            ringLight.maxParticles = 1;
            highCombo = false;
        }
        if (combo >= 10 && combo <= 19)
        {
            comboTxt.color = Color.yellow;
            ringLight.startColor = Color.yellow;
            particles[particles.Count - 1].startColor = Color.yellow;
            ringLight.maxParticles = 2;
            highCombo = false;
        }
        if (combo >= 20 && combo <= 29)
        {
            comboTxt.color = Color.green;
            ringLight.startColor = Color.green;
            particles[particles.Count - 1].startColor = Color.green;
            ringLight.maxParticles = 3;
            highCombo = false;
        }
        if (combo >= 30 && combo <= 35)
        {
            comboTxt.color = Color.cyan;
            ringLight.startColor = Color.cyan;
            particles[particles.Count - 1].startColor = Color.cyan;
            particles[particles.Count - 2].startColor = Color.cyan;
            ringLight.maxParticles = 5;
            highCombo = false;

        }
        if (combo >= 36 && combo <= 39)
        {
            comboTxt.color = Color.cyan;
            ringLight.startColor = Color.cyan;
            ringLight.maxParticles = 5;
            comboTxt.fontSize = combo;
            highCombo = true;
        }
        if (combo >= 40)
        {
            comboTxt.color = Color.cyan;
            ringLight.startColor = Color.cyan;
            ringLight.maxParticles = 7;
            comboTxt.fontSize = combo;
            preLightning.Play();

            if (comboTxt.fontSize >= 50)
            {
                comboTxt.fontSize = 50;

            }
        }
    }
}
