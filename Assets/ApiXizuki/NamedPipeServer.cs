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
    public int currentSceneIndex;


    private void Awake()
    {
        DontDestroyOnLoad(this);

    }

    private void Start()
    {
        // Register the Application.quitting event to handle application exit
        Application.quitting += HandleApplicationQuit;
        //SceneManager.sceneLoaded += OnSceneLoaded;
        // Start the named pipe server asynchronously


        NamedPipeServer[] namePipeServers = GameObject.FindObjectsByType<NamedPipeServer>(FindObjectsSortMode.None);

        foreach (NamedPipeServer namePipeServer in namePipeServers)
        {
            if (namePipeServer != this) { Destroy(namePipeServer.gameObject); Time.timeScale = 1; return; }
        }

        // Register the Application.quitting event to handle application exit
        Application.quitting += HandleApplicationQuit;
        //SceneManager.sceneLoaded += OnSceneLoaded;
        // Start the named pipe server asynchronously
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

    //private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    //{
    //    if (GameObject.FindGameObjectWithTag("Player"))
    //    {
    //        jumpingPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<JumpingPlayerScript>();
    //    }
    //}

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

            // Handle communication with the connected client here...
            //HandleClientCommunication(pipeServer);

            // Do not close the pipe after communication; keep it open for the next messages
            //pipeServer.Close();

            isRunning = false;
        }

    }
    //private IEnumerator NamedPipeServerCoroutine()
    //{
    //    //print("NamedPipeServerCoroutine  1");
    //    while (isRunning)
    //    {
    //        //print("isConnected 1 = " + isConnected);


    //        //if (pipeServer!=null)

    //        //if (!isConnected)
    //        //{ 
    //        // print("pipeServer.IsConnected 1 = " + pipeServer.IsConnected);
    //        // Replace the named pipe server creation with async version for Unity
    //        pipeServer = new NamedPipeServerStream(pipeName);


    //        //print("NamedPipeServerCoroutine  3");
    //        //print("pipeServer.IsConnected 1.5 = " + pipeServer.IsConnected);

    //        // Start the asynchronous operation to wait for the client connection\
    //        IAsyncResult result = pipeServer.BeginWaitForConnection(OnClientConnected, null);
    //        //print("NamedPipeServerCoroutine  4");

    //        //print("pipeServer.IsConnected 2 = " + pipeServer.IsConnected);
    //        //print("isConnected 2 = " + isConnected);

    //        while (!result.IsCompleted)
    //        {
    //            print("1result.IsCompleted");
    //            yield return null; // Yield until the next frame

    //        }

    //        //print("isConnected 3 = " + isConnected);

    //        //print("pipeServer.IsConnected 3 = " + pipeServer.IsConnected);

    //        //pipeServer.EndWaitForConnection(result);
    //        //}
    //        //print("NamedPipeServerCoroutine  5");

    //        //print("NamedPipeServerCoroutine  6");
    //        //print("pipeServer.IsConnected 4 = " + pipeServer.IsConnected);

    //        //Complete the connection process
    //        pipeServer.EndWaitForConnection(result);
    //        //print("NamedPipeServerCoroutine  5");

    //        // Handle communication with the connected client here...
    //        // For example, you can use StreamReader and StreamWriter to read and write data on the pipe.

    //        // After communication, close the pipe
    //        //if(!isConnected)
    //        pipeServer.Close();
    //        //try
    //        //{
    //        //    // Attempt to read or write to the pipe
    //        //    pipeServer.ReadByte();
    //        //    Debug.Log("The pipe stream is not broken.");
    //        //}
    //        //catch (IOException ex) when (IsPipeBrokenException(ex))
    //        //{

    //        //    Debug.Log("The pipe stream is broken.");
    //        //}

    //        //isRunning = false;

    //    }

    //    //pipeServer.EndWaitForConnection(result);
    //    //pipeServer.Close();

    //}


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

        if(GameObject.FindAnyObjectByType<Pause>() != null)
        {
            pauseScript = GameObject.FindAnyObjectByType<Pause>();
        }
        //print("pipeServer.IsConnected UPDATE = " + pipeServer.IsConnected);
        //print("isConnected UPDATE = " + isConnected);

        //if (isConnected)
        //{
        //    print("reader.ReadLine() = " + reader.ReadLine());
        //}
        //print("IsRunning = " + isRunning);
    }

    private void OnClientConnected(IAsyncResult result)
    {
        //isConnected = true;
        reader = new StreamReader(pipeServer);
        ReadMessage();
        try
        {
            // Attempt to read or write to the pipe
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

    // DO NOT FKING CALL METHODS IN THIS, CHANGE A VARIABLE THEN RUN A METHOD BY CHECKING THAT VARIABLE INSTEAD ,
    public async void ReadMessage()
    {
        print("ReadMessage()");

        while (true)
        {
            print("ReadMessage()1");

            //if (!GameObject.FindObjectOfType<Pause>())
            //{
            //    continue;
            //}

            //if (!serverStream.IsConnected) { continue; }
            //if (lastestLine == "Null") { serverStream.Close(); }
            //lastestLine =  reader.ReadLine();
            lastestLine = await reader.ReadLineAsync();
            print(lastestLine);

            //if (!gameobject.findobjectoftype<pause>())
            //{
            //    continue;
            //}

            //if (lastestLine.Contains("PAUSE"))
            //{

            //    Debug.Log("PAUSE FROM EEG");
            //    //Pause pauseScript = GameObject.FindObjectOfType<Pause>();
            //    //pauseScript.PauseGame();
            //}

            //if (lastestLine.Contains("RESUME"))
            //{
            //    //Debug.Log("RESUME FROM EEG");
            //    //Pause pauseScript = GameObject.FindObjectOfType<Pause>();
            //    //pauseScript.ResumeGame();
            //}


            //if (GameObject.FindObjectOfType<Pause>() != null)
            //{
            //    //if (lastestLine.Contains("PAUSE") && SceneManager.GetActiveScene().buildIndex > 1)
            //    //{


            //    //    Debug.Log("PAUSE FROM EEG");
            //    //    //Pause pauseScript = GameObject.FindObjectOfType<Pause>();
            //    //    //pauseScript.PauseGame();
            //    //}

            //    //if (lastestLine.Contains("RESUME") && SceneManager.GetActiveScene().buildIndex > 1)
            //    //{
            //    //    Debug.Log("RESUME FROM EEG");
            //    //    //Pause pauseScript = GameObject.FindObjectOfType<Pause>();
            //    //    //pauseScript.ResumeGame();
            //    //}
            //}


            print("EEG1");
            if (lastestLine.Contains("Trigger:"))
            {
                print("EEG2");

                if (jumpingPlayer != null)
                {
                    print("EEG3");

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
                    print("EEG4");

                    //jumpingPlayer.isCharging();
                }
            }

            print("EEG5");


            if (lastestLine.Contains("PAUSE") && currentSceneIndex > 1 && pauseScript != null)
            {

                print("EEG6");

                Debug.Log("PAUSE FROM EEG");
                //Pause pauseScript = GameObject.FindObjectOfType<Pause>();
                //pauseScript.PauseGame();
                pauseScript.asyncForcePause = true;

                //CheckPipeStream();

                //reader.Close();
                //reader.Dispose();
                //if (serverStream.IsConnected)
                //serverStream.Disconnect();
                //serverStream.Close();
                //serverStream.Dispose();
            }
            print("EEG7");

            if (lastestLine.Contains("RESUME") && currentSceneIndex > 1 && pauseScript != null)
            {
                pauseScript.asyncForceResume = true;


                //print("EE8");

                //Debug.Log("RESUME FROM EEG");
                ////Pause pauseScript = GameObject.FindObjectOfType<Pause>();
                //pauseScript.ResumeGame();
            }

            print("EEG9");

        }
    }
}







////using System;
//using System.IO;
//using System.IO.Pipes;
//using System.Threading;
//using System.Threading.Tasks;
//using UnityEngine;

//public class NamedPipeServer : MonoBehaviour
//{
//    private NamedPipeServerStream serverStream;
//    private static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
//    private static CancellationToken cancellationToken;
//    private StreamReader reader;
//    private Task waitingTask;

//    public JumpingPlayerScript jumpingPlayer; // Reference to the JumpingPlayerScript
//    string lastestLine;

//    private void Awake()
//    {
//        jumpingPlayer = GetComponent<JumpingPlayerScript>(); // Get a reference to the JumpingPlayerScript component
//    }

//    private void Start()
//    {
//        // Create a named pipe server with a specific name
//        serverStream = new NamedPipeServerStream("MyNamedPipe", PipeDirection.In);
//        reader = new StreamReader(serverStream);

//        // Start waiting for a client to connect asynchronously
//        //cancellationTokenSource = new CancellationTokenSource();
//        // Step 2: Get the CancellationToken from the CancellationTokenSource
//        cancellationToken = cancellationTokenSource.Token;

//        cancellationToken.Register(() =>
//        {
//            Console.WriteLine("Task has been cancelled!");
//        });

//        Debug.Log("Start() 0 is token CanBeCanceled =  " + cancellationToken.CanBeCanceled);

//        Debug.Log("Start() 1 ");
//        //cancellationTokenSource.Cancel();
//        Task.Run(async () =>
//        {
//            await WaitForConnectionAsync(cancellationToken);
//        });
//        //waitingTask = 
//        cancellationTokenSource.Cancel();
//        Debug.Log("Start() 2 ");
//    }

//    public void CancelToken()
//    {
//        cancellationTokenSource.Cancel();
//    }
//    static bool WantsToQuit()
//    {
//        Debug.Log("Player prevented from quitting.");
//        cancellationTokenSource.Cancel();
//        return true;
//    }

//    private async Task WaitForConnectionAsync(CancellationToken cancellationToken)
//    {
//        Debug.Log("WaitForConnectionAsync() 1 ");
//        // Check if cancellation has been requested before proceeding
//        //cancellationToken.ThrowIfCancellationRequested();
//        //try
//        //{
//        //    // Wait for a client to connect zasynchronously

//        Application.wantsToQuit += WantsToQuit;
//        //if (!Application.isPlaying)
//        //{
//        //    print("!Application.isPlaying");
//        //    cancellationTokenSource.Cancel();
//        //    return;
//        //}

//        await serverStream. (cancellationToken);
//            Debug.Log("WaitForConnectionAsync() 2 ");

//            // Check if the pipe stream is broken
//            try
//            {
//                // Attempt to read or write to the pipe
//                serverStream.ReadByte();
//                Debug.Log("The pipe stream is not broken.");
//            }
//            catch (IOException ex) when (IsPipeBrokenException(ex))
//            {

//                Debug.Log("The pipe stream is broken.");
//            }

//            // Start reading messages from the connected client
//            ReadMessage();
//        //}
//        //catch (OperationCanceledException)
//        //{
//        //    // The waiting task has been canceled, ignore the exception
//        //    return;
//        //}
//        //catch (Exception ex)
//        //{
//        //    // Handle any other exceptions
//        //    Debug.LogError($"An error occurred while waiting for connection: {ex.Message}");
//        //}
//    }

//    static bool IsPipeBrokenException(IOException ex)
//    {
//        const int ERROR_PIPE_NOT_CONNECTED = 233;
//        const int ERROR_NO_DATA = 232;

//        var errorCode = ex.HResult & 0xFFFF;
//        return errorCode == ERROR_PIPE_NOT_CONNECTED || errorCode == ERROR_NO_DATA;
//    }

//    private void ReadMessage()
//    {
//        Debug.Log("ReadMessage() 1 ");

//        while (serverStream.IsConnected)
//        {
//            Debug.Log("ReadMessage() 2 ");

//            if (lastestLine == "Null")
//            {
//                serverStream.Close();
//            }



//            // Read the next line from the stream
//            lastestLine = reader.ReadLine();
//        }
//    }

//    private void Update()
//    {

//    }

//    private void OnDisable()
//    {
//        print("ONDISABLE");
//        cancellationTokenSource.Cancel();

//    }

//    private void OnApplicationQuit()
//    {
//        print("OnApplicationQuit");

//        cancellationTokenSource.Cancel();

//    }
//}









//using System;
//using System.IO;
//using System.IO.Pipes;
//using UnityEngine;

//public class NamedPipeServer : MonoBehaviour
//{
//    private NamedPipeServerStream serverStream;

//    public JumpingPlayerScript jumpingPlayer; // Reference to the JumpingPlayerScript
//    string lastestLine;

//    private void Awake()
//    {
//        jumpingPlayer = GetComponent<JumpingPlayerScript>(); // Get a reference to the JumpingPlayerScript component
//    }
//    StreamReader reader;

//    // Replace "pipeName" with the actual pipe name you're using

//    private void CheckPipeStream()
//    {

//        // Wait for a client to connect
//        serverStream.WaitForConnection();

//        // Check if the pipe stream is broken
//        try
//        {
//            // Attempt to read or write to the pipe
//            serverStream.ReadByte();
//            Debug.Log("The pipe stream is not broken.");
//        }
//        catch (IOException ex) when (IsPipeBrokenException(ex))
//        {
//            Debug.Log("The pipe stream is broken.");
//        }

//    }


//    private void Start()
//    {
//        // Create a named pipe server with a specific name
//        serverStream = new NamedPipeServerStream("MyNamedPipe", PipeDirection.In);
//        print("new serverStream");
//        reader = new StreamReader(serverStream);
//        //print("BeginWaitForConnection 1");


//        print("BeginWaitForConnection 1");

//        serverStream.BeginWaitForConnection(OnClientConnected, null);
//        print("BeginWaitForConnection 2");

//        print("BeginWaitForConnection 3 if connected = " + serverStream.IsConnected);

//        //print("BeginWaitForConnection 2");

//        // Create a new thread to avoid blocking the main Unity thread
//        //System.Threading.Thread thread = new System.Threading.Thread(CheckPipeStream);
//        //thread.Start();
//    }

//    static bool IsPipeBrokenException(IOException ex)
//    {
//        const int ERROR_PIPE_NOT_CONNECTED = 233;
//        const int ERROR_NO_DATA = 232;

//        var errorCode = ex.HResult & 0xFFFF;
//        return errorCode == ERROR_PIPE_NOT_CONNECTED || errorCode == ERROR_NO_DATA;
//    }
//    private void Update()
//    {
//        //jumpingPlayer.namedPipeJumpCharging = false;
//        //print("server.isconnected = " + serverStream.IsConnected);
//        //System.Threading.Thread thread = new System.Threading.Thread(CheckPipeStream);
//        //print("Update if connected = " + serverStream.IsConnected);
//        //print("Update serverstream null = " + (serverStream == null));

//    }

//    private void OnClientConnected(System.IAsyncResult result)
//    {
//        print("OnClientConnected()");

//        ReadMessage();
//    }
//    public async void ReadMessage()
//    {
//        print("ReadMessage()");

//        while (true)
//        {
//            print("ReadMessage()1");

//            //if (!serverStream.IsConnected) { continue; }
//            //if (lastestLine == "Null") { serverStream.Close(); }
//            //lastestLine =  reader.ReadLine();
//            lastestLine = await reader.ReadLineAsync();
//            print(lastestLine);

//            if (lastestLine.Contains("Trigger:"))
//            {
//                string boolean = lastestLine.Remove(0, lastestLine.IndexOf(':') + 1);
//                print(boolean);

//                if (boolean == "True")
//                {
//                    jumpingPlayer.isCharging = true;
//                }
//                else if (boolean == "False")
//                {
//                    jumpingPlayer.isCharging = false;
//                }

//                //jumpingPlayer.isCharging();
//            }


//            //CheckPipeStream();

//            //reader.Close();
//            //reader.Dispose();
//            //if (serverStream.IsConnected)
//            //serverStream.Disconnect();
//            //serverStream.Close();
//            //serverStream.Dispose();
//        }
//    }
//    public void Jump()
//    {


//    }

//    private void OnDisable()
//    {
//        reader.Close();
//        reader.Dispose();
//        if (serverStream.IsConnected)
//        {
//            serverStream.Disconnect();

//        }

//        serverStream.Close();
//        serverStream.Dispose();

//    }

//    private void OnApplicationQuit()
//    {
//        reader.Close();
//        reader.Dispose();
//        if (serverStream.IsConnected)
//        {
//            serverStream.Disconnect();
//        }

//        serverStream.Close();
//        serverStream.Dispose();

//    }

//}