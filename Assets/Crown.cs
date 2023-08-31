using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crown : MonoBehaviour
{
    public GameObject crown;
    public GameObject crownProfile;
    public float requirementScore;


    private void Start()
    {
        crownProfile = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasScript>().crownProfile;
    }
    // Update is called once per frame
    void Update()
    {
        if (Score.score < requirementScore)
        {
            crown.SetActive(false);
            crownProfile.SetActive(false);
        }
        
        if (Score.score >= requirementScore)
        {
            crown.SetActive(true);
            crownProfile.SetActive(true);
        }
    }
}
