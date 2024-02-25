using UnityEngine;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System;
using System.Collections;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class NamedPipeServer : MonoBehaviour
{
    public string pipeName = "ShibaToTheTop";
    public JumpingPlayerScript jumpingPlayer;
    public JumpingPlayerInputs jumpingPlayerInputs;
    private static NamedPipeServerStream pipeServer;
    private bool isRunning = true;
    public bool isConnected = false;
    private static StreamReader reader;
    public Pause pauseScript;
    public Pause intervalPause;
    public GameTimer gameTimerScript;
    public EndScene endSceneRefScript;
    public SoundControl soundControl;
    public int currentSceneIndex;
    public string prevLine;


    private void Awake()
    {
        DontDestroyOnLoad(this);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(GameObject.FindAnyObjectByType<SoundControl>())
        {
            soundControl = GameObject.FindAnyObjectByType<SoundControl>();
        }

    }

    private void Start()
    {
        //Application.quitting += HandleApplicationQuit;

        NamedPipeServer[] namePipeServers = GameObject.FindObjectsByType<NamedPipeServer>(FindObjectsSortMode.None);

        foreach (NamedPipeServer namePipeServer in namePipeServers)
        {
            if (namePipeServer != this) { Destroy(namePipeServer.gameObject); Time.timeScale = 1; return; }
        }

        // Register the Application.quitting event to handle application exit
        //Application.quitting += HandleApplicationQuit;

        if (jumpingPlayer == null)
        {
            if (GameObject.FindGameObjectWithTag("Player"))
            {
                jumpingPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<JumpingPlayerScript>();
                jumpingPlayerInputs = GameObject.FindGameObjectWithTag("Player").GetComponent<JumpingPlayerInputs>();
            }
        }
        if (pipeServer == null)
            StartNamedPipeServer();



    }

    private void HandleApplicationQuit()
    {
        // Set isRunning to false to exit the server loop gracefully
        isRunning = false;
        if (reader != null)
        {
            reader.Close();
            reader.Dispose();
            reader = null;
        }
        
        // Close the pipe server if it was created
        if (pipeServer != null)
        {
            try
            {
                //pipeServer.EndWaitForConnection(result);
                pipeServer.Close();
                pipeServer.Dispose();
                Debug.Log("Pipe server closed.");
            }
            catch (IOException ex)
            {
                Debug.LogError("An error occurred while closing the pipe server: " + ex.Message);
            }
        }
    }

    private void StartNamedPipeServer()
    {
        // Start a coroutine to handle the named pipe server asynchronously
        StartCoroutine(NamedPipeServerCoroutine());
    }
    //int i = 0;
    IAsyncResult result;

    private IEnumerator NamedPipeServerCoroutine()
    {
        while (isRunning)
        {
            if (pipeServer == null || !pipeServer.IsConnected)
            {
                // Replace the named pipe server creation with async version for Unity
                pipeServer = new NamedPipeServerStream(pipeName,
                    PipeDirection.InOut, 1, PipeTransmissionMode.Byte,
                    PipeOptions.Asynchronous);

                // Start the asynchronous operation to wait for the client connection
                result = pipeServer.BeginWaitForConnection(OnClientConnected, null);
            }
            // Wait for the connection or timeout
            float startTime = Time.time;
            while (!result.IsCompleted)
            {
                yield return null; // Yield until the next frame
            }

            if (pipeServer == null || !pipeServer.IsConnected)
            {
                // Complete the connection process
                pipeServer.EndWaitForConnection(result);
            }


            isRunning = false;
        }

    }

    public void OnApplicationQuit()
    {
        HandleApplicationQuit();    

    }

    bool endSceneStart = false;
    static bool IsPipeBrokenException(IOException ex)
    {
        const int ERROR_PIPE_NOT_CONNECTED = 233;
        const int ERROR_NO_DATA = 232;

        var errorCode = ex.HResult & 0xFFFF;
        return errorCode == ERROR_PIPE_NOT_CONNECTED || errorCode == ERROR_NO_DATA;
    }
    public void LateUpdate()
    {
        //print("LateUpdate 1");

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        //lastestLine = await reader.ReadLineAsync();
        //print("LateUpdate 2");

        if (GameObject.FindAnyObjectByType<SoundControl>() && soundControl==null)
        {
            soundControl = GameObject.FindAnyObjectByType<SoundControl>();
        }

        if (jumpingPlayer == null)
        {
            if (GameObject.FindGameObjectWithTag("Player"))
            {
                jumpingPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<JumpingPlayerScript>();
                jumpingPlayerInputs = GameObject.FindGameObjectWithTag("Player").GetComponent<JumpingPlayerInputs>();
            }
        }
        //print("LateUpdate 3");





        if (GameObject.FindAnyObjectByType<CanvasScript>() != null && intervalPause == null)
        {
            endSceneRefScript = GameObject.FindAnyObjectByType<CanvasScript>().endScene;
            gameTimerScript = GameObject.FindAnyObjectByType<CanvasScript>().gameTimer;
            pauseScript = GameObject.FindAnyObjectByType<CanvasScript>().pause;
            intervalPause = GameObject.FindAnyObjectByType<CanvasScript>().intervalPause;

        }

        //print("LateUpdate 4");



        if(reader == null) return;

        //print("LateUpdate 5");

        ReadMessage();

    }




    private void OnClientConnected(IAsyncResult result)
    {
        reader = new StreamReader(pipeServer);
        isConnected = true;
        try
        {
            pipeServer.ReadByte();
            Debug.Log("The pipe stream is not broken.");
        }
        catch (IOException ex) when (IsPipeBrokenException(ex))
        {

            Debug.Log("The pipe stream is broken.");
        }

        //print("OnClientConnected()");
    }




    public string lastestLine;

    public void ReadMessage()
    {
   
        lastestLine = reader.ReadLine();
        //print("EEG0");

        if (currentSceneIndex == 0) return;
        if (currentSceneIndex == 1) return;


        //print("EEG1");
        if(lastestLine == null) { return; }
        if (lastestLine.Contains("Trigger:"))
        {
            if (jumpingPlayer is not null)
            {
                //print("EEG3");

                string boolean = lastestLine.Remove(0, lastestLine.IndexOf(':') + 1);
                //print(boolean);

                if (boolean == "True")
                {
                    //print("EEG4");

                    if (jumpingPlayer.isGrounded)
                    {
                        jumpingPlayer.isCharging = true;
                    }
                }
                else if (boolean == "False")
                {
                    if (jumpingPlayer.isGrounded)
                    {
                        jumpingPlayer.isCharging = false;
                    }
                }
            }
        }

        //print("lastestLine = " + lastestLine);






        if (lastestLine.Contains("PAUSE") && currentSceneIndex > 1 && pauseScript != null)
        {
            Debug.Log("PAUSE FROM EEG");

            if (gameTimerScript.gameEnded)
            {
                Debug.Log("INTERVAL PAUSE FROM EEG");

                endSceneRefScript.intervalPaused = true;

            }
            else
                pauseScript.PauseGame();

        }

        if (lastestLine.Contains("RESUME") && currentSceneIndex > 1 && pauseScript != null)
        {
            if (gameTimerScript.gameEnded)
            {
                endSceneRefScript.intervalPaused = false;

            }
            else
                pauseScript.ResumeGame();
        }

        if (lastestLine.Contains("INTERVAL END") && currentSceneIndex > 1 && endSceneRefScript != null)
        {
            endSceneRefScript.IntervalEnd();
            if (currentSceneIndex > 1)
            {
                soundControl.AdjustAll();
                Pause intervalPause = GameObject.FindObjectOfType<CanvasScript>().intervalPause;
                if(intervalPause.pauseMenu.activeInHierarchy)
                    intervalPause.pauseMenu.SetActive(false);
            }
        }
        else if (lastestLine.Contains("INTERVAL START") && currentSceneIndex > 1 && gameTimerScript != null)
        {
            if (!prevLine.Contains("INTERVAL END"))
            {
                if (!gameTimerScript.gameEnded)
                {
                    soundControl.AdjustAmbient(0.4f);
                    soundControl.AdjustBGVolume(0.4f);

                    gameTimerScript.Interval();
                }
            }

        }
     
        prevLine = lastestLine;







        if (lastestLine.Contains(":Left") && currentSceneIndex > 1 && pauseScript != null)
        {
            if (!Application.isFocused)
            {
                if (jumpingPlayerInputs.controlType == ControlType.option1)
                {
                    jumpingPlayer.IncrementalMoveJumpVectorNegative();
                    jumpingPlayer.IncrementalMoveJumpVectorNegative();

                }
            }
        }
        if (lastestLine.Contains(":Right") && currentSceneIndex > 1 && pauseScript != null)
        {
            if (!Application.isFocused)
            {
                if (jumpingPlayerInputs.controlType == ControlType.option1)
                {
                    jumpingPlayer.IncrementalMoveJumpVectorPositive();
                    jumpingPlayer.IncrementalMoveJumpVectorPositive();
                }
            }
        }




        if (lastestLine.Contains(":Z") && currentSceneIndex > 1 && pauseScript != null)
        {
            if (!Application.isFocused)
            {
                if (jumpingPlayerInputs.controlType == ControlType.option1)
                { jumpingPlayer.Left1(2f) ; jumpingPlayer.Left1(2f); }

                    if (jumpingPlayerInputs.controlType == ControlType.option2)
                    jumpingPlayer.Left2(-1.5f*2.25f);
            }
        }
        if (lastestLine.Contains(":C") && currentSceneIndex > 1 && pauseScript != null)
        {
            if (!Application.isFocused)
            {
                if (jumpingPlayerInputs.controlType == ControlType.option1)
                {
                    jumpingPlayer.Right1(2f); jumpingPlayer.Right1(2f);
                }
                    if (jumpingPlayerInputs.controlType == ControlType.option2)
                    jumpingPlayer.Right2(-1.5f * 2.25f);
            }

        }
        if (lastestLine.Contains(":X") && currentSceneIndex > 1 && pauseScript != null)
        {
            if (!Application.isFocused)
            {
                jumpingPlayer.isCharging = true;
                jumpingPlayer.dllCharge = true;
            }
        }
        else
            jumpingPlayer.dllCharge=false;

        if (lastestLine.Contains(":Space") && currentSceneIndex > 1 && pauseScript != null)
        {
            if (!Application.isFocused)
            {
                jumpingPlayer.Jump();
            }
        }

        if (lastestLine.Contains(":1") && currentSceneIndex > 1 && pauseScript != null)
        {
            jumpingPlayerInputs.controlType = ControlType.option1;
        }
        if (lastestLine.Contains(":2") && currentSceneIndex > 1 && pauseScript != null)
        {
            jumpingPlayerInputs.controlType = ControlType.option2;

        }
    }




    [ContextMenu("Force Interval End")]
    public void ForceIntervalEnd()
    {
        endSceneRefScript.IntervalEnd();
        if (currentSceneIndex > 1)
        {
            soundControl.AdjustAll();
            Pause intervalPause = GameObject.FindObjectOfType<CanvasScript>().intervalPause;
            if (intervalPause.pauseMenu.activeInHierarchy)
                intervalPause.pauseMenu.SetActive(false);
        }
    }


    [ContextMenu("Force Interval Start")]
    public void ForceIntervalStart()
    {
        if (!gameTimerScript.gameEnded)
        {
            soundControl.AdjustAmbient(0.4f);
            soundControl.AdjustBGVolume(0.4f);

            gameTimerScript.Interval();
        }
    }
}







