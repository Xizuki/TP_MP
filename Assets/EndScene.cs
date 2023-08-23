using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndScene : MonoBehaviour
{
    public Score score;
    public float highScore;
    public Image bar1;
    public Image bar2;
    public Image bar3;
    public Image bar4;
    public Image bar5;
    public Image bar6;
    public Image bar7;
    public TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        highScore = score.score;  

    }
}
