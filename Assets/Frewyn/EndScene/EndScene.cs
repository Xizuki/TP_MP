using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
    public int timesPlayed; //How many scores there are, I.E how many times game has been completed
    public Button tryAgain; 
    public GameTimer gameTimer;


    public float highScore; //Current highestscore, the fill percentage of other bars are based on this score

    [Header("ProgresBars")]
    public HighscoreBar[] progressBars;



    [Header("Gameobjects")]
    [SerializeField]
    GameObject objectEndScene;

    [Header("Timer")]
    [SerializeField]
    private int endScreenTimerOriginal = 15;
    [SerializeField]
    private int endScreenTimer = 15;

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
      

    }

    private void OnEnable()
    {


        StartCoroutine(Countdown());
        //comboCount = GameObject.FindObjectOfType<ComboCount>();
        // Gets the score script from the scene its in
        //scoreScript = GameObject.FindObjectOfType<Score>();
        comboText.text = ComboCount.combo.ToString();

        if (timesPlayed < 10)
        {
            SetScore();
            CheckHighscore();
        }
        else
        {
            timesPlayed = 0;
            SetScore();
            CheckHighscore();
        }



    }

    private void OnDisable()
    {
        

        TryAgain();
        ResetScene();
    


    }

 


    void SetScore()
    {
        progressBars[timesPlayed].score = Score.score;    
    }


    public void ResetScene() //Sets score, combo and timer to orignal values
    {

        ComboCount.combo = 0;
        Score.score = 0;
        endScreenTimer = endScreenTimerOriginal;
        gameTimerScript.timer = gameTimerScript.timerOriginal;
        Time.timeScale = 1;
    }

    public void NextScene()
    {
        if(endSceneButtons.chosenStage==EndSceneButtons.Stage.Castle)
        {
            ResetScene();
            //Go to scene...
        }
        else if (endSceneButtons.chosenStage == EndSceneButtons.Stage.Forest)
        {
            ResetScene();
        }
        else if (endSceneButtons.chosenStage == EndSceneButtons.Stage.Winter)
        {
            ResetScene();
        }
    }

    IEnumerator Countdown()
    {
        while (endScreenTimer>=0)
        {
            yield return new WaitForSeconds(1f);
            if (endScreenTimer > 0)
            {
                endScreenTimer -= 1;
                timerText.text = endScreenTimer.ToString();
            }
            else if(endScreenTimer<= 0)
            {
                Debug.Log("Close end scene");
                objectEndScene.SetActive(false);
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
