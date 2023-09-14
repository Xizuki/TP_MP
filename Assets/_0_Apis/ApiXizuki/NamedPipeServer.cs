using UnityEngine;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class NamedPipeServer : MonoBehaviour
{
    public string pipeName = "MyNamedPipe";
    public JumpingPlayerScript jumpingPlayer;
    private NamedPipeServerStream pipeServer;
    private bool isRunning = true;
    //public bool isConnected = false;
    private StreamReader reader;
    public Pause pauseScript;
    public GameTimer gameTimerScript;
    public EndSceneRef endSceneRefScript;
    public int currentSceneIndex;


    private void Awake()
    {
        DontDestroyOnLoad(this);

    }

    private void Start()
    {
        Application.quitting += HandleApplicationQuit;

        NamedPipeServer[] namePipeServers = GameObject.FindObjectsByType<NamedPipeServer>(FindObjectsSortMode.None);

        foreach (NamedPipeServer namePipeServer in namePipeServers)
        {
            if (namePipeServer != this) { Destroy(namePipeServer.gameObject); Time.timeScale = 1; return; }
        }

        // Register the Application.quitting event to handle application exit
        Application.quitting += HandleApplicationQuit;

        if (jumpingPlayer == null)
        {
            if (GameObject.FindGameObjectWithTag("Player"))
            {
                jumpingPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<JumpingPlayerScript>();
            }
        }
        if (pipeServer == null)
            StartNamedPipeServer();



    }

    private void HandleApplicationQuit()
    {
        // Set isRunning to false to exit the server loop gracefully
        isRunning = false;
        // Close the pipe server if it was created
        if (pipeServer != null)
        {
            try
            {
                //pipeServer.EndWaitForConnection(result);

                pipeServer.Close();
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
                pipeServer = new NamedPipeServerStream(pipeName, PipeDirection.InOut, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);

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


    bool endSceneStart = false;
    static bool IsPipeBrokenException(IOException ex)
    {
        const int ERROR_PIPE_NOT_CONNECTED = 233;
        const int ERROR_NO_DATA = 232;

        var errorCode = ex.HResult & 0xFFFF;
        return errorCode == ERROR_PIPE_NOT_CONNECTED || errorCode == ERROR_NO_DATA;
    }
    public void FixedUpdate()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        //lastestLine = await reader.ReadLineAsync();


        if (jumpingPlayer == null)
        {
            if (GameObject.FindGameObjectWithTag("Player"))
            {
                jumpingPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<JumpingPlayerScript>();
            }
        }


        pauseScript = GameObject.FindAnyObjectByType<Pause>();

        gameTimerScript = GameObject.FindAnyObjectByType<GameTimer>();

        endSceneRefScript = GameObject.FindAnyObjectByType<EndSceneRef>();


    }

    private void OnClientConnected(IAsyncResult result)
    {
        reader = new StreamReader(pipeServer);
        ReadMessage();
        try
        {
            pipeServer.ReadByte();
            Debug.Log("The pipe stream is not broken.");
        }
        catch (IOException ex) when (IsPipeBrokenException(ex))
        {

            Debug.Log("The pipe stream is broken.");
        }

        print("OnClientConnected()");
    }

    public string lastestLine;

    public async void ReadMessage()
    {
        while (true)
        {
           
            lastestLine = await reader.ReadLineAsync();


            if (lastestLine.Contains("Trigger:"))
            {
                if (jumpingPlayer != null)
                {
                    string boolean = lastestLine.Remove(0, lastestLine.IndexOf(':') + 1);
                    print(boolean);

                    if (boolean == "True")
                    {
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



            if (lastestLine.Contains("PAUSE") && currentSceneIndex > 1 && pauseScript != null)
            {

                print("EEG6");

                Debug.Log("PAUSE FROM EEG");

                pauseScript.asyncForcePause = true;

            }

            if (lastestLine.Contains("RESUME") && currentSceneIndex > 1 && pauseScript != null)
            {
                pauseScript.asyncForceResume = true;

            }


            if (lastestLine.Contains("INTERVAL START") && currentSceneIndex > 1 & gameTimerScript != null)
            {
                if(!gameTimerScript.gameEnded)
                    gameTimerScript.gameEnded = true;

            }
            else if (lastestLine.Contains("INTERVAL END") && currentSceneIndex > 1 & endSceneRefScript != null)
            
                if(!endSceneRefScript.endScene.asyncForceEndInterval)
                    endSceneRefScript.endScene.asyncForceEndInterval = true;
            }

    }
    
}




