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

        Player player => (Player)m_Clients[0];

        //public static Background BG;
        //public static Monkey Monkey;
        //public static Bubble Bubble;
        //public static Basket Basket;
        //public static Arrow Arrow;
        //private Frame GenericFrame;
        //private Animation GenericAnimation;
        //private Sprite GenericSprite;
        //private Sprite m_Background;
        private ArrayList m_Monkey;
        private bool m_genBubble;
        public const int LEFT_POS = 0;
        public const int RIGHT_POS = 1;
        public const double LEFT_POSX = -275.0;
        public const double RIGHT_POSX = -185.0;
        public const double POSY = -200.0;
        public const int TOTAL_LIFE_BARS = 10;
        public static Stack m_LifeBars = new Stack();
        public const double MAXHARDBUBBLE_DUR = 10.0;
        private double m_hardBubbleDur;
        public const double MAXNEGARROW_DUR = 6.0;
        private double m_negArrowDur;
        public const double MAXPINBUBBLE_DUR = 12.0;
        private double m_pinBubbleDur;
        //private AudioSource m_BackgroundMusic;
        //private AudioSource m_Charging;
        public int HiScores;
        public ArrayList ScoresList;
        public ArrayList ScoresHistoryList;
        public ArrayList HiScoresList;
        public const string HISCORES_DATA_PATH = "../BubblePopper/data/HiScores/list.txt";
        public const string CLIENT_DATA_PATH = "../BubblePopper/data/Clients/";

        public TestGame()
        {
            InitializeComponent();

            ((UserControl)this).Load += new EventHandler(this.BubblePopper_Load);
            this.m_Monkey = new ArrayList();
            this.m_genBubble = true;
            this.m_hardBubbleDur = 10.0;
            this.m_negArrowDur = 6.0;
            this.m_pinBubbleDur = 12.0;
            this.ScoresList = new ArrayList();
            this.ScoresHistoryList = new ArrayList();
            this.HiScoresList = new ArrayList();
        }
        private void BubblePopper_Load(object sender, EventArgs e)
        {
        }
        public virtual void Initialize()
        {
            this.FrameRate = 30.0;
            Game.MinScores = 0;
            this.m_bIsBusy = true;
            ((ContainerControl)this).ParentForm.Text = "Bubble Popper";
            Game.LoadImage("../BubblePopper/images/splash.png");
            Game.LoadImage("../BubblePopper/images/pause.png");
            Game.LoadImage("../BubblePopper/images/progresschart.png");
            Game.LoadImage("../BubblePopper/images/fulllifebar.png");
            Game.LoadImage("../BubblePopper/images/lifebar_head.png");
            Game.LoadImage("../BubblePopper/images/highscore.png");
            Game.LoadImage("../BubblePopper/images/scorehistory.png");
            Game.LoadImage("../BubblePopper/images/bg1.png");
            Game.LoadImage("../BubblePopper/images/monkey_empty_bg1.png");
            Game.LoadImage("../BubblePopper/images/bg2.png");
            Game.LoadImage("../BubblePopper/images/monkey_empty_bg2.png");
            Game.LoadImage("../BubblePopper/images/bg3.png");
            Game.LoadImage("../BubblePopper/images/monkey_empty_bg3.png");
            Game.LoadImage("../BubblePopper/images/pinbubble.png");
            Game.LoadImage("../BubblePopper/images/basket1.png");
            Game.LoadImage("../BubblePopper/images/basket2.png");
            Game.LoadImage("../BubblePopper/images/bubble_blue.png");
            Game.LoadImage("../BubblePopper/images/bubble_yellow.png");
            Game.LoadImage("../BubblePopper/images/hardbubble_red.png");
            Game.LoadImage("../BubblePopper/images/normalarrow.png");
            Game.LoadImage("../BubblePopper/images/icearrow.png");
            Game.LoadImage("../BubblePopper/images/firearrow.png");
            Game.LoadImage("../BubblePopper/images/normal.png");
            Game.LoadImage("../BubblePopper/images/normal_pullback.png");
            Game.LoadImage("../BubblePopper/images/normal_start1.png");
            Game.LoadImage("../BubblePopper/images/normal_start2.png");
            Game.LoadImage("../BubblePopper/images/normal_start3.png");
            Game.LoadImage("../BubblePopper/images/stun1.png");
            Game.LoadImage("../BubblePopper/images/stun2.png");
            Game.LoadImage("../BubblePopper/images/stun3.png");
            //AudioManager.Singleton.LoadAudioSample("../BubblePopper/sound/background.wav");
            //AudioManager.Singleton.LoadAudioSample("../BubblePopper/sound/normalarrow.wav");
            //AudioManager.Singleton.LoadAudioSample("../BubblePopper/sound/icearrow.wav");
            //AudioManager.Singleton.LoadAudioSample("../BubblePopper/sound/firearrow.wav");
            //AudioManager.Singleton.LoadAudioSample("../BubblePopper/sound/pop.wav");
            //AudioManager.Singleton.LoadAudioSample("../BubblePopper/sound/pinbubble.wav");
            //AudioManager.Singleton.LoadAudioSample("../BubblePopper/sound/basket.wav");
            //AudioManager.Singleton.LoadAudioSample("../BubblePopper/sound/tarzanhit.wav");
            //AudioManager.Singleton.LoadAudioSample("../BubblePopper/sound/stunpause.wav");
            //AudioManager.Singleton.LoadAudioSample("../BubblePopper/sound/chargeup.wav");
            FileStream fileStream = (FileStream)null;
            StreamReader streamReader = (StreamReader)null;
            try
            {
                fileStream = File.OpenRead("../BubblePopper/data/HiScores/list.txt");
                streamReader = new StreamReader((Stream)fileStream);
                char[] charArray = " \\t\\n\\r".ToCharArray();
                while (streamReader.Peek() >= 0)
                {
                    string[] strArray = streamReader.ReadLine().Split(charArray);
                    //this.HiScoresList.Add((object)new HiScoresData()
                    //{
                    //    Name = strArray[0],
                    //    Scores = int.Parse(strArray[1])
                    //});
                }
            }
            catch (Exception ex)
            {
                //ProjectData.SetProjectError(ex);
                Console.WriteLine(ex.Message);
                //ProjectData.ClearProjectError();
            }
            finally
            {
                streamReader?.Close();
                fileStream?.Close();
            }
            float[] elements = this.WorldMatrix.Elements;
            elements[4] = 0.0f;
            elements[5] = 0.0f;
            //this.WorldMatrix = new Matrix(elements[0], elements[1], elements[2], elements[3], elements[4], elements[5]);
            this.m_WorldMatrix.Translate((float)Game.m_Resolution.Width * 0.5f, (float)Game.m_Resolution.Height * 0.5f);
            this.Level = 0;
            this.m_bIsBusy = false;
        }

        public override void Start_Game()
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

            base.Start_Game();
            AddClient("hello world");

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

        }
        public void StreamConnection()
        {
            //string executablePath = "C://Users/Xizuk/OneDrive/Documents/GitHub/TP_MP/TP_MP/Builds/Unity EXE/TP_MP.exe";

            //Process.Start(executablePath);

            //System.Threading.Thread.Sleep(15000);


        }
        public override void Update(double elapsed)
        {

         //m_bIsBusy = false;

         //m_bIsPaused = false;

         //m_bIsRunning = true;

         //m_bInSession = true;

        C_Value_A = 3f;

            base.Update(elapsed);

            player.Update(elapsed);

            A_Value_A = 1f;
            B_Value_A = 2f;
            //C_Value_A = 3f;


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

            writer.WriteLine("Fps = " + Fps); // Command to trigger the Jump method                                                         // Flush the writer and check for IOException (pipe broken)
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


            writer.WriteLine("m_bIsBusy = " + m_bIsBusy); // Command to trigger the Jump method                                                         // Flush the writer and check for IOException (pipe broken)
            try
            {
                writer.Flush();
            }
            catch (IOException ex)
            {
                Exit();
            }

            writer.WriteLine("m_bIsRunning = " + m_bIsRunning); // Command to trigger the Jump method                                                         // Flush the writer and check for IOException (pipe broken)
            try
            {
                writer.Flush();
            }
            catch (IOException ex)
            {
                Exit();
            }

            writer.WriteLine("m_bIsPaused = " + m_bIsPaused); // Command to trigger the Jump method                                                         // Flush the writer and check for IOException (pipe broken)
            try
            {
                writer.Flush();
            }
            catch (IOException ex)
            {
                Exit();
            }

            writer.WriteLine("m_bInSession = " + m_bInSession); // Command to trigger the Jump method                                                         // Flush the writer and check for IOException (pipe broken)
            try
            {
                writer.Flush();
            }
            catch (IOException ex)
            {
                Exit();
            }

            //writer.WriteLine("A_Value_A = " + A_Value_A); // Command to trigger the Jump method                                                               // Flush the writer and check for IOException (pipe broken)
            //try
            //{
            //    writer.Flush();
            //}
            //catch (IOException ex)
            //{
            //    Exit();
            //}
            //writer.WriteLine("B_Value_A = " + B_Value_A); // Command to trigger the Jump method                                                               // Flush the writer and check for IOException (pipe broken)
            //try
            //{
            //    writer.Flush();
            //}
            //catch (IOException ex)
            //{
            //    Exit();
            //}
            //writer.WriteLine("C_Value_A = " + C_Value_A); // Command to trigger the Jump method                                                               // Flush the writer and check for IOException (pipe broken)
            //try
            //{
            //    writer.Flush();
            //}
            //catch (IOException ex)
            //{
            //    Exit();
            //}
            writer.WriteLine("Player.EegChannel.A_Value = " + player.EegChannel.A_Value); // Command to trigger the Jump method                                                               // Flush the writer and check for IOException (pipe broken)
            try
            {
                writer.Flush();
            }
            catch (IOException ex)
            {
                Exit();
            }
            writer.WriteLine("Player.EegChannel.B_Value = " + player.EegChannel.B_Value); // Command to trigger the Jump method                                                               // Flush the writer and check for IOException (pipe broken)
            try
            {
                writer.Flush();
            }
            catch (IOException ex)
            {
                Exit();
            }
            writer.WriteLine("Player.EegChannel.C_Value = " + player.EegChannel.C_Value); // Command to trigger the Jump method                                                               // Flush the writer and check for IOException (pipe broken)
            try
            {
                writer.Flush();
            }
            catch (IOException ex)
            {
                Exit();
            }
            writer.WriteLine("Player.EegChannel.D_Value = " + player.EegChannel.D_Value); // Command to trigger the Jump method                                                               // Flush the writer and check for IOException (pipe broken)
            try
            {
                writer.Flush();
            }
            catch (IOException ex)
            {
                Exit();
            }
            writer.WriteLine("Player.EegChannel.R_Value = " + player.EegChannel.R_Value); // Command to trigger the Jump method                                                               // Flush the writer and check for IOException (pipe broken)
            try
            {
                writer.Flush();
            }
            catch (IOException ex)
            {
                Exit();
            }


            writer.WriteLine("Level = " + Level); // Command to trigger the Jump method
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




        public virtual bool AddClient(string name)
        {
            if (Game.m_Clients.Count >= this.m_nMaxClients || name == null)
                return false;
            TarzanBoy tarzanBoy = new TarzanBoy();
            tarzanBoy.Client_Name = name;
            Game.m_Clients.Add((object)tarzanBoy);
            Game.Add(tarzanBoy);
            this.ScoresHistoryList.Clear();
            this.m_bIsBusy = true;
            FileStream fileStream = (FileStream)null;
            StreamReader streamReader = (StreamReader)null;
            try
            {
                if (File.Exists("../BubblePopper/data/Clients/" + tarzanBoy.Client_Name + ".txt"))
                {
                    fileStream = File.OpenRead("../BubblePopper/data/Clients/" + tarzanBoy.Client_Name + ".txt");
                    streamReader = new StreamReader((Stream)fileStream);
                    char[] charArray = " \\t\\r\\n/".ToCharArray();
                    while (streamReader.Peek() >= 0)
                    {
                        string[] strArray = streamReader.ReadLine().Split(charArray);
                        //this.ScoresHistoryList.Add((object)new ScoresHistoryData()
                        //{
                        //    Scores = int.Parse(strArray[0]),
                        //    Level = int.Parse(strArray[1]),
                        //    Day = int.Parse(strArray[2]),
                        //    Month = int.Parse(strArray[3]),
                        //    Year = int.Parse(strArray[4])
                        //});
                    }
                }
            }
            catch (Exception ex)
            {
                //ProjectData.SetProjectError(ex);
                Console.WriteLine(ex.Message);
                //ProjectData.ClearProjectError();
            }
            finally
            {
                streamReader?.Close();
                fileStream?.Close();
            }
            this.m_bIsBusy = false;
            return true;
        }





        public virtual double R_Value_A
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

        public virtual double R_Value_B
        {
            set => this.R_Value_A = value;
        }


        public virtual double A_Value_A
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

        public virtual double A_Value_B
        {
            set => this.A_Value_A = value;
        }

        public virtual double B_Value_A
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

        public virtual double B_Value_B
        {
            set => this.B_Value_A = value;
        }

        public virtual double C_Value_A
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

        public virtual double C_Value_B
        {
            set => this.C_Value_A = value;
        }

        public virtual double D_Value_A
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

        public virtual double D_Value_B
        {
            set => this.D_Value_A = value;
        }

        public virtual double R_Threshold_A
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

        public virtual double R_Threshold_B
        {
            set => this.R_Threshold_A = value;
        }

        public virtual double A_Threshold_A
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

        public virtual double A_Threshold_B
        {
            set => this.A_Threshold_A = value;
        }

        public virtual double B_Threshold_A
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

        public virtual double B_Threshold_B
        {
            set => this.B_Threshold_A = value;
        }

        public virtual double C_Threshold_A
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

        public virtual double C_Threshold_B
        {
            set => this.C_Threshold_A = value;
        }

        public virtual double D_Threshold_A
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

        public virtual double D_Threshold_B
        {
            set => this.D_Threshold_A = value;
        }

        public virtual bool R_Trigger_A
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

        public virtual bool R_Trigger_B
        {
            set => this.R_Trigger_A = value;
        }

        public virtual bool A_Trigger_A
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

        public virtual bool A_Trigger_B
        {
            set => this.A_Trigger_A = value;
        }

        public virtual bool B_Trigger_A
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

        public virtual bool B_Trigger_B
        {
            set => this.B_Trigger_A = value;
        }

        public virtual bool C_Trigger_A
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

        public virtual bool C_Trigger_B
        {
            set => this.C_Trigger_A = value;
        }

        public virtual bool D_Trigger_A
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

        public virtual bool D_Trigger_B
        {
            set => this.D_Trigger_A = value;
        }

        public virtual bool R_Ignore_A
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

        public virtual bool R_Ignore_B
        {
            set => this.R_Ignore_A = value;
        }

        public virtual bool A_Ignore_A
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

        public virtual bool A_Ignore_B
        {
            set => this.A_Ignore_A = value;
        }

        public virtual bool B_Ignore_A
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

        public virtual bool B_Ignore_B
        {
            set => this.B_Ignore_A = value;
        }

        public virtual bool C_Ignore_A
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

        public virtual bool C_Ignore_B
        {
            set => this.C_Ignore_A = value;
        }

        public virtual bool D_Ignore_A
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

        public virtual bool D_Ignore_B
        {
            set => this.D_Ignore_A = value;
        }

        private void InitializeComponent()
        {
            ((Control)this).SuspendLayout();
            ((Control)this).Name = nameof(TestGame);
            ((Control)this).Size = new Size(50, 50);
            ((Control)this).ResumeLayout(false);
        }


        /*
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
        */
    }



    public class TarzanBoy : Player
    {
        //private Frame TarzanBoyFrame;
        //private Animation TarzanBoyAnimation;
        //private Vector2 TopLeft;
        //private Vector2 BottomLeft;
        //private Vector2 BottomRight;
        //private Vector2 TopRight;
        //private HitBox TarzanBoyHitBox;
        public const float TARZANBOY_NORMAL_SPEED = 150f;
        public const int TARZAN_NORMAL_IDLE = 0;
        public const int TARZAN_NORMAL_ARROW = 1;
        public const int TARZAN_NORMAL_STUNNED = 2;
        public const double FIRE_DELAY = 1.0;
        private double m_dFireElapsed;
        public const double DIZZY_DUR = 3.0;
        private double m_dDizzyElapsed;
        public const double STUN_DUR = 5.0;
        private double m_dStunElapsed;
        private bool m_bPause;
        //private AudioSource m_PauseSound;
        //private AudioSource m_ChargeupSound;

        //private HitBox getTarzanHitbox()
        //{
        //    //((Vector2)ref this.TopLeft).X = -33f;
        //    //((Vector2)ref this.TopLeft).Y = 40f;
        //    //((Vector2)ref this.BottomLeft).X = -33f;
        //    //((Vector2)ref this.BottomLeft).Y = -34f;
        //    //((Vector2)ref this.BottomRight).X = 34f;
        //    //((Vector2)ref this.BottomRight).Y = -34f;
        //    //((Vector2)ref this.TopRight).X = 34f;
        //    //((Vector2)ref this.TopRight).Y = 40f;
        //    //((HitBox)ref this.TarzanBoyHitBox).Set(this.TopLeft, this.BottomLeft, this.BottomRight, this.TopRight);
        //    return this.TarzanBoyHitBox;
        //}

        private void LoadTarzan()
        {
            //this.TarzanBoyHitBox = this.getTarzanHitbox();
            //this.TarzanBoyAnimation = new Animation();
            //this.TarzanBoyFrame = new Frame();
            //this.TarzanBoyFrame.Image = Game.LoadImage("../BubblePopper/images/normal.png");
            //this.TarzanBoyFrame.Add(this.TarzanBoyHitBox);
            //this.TarzanBoyAnimation.Add(this.TarzanBoyFrame);
            //this.TarzanBoyAnimation.Duration = 1.0;
            //this.TarzanBoyAnimation.Looping = true;
            //((Sprite)this).Add(this.TarzanBoyAnimation);
            //this.TarzanBoyAnimation = new Animation();
            //this.TarzanBoyFrame = new Frame();
            //this.TarzanBoyFrame.Image = Game.LoadImage("../BubblePopper/images/normal_pullback.png");
            //this.TarzanBoyFrame.Add(this.TarzanBoyHitBox);
            //this.TarzanBoyAnimation.Add(this.TarzanBoyFrame);
            //this.TarzanBoyFrame = new Frame();
            //this.TarzanBoyFrame.Image = Game.LoadImage("../BubblePopper/images/normal_start3.png");
            //this.TarzanBoyFrame.Add(this.TarzanBoyHitBox);
            //this.TarzanBoyAnimation.Add(this.TarzanBoyFrame);
            //this.TarzanBoyFrame = new Frame();
            //this.TarzanBoyFrame.Image = Game.LoadImage("../BubblePopper/images/normal_start2.png");
            //this.TarzanBoyFrame.Add(this.TarzanBoyHitBox);
            //this.TarzanBoyAnimation.Add(this.TarzanBoyFrame);
            //this.TarzanBoyFrame = new Frame();
            //this.TarzanBoyFrame.Image = Game.LoadImage("../BubblePopper/images/normal_start1.png");
            //this.TarzanBoyFrame.Add(this.TarzanBoyHitBox);
            //this.TarzanBoyAnimation.Add(this.TarzanBoyFrame);
            //((Sprite)this).Add(this.TarzanBoyAnimation);
            //this.TarzanBoyAnimation = new Animation();
            //this.TarzanBoyFrame = new Frame();
            //this.TarzanBoyFrame.Image = Game.LoadImage("../BubblePopper/images/stun1.png");
            //this.TarzanBoyFrame.Add(this.TarzanBoyHitBox);
            //this.TarzanBoyAnimation.Add(this.TarzanBoyFrame);
            //this.TarzanBoyFrame = new Frame();
            //this.TarzanBoyFrame.Image = Game.LoadImage("../BubblePopper/images/stun2.png");
            //this.TarzanBoyFrame.Add(this.TarzanBoyHitBox);
            //this.TarzanBoyAnimation.Add(this.TarzanBoyFrame);
            //this.TarzanBoyFrame = new Frame();
            //this.TarzanBoyFrame.Image = Game.LoadImage("../BubblePopper/images/stun1.png");
            //this.TarzanBoyFrame.Add(this.TarzanBoyHitBox);
            //this.TarzanBoyAnimation.Add(this.TarzanBoyFrame);
            //this.TarzanBoyFrame = new Frame();
            //this.TarzanBoyFrame.Image = Game.LoadImage("../BubblePopper/images/stun3.png");
            //this.TarzanBoyFrame.Add(this.TarzanBoyHitBox);
            //this.TarzanBoyAnimation.Add(this.TarzanBoyFrame);
            //this.TarzanBoyAnimation.Duration = 0.5;
            //this.TarzanBoyAnimation.Looping = true;
            //((Sprite)this).Add(this.TarzanBoyAnimation);
        }

        public void Reset()
        {
            //((Sprite)this).LocalMatrix.Reset();
            //((Sprite)this).LocalMatrix.Translate(260f, -45f);
            //((Sprite)this).m_bVisible = true;
            //((Sprite)this).m_bActive = true;
            //Vector2 vector2;
            //// ISSUE: explicit constructor call
            //((Vector2)ref vector2).\u002Ector(0.0f, 150f);
            //((Sprite)this).Velocity = vector2;
            //this.m_dFireElapsed = 1.0;
            //this.m_dDizzyElapsed = 3.0;
            //this.m_dStunElapsed = 5.0;
            //((Sprite)this).CurrentIndex = 0;
        }

        public TarzanBoy()
        {
            //this.TarzanBoyHitBox = new HitBox();
            this.m_bPause = false;
            this.LoadTarzan();
            this.Reset();
        }

        private void keyDownTriggered()
        {
          //  Vector2 velocity1;
          //  if ((double)((Sprite)this).LocalMatrix.OffsetX < 0.0)
          //  {
          //      Matrix localMatrix1 = ((Sprite)this).LocalMatrix;
          //      Vector2 velocity2 = ((Sprite)this).Velocity;
          //      double x = (double)((Vector2)ref velocity2).X;
          //      Vector2 velocity3 = ((Sprite)this).Velocity;
          //      double y = (double)((Vector2)ref velocity3).Y;
          //      localMatrix1.Translate((float)x, (float)y);
          //      ((Sprite)this).LocalMatrix.Scale(-1f, 1f);
          //      Matrix localMatrix2 = ((Sprite)this).LocalMatrix;
          //      velocity1 = ((Sprite)this).Velocity;
          //      double offsetX = -(double)((Vector2)ref velocity1).X;
          //      Vector2 velocity4 = ((Sprite)this).Velocity;
          //      double offsetY = -(double)((Vector2)ref velocity4).Y;
          //      localMatrix2.Translate((float)offsetX, (float)offsetY);
          //  }
          //// ISSUE: explicit constructor call
          //((Vector2)ref velocity1).\u002Ector(0.0f, 150f);
          //  ((Sprite)this).Velocity = velocity1;
        }

        private void keyDownPressed(double elapsed)
        {
            //Matrix localMatrix = ((Sprite)this).m_LocalMatrix;
            //Vector2 velocity1 = ((Sprite)this).Velocity;
            //double offsetX = (double)((Vector2)ref velocity1).X * elapsed;
            //Vector2 velocity2 = ((Sprite)this).Velocity;
            //double offsetY = (double)((Vector2)ref velocity2).Y * elapsed;
            //localMatrix.Translate((float)offsetX, (float)offsetY);
        }

        private void keyUpTriggered()
        {
          //  Vector2 velocity1;
          //  if ((double)((Sprite)this).LocalMatrix.OffsetX < 0.0)
          //  {
          //      Matrix localMatrix1 = ((Sprite)this).LocalMatrix;
          //      Vector2 velocity2 = ((Sprite)this).Velocity;
          //      double x = (double)((Vector2)ref velocity2).X;
          //      Vector2 velocity3 = ((Sprite)this).Velocity;
          //      double y = (double)((Vector2)ref velocity3).Y;
          //      localMatrix1.Translate((float)x, (float)y);
          //      ((Sprite)this).LocalMatrix.Scale(-1f, 1f);
          //      Matrix localMatrix2 = ((Sprite)this).LocalMatrix;
          //      velocity1 = ((Sprite)this).Velocity;
          //      double offsetX = -(double)((Vector2)ref velocity1).X;
          //      Vector2 velocity4 = ((Sprite)this).Velocity;
          //      double offsetY = -(double)((Vector2)ref velocity4).Y;
          //      localMatrix2.Translate((float)offsetX, (float)offsetY);
          //  }
          //// ISSUE: explicit constructor call
          //((Vector2)ref velocity1).\u002Ector(0.0f, -150f);
          //  ((Sprite)this).Velocity = velocity1;
        }

        private void keyUpPressed(double elapsed)
        {
            //Matrix localMatrix = ((Sprite)this).m_LocalMatrix;
            //Vector2 velocity1 = ((Sprite)this).Velocity;
            //double offsetX = (double)((Vector2)ref velocity1).X * elapsed;
            //Vector2 velocity2 = ((Sprite)this).Velocity;
            //double offsetY = (double)((Vector2)ref velocity2).Y * elapsed;
            //localMatrix.Translate((float)offsetX, (float)offsetY);
        }

        private void ActivateArrow()
        {
            //Arrow arrow1 = new Arrow(0);
            //arrow1.Owner = (Sprite)this;
            //arrow1.Visible = true;
            //arrow1.ZOrder = 1.5f;
            //((Sprite)this).CurrentIndex = 1;
            //arrow1.LocalMatrix.Translate(((Sprite)this).m_LocalMatrix.OffsetX - 25f, ((Sprite)this).m_LocalMatrix.OffsetY);
            //arrow1.LocalMatrix.Scale(1.25f, 1.25f);
            //Arrow arrow2 = arrow1;
            //Vector2 vector2_1;
            //// ISSUE: explicit constructor call
            //((Vector2)ref vector2_1).\u002Ector(-775f, 0.0f);
            //Vector2 vector2_2 = vector2_1;
            //arrow2.Velocity = vector2_2;
            //arrow1.CurrentAnimation.Play();
            //arrow1.playArrow_Sound(0);
            //Game.Add((Sprite)arrow1);
            //this.m_dFireElapsed = 1.0;
        }

        public virtual void Update(double elapsed)
        {
            {

                bool flag1 = this.EegChannel.A_Trigger | this.EegChannel.A_Ignore;
                bool flag2 = this.EegChannel.B_Trigger | this.EegChannel.B_Ignore;
                bool flag3 = this.EegChannel.C_Trigger | this.EegChannel.C_Ignore;
                if (this.m_dFireElapsed > 0.0)
                    this.m_dFireElapsed -= elapsed;
                if (!(flag1 & flag2 & flag3) || this.m_dFireElapsed > 0.0)
                    return;
                this.ActivateArrow();
            }
        }

       
    }
}
