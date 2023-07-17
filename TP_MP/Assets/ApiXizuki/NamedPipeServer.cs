using System;
using System.IO;
using System.IO.Pipes;
using UnityEngine;

public class NamedPipeServer : MonoBehaviour
{
    private NamedPipeServerStream serverStream;

    public JumpingPlayerScript jumpingPlayer; // Reference to the JumpingPlayerScript
    string lastestLine;

    private void Awake()
    {
        jumpingPlayer = GetComponent<JumpingPlayerScript>(); // Get a reference to the JumpingPlayerScript component
    }
    StreamReader reader;

    // Replace "pipeName" with the actual pipe name you're using

    private void CheckPipeStream()
    {
        using (NamedPipeServerStream pipeStream = serverStream)
        {
            // Wait for a client to connect
            pipeStream.WaitForConnection();

            // Check if the pipe stream is broken
            try
            {
                // Attempt to read or write to the pipe
                pipeStream.ReadByte();
                Debug.Log("The pipe stream is not broken.");
            }
            catch (IOException ex) when (IsPipeBrokenException(ex))
            {
                Debug.Log("The pipe stream is broken.");
            }
        }
    }


    private void Start()
    {
        // Create a new thread to avoid blocking the main Unity thread
        System.Threading.Thread thread = new System.Threading.Thread(CheckPipeStream);
        thread.Start();

        // Create a named pipe server with a specific name
        serverStream = new NamedPipeServerStream("MyNamedPipe", PipeDirection.In);
        print("new serverStream");
        reader = new StreamReader(serverStream);
        //print("BeginWaitForConnection 1");

        serverStream.BeginWaitForConnection(OnClientConnected, null);

        //print("BeginWaitForConnection 2");
    }

    static bool IsPipeBrokenException(IOException ex)
    {
        const int ERROR_PIPE_NOT_CONNECTED = 233;
        const int ERROR_NO_DATA = 232;

        var errorCode = ex.HResult & 0xFFFF;
        return errorCode == ERROR_PIPE_NOT_CONNECTED || errorCode == ERROR_NO_DATA;
    }
    private void Update()
    {
        jumpingPlayer.namedPipeJumpCharging = false;
        //print("server.isconnected = " + serverStream.IsConnected);
        System.Threading.Thread thread = new System.Threading.Thread(CheckPipeStream);

    }

    private void OnClientConnected(System.IAsyncResult result)
    {
        ReadMessage();
    }
    public void ReadMessage()
    {
        while (serverStream.IsConnected)
        {
            //if (!serverStream.IsConnected) { continue; }
            if (lastestLine == "Null") { serverStream.Close(); }
            lastestLine =  reader.ReadLine();

            print(lastestLine);
            /*
            if(lastestLine == "Jump")
            {
                jumpingPlayer.Jump();
            }
            3*/
            if (lastestLine == "JumpCharge")
            {
                jumpingPlayer.namedPipeJumpCharging = true ;
            }

        }

        reader.Close();
        reader.Dispose();
        //if (serverStream.IsConnected)
        serverStream.Disconnect();
        serverStream.Close();
        serverStream.Dispose();
    }
   
    public void Jump()
    {
      

    }
    private void OnDisable()
    {
        reader.Close();
        reader.Dispose();
        //if (serverStream.IsConnected)
        serverStream.Disconnect();
        serverStream.Close();
        serverStream.Dispose();


    }
    
    private void OnApplicationQuit()
    {
        reader.Close();
        reader.Dispose();
       // if (serverStream.IsConnected)
        serverStream.Disconnect();
        serverStream.Close();
        serverStream.Dispose();
    }
}
