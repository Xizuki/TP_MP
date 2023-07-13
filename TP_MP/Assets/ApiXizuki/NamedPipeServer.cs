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
    private void Start()
    {
        // Create a named pipe server with a specific name
        serverStream = new NamedPipeServerStream("MyNamedPipe", PipeDirection.In);
        print("new serverStream");
        reader = new StreamReader(serverStream);
        ReadMessage();
        //print("BeginWaitForConnection 1");

        serverStream.BeginWaitForConnection(OnClientConnected, null);

        //print("BeginWaitForConnection 2");
    }

    private void Update()
    {
        //print("server.isconnected = " + serverStream.IsConnected);

    }

    private void OnClientConnected(System.IAsyncResult result)
    {
        ReadMessage();
    }
    public async void ReadMessage()
    {
        while (true)
        {
            //if (!serverStream.IsConnected) { continue; }
            if (lastestLine == "Null") { serverStream.Close(); }
            lastestLine = await reader.ReadLineAsync();

            print(lastestLine);
            if(lastestLine == "Jump")
            {
                jumpingPlayer.Jump();
            }
        }
    }
    void test()
    {
        Jump();
        for(int i =0; i <500; i++)
        {
            //print(i);
        }
    }
    public void Jump()
    {
      

    }
    private void OnDisable()
    {
        if (serverStream.IsConnected)
            serverStream.Disconnect();
        serverStream.Close();
        serverStream.Dispose();
    }
    
    private void OnApplicationQuit()
    {
        if(serverStream.IsConnected)
            serverStream.Disconnect();
        serverStream.Close();
        serverStream.Dispose();
    }
}