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

        Player player => (Player)m_Clients[0];

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

            writer.WriteLine("Player == null = " + player == null); // Command to trigger the Jump method
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

            writer.WriteLine("m_Clients.Count = " + m_Clients.Count); // Command to trigger the Jump method
            try
            {
                writer.Flush();
            }
            catch (IOException ex)
            {
                Exit();
            }


            writer.WriteLine("Player == null = " + (player != null)); // Command to trigger the Jump method                                                         // Flush the writer and check for IOException (pipe broken)
            try
            {
                writer.Flush();
            }
            catch (IOException ex)
            {
                Exit();
            }

            writer.WriteLine("Player.EegChannel.R_Threshold = " + player.EegChannel.R_Threshold); // Command to trigger the Jump method
                                                                                                  // Flush the writer and check for IOException (pipe broken)
            try
            {
                writer.Flush();
            }
            catch (IOException ex)
            {
                Exit();
            }


            writer.WriteLine("Player.EegChannel.A_Trgger = " + player.EegChannel.A_Trigger); // Command to trigger the Jump method       try
            {
                writer.Flush();
            }
            try
            {
                writer.Flush();
            }
            catch (IOException ex)
            {
                Exit();
            }
            writer.WriteLine("Player.EegChannel.B_Trgger = " + player.EegChannel.B_Trigger); // Command to trigger the Jump method
            try
            {
                writer.Flush();
            }
            catch (IOException ex)
            {
                Exit();
            }
            writer.WriteLine("Player.EegChannel.C_Trgger = " + player.EegChannel.C_Trigger); // Command to trigger the Jump method
            try
            {
                writer.Flush();
            }
            catch (IOException ex)
            {
                Exit();
            }
            writer.WriteLine("Player.EegChannel.D_Trgger = " + player.EegChannel.D_Trigger); // Command to trigger the Jump method
            try
            {
                writer.Flush();
            }
            catch (IOException ex)
            {
                Exit();
            }
            writer.WriteLine("Player.EegChannel.R_Trgger = " + player.EegChannel.R_Trigger); // Command to trigger the Jump method
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





        Player PlayerOne => (Player)m_Clients[0];

        public virtual double R_Value_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.R_Value = value;
            }
        }

        public virtual double R_Threshold_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.R_Threshold = value;
            }
        }

        public virtual bool R_Trigger_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.R_Trigger = value;
            }
        }

        public virtual bool R_Ignore_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.R_Ignore = value;
            }
        }

        public virtual double A_Value_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.A_Value = value;
            }
        }

        public virtual double A_Threshold_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.A_Threshold = value;
            }
        }

        public virtual bool A_Trigger_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.A_Trigger = value;
            }
        }

        public virtual bool A_Ignore_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.A_Ignore = value;
            }
        }

        public virtual double B_Value_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.B_Value = value;
            }
        }

        public virtual double B_Threshold_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.B_Threshold = value;
            }
        }

        public virtual bool B_Trigger_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.B_Trigger = value;
            }
        }

        public virtual bool B_Ignore_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.B_Ignore = value;
            }
        }

        public virtual double C_Value_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.C_Value = value;
            }
        }

        public virtual double C_Threshold_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.C_Threshold = value;
            }
        }

        public virtual bool C_Trigger_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.C_Trigger = value;
            }
        }

        public virtual bool C_Ignore_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.C_Ignore = value;
            }
        }

        public virtual double D_Value_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.D_Value = value;
            }
        }

        public virtual double D_Threshold_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.D_Threshold = value;
            }
        }

        public virtual bool D_Trigger_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.D_Trigger = value;
            }
        }

        public virtual bool D_Ignore_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.D_Ignore = value;
            }
        }
    }
}
