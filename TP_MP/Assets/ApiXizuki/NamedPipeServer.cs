using System.IO;
using System.IO.Pipes;
using UnityEngine;

public class NamedPipeServer : MonoBehaviour
{
    private NamedPipeServerStream serverStream;

    public JumpingPlayerScript jumpingPlayer; // Reference to the JumpingPlayerScript

    private void Awake()
    {
        jumpingPlayer = GetComponent<JumpingPlayerScript>(); // Get a reference to the JumpingPlayerScript component
    }

    private void Start()
    {
        // Create a named pipe server with a specific name
        serverStream = new NamedPipeServerStream("MyNamedPipe");

        // Start listening for a connection asynchronously
        serverStream.BeginWaitForConnection(OnClientConnected, null);
    }

    private void OnClientConnected(System.IAsyncResult result)
    {
        // Client connected, handle the connection
        serverStream.EndWaitForConnection(result);

        // Read the incoming message or command
        StreamReader reader = new StreamReader(serverStream);
        string command = reader.ReadLine();

        // Handle the command, call the corresponding method
        if (command == "Jump")
        {
            jumpingPlayer.Jump();
        }

        // Close the named pipe server
        //serverStream.Close();

        // Restart the server to listen for the next connection
        //Start();
    }
}