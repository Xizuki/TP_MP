using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    public Score score; //Reference to Score script
    public int timesPlayed; //How many scores there are, I.E how many times game has been completed
    public Button tryAgain; 
    public GameTimer gameTimer;


    public float highScore; //Current highestscore, the fill percentage of other bars are based on this score
    public HighscoreBar[] progressBars;



    public TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {

        CheckHighscore();
     
        SetScore();
 
    }

    private void OnEnable()
    {
        progressBars[timesPlayed].score = score.score;
    }

    private void OnDisable()
    {
        score.score = 0;

        //TryAgain();



    }



    void SetScore()
    {
        progressBars[timesPlayed].score = score.score;
    }

    

 


    //Replaces the highscore whenever the a new highscore is achieved.
    public void CheckHighscore()
    {
        if (score.score > highScore)
        {
            highScore = score.score;
        }
    }    

    

    public void TryAgain()
    {
        timesPlayed += 1;    
        //Scene scene = SceneManager.GetActiveScene();
        //SceneManager.LoadScene(scene.name);
        //Time.timeScale = 1;
    }
}
