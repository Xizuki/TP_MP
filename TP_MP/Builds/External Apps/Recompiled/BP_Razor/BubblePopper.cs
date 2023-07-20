// Decompiled with JetBrains decompiler
// Type: BP_Razor.BubblePopper
// Assembly: BP_Razor, Version=1.0.2635.17043, Culture=neutral, PublicKeyToken=null
// MVID: 44F336AB-547C-4D12-89AB-EC84272374D7
// Assembly location: C:\Program Files (x86)\Spectrum Learning\BT v11a\dll\BP_Razor.dll

using Microsoft.VisualBasic.CompilerServices;
using Nyp.Razor;
using Nyp.Razor.Spectrum;
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace BP_Razor
{
  public class BubblePopper : Game
  {
    public static Background BG;
    public static Monkey Monkey;
    public static Bubble Bubble;
    public static Basket Basket;
    public static Arrow Arrow;
    private Frame GenericFrame;
    private Animation GenericAnimation;
    private Sprite GenericSprite;
    private Sprite m_Background;
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
    private AudioSource m_BackgroundMusic;
    private AudioSource m_Charging;
    public int HiScores;
    public ArrayList ScoresList;
    public ArrayList ScoresHistoryList;
    public ArrayList HiScoresList;
    public const string HISCORES_DATA_PATH = "../BubblePopper/data/HiScores/list.txt";
    public const string CLIENT_DATA_PATH = "../BubblePopper/data/Clients/";




        TextBox textBox;
        TextBox textBox2;
        TextBox textBox3;
        public void DebugAudio()
        {
            Console.Beep();
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
        }
        public BubblePopper()
    {

           
      ((UserControl) this).Load += new EventHandler(this.BubblePopper_Load);
      this.m_Monkey = new ArrayList();
      this.m_genBubble = true;
      this.m_hardBubbleDur = 10.0;
      this.m_negArrowDur = 6.0;
      this.m_pinBubbleDur = 12.0;
      this.ScoresList = new ArrayList();
      this.ScoresHistoryList = new ArrayList();
      this.HiScoresList = new ArrayList();

            DebugForm();
        }

    public override void Initialize()
    {
      this.FrameRate = 30.0;
      Game.MinScores = 0;
      this.m_bIsBusy = true;
      ((ContainerControl) this).ParentForm.Text = "Bubble Popper";
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
      AudioManager.Singleton.LoadAudioSample("../BubblePopper/sound/background.wav");
      AudioManager.Singleton.LoadAudioSample("../BubblePopper/sound/normalarrow.wav");
      AudioManager.Singleton.LoadAudioSample("../BubblePopper/sound/icearrow.wav");
      AudioManager.Singleton.LoadAudioSample("../BubblePopper/sound/firearrow.wav");
      AudioManager.Singleton.LoadAudioSample("../BubblePopper/sound/pop.wav");
      AudioManager.Singleton.LoadAudioSample("../BubblePopper/sound/pinbubble.wav");
      AudioManager.Singleton.LoadAudioSample("../BubblePopper/sound/basket.wav");
      AudioManager.Singleton.LoadAudioSample("../BubblePopper/sound/tarzanhit.wav");
      AudioManager.Singleton.LoadAudioSample("../BubblePopper/sound/stunpause.wav");
      AudioManager.Singleton.LoadAudioSample("../BubblePopper/sound/chargeup.wav");
      FileStream fileStream = (FileStream) null;
      StreamReader streamReader = (StreamReader) null;
      try
      {
        fileStream = File.OpenRead("../BubblePopper/data/HiScores/list.txt");
        streamReader = new StreamReader((Stream) fileStream);
        char[] charArray = " \\t\\n\\r".ToCharArray();
        while (streamReader.Peek() >= 0)
        {
          string[] strArray = streamReader.ReadLine().Split(charArray);
          this.HiScoresList.Add((object) new HiScoresData()
          {
            Name = strArray[0],
            Scores = int.Parse(strArray[1])
          });
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Console.WriteLine(ex.Message);
        ProjectData.ClearProjectError();
      }
      finally
      {
        streamReader?.Close();
        fileStream?.Close();
      }
      float[] elements = this.WorldMatrix.Elements;
      elements[4] = 0.0f;
      elements[5] = 0.0f;
      this.WorldMatrix = new Matrix(elements[0], elements[1], elements[2], elements[3], elements[4], elements[5]);
      this.m_WorldMatrix.Translate((float) Game.m_Resolution.Width * 0.5f, (float) Game.m_Resolution.Height * 0.5f);
      this.Level = 0;
      this.m_bIsBusy = false;
    }

    private void loadMusic()
    {
      this.m_BackgroundMusic = AudioManager.Singleton.LoadAudioSource("../BubblePopper/sound/background.wav");
      this.m_BackgroundMusic.Looping = true;
      this.m_BackgroundMusic.Play();
    }

    private void loadSplashPage()
    {
      this.GenericFrame = new Frame();
      this.GenericFrame.Image = Game.LoadImage("../BubblePopper/images/splash.png");
      this.GenericAnimation = new Animation();
      this.GenericAnimation.Add(this.GenericFrame);
      this.GenericSprite = new Sprite();
      this.GenericSprite.Add(this.GenericAnimation);
      this.GenericSprite.ZOrder = -10f;
      Game.Add(this.GenericSprite);
      this.loadMusic();
    }

    public void loadHighScorePage()
    {
      this.GenericFrame = new Frame();
      this.GenericFrame.Image = Game.LoadImage("../BubblePopper/images/highscore.png");
      this.GenericAnimation = new Animation();
      this.GenericAnimation.Add(this.GenericFrame);
      this.GenericSprite = new Sprite();
      this.GenericSprite.Add(this.GenericAnimation);
      this.GenericSprite.ZOrder = 10f;
      Game.Add(this.GenericSprite);
      float num = 0.0f;
      try
      {
        foreach (HiScoresData hiScores in this.HiScoresList)
        {
          float y = (float) (49.5 * (double) num - 175.0);
          Text2D text2D1 = new Text2D("Courier New", 24f, FontStyle.Bold);
          text2D1.Text = hiScores.Name;
          text2D1.Color = Color.AntiqueWhite;
          Text2D text2D2 = text2D1;
          PointF pointF1 = new PointF(-205f, y);
          PointF pointF2 = pointF1;
          text2D2.Position = pointF2;
          Game.Add(text2D1);
          Text2D text2D3 = new Text2D("Courier New", 24f, FontStyle.Bold);
          text2D3.Color = Color.AntiqueWhite;
          text2D3.Text = hiScores.Scores.ToString("D5");
          Text2D text2D4 = text2D3;
          pointF1 = new PointF(245f, y);
          PointF pointF3 = pointF1;
          text2D4.Position = pointF3;
          Game.Add(text2D3);
          num += 0.9f;
        }
      }
      finally
      {
        IEnumerator enumerator = null;
        if (enumerator is IDisposable)
          ((IDisposable) enumerator).Dispose();
      }
      this.loadMusic();
    }

    public void loadHistoryScorePage()
    {
      this.GenericFrame = new Frame();
      this.GenericFrame.Image = Game.LoadImage("../BubblePopper/images/scorehistory.png");
      this.GenericAnimation = new Animation();
      this.GenericAnimation.Add(this.GenericFrame);
      this.GenericSprite = new Sprite();
      this.GenericSprite.Add(this.GenericAnimation);
      this.GenericSprite.ZOrder = 10f;
      Game.Add(this.GenericSprite);
      Text2D text2D1 = new Text2D("Courier New", 23f, FontStyle.Bold);
      text2D1.Text = BubblePopper.Client.Client_Name;
      text2D1.Color = Color.Snow;
      Text2D text2D2 = text2D1;
      PointF pointF1 = new PointF(-190f, -215.5f);
      PointF pointF2 = pointF1;
      text2D2.Position = pointF2;
      Game.Add(text2D1);
      float num = 0.0f;
      try
      {
        foreach (ScoresHistoryData scoresHistory in this.ScoresHistoryList)
        {
          float y = (float) (44.5 * (double) num - 144.0);
          Text2D text2D3 = new Text2D("Courier New", 20f, FontStyle.Bold);
          text2D3.Text = scoresHistory.Scores.ToString("D5");
          text2D3.Color = Color.AntiqueWhite;
          Text2D text2D4 = text2D3;
          pointF1 = new PointF(-220f, y);
          PointF pointF3 = pointF1;
          text2D4.Position = pointF3;
          Game.Add(text2D3);
          Text2D text2D5 = new Text2D("Courier New", 20f, FontStyle.Bold);
          text2D5.Text = scoresHistory.Level.ToString("D2");
          text2D5.Color = Color.AntiqueWhite;
          Text2D text2D6 = text2D5;
          pointF1 = new PointF(40f, y);
          PointF pointF4 = pointF1;
          text2D6.Position = pointF4;
          Game.Add(text2D5);
          Text2D text2D7 = new Text2D("Courier New", 12f, FontStyle.Bold);
          text2D7.Text = scoresHistory.Day.ToString("D2") + "/" + scoresHistory.Month.ToString("D2") + "/" + scoresHistory.Year.ToString("D4");
          text2D7.Color = Color.AntiqueWhite;
          Text2D text2D8 = text2D7;
          pointF1 = new PointF(175f, y + 5f);
          PointF pointF5 = pointF1;
          text2D8.Position = pointF5;
          Game.Add(text2D7);
          num += 0.9f;
        }
      }
      finally
      {
        IEnumerator enumerator = null;
        if (enumerator is IDisposable)
          ((IDisposable) enumerator).Dispose();
      }
      this.loadMusic();
    }

    public void loadIntervalPage()
    {
      this.GenericFrame = new Frame();
      this.GenericFrame.Image = Game.LoadImage("../BubblePopper/images/progresschart.png");
      this.GenericAnimation = new Animation();
      this.GenericAnimation.Add(this.GenericFrame);
      this.GenericSprite = new Sprite();
      this.GenericSprite.Add(this.GenericAnimation);
      this.GenericSprite.ZOrder = -10f;
      Game.Add(this.GenericSprite);
      if (this.m_nSavedLevel != -1)
      {
        this.ScoresList.Add((object) Game.m_nScores);
        if (Game.m_nScores > this.HiScores)
          this.HiScores = Game.m_nScores;
      }
      Bitmap bitmap = Game.LoadImage("../BubblePopper/images/fulllifebar.png");
      SizeF sizeF = new Size();
      sizeF.Width = (float) bitmap.Width;
      sizeF.Height = (float) bitmap.Height;
      float num1 = sizeF.Height * 0.5f;
      float offsetX = -335f;
      try
      {
        foreach (object scores in this.ScoresList)
        {
          int num2 = IntegerType.FromObject(scores);
          if (num2 > 0 & this.HiScores > 0)
          {
            Sprite sprite = new Sprite();
            Animation animation = new Animation();
            animation.Add(new Frame() { Image = bitmap });
            sprite.Add(animation);
            float scaleY = (float) num2 / (float) this.HiScores;
            float offsetY = num1 * (1f - scaleY);
            sprite.LocalMatrix.Translate(offsetX, offsetY);
            sprite.LocalMatrix.Scale(1f, scaleY);
            Game.Add(sprite);
          }
          Game.Add(new Text2D("Verdana", 12f, FontStyle.Bold)
          {
            Color = Color.Chocolate,
            Text = num2.ToString("D4"),
            Position = new PointF(offsetX - sizeF.Width * 0.5f, num1 + 5f)
          });
          offsetX += 80f;
        }
      }
      finally
      {
        IEnumerator enumerator = null;
        if (enumerator is IDisposable)
          ((IDisposable) enumerator).Dispose();
      }
      this.loadMusic();
    }

    private void GenerateMonkey(int whichBG)
    {
      this.m_Monkey.Clear();
      try
      {
        foreach (Sprite sprite in this.m_Monkey)
          Game.Remove(sprite);
      }
      finally
      {
        IEnumerator enumerator = null;
        if (enumerator is IDisposable)
          ((IDisposable) enumerator).Dispose();
      }
      BubblePopper.Monkey = new Monkey(whichBG);
      BubblePopper.Monkey.MonkeyID = 0;
      Game.Add((Sprite) BubblePopper.Monkey);
      this.m_Monkey.Add((object) BubblePopper.Monkey);
      ((Sprite) BubblePopper.Monkey).LocalMatrix.Translate(-275f, -10f);
      BubblePopper.Monkey = new Monkey(whichBG);
      BubblePopper.Monkey.MonkeyID = 1;
      Game.Add((Sprite) BubblePopper.Monkey);
      this.m_Monkey.Add((object) BubblePopper.Monkey);
      ((Sprite) BubblePopper.Monkey).LocalMatrix.Translate(-185f, -80f);
      BubblePopper.Monkey = new Monkey(whichBG);
      BubblePopper.Monkey.MonkeyID = 2;
      Game.Add((Sprite) BubblePopper.Monkey);
      this.m_Monkey.Add((object) BubblePopper.Monkey);
      ((Sprite) BubblePopper.Monkey).LocalMatrix.Translate(-275f, 148f);
      BubblePopper.Monkey = new Monkey(whichBG);
      BubblePopper.Monkey.MonkeyID = 3;
      Game.Add((Sprite) BubblePopper.Monkey);
      this.m_Monkey.Add((object) BubblePopper.Monkey);
      ((Sprite) BubblePopper.Monkey).LocalMatrix.Translate(-185f, 70f);
      BubblePopper.Monkey = new Monkey(whichBG);
      BubblePopper.Monkey.MonkeyID = 4;
      Game.Add((Sprite) BubblePopper.Monkey);
      this.m_Monkey.Add((object) BubblePopper.Monkey);
      ((Sprite) BubblePopper.Monkey).LocalMatrix.Translate(-185f, 220f);
    }

    public static bool AddChargeBar()
    {
      if (BubblePopper.m_LifeBars.Count >= 10)
        return false;
      Sprite sprite = new Sprite();
      Animation animation = new Animation();
      animation.Add(new Frame()
      {
        Image = Game.LoadImage("../BubblePopper/images/lifebar_head.png")
      });
      sprite.Add(animation);
      sprite.ZOrder = 10f;
      sprite.LocalMatrix.Translate(353f, (float) (223.0 - 39.0 * (double) BubblePopper.m_LifeBars.Count));
      BubblePopper.m_LifeBars.Push((object) sprite);
      Game.Add(sprite);
      return true;
    }

    public void loadBackground()
    {
      int whichBG;
      if (this.Level == 1 | this.Level == 2)
        whichBG = 0;
      else if (this.Level == 3 | this.Level == 4)
      {
        whichBG = 1;
      }
      else
      {
        if (this.Level != 5)
          return;
        whichBG = 2;
      }
      BubblePopper.BG = new Background(whichBG);
      BubblePopper.BG.Visible = true;
      Game.Add((Sprite) BubblePopper.BG);
      this.m_Background = (Sprite) BubblePopper.BG;
      this.GenerateMonkey(whichBG);
      BubblePopper.Basket = new Basket();
      Game.Add((Sprite) BubblePopper.Basket);
      BubblePopper.Basket.LocalMatrix.Translate(-220f, 260f);
      do
        ;
      while (BubblePopper.AddChargeBar());
      Text2D text2D1 = new Text2D("Courier New", 20f, FontStyle.Bold);
      Text2D text2D2 = text2D1;
      int num = this.Level;
      string str1 = num.ToString("D2");
      text2D2.Text = str1;
      text2D1.Color = Color.Black;
      Text2D text2D3 = text2D1;
      PointF pointF1 = new PointF(-285f, -240f);
      PointF pointF2 = pointF1;
      text2D3.Position = pointF2;
      Game.Add(text2D1);
      Text2D text2D4 = new Text2D("Courier New", 20f, FontStyle.Bold);
      Text2D text2D5 = text2D4;
      num = checked (this.ScoresList.Count + 1);
      string str2 = num.ToString("D2");
      text2D5.Text = str2;
      text2D4.Color = Color.Black;
      Text2D text2D6 = text2D4;
      pointF1 = new PointF(-215f, -240f);
      PointF pointF3 = pointF1;
      text2D6.Position = pointF3;
      Game.Add(text2D4);
    }

    public override void LoadLevel()
    {
      BubblePopper.Client.Reset();
      switch (this.Level)
      {
        case -3:
          this.loadHighScorePage();
          break;
        case -2:
          this.loadHistoryScorePage();
          break;
        case -1:
          this.loadIntervalPage();
          break;
        case 0:
          this.loadSplashPage();
          break;
        case 1:
        case 2:
        case 3:
        case 4:
        case 5:
          this.loadBackground();
          Game.Scores = 0;
          Game.Add((Text2D) new ScoreText());
          this.m_genBubble = true;
          break;
      }
    }

    public override void UnloadLevel()
    {
      base.UnloadLevel();
      BubblePopper.m_LifeBars.Clear();
      this.m_Monkey.Clear();
      if (this.m_BackgroundMusic == null)
        return;
      this.m_BackgroundMusic.Stop();
      this.m_BackgroundMusic = (AudioSource) null;
    }

    private int GenerateHardBubble()
    {
      int hardBubble=0;
      if (BubblePopper.Client.EegChannel.B_Trigger)
      {
        if (BubblePopper.Client.EegChannel.B_Value - BubblePopper.Client.EegChannel.B_Threshold > 20.0 & this.m_hardBubbleDur <= 0.0)
        {
          hardBubble = 2;
          this.m_hardBubbleDur = 10.0;
        }
        else if (BubblePopper.Client.EegChannel.B_Value - BubblePopper.Client.EegChannel.B_Threshold > 10.0 & BubblePopper.Client.EegChannel.B_Value - BubblePopper.Client.EegChannel.B_Threshold <= 20.0 & this.m_hardBubbleDur <= 8.0)
        {
          hardBubble = 2;
          this.m_hardBubbleDur = 10.0;
        }
        else if (BubblePopper.Client.EegChannel.B_Value - BubblePopper.Client.EegChannel.B_Threshold <= 10.0 & this.m_hardBubbleDur <= 6.0)
        {
          hardBubble = 2;
          this.m_hardBubbleDur = 10.0;
        }
        else
          hardBubble = checked ((int) Math.Round((double) Game.Random.Next(0, 2)));
      }
      else if (!BubblePopper.Client.EegChannel.B_Trigger)
      {
        if (this.m_hardBubbleDur <= 6.0)
        {
          hardBubble = 2;
          this.m_hardBubbleDur = 10.0;
        }
        else
          hardBubble = checked ((int) Math.Round((double) Game.Random.Next(0, 2)));
      }
      return hardBubble;
    }

    public bool GenerateNegArrow()
    {
      bool negArrow = false;
      if (this.Level == 3 | this.Level == 4 | this.Level == 5)
      {
        if (BubblePopper.Client.EegChannel.A_Trigger)
        {
          if (BubblePopper.Client.EegChannel.A_Threshold - BubblePopper.Client.EegChannel.A_Value > 20.0 & this.m_negArrowDur <= 0.0)
          {
            negArrow = true;
            this.m_negArrowDur = 6.0;
          }
          else if (BubblePopper.Client.EegChannel.A_Threshold - BubblePopper.Client.EegChannel.A_Value > 10.0 & BubblePopper.Client.EegChannel.A_Threshold - BubblePopper.Client.EegChannel.A_Value <= 20.0 & this.m_negArrowDur <= 4.0)
          {
            negArrow = true;
            this.m_negArrowDur = 6.0;
          }
          else if (BubblePopper.Client.EegChannel.A_Threshold - BubblePopper.Client.EegChannel.A_Value <= 10.0 & this.m_negArrowDur <= 2.0)
          {
            negArrow = true;
            this.m_negArrowDur = 6.0;
          }
        }
        else if (!BubblePopper.Client.EegChannel.A_Trigger && this.m_negArrowDur <= 2.0)
        {
          negArrow = true;
          this.m_negArrowDur = 6.0;
        }
      }
      return negArrow;
    }

    private int GeneratePinBubble()
    {
      int pinBubble=0;
      if (BubblePopper.Client.EegChannel.C_Trigger)
      {
        if (BubblePopper.Client.EegChannel.C_Threshold - BubblePopper.Client.EegChannel.C_Value > 20.0 & this.m_pinBubbleDur <= 0.0)
        {
          pinBubble = 3;
          this.m_pinBubbleDur = 12.0;
        }
        else if (BubblePopper.Client.EegChannel.C_Threshold - BubblePopper.Client.EegChannel.C_Value > 10.0 & BubblePopper.Client.EegChannel.C_Threshold - BubblePopper.Client.EegChannel.C_Value <= 20.0 & this.m_pinBubbleDur <= 8.0)
        {
          pinBubble = 3;
          this.m_pinBubbleDur = 12.0;
        }
        else if (BubblePopper.Client.EegChannel.C_Threshold - BubblePopper.Client.EegChannel.C_Value <= 10.0 & this.m_pinBubbleDur <= 4.0)
        {
          pinBubble = 3;
          this.m_pinBubbleDur = 12.0;
        }
        else
          pinBubble = checked ((int) Math.Round((double) Game.Random.Next(0, 2)));
      }
      else if (!BubblePopper.Client.EegChannel.C_Trigger)
      {
        if (this.m_pinBubbleDur <= 2.0)
        {
          pinBubble = 3;
          this.m_pinBubbleDur = 12.0;
        }
        else
          pinBubble = checked ((int) Math.Round((double) Game.Random.Next(0, 2)));
      }
      return pinBubble;
    }

    public void GenerateBubble(int column)
    {
      bool flag = false;
      int bubbleType = 0;
      switch (this.Level)
      {
        case 1:
          bubbleType = checked ((int) Math.Round((double) Game.Random.Next(0, 2)));
          break;
        case 2:
          bubbleType = this.GenerateHardBubble();
          break;
        case 3:
          bubbleType = this.GenerateHardBubble();
          if (bubbleType == 0 | bubbleType == 1)
          {
            flag = this.GenerateNegArrow();
            break;
          }
          break;
        case 4:
          bubbleType = this.GenerateHardBubble();
          flag = this.GenerateNegArrow();
          break;
        case 5:
          bubbleType = this.GeneratePinBubble();
          if (bubbleType != 3)
          {
            bubbleType = this.GenerateHardBubble();
            flag = this.GenerateNegArrow();
            break;
          }
          break;
      }
      BubblePopper bp = this;
      BubblePopper.Bubble = new Bubble(ref bp, bubbleType, column);
      BubblePopper.Bubble.spawnArrow = flag;
      if (column == ((Control) this).Left)
        BubblePopper.Bubble.LocalMatrix.Translate(-275f, -200f);
      else
        BubblePopper.Bubble.LocalMatrix.Translate(-185f, -200f);
      Game.Add((Sprite) BubblePopper.Bubble);
    }

    public void GenerateArrow(int arrowType, Matrix matrix)
    {
      BubblePopper.Arrow = new Arrow(arrowType);
      BubblePopper.Arrow.Visible = true;
      BubblePopper.Arrow.ZOrder = 1.5f;
      BubblePopper.Arrow.CurrentIndex = 0;
      BubblePopper.Arrow.Scale(2f, 2f);
      BubblePopper.Arrow.Translate(matrix.OffsetX, matrix.OffsetY);
      Game.Add((Sprite) BubblePopper.Arrow);
      Arrow arrow = BubblePopper.Arrow;
      Vector2 vector2_1= new Vector2(700f, 0.0f);
      Vector2 vector2_2 = vector2_1;
      arrow.Velocity = vector2_2;
      BubblePopper.Arrow.CurrentAnimation.Play();
      BubblePopper.Arrow.playArrow_Sound(arrowType);
    }

    public void PopAllBubbles()
    {
      double num = 0.0;
      try
      {
        foreach (Sprite sprite in Game.m_Sprites)
        {
          if (sprite is Bubble)
          {
            ((Bubble) sprite).toPop = true;
            num += (double) ((Bubble) sprite).Reward;
          }
        }
      }
      finally
      {
        IEnumerator enumerator = null;
        if (enumerator is IDisposable)
          ((IDisposable) enumerator).Dispose();
      }
      Game.Scores = checked ((int) Math.Round(unchecked ((double) Game.Scores + num)));
      this.m_genBubble = true;
    }

    private void CheckBackgroundCollision()
    {
      if (this.m_Background == null)
        return;
      HitBox[] hitBoxes1 = this.m_Background.HitBoxes;
      try
      {
        foreach (Sprite sprite in Game.m_Sprites)
        {
          if (sprite != this.m_Background & !(sprite is Arrow) & !(sprite is Bubble))
          {
            HitBox[] hitBoxes2 = sprite.HitBoxes;
            if (hitBoxes2 != null)
            {
              if ((hitBoxes1[0]).IntersectWith(hitBoxes2[0]))
                sprite.LocalMatrix.Translate((hitBoxes1[0].Center).X + (hitBoxes1[0].Extents).X + (hitBoxes2[0].Extents).X - (hitBoxes2[0].Center).X, 0.0f, MatrixOrder.Append);
              if ((hitBoxes1[1]).IntersectWith(hitBoxes2[0]))
                sprite.LocalMatrix.Translate((hitBoxes1[1].Center).X - (hitBoxes1[1].Extents).X - (hitBoxes2[0].Extents).X - (hitBoxes2[0].Center).X, 0.0f, MatrixOrder.Append);
              if ((hitBoxes1[2]).IntersectWith(hitBoxes2[0]))
                sprite.LocalMatrix.Translate(0.0f, (hitBoxes1[2].Center).Y + (hitBoxes1[2].Extents).Y + (hitBoxes2[0].Extents).Y - (hitBoxes2[0].Center).Y, MatrixOrder.Append);
              if ((hitBoxes1[3]).IntersectWith(hitBoxes2[0]))
                sprite.LocalMatrix.Translate(0.0f, (hitBoxes1[3].Center).Y - (hitBoxes1[3].Extents).Y - (hitBoxes2[0].Extents).Y - (hitBoxes2[0].Center).Y, MatrixOrder.Append);
            }
          }
        }
      }
      finally
      {
        IEnumerator enumerator = null;
        if (enumerator is IDisposable)
          ((IDisposable) enumerator).Dispose();
      }
    }

    public override void Update(double elapsed)
    {
            //DebugAudio();
            //if (((Player)m_Clients[0]).EegChannel.A_Value > 0 )
            //textBox.Text = "client value a = " + ((Player)m_Clients[0]).EegChannel.A_Value;
            //textBox.Text = "(m_Clients[0] is Player) " + (m_Clients[0] is Player);

            //Player player = (Player)m_Clients[0];
            //player.EegChannel = new EegChannel();
            //player.EegChannel.A_Value = 12345f;
            textBox.Text = "Client.EegChannel.A_Value =  " + Client.EegChannel.A_Value;
            textBox2.Text = "Client.EegChannel.B_Value =  " + Client.EegChannel.B_Value;
            textBox3.Text = "Client.EegChannel.C_Value =  " + Client.EegChannel.C_Value;



            if (!this.m_bInSession | this.m_bIsPaused | !this.m_bIsRunning)
        return;
      this.m_hardBubbleDur -= elapsed;
      this.m_pinBubbleDur -= elapsed;
      this.m_negArrowDur -= elapsed;
      this.CheckBackgroundCollision();
      if (this.m_genBubble)
      {
        this.GenerateBubble(0);
        this.GenerateBubble(1);
        this.m_genBubble = false;
      }
      if (BubblePopper.m_LifeBars.Count == 0)
      {
        BubblePopper.Client.Pause();
      }
      else
      {
        if (BubblePopper.m_LifeBars.Count < 10)
          return;
        BubblePopper.Client.Unpause();
      }
    }

    public static bool RemoveChargeBar()
    {
      if (BubblePopper.m_LifeBars.Count <= 0)
        return false;
      LateBinding.LateCall((object) null, typeof (Game), "Remove", new object[1]
      {
        RuntimeHelpers.GetObjectValue(BubblePopper.m_LifeBars.Pop())
      }, (string[]) null, (bool[]) null);
      return true;
    }

    public override void Pause_Game()
    {
      if (this.m_bIsPaused | this.Level <= 0)
        return;
      try
      {
        foreach (Sprite addedSprite in Game.m_AddedSprites)
          addedSprite.Active = false;
      }
      finally
      {
        IEnumerator enumerator = null;
        if (enumerator is IDisposable)
          ((IDisposable) enumerator).Dispose();
      }
      try
      {
        foreach (Sprite sprite in Game.m_Sprites)
          sprite.Active = false;
      }
      finally
      {
        IEnumerator enumerator = null;
        if (enumerator is IDisposable)
          ((IDisposable) enumerator).Dispose();
      }
      Frame frame = new Frame();
      Animation animation = new Animation();
      Sprite sprite1 = new Sprite();
      frame.Image = Game.LoadImage("../BubblePopper/images/pause.png");
      animation.Add(frame);
      sprite1.Add(animation);
      sprite1.ZOrder = 10f;
      Game.Add(sprite1);
      this.m_bIsPaused = true;
      base.Pause_Game();
    }

    public override void Stop_Game()
    {
      base.Stop_Game();
      this.m_bIsBusy = true;
      ScoresHistoryData scoresHistoryData = new ScoresHistoryData();
      try
      {
        foreach (object scores in this.ScoresList)
        {
          int num = IntegerType.FromObject(scores);
          checked { scoresHistoryData.Scores += num; }
        }
      }
      finally
      {
        IEnumerator enumerator = null;
        if (enumerator is IDisposable)
          ((IDisposable) enumerator).Dispose();
      }
      scoresHistoryData.Level = this.Level > 0 ? this.Level : this.m_nSavedLevel;
      DateTime now = DateTime.Now;
      scoresHistoryData.Day = now.Day;
      scoresHistoryData.Month = now.Month;
      scoresHistoryData.Year = now.Year;
      this.ScoresHistoryList.Add((object) scoresHistoryData);
      this.ScoresHistoryList.Sort();
      while (this.ScoresHistoryList.Count > 10)
        this.ScoresHistoryList.RemoveAt(10);
      this.HiScoresList.Add((object) new HiScoresData()
      {
        Scores = scoresHistoryData.Scores,
        Name = StringType.FromObject(BubblePopper.Client.Client_Name.Clone())
      });
      this.HiScoresList.Sort();
      while (this.HiScoresList.Count > 10)
        this.HiScoresList.RemoveAt(10);
      this.HiScores = 0;
      this.ScoresList.Clear();
      ((Sprite) BubblePopper.Client).CurrentIndex = 0;
      this.m_bIsBusy = false;
      this.m_nSavedLevel = -1;
    }

    public override bool AddClient(string name)
    {
      if (Game.m_Clients.Count >= this.m_nMaxClients || name == null)
        return false;
      TarzanBoy tarzanBoy = new TarzanBoy();
      tarzanBoy.Client_Name = StringType.FromObject(name.Clone());
      Game.m_Clients.Add((object) tarzanBoy);
      Game.Add((Sprite) tarzanBoy);
      this.ScoresHistoryList.Clear();
      this.m_bIsBusy = true;
      FileStream fileStream = (FileStream) null;
      StreamReader streamReader = (StreamReader) null;
      try
      {
        if (File.Exists("../BubblePopper/data/Clients/" + tarzanBoy.Client_Name + ".txt"))
        {
          fileStream = File.OpenRead("../BubblePopper/data/Clients/" + tarzanBoy.Client_Name + ".txt");
          streamReader = new StreamReader((Stream) fileStream);
          char[] charArray = " \\t\\r\\n/".ToCharArray();
          while (streamReader.Peek() >= 0)
          {
            string[] strArray = streamReader.ReadLine().Split(charArray);
            this.ScoresHistoryList.Add((object) new ScoresHistoryData()
            {
              Scores = int.Parse(strArray[0]),
              Level = int.Parse(strArray[1]),
              Day = int.Parse(strArray[2]),
              Month = int.Parse(strArray[3]),
              Year = int.Parse(strArray[4])
            });
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Console.WriteLine(ex.Message);
        ProjectData.ClearProjectError();
      }
      finally
      {
        streamReader?.Close();
        fileStream?.Close();
      }
      this.m_bIsBusy = false;
      return true;
    }

    public static TarzanBoy Client => Game.m_Clients.Count > 0 ? (TarzanBoy) Game.m_Clients[0] : (TarzanBoy) null;

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
          ((Player) enumerator.Current).EegChannel.R_Value = value;
        }
        finally
        {
          if (enumerator is IDisposable)
            ((IDisposable) enumerator).Dispose();
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
          ((Player) enumerator.Current).EegChannel.A_Value = value;
        }
        finally
        {
          if (enumerator is IDisposable)
            ((IDisposable) enumerator).Dispose();
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
          ((Player) enumerator.Current).EegChannel.B_Value = value;
        }
        finally
        {
          if (enumerator is IDisposable)
            ((IDisposable) enumerator).Dispose();
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
          ((Player) enumerator.Current).EegChannel.C_Value = value;
        }
        finally
        {
          if (enumerator is IDisposable)
            ((IDisposable) enumerator).Dispose();
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
          ((Player) enumerator.Current).EegChannel.D_Value = value;
        }
        finally
        {
          if (enumerator is IDisposable)
            ((IDisposable) enumerator).Dispose();
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
          ((Player) enumerator.Current).EegChannel.R_Threshold = value;
        }
        finally
        {
          if (enumerator is IDisposable)
            ((IDisposable) enumerator).Dispose();
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
          ((Player) enumerator.Current).EegChannel.A_Threshold = value;
        }
        finally
        {
          if (enumerator is IDisposable)
            ((IDisposable) enumerator).Dispose();
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
          ((Player) enumerator.Current).EegChannel.B_Threshold = value;
        }
        finally
        {
          if (enumerator is IDisposable)
            ((IDisposable) enumerator).Dispose();
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
          ((Player) enumerator.Current).EegChannel.C_Threshold = value;
        }
        finally
        {
          if (enumerator is IDisposable)
            ((IDisposable) enumerator).Dispose();
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
          ((Player) enumerator.Current).EegChannel.D_Threshold = value;
        }
        finally
        {
          if (enumerator is IDisposable)
            ((IDisposable) enumerator).Dispose();
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
          ((Player) enumerator.Current).EegChannel.R_Trigger = value;
        }
        finally
        {
          if (enumerator is IDisposable)
            ((IDisposable) enumerator).Dispose();
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
          ((Player) enumerator.Current).EegChannel.A_Trigger = value;
        }
        finally
        {
          if (enumerator is IDisposable)
            ((IDisposable) enumerator).Dispose();
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
          ((Player) enumerator.Current).EegChannel.B_Trigger = value;
        }
        finally
        {
          if (enumerator is IDisposable)
            ((IDisposable) enumerator).Dispose();
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
          ((Player) enumerator.Current).EegChannel.C_Trigger = value;
        }
        finally
        {
          if (enumerator is IDisposable)
            ((IDisposable) enumerator).Dispose();
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
          ((Player) enumerator.Current).EegChannel.D_Trigger = value;
        }
        finally
        {
          if (enumerator is IDisposable)
            ((IDisposable) enumerator).Dispose();
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
          ((Player) enumerator.Current).EegChannel.R_Ignore = value;
        }
        finally
        {
          if (enumerator is IDisposable)
            ((IDisposable) enumerator).Dispose();
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
          ((Player) enumerator.Current).EegChannel.A_Ignore = value;
        }
        finally
        {
          if (enumerator is IDisposable)
            ((IDisposable) enumerator).Dispose();
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
          ((Player) enumerator.Current).EegChannel.B_Ignore = value;
        }
        finally
        {
          if (enumerator is IDisposable)
            ((IDisposable) enumerator).Dispose();
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
          ((Player) enumerator.Current).EegChannel.C_Ignore = value;
        }
        finally
        {
          if (enumerator is IDisposable)
            ((IDisposable) enumerator).Dispose();
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
          ((Player) enumerator.Current).EegChannel.D_Ignore = value;
        }
        finally
        {
          if (enumerator is IDisposable)
            ((IDisposable) enumerator).Dispose();
        }
      }
    }

    public override bool D_Ignore_B
    {
      set => this.D_Ignore_A = value;
    }

    private void InitializeComponent()
    {
      ((Control) this).SuspendLayout();
      ((Control) this).Name = nameof (BubblePopper);
      ((Control) this).Size = new Size(1276, 784);
      ((Control) this).ResumeLayout(false);
    }

    private void BubblePopper_Load(object sender, EventArgs e)
    {
    }
  }
}
