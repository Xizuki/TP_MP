using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class NamedPipeServer : MonoBehaviour
{
    private NamedPipeServerStream serverStream;
    private static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
    private static CancellationToken cancellationToken;
    private StreamReader reader;
    private Task waitingTask;

    public JumpingPlayerScript jumpingPlayer; // Reference to the JumpingPlayerScript
    string lastestLine;

    private void Awake()
    {
        jumpingPlayer = GetComponent<JumpingPlayerScript>(); // Get a reference to the JumpingPlayerScript component
    }

    private void Start()
    {
        // Create a named pipe server with a specific name
        serverStream = new NamedPipeServerStream("MyNamedPipe", PipeDirection.In);
        reader = new StreamReader(serverStream);

        // Start waiting for a client to connect asynchronously
        //cancellationTokenSource = new CancellationTokenSource();
        // Step 2: Get the CancellationToken from the CancellationTokenSource
        cancellationToken = cancellationTokenSource.Token;

        cancellationToken.Register(() =>
        {
            Console.WriteLine("Task has been cancelled!");
        });

        Debug.Log("Start() 0 is token CanBeCanceled =  " + cancellationToken.CanBeCanceled);

        Debug.Log("Start() 1 ");
        //cancellationTokenSource.Cancel();
        Task.Run(async () =>
        {
            await WaitForConnectionAsync(cancellationToken);
        }).Wait();
        //waitingTask = 
        cancellationTokenSource.Cancel();
        Debug.Log("Start() 2 ");
    }

    public void CancelToken()
    {
        cancellationTokenSource.Cancel();
    }
    static bool WantsToQuit()
    {
        Debug.Log("Player prevented from quitting.");
        cancellationTokenSource.Cancel();
        return true;
    }

    private async Task WaitForConnectionAsync(CancellationToken cancellationToken)
    {
        Debug.Log("WaitForConnectionAsync() 1 ");
        // Check if cancellation has been requested before proceeding
        //cancellationToken.ThrowIfCancellationRequested();
        //try
        //{
        //    // Wait for a client to connect zasynchronously

        Application.wantsToQuit += WantsToQuit;
        //if (!Application.isPlaying)
        //{
        //    print("!Application.isPlaying");
        //    cancellationTokenSource.Cancel();
        //    return;
        //}

        await serverStream.WaitForConnectionAsync(cancellationToken);
            Debug.Log("WaitForConnectionAsync() 2 ");

            // Check if the pipe stream is broken
            try
            {
                // Attempt to read or write to the pipe
                serverStream.ReadByte();
                Debug.Log("The pipe stream is not broken.");
            }
            catch (IOException ex) when (IsPipeBrokenException(ex))
            {

                Debug.Log("The pipe stream is broken.");
            }

            // Start reading messages from the connected client
            ReadMessage();
        //}
        //catch (OperationCanceledException)
        //{
        //    // The waiting task has been canceled, ignore the exception
        //    return;
        //}
        //catch (Exception ex)
        //{
        //    // Handle any other exceptions
        //    Debug.LogError($"An error occurred while waiting for connection: {ex.Message}");
        //}
    }

    static bool IsPipeBrokenException(IOException ex)
    {
        const int ERROR_PIPE_NOT_CONNECTED = 233;
        const int ERROR_NO_DATA = 232;

        var errorCode = ex.HResult & 0xFFFF;
        return errorCode == ERROR_PIPE_NOT_CONNECTED || errorCode == ERROR_NO_DATA;
    }

    private void ReadMessage()
    {
        Debug.Log("ReadMessage() 1 ");

        while (serverStream.IsConnected)
        {
            Debug.Log("ReadMessage() 2 ");

            if (lastestLine == "Null")
            {
                serverStream.Close();
            }



            // Read the next line from the stream
            lastestLine = reader.ReadLine();
        }
    }

    private void Update()
    {
        
    }

    private void OnDisable()
    {
        print("ONDISABLE");
        cancellationTokenSource.Cancel();

    }

    private void OnApplicationQuit()
    {
        print("OnApplicationQuit");

        cancellationTokenSource.Cancel();
      
    }
}


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
