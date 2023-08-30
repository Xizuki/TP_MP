using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;

public class EndScene : MonoBehaviour
{
    [Header("Scripts")]
    public Score scoreScript; //Reference to Score script
    public ComboCount comboCountScript; //Reference to combo count script
    [SerializeField]
    private EndSceneButtons endSceneButtons;

    [SerializeField]
    private GameTimer gameTimerScript;

    [Header("Logic")]
    public static int timesPlayed; //How many scores there are, I.E how many times game has been completed
 
 

    public float highScore; //Current highestscore, the fill percentage of other bars are based on this score

    [Header("ProgresBars")]
    public HighscoreBar[] progressBars;
    [Header("Scores")]
    public SOScore soScore;



    [Header("Gameobjects")]
    [SerializeField]
    GameObject objectEndScene;
    [SerializeField]
    GameObject playerUI;

    [Header("Timer")]
    [SerializeField]
    private int endScreenTimerOriginal = 15;
    [SerializeField]
    private int endScreenTimer = 15;

    public Button tryAgain;

    [Header("Text Objects")]
    [SerializeField]
    private TextMeshProUGUI timerText;
    [SerializeField]
    private TextMeshProUGUI comboText;
    [SerializeField]
    private TextMeshProUGUI scoreText;




    // Start is called before the first frame update
    void Start()
    {

        
     
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Times Played: " + timesPlayed);

        
      

    }

    private void OnEnable()
    {
        scoreScript = FindObjectOfType<Score>();
        comboCountScript = FindObjectOfType<ComboCount>();
        gameTimerScript  = FindObjectOfType<GameTimer>();

        StartCoroutine(Countdown());//Countdown timer
 
        comboText.text = ComboCount.combo.ToString();//Sets combo text

        playerUI.SetActive(false);

        if (timesPlayed < 10)//If it goes beyond 10 sessions, starts overwriting score from session 1
        {
            SetScoreForLoop();
            CheckHighscore();
        }
        else
        {
            timesPlayed = 0;
            SetScoreForLoop();
            CheckHighscore();
        }



    }

    private void OnDisable()//Reset the scene
    {
        

        TryAgain();
        ResetScene();
    


    }

 


    void SetScore()//Save the current score to progress bar
    {
        progressBars[timesPlayed].score = Score.score;

        scoreText.text = Mathf.Round(Score.score).ToString();

    }

    void SetScoreForLoop()//Save the current score to progress bar
    {

        //scoreList[timesPlayed]=Score.score;


        soScore.scores[timesPlayed]= Score.score;

        if (timesPlayed == 0)
        {
            progressBars[timesPlayed].score = Score.score;
        }
        else 
        {
            for (int i = 0; i < timesPlayed+1; i++)
            {
                Debug.Log("For Loop running");
   
                progressBars[i].score = soScore.scores[i];

                if (progressBars[i].score >highScore)
                {
                    highScore = progressBars[i].score;
                }

            }
        }

        scoreText.text = Mathf.Round(Score.score).ToString();
    }



    public void ResetScene() //Sets score, combo and timer to orignal values... Resets stuff in canvas to original state
    {

        ComboCount.combo = 0;
        Score.score = 0;
        endScreenTimer = endScreenTimerOriginal;
        gameTimerScript.timer = gameTimerScript.timerOriginal;
        playerUI.SetActive(true);
        Time.timeScale = 1;
    }

    public void NextScene()
    {
        if(endSceneButtons.chosenStage==EndSceneButtons.Stage.Castle)
        {
            ResetScene();
            SceneManager.LoadScene("Castle");
        }
        else if (endSceneButtons.chosenStage == EndSceneButtons.Stage.Forest)
        {
            ResetScene();
            SceneManager.LoadScene("Forest");
        }
        else if (endSceneButtons.chosenStage == EndSceneButtons.Stage.Winter)
        {
            ResetScene();
            SceneManager.LoadScene("Winter");
        }
    }

    IEnumerator Countdown()
    {
        while (endScreenTimer>=0)
        {
            yield return new WaitForSecondsRealtime(1f);
            if (endScreenTimer > 0)
            {

                Debug.Log("Countdown");
                endScreenTimer -= 1;
                timerText.text = endScreenTimer.ToString();
            }
            else if(endScreenTimer<= 0)
            {
                Debug.Log("Close end scene");
                objectEndScene.SetActive(false);
                NextScene();
                StopCoroutine(Countdown());
            }
        }

    }







    //Replaces the highscore whenever the a new highscore is achieved.
    public void CheckHighscore()
    {
        if (Score.score> highScore)
        {
            highScore = Score.score;
        }
    }    

    

    public void TryAgain()
    {
        if (timesPlayed < 10)
        {
            timesPlayed += 1;
        }
        else
        {
            timesPlayed = 0;
        }
            
        //Scene scene = SceneManager.GetActiveScene();
        //SceneManager.LoadScene(scene.name);
        //Time.timeScale = 1;
    }
}
