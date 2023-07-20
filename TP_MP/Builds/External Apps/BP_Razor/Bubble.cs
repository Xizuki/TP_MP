// Decompiled with JetBrains decompiler
// Type: BP_Razor.Bubble
// Assembly: BP_Razor, Version=1.0.2635.17043, Culture=neutral, PublicKeyToken=null
// MVID: 44F336AB-547C-4D12-89AB-EC84272374D7
// Assembly location: C:\Program Files (x86)\Spectrum Learning\BT v11a\dll\BP_Razor.dll

using Nyp.Razor;
using Nyp.Razor.Spectrum;
using System;
using System.Collections;
using System.Drawing.Drawing2D;

namespace BP_Razor
{
  public class Bubble : Sprite
  {
    private BubblePopper BPGame;
    private Animation BubbleAnimation;
    private Frame BubbleFrame;
    private Vector2 TopLeft;
    private Vector2 BottomLeft;
    private Vector2 BottomRight;
    private Vector2 TopRight;
    private HitBox BubbleHitBox;
    public const int BUBBLE_BLUE_NORMAL = 0;
    public const int BUBBLE_YELLOW_NORMAL = 1;
    public const int BUBBLE_RED_HARD = 2;
    public const int BUBBLE_PIN = 3;
    private int m_bubbleType;
    public const int BUBBLE_BURST = 1;
    public const double BUBBLE_MONKEY_DUR = 3.5;
    private double m_dBubbleMonkey;
    public const double BUBBLE_BURST_DUR = 0.20000000298023224;
    private double m_dBubbleBurst;
    private int m_hits;
    private int m_column;
    private bool m_bArrow;
    private int m_arrowType;
    private bool m_pop;
    private int m_monkeyID;
    private bool m_ignore;
    private AudioSource m_PopSound;
    private AudioSource m_PinBubble;

    private HitBox getBubbleHitbox()
    {
      (TopLeft).X = 18f;
      (TopLeft).Y = -18f;
      (BottomLeft).X = 18f;
      (BottomLeft).Y = 16f;
      (BottomRight).X = -18f;
      (BottomRight).Y = 16f;
      (TopRight).X = -18f;
      (TopRight).Y = -18f;
      (BubbleHitBox).Set(this.TopLeft, this.BottomLeft, this.BottomRight, this.TopRight);
      return this.BubbleHitBox;
    }

    private void loadBubbleBurst()
    {
      this.BubbleAnimation = new Animation();
      this.BubbleFrame = new Frame();
      this.BubbleFrame.Image = Game.LoadImage("../BubblePopper/images/burst1.png");
      this.BubbleAnimation.Add(this.BubbleFrame);
      this.BubbleFrame = new Frame();
      this.BubbleFrame.Image = Game.LoadImage("../BubblePopper/images/burst2.png");
      this.BubbleAnimation.Add(this.BubbleFrame);
      this.Add(this.BubbleAnimation);
    }

    public Bubble(ref BubblePopper bp, int bubbleType, int column)
    {
      this.m_dBubbleMonkey = 3.5;
      this.m_dBubbleBurst = 0.20000000298023224;
      this.m_hits = 0;
      this.m_bArrow = false;
      this.m_pop = false;
      this.m_monkeyID = -1;
      this.m_ignore = false;
      this.m_bubbleType = bubbleType;
      this.BubbleHitBox = this.getBubbleHitbox();
      this.BubbleAnimation = new Animation();
      this.BubbleFrame = new Frame();
      switch (bubbleType)
      {
        case 0:
          this.BubbleFrame.Image = Game.LoadImage("../BubblePopper/images/bubble_blue.png");
          break;
        case 1:
          this.BubbleFrame.Image = Game.LoadImage("../BubblePopper/images/bubble_yellow.png");
          break;
        case 2:
          this.BubbleFrame.Image = Game.LoadImage("../BubblePopper/images/hardbubble_red.png");
          break;
        case 3:
          this.BubbleFrame.Image = Game.LoadImage("../BubblePopper/images/pinbubble.png");
          break;
      }
      this.BubbleFrame.Add(this.BubbleHitBox);
      this.BubbleAnimation.Add(this.BubbleFrame);
      this.Add(this.BubbleAnimation);
      this.loadBubbleBurst();
      Vector2 vector2 = new Vector2(0.0f, 10f);
            // ISSUE: explicit constructor call
            //((Vector2) ref vector2).\u002Ector(0.0f, 10f);
            this.Velocity = vector2;
      this.ZOrder = 1.5f;
      this.BPGame = bp;
      this.m_column = column;
      if (bubbleType != 3)
        return;
      this.m_PinBubble = AudioManager.Singleton.LoadAudioSource("../BubblePopper/sound/pinbubble.wav");
      this.m_PinBubble.Looping = false;
      this.m_PinBubble.Play();
    }

    private void playPop_Sound()
    {
      this.m_PopSound = AudioManager.Singleton.LoadAudioSource("../BubblePopper/sound/pop.wav");
      this.m_PopSound.Looping = false;
      this.m_PopSound.Play();
    }

    public virtual void Update(double elapsed)
    {
      if (this.m_pop)
      {
        if (this.CurrentIndex != 1)
        {
          this.CurrentIndex = 1;
          this.CurrentAnimation.Play();
        }
        else
        {
          this.m_dBubbleBurst -= elapsed;
          if (this.m_dBubbleBurst > 0.0)
            return;
          this.playPop_Sound();
          Game.Remove((Sprite) this);
        }
      }
      else if (this.CurrentIndex == 1)
      {
        this.m_dBubbleBurst -= elapsed;
        if (this.m_dBubbleBurst > 0.0)
          return;
        this.playPop_Sound();
        if (this.m_monkeyID <= 1 & !this.m_ignore)
          this.BPGame.GenerateBubble(this.m_column);
        Game.Remove((Sprite) this);
      }
      else
      {
        ArrayList collidedSprites = Game.GetCollidedSprites((Sprite) this);
        if (collidedSprites.Count > 0)
        {
          try
          {
            foreach (Sprite sprite in collidedSprites)
            {
              switch (sprite)
              {
                case Arrow _:
                  checked { ++this.m_hits; }
                  Game.Remove(sprite);
                  if (this.m_hits >= this.NumHits & this.CurrentIndex != 1)
                  {
                    if (this.m_bubbleType == 3)
                    {
                      this.BPGame.PopAllBubbles();
                    }
                    else
                    {
                      this.m_bArrow = this.BPGame.GenerateNegArrow();
                      if (this.m_bArrow)
                      {
                        if (this.m_bubbleType == 0 | this.m_bubbleType == 1)
                          this.m_arrowType = 1;
                        else if (this.m_bubbleType == 2)
                          this.m_arrowType = 2;
                        this.BPGame.GenerateArrow(this.m_arrowType, this.m_LocalMatrix);
                      }
                      this.CurrentIndex = 1;
                      this.CurrentAnimation.Play();
                      checked { Game.Scores += this.Reward; }
                    }
                    BubblePopper.AddChargeBar();
                    continue;
                  }
                  continue;
                case Monkey _:
                  if (this.m_monkeyID != ((Monkey) sprite).MonkeyID)
                  {
                    this.m_monkeyID = ((Monkey) sprite).MonkeyID;
                    this.m_ignore = false;
                    this.m_dBubbleMonkey = 3.5;
                    (m_Velocity).Y = 0.0f;
                  }
                  if (!this.m_ignore)
                  {
                    this.m_dBubbleMonkey -= elapsed;
                    if (this.m_dBubbleMonkey <= 0.0)
                    {
                      this.m_ignore = true;
                      this.m_dBubbleMonkey = 3.5;
                      (m_Velocity).Y = 10f;
                      if (this.m_monkeyID == 0 | this.m_monkeyID == 1)
                      {
                        this.BPGame.GenerateBubble(this.m_column);
                        continue;
                      }
                      continue;
                    }
                    continue;
                  }
                  continue;
                case Basket _:
                  ((Basket) sprite).receiveBubble();
                  BubblePopper.RemoveChargeBar();
                  Game.Remove((Sprite) this);
                  continue;
                default:
                  continue;
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
        Matrix localMatrix = this.m_LocalMatrix;
        Vector2 velocity1 = this.Velocity;
        double x = (double) (velocity1).X;
        Vector2 velocity2 = this.Velocity;
        double y = (double) ( velocity2).Y;
        localMatrix.Translate((float) x, (float) y);
      }
    }

    public int Reward
    {
      get
      {
        switch (this.m_bubbleType)
        {
          case 0:
          case 1:
            return 10;
          case 2:
            return 20;
          case 3:
            return 30;
          default:
            int reward = 0;
            return reward;
        }
      }
    }

    public int Penalty
    {
      get
      {
        switch (this.m_bubbleType)
        {
          case 0:
          case 1:
            return -10;
          case 2:
            return -20;
          case 3:
            return -50;
          default:
            int penalty = 0;
            return penalty;
        }
      }
    }

    public int NumHits
    {
      get
      {
        switch (this.m_bubbleType)
        {
          case 0:
          case 1:
            return 1;
          case 2:
            return 2;
          case 3:
            return 3;
          default:
            int numHits = 0;
            return numHits;
        }
      }
    }

    public int numHitsSoFar
    {
      get => this.m_hits;
      set => this.m_hits = value;
    }

    public bool spawnArrow
    {
      get => this.m_bArrow;
      set => this.m_bArrow = value;
    }

    public bool toPop
    {
      set => this.m_pop = value;
    }
  }
}
