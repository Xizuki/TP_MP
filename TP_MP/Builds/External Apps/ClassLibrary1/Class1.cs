using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nyp.Razor.Spectrum;
using System.Drawing;
using System.Collections;
using System.Threading;
using System.IO.Pipes;
using System.IO;
using System.Windows.Forms;

namespace BTGame
{
    public class TestGame : Game
    {
        static NamedPipeClientStream clientStream;
        static StreamWriter writer;



        TextBox textBox;
        TextBox textBox2;
        TextBox textBox3;
        TextBox textBox4;
        TextBox textBox5;
        TextBox textBox6;
        TextBox textBox7;
        TextBox textBox8;
        TextBox textBox9;
        TextBox textBox10;
        TextBox textBox11;
        TextBox textBox12;
        TextBox textBox13;
        TextBox textBox14;
        TextBox textBox15;

        public static Player Client => Game.m_Clients.Count > 0 ? (Player)Game.m_Clients[0] : (Player)null;

        public TestGame()
        {
           
        }

        public override void Initialize()
        {
            base.Initialize();

            if (clientStream == null || !clientStream.IsConnected)
            {
                // Create the named pipe client stream and connect
                clientStream = new NamedPipeClientStream(".", "MyNamedPipe", PipeDirection.Out);
                clientStream.Connect();

                // Create the stream writer
                writer = new StreamWriter(clientStream);
            }   

            DebugForm();
        }

        public override void Update(double elapsed)
        {
            base.Update(elapsed);
            writer.WriteLine("Trigger:" + Client.EegChannel.A_Trigger);
            // Flush the writer and check for IOException (pipe broken)
            try
            {
                writer.Flush();
            }
            catch (IOException ex)
            {
                //Exit();
            }


            ///* Send Values and Thresholds to get variable jump charge speed in the futre

            //writer.WriteLine("A Value : " + Client.EegChannel.A_Value);
            //// Flush the writer and check for IOException (pipe broken)
            //try
            //{
            //    writer.Flush();
            //}
            //catch (IOException ex)
            //{
            //    Exit();
            //}


            textBox.Text = "Client.EegChannel.A_Value =  " + Client.EegChannel.A_Value;
            textBox2.Text = "Client.EegChannel.B_Value =  " + Client.EegChannel.B_Value;
            textBox3.Text = "Client.EegChannel.C_Value =  " + Client.EegChannel.C_Value;
            textBox4.Text = "Client.EegChannel.D_Value =  " + Client.EegChannel.D_Value;
            textBox5.Text = "Client.EegChannel.R_Value =  " + Client.EegChannel.R_Value;


            textBox6.Text = "Client.EegChannel.A_Trigger =  " + Client.EegChannel.A_Trigger;
            textBox7.Text = "Client.EegChannel.B_Trigger =  " + Client.EegChannel.B_Trigger;
            textBox8.Text = "Client.EegChannel.C_Trigger =  " + Client.EegChannel.C_Trigger;
            textBox9.Text = "Client.EegChannel.D_Trigger =  " + Client.EegChannel.D_Trigger;
            textBox10.Text = "Client.EegChannel.R_Trigger =  " + Client.EegChannel.R_Trigger;


            textBox11.Text = "Client.EegChannel.A_Threshold =  " + Client.EegChannel.A_Threshold;
            textBox12.Text = "Client.EegChannel.B_Threshold =  " + Client.EegChannel.B_Threshold;
            textBox13.Text = "Client.EegChannel.C_Threshold =  " + Client.EegChannel.C_Threshold;
            textBox14.Text = "Client.EegChannel.D_Threshold =  " + Client.EegChannel.D_Threshold;
            textBox15.Text = "Client.EegChannel.R_Threshold =  " + Client.EegChannel.R_Threshold;
           
        }


        public void DebugForm()
        {
            textBox = new TextBox();
            // Set properties for the textbox (optional)
            textBox.Name = "dynamicTextBox";
            textBox.Text = "This is a dynamically created textbox.";
            textBox.Location = new System.Drawing.Point(50, 50);
            textBox.Size = new System.Drawing.Size(350, 20);
            // Add the textbox to the form's Controls collection
            this.Controls.Add(textBox);


            textBox2 = new TextBox();
            // Set properties for the textBox2 (optional)
            textBox2.Name = "dynamictextBox2";
            textBox2.Text = "This is a dynamically created textBox2.";
            textBox2.Location = new System.Drawing.Point(50, 75);
            textBox2.Size = new System.Drawing.Size(350, 20);
            // Add the textBox2 to the form's Controls collection
            this.Controls.Add(textBox2);


            textBox3 = new TextBox();
            // Set properties for the textBox2 (optional)
            textBox3.Name = "dynamictextBox3";
            textBox3.Text = "This is a dynamically created textBox2.";
            textBox3.Location = new System.Drawing.Point(50, 100);
            textBox3.Size = new System.Drawing.Size(350, 20);
            // Add the textBox2 to the form's Controls collection
            this.Controls.Add(textBox3);

            textBox4 = new TextBox();
            // Set properties for the textbox (optional)
            textBox4.Name = "dynamicTextBox";
            textBox4.Text = "This is a dynamically created textbox.";
            textBox4.Location = new System.Drawing.Point(50, 125);
            textBox4.Size = new System.Drawing.Size(350, 20);
            // Add the textbox to the form's Controls collection
            this.Controls.Add(textBox4);


            textBox5 = new TextBox();
            // Set properties for the textBox2 (optional)
            textBox5.Name = "dynamictextBox2";
            textBox5.Text = "This is a dynamically created textBox2.";
            textBox5.Location = new System.Drawing.Point(50, 150);
            textBox5.Size = new System.Drawing.Size(350, 20);
            // Add the textBox2 to the form's Controls collection
            this.Controls.Add(textBox5);


            textBox6 = new TextBox();
            // Set properties for the textBox2 (optional)
            textBox6.Name = "dynamictextBox3";
            textBox6.Text = "This is a dynamically created textBox2.";
            textBox6.Location = new System.Drawing.Point(50, 175);
            textBox6.Size = new System.Drawing.Size(350, 20);
            // Add the textBox2 to the form's Controls collection
            this.Controls.Add(textBox6);

            textBox7 = new TextBox();
            // Set properties for the textbox (optional)
            textBox7.Name = "dynamicTextBox";
            textBox7.Text = "This is a dynamically created textbox.";
            textBox7.Location = new System.Drawing.Point(50, 200);
            textBox7.Size = new System.Drawing.Size(350, 20);
            // Add the textbox to the form's Controls collection
            this.Controls.Add(textBox7);


            textBox8 = new TextBox();
            // Set properties for the textBox2 (optional)
            textBox8.Name = "dynamictextBox2";
            textBox8.Text = "This is a dynamically created textBox2.";
            textBox8.Location = new System.Drawing.Point(50, 225);
            textBox8.Size = new System.Drawing.Size(350, 20);
            // Add the textBox2 to the form's Controls collection
            this.Controls.Add(textBox8);


            textBox9 = new TextBox();
            // Set properties for the textBox2 (optional)
            textBox9.Name = "dynamictextBox3";
            textBox9.Text = "This is a dynamically created textBox2.";
            textBox9.Location = new System.Drawing.Point(50, 250);
            textBox9.Size = new System.Drawing.Size(350, 20);
            // Add the textBox2 to the form's Controls collection
            this.Controls.Add(textBox3);

            textBox10 = new TextBox();
            // Set properties for the textbox (optional)
            textBox10.Name = "dynamicTextBox";
            textBox10.Text = "This is a dynamically created textbox.";
            textBox10.Location = new System.Drawing.Point(50, 275);
            textBox10.Size = new System.Drawing.Size(350, 20);
            // Add the textbox to the form's Controls collection
            this.Controls.Add(textBox10);


            textBox11 = new TextBox();
            // Set properties for the textBox2 (optional)
            textBox11.Name = "dynamictextBox2";
            textBox11.Text = "This is a dynamically created textBox2.";
            textBox11.Location = new System.Drawing.Point(50, 300);
            textBox11.Size = new System.Drawing.Size(350, 20);
            // Add the textBox2 to the form's Controls collection
            this.Controls.Add(textBox11);


            textBox12 = new TextBox();
            // Set properties for the textBox2 (optional)
            textBox12.Name = "dynamictextBox3";
            textBox12.Text = "This is a dynamically created textBox2.";
            textBox12.Location = new System.Drawing.Point(50, 325);
            textBox12.Size = new System.Drawing.Size(350, 20);
            // Add the textBox2 to the form's Controls collection
            this.Controls.Add(textBox12);

            textBox13 = new TextBox();
            // Set properties for the textbox (optional)
            textBox13.Name = "dynamicTextBox";
            textBox13.Text = "This is a dynamically created textbox.";
            textBox13.Location = new System.Drawing.Point(50, 350);
            textBox13.Size = new System.Drawing.Size(350, 20);
            // Add the textbox to the form's Controls collection
            this.Controls.Add(textBox13);


            textBox14 = new TextBox();
            // Set properties for the textBox2 (optional)
            textBox14.Name = "dynamictextBox2";
            textBox14.Text = "This is a dynamically created textBox2.";
            textBox14.Location = new System.Drawing.Point(50, 375);
            textBox14.Size = new System.Drawing.Size(350, 20);
            // Add the textBox2 to the form's Controls collection
            this.Controls.Add(textBox14);


            textBox15 = new TextBox();
            // Set properties for the textBox2 (optional)
            textBox15.Name = "dynamictextBox3";
            textBox15.Text = "This is a dynamically created textBox2.";
            textBox15.Location = new System.Drawing.Point(50, 400);
            textBox15.Size = new System.Drawing.Size(350, 20);
            // Add the textBox2 to the form's Controls collection
            this.Controls.Add(textBox15);
        }










        public override double R_Value_A
        {
            set
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = Game.m_Clients.GetEnumerator();
                    if (!enumerator.MoveNext())
                        return;
                    ((Player)enumerator.Current).EegChannel.R_Value = value;
                }
                finally
                {
                    if (enumerator is IDisposable)
                        ((IDisposable)enumerator).Dispose();
                }
            }
        }

        public override double R_Value_B
        {
            set => this.R_Value_A = value;
        }

        public override double A_Value_A
        {
            set
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = Game.m_Clients.GetEnumerator();
                    if (!enumerator.MoveNext())
                        return;
                    ((Player)enumerator.Current).EegChannel.A_Value = value;
                }
                finally
                {
                    if (enumerator is IDisposable)
                        ((IDisposable)enumerator).Dispose();
                }
            }
        }

        public override double A_Value_B
        {
            set => this.A_Value_A = value;
        }

        public override double B_Value_A
        {
            set
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = Game.m_Clients.GetEnumerator();
                    if (!enumerator.MoveNext())
                        return;
                    ((Player)enumerator.Current).EegChannel.B_Value = value;
                }
                finally
                {
                    if (enumerator is IDisposable)
                        ((IDisposable)enumerator).Dispose();
                }
            }
        }

        public override double B_Value_B
        {
            set => this.B_Value_A = value;
        }

        public override double C_Value_A
        {
            set
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = Game.m_Clients.GetEnumerator();
                    if (!enumerator.MoveNext())
                        return;
                    ((Player)enumerator.Current).EegChannel.C_Value = value;
                }
                finally
                {
                    if (enumerator is IDisposable)
                        ((IDisposable)enumerator).Dispose();
                }
            }
        }

        public override double C_Value_B
        {
            set => this.C_Value_A = value;
        }

        public override double D_Value_A
        {
            set
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = Game.m_Clients.GetEnumerator();
                    if (!enumerator.MoveNext())
                        return;
                    ((Player)enumerator.Current).EegChannel.D_Value = value;
                }
                finally
                {
                    if (enumerator is IDisposable)
                        ((IDisposable)enumerator).Dispose();
                }
            }
        }

        public override double D_Value_B
        {
            set => this.D_Value_A = value;
        }

        public override double R_Threshold_A
        {
            set
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = Game.m_Clients.GetEnumerator();
                    if (!enumerator.MoveNext())
                        return;
                    ((Player)enumerator.Current).EegChannel.R_Threshold = value;
                }
                finally
                {
                    if (enumerator is IDisposable)
                        ((IDisposable)enumerator).Dispose();
                }
            }
        }

        public override double R_Threshold_B
        {
            set => this.R_Threshold_A = value;
        }

        public override double A_Threshold_A
        {
            set
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = Game.m_Clients.GetEnumerator();
                    if (!enumerator.MoveNext())
                        return;
                    ((Player)enumerator.Current).EegChannel.A_Threshold = value;
                }
                finally
                {
                    if (enumerator is IDisposable)
                        ((IDisposable)enumerator).Dispose();
                }
            }
        }

        public override double A_Threshold_B
        {
            set => this.A_Threshold_A = value;
        }

        public override double B_Threshold_A
        {
            set
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = Game.m_Clients.GetEnumerator();
                    if (!enumerator.MoveNext())
                        return;
                    ((Player)enumerator.Current).EegChannel.B_Threshold = value;
                }
                finally
                {
                    if (enumerator is IDisposable)
                        ((IDisposable)enumerator).Dispose();
                }
            }
        }

        public override double B_Threshold_B
        {
            set => this.B_Threshold_A = value;
        }

        public override double C_Threshold_A
        {
            set
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = Game.m_Clients.GetEnumerator();
                    if (!enumerator.MoveNext())
                        return;
                    ((Player)enumerator.Current).EegChannel.C_Threshold = value;
                }
                finally
                {
                    if (enumerator is IDisposable)
                        ((IDisposable)enumerator).Dispose();
                }
            }
        }

        public override double C_Threshold_B
        {
            set => this.C_Threshold_A = value;
        }

        public override double D_Threshold_A
        {
            set
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = Game.m_Clients.GetEnumerator();
                    if (!enumerator.MoveNext())
                        return;
                    ((Player)enumerator.Current).EegChannel.D_Threshold = value;
                }
                finally
                {
                    if (enumerator is IDisposable)
                        ((IDisposable)enumerator).Dispose();
                }
            }
        }

        public override double D_Threshold_B
        {
            set => this.D_Threshold_A = value;
        }

        public override bool R_Trigger_A
        {
            set
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = Game.m_Clients.GetEnumerator();
                    if (!enumerator.MoveNext())
                        return;
                    ((Player)enumerator.Current).EegChannel.R_Trigger = value;
                }
                finally
                {
                    if (enumerator is IDisposable)
                        ((IDisposable)enumerator).Dispose();
                }
            }
        }

        public override bool R_Trigger_B
        {
            set => this.R_Trigger_A = value;
        }

        public override bool A_Trigger_A
        {
            set
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = Game.m_Clients.GetEnumerator();
                    if (!enumerator.MoveNext())
                        return;
                    ((Player)enumerator.Current).EegChannel.A_Trigger = value;
                }
                finally
                {
                    if (enumerator is IDisposable)
                        ((IDisposable)enumerator).Dispose();
                }
            }
        }

        public override bool A_Trigger_B
        {
            set => this.A_Trigger_A = value;
        }

        public override bool B_Trigger_A
        {
            set
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = Game.m_Clients.GetEnumerator();
                    if (!enumerator.MoveNext())
                        return;
                    ((Player)enumerator.Current).EegChannel.B_Trigger = value;
                }
                finally
                {
                    if (enumerator is IDisposable)
                        ((IDisposable)enumerator).Dispose();
                }
            }
        }

        public override bool B_Trigger_B
        {
            set => this.B_Trigger_A = value;
        }

        public override bool C_Trigger_A
        {
            set
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = Game.m_Clients.GetEnumerator();
                    if (!enumerator.MoveNext())
                        return;
                    ((Player)enumerator.Current).EegChannel.C_Trigger = value;
                }
                finally
                {
                    if (enumerator is IDisposable)
                        ((IDisposable)enumerator).Dispose();
                }
            }
        }

        public override bool C_Trigger_B
        {
            set => this.C_Trigger_A = value;
        }

        public override bool D_Trigger_A
        {
            set
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = Game.m_Clients.GetEnumerator();
                    if (!enumerator.MoveNext())
                        return;
                    ((Player)enumerator.Current).EegChannel.D_Trigger = value;
                }
                finally
                {
                    if (enumerator is IDisposable)
                        ((IDisposable)enumerator).Dispose();
                }
            }
        }

        public override bool D_Trigger_B
        {
            set => this.D_Trigger_A = value;
        }

        public override bool R_Ignore_A
        {
            set
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = Game.m_Clients.GetEnumerator();
                    if (!enumerator.MoveNext())
                        return;
                    ((Player)enumerator.Current).EegChannel.R_Ignore = value;
                }
                finally
                {
                    if (enumerator is IDisposable)
                        ((IDisposable)enumerator).Dispose();
                }
            }
        }

        public override bool R_Ignore_B
        {
            set => this.R_Ignore_A = value;
        }

        public override bool A_Ignore_A
        {
            set
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = Game.m_Clients.GetEnumerator();
                    if (!enumerator.MoveNext())
                        return;
                    ((Player)enumerator.Current).EegChannel.A_Ignore = value;
                }
                finally
                {
                    if (enumerator is IDisposable)
                        ((IDisposable)enumerator).Dispose();
                }
            }
        }

        public override bool A_Ignore_B
        {
            set => this.A_Ignore_A = value;
        }

        public override bool B_Ignore_A
        {
            set
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = Game.m_Clients.GetEnumerator();
                    if (!enumerator.MoveNext())
                        return;
                    ((Player)enumerator.Current).EegChannel.B_Ignore = value;
                }
                finally
                {
                    if (enumerator is IDisposable)
                        ((IDisposable)enumerator).Dispose();
                }
            }
        }

        public override bool B_Ignore_B
        {
            set => this.B_Ignore_A = value;
        }

        public override bool C_Ignore_A
        {
            set
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = Game.m_Clients.GetEnumerator();
                    if (!enumerator.MoveNext())
                        return;
                    ((Player)enumerator.Current).EegChannel.C_Ignore = value;
                }
                finally
                {
                    if (enumerator is IDisposable)
                        ((IDisposable)enumerator).Dispose();
                }
            }
        }

        public override bool C_Ignore_B
        {
            set => this.C_Ignore_A = value;
        }

        public override bool D_Ignore_A
        {
            set
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = Game.m_Clients.GetEnumerator();
                    if (!enumerator.MoveNext())
                        return;
                    ((Player)enumerator.Current).EegChannel.D_Ignore = value;
                }
                finally
                {
                    if (enumerator is IDisposable)
                        ((IDisposable)enumerator).Dispose();
                }
            }
        }

        public override bool D_Ignore_B
        {
            set => this.D_Ignore_A = value;
        }
    }
}
