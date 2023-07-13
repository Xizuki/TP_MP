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
        public void StreamConnection()
        {
          
        }
        public override void Update(double elapsed)
        {
            base.Update(elapsed);

            if (clientStream == null)
            {
                // Create the named pipe client stream and connect
                clientStream = new NamedPipeClientStream(".", "MyNamedPipe", PipeDirection.Out);
                clientStream.Connect();

                // Create the stream writer
                writer = new StreamWriter(clientStream);
            }

            //Console.WriteLineasd("");

            // Send the command to trigger the Jump method
            writer.WriteLine("Jump"); // Command to trigger the Jump method
            //writer.Flush();
            //if(player.EegChannel.)
            Console.Beep();
        }
    }
}
