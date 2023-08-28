
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighscoreBar : MonoBehaviour
{

    //public float fill = 0;

    public float score = 0;

    [SerializeField]
    private Image bar;

    [SerializeField]
    private EndScene endScene;

    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private GameObject scoreTextObject;
    


    void Start()
    {
        bar = GetComponent<Image>();

        scoreTextObject = this.gameObject.transform.GetChild(0).gameObject;

        scoreText = scoreTextObject.GetComponent<TextMeshProUGUI>();

        SetFill();
        
    }

    // Update is called once per frame
    void Update()
    {


        SetFill();
        if (endScene.progressBars[endScene.timesPlayed] == this)
        {
           
            SetScoreText();
          
        }
    }


    private void SetScoreText()
    {
        scoreTextObject.SetActive(true);


        if (score < 10)
        {
            scoreText.text = "" + Mathf.Round(score);
        }
        else if (score<100)
        {
            scoreText.text = "" + Mathf.Round(score);
        }
        else if (score < 1000)
        {
            scoreText.text = "" + Mathf.Round(score);
        }
        else if (score < 10000)
        {
            scoreText.text = Mathf.Round(score).ToString();
        }
    }



    //Determines what the fill percentage should be relative 
    float DetermineFIll()
    {
        float fillAmount;
        fillAmount = score / endScene.highScore;

        return fillAmount;
    }



    public void SetFill()
    {
     
        bar.fillAmount = score/endScene.highScore; 
    }
}
