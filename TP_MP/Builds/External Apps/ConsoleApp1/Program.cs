using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Pipes;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static NamedPipeClientStream clientStream;
        static StreamWriter writer;

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("TEST");
                if (clientStream == null || !clientStream.IsConnected)
                {
                    // Create the named pipe client stream and connect
                    clientStream = new NamedPipeClientStream(".", "MyNamedPipe", PipeDirection.Out);
                    clientStream.Connect();

                    // Create the stream writer
                    writer = new StreamWriter(clientStream);
                }
                Console.WriteLine("IsConnected: " + clientStream.IsConnected);

                // Send the command to trigger the Jump method
                writer.WriteLine("Jump"); // Command to trigger the Jump method
                Console.Beep();

                // Flush the writer and check for IOException (pipe broken)
                try
                {
                    writer.Flush();
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Pipe is broken: " + ex.Message);
                    // Handle the pipe broken condition
                    // You can choose to reconnect, exit the application, or take appropriate actions
                }

                System.Threading.Thread.Sleep(250); // Delay for 250 milliseconds
            }
        }
    }
}
