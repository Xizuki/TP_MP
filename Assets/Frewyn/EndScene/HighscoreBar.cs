
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreBar : MonoBehaviour
{

    //public float fill = 0;

    public float score = 0;

    private Image bar;

    [SerializeField]
    private EndScene endScene;

    


    void Start()
    {
        bar = GetComponent<Image>();
        SetFill();
        
    }

    // Update is called once per frame
    void Update()
    {
        SetFill();
        
    }

    //Determines what the fill percentage should be relative 
    float DetermineFIll(HighscoreBar bar)
    {
        float fillAmount;
        fillAmount = bar.score / endScene.highScore;

        return fillAmount;
    }



    public void SetFill()
    {
     
        bar.fillAmount = score/endScene.highScore; 
    }
}
