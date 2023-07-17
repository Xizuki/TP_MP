using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nyp.Razor.Spectrum;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using System.Drawing.Drawing2D;
using System.IO.Pipes;
using System.IO;

namespace GameInterface
{
    public class TestGame : Game
    {
        static NamedPipeClientStream clientStream;
        static StreamWriter writer;

        Player player => (Player)Game.m_Clients[0];

        public TestGame()
        {
            //Console.Beep();


            StreamConnection();
        }

        public override void Start_Game()
        {
            base.Start_Game();
            Debug.WriteLine("Debugging message"); // Output a debugging message
            Console.WriteLine("Debugging message"); // Output a debugging message to the console
            MessageBox.Show("Debugging message");

            if (clientStream == null || !clientStream.IsConnected)
            {
                // Create the named pipe client stream and connect
                clientStream = new NamedPipeClientStream(".", "MyNamedPipe", PipeDirection.Out);
                clientStream.Connect();

                // Create the stream writer
                writer = new StreamWriter(clientStream);
            }

            writer.WriteLine("Player == null = " + player==null); // Command to trigger the Jump method
            writer.WriteLine("Player.EegChannel.R_Threshold = " + player.EegChannel.R_Threshold); // Command to trigger the Jump method

        }
        public void StreamConnection()
        {
            //string executablePath = "C://Users/Xizuk/OneDrive/Documents/GitHub/TP_MP/TP_MP/Builds/Unity EXE/TP_MP.exe";

            //Process.Start(executablePath);

            //System.Threading.Thread.Sleep(15000);


        }
        public override void Update(double elapsed)
        {
            base.Update(elapsed);

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
            writer.WriteLine("JumpCharge"); // Command to trigger the Jump method
            Console.Beep();

            // Flush the writer and check for IOException (pipe broken)
            try
            {
                writer.Flush();
            }
            catch (IOException ex)
            {
                Exit();
            }
        }

        public override void Exit()
        {
            base.Exit();

            writer.Close();
            writer.Dispose();
            clientStream.Close();
            clientStream.Dispose();
        }
    }
}
