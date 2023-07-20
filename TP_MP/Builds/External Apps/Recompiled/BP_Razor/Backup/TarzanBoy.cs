// Decompiled with JetBrains decompiler
// Type: BP_Razor.TarzanBoy
// Assembly: BP_Razor, Version=1.0.2635.17043, Culture=neutral, PublicKeyToken=null
// MVID: 44F336AB-547C-4D12-89AB-EC84272374D7
// Assembly location: C:\Program Files (x86)\Spectrum Learning\BT v11a\dll\BP_Razor.dll

using Nyp.Razor;
using Nyp.Razor.Spectrum;
using System.Drawing.Drawing2D;

namespace BP_Razor
{
  public class TarzanBoy : Player
  {
    private Frame TarzanBoyFrame;
    private Animation TarzanBoyAnimation;
    private Vector2 TopLeft;
    private Vector2 BottomLeft;
    private Vector2 BottomRight;
    private Vector2 TopRight;
    private HitBox TarzanBoyHitBox;
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
    private AudioSource m_PauseSound;
    private AudioSource m_ChargeupSound;

    private HitBox getTarzanHitbox()
    {
      ((Vector2) ref this.TopLeft).X = -33f;
      ((Vector2) ref this.TopLeft).Y = 40f;
      ((Vector2) ref this.BottomLeft).X = -33f;
      ((Vector2) ref this.BottomLeft).Y = -34f;
      ((Vector2) ref this.BottomRight).X = 34f;
      ((Vector2) ref this.BottomRight).Y = -34f;
      ((Vector2) ref this.TopRight).X = 34f;
      ((Vector2) ref this.TopRight).Y = 40f;
      ((HitBox) ref this.TarzanBoyHitBox).Set(this.TopLeft, this.BottomLeft, this.BottomRight, this.TopRight);
      return this.TarzanBoyHitBox;
    }

    private void LoadTarzan()
    {
      this.TarzanBoyHitBox = this.getTarzanHitbox();
      this.TarzanBoyAnimation = new Animation();
      this.TarzanBoyFrame = new Frame();
      this.TarzanBoyFrame.Image = Game.LoadImage("../BubblePopper/images/normal.png");
      this.TarzanBoyFrame.Add(this.TarzanBoyHitBox);
      this.TarzanBoyAnimation.Add(this.TarzanBoyFrame);
      this.TarzanBoyAnimation.Duration = 1.0;
      this.TarzanBoyAnimation.Looping = true;
      ((Sprite) this).Add(this.TarzanBoyAnimation);
      this.TarzanBoyAnimation = new Animation();
      this.TarzanBoyFrame = new Frame();
      this.TarzanBoyFrame.Image = Game.LoadImage("../BubblePopper/images/normal_pullback.png");
      this.TarzanBoyFrame.Add(this.TarzanBoyHitBox);
      this.TarzanBoyAnimation.Add(this.TarzanBoyFrame);
      this.TarzanBoyFrame = new Frame();
      this.TarzanBoyFrame.Image = Game.LoadImage("../BubblePopper/images/normal_start3.png");
      this.TarzanBoyFrame.Add(this.TarzanBoyHitBox);
      this.TarzanBoyAnimation.Add(this.TarzanBoyFrame);
      this.TarzanBoyFrame = new Frame();
      this.TarzanBoyFrame.Image = Game.LoadImage("../BubblePopper/images/normal_start2.png");
      this.TarzanBoyFrame.Add(this.TarzanBoyHitBox);
      this.TarzanBoyAnimation.Add(this.TarzanBoyFrame);
      this.TarzanBoyFrame = new Frame();
      this.TarzanBoyFrame.Image = Game.LoadImage("../BubblePopper/images/normal_start1.png");
      this.TarzanBoyFrame.Add(this.TarzanBoyHitBox);
      this.TarzanBoyAnimation.Add(this.TarzanBoyFrame);
      ((Sprite) this).Add(this.TarzanBoyAnimation);
      this.TarzanBoyAnimation = new Animation();
      this.TarzanBoyFrame = new Frame();
      this.TarzanBoyFrame.Image = Game.LoadImage("../BubblePopper/images/stun1.png");
      this.TarzanBoyFrame.Add(this.TarzanBoyHitBox);
      this.TarzanBoyAnimation.Add(this.TarzanBoyFrame);
      this.TarzanBoyFrame = new Frame();
      this.TarzanBoyFrame.Image = Game.LoadImage("../BubblePopper/images/stun2.png");
      this.TarzanBoyFrame.Add(this.TarzanBoyHitBox);
      this.TarzanBoyAnimation.Add(this.TarzanBoyFrame);
      this.TarzanBoyFrame = new Frame();
      this.TarzanBoyFrame.Image = Game.LoadImage("../BubblePopper/images/stun1.png");
      this.TarzanBoyFrame.Add(this.TarzanBoyHitBox);
      this.TarzanBoyAnimation.Add(this.TarzanBoyFrame);
      this.TarzanBoyFrame = new Frame();
      this.TarzanBoyFrame.Image = Game.LoadImage("../BubblePopper/images/stun3.png");
      this.TarzanBoyFrame.Add(this.TarzanBoyHitBox);
      this.TarzanBoyAnimation.Add(this.TarzanBoyFrame);
      this.TarzanBoyAnimation.Duration = 0.5;
      this.TarzanBoyAnimation.Looping = true;
      ((Sprite) this).Add(this.TarzanBoyAnimation);
    }

    public void Reset()
    {
      ((Sprite) this).LocalMatrix.Reset();
      ((Sprite) this).LocalMatrix.Translate(260f, -45f);
      ((Sprite) this).m_bVisible = true;
      ((Sprite) this).m_bActive = true;
      Vector2 vector2;
      // ISSUE: explicit constructor call
      ((Vector2) ref vector2).\u002Ector(0.0f, 150f);
      ((Sprite) this).Velocity = vector2;
      this.m_dFireElapsed = 1.0;
      this.m_dDizzyElapsed = 3.0;
      this.m_dStunElapsed = 5.0;
      ((Sprite) this).CurrentIndex = 0;
    }

    public TarzanBoy()
    {
      this.TarzanBoyHitBox = new HitBox();
      this.m_bPause = false;
      this.LoadTarzan();
      this.Reset();
    }

    private void keyDownTriggered()
    {
      Vector2 velocity1;
      if ((double) ((Sprite) this).LocalMatrix.OffsetX < 0.0)
      {
        Matrix localMatrix1 = ((Sprite) this).LocalMatrix;
        Vector2 velocity2 = ((Sprite) this).Velocity;
        double x = (double) ((Vector2) ref velocity2).X;
        Vector2 velocity3 = ((Sprite) this).Velocity;
        double y = (double) ((Vector2) ref velocity3).Y;
        localMatrix1.Translate((float) x, (float) y);
        ((Sprite) this).LocalMatrix.Scale(-1f, 1f);
        Matrix localMatrix2 = ((Sprite) this).LocalMatrix;
        velocity1 = ((Sprite) this).Velocity;
        double offsetX = -(double) ((Vector2) ref velocity1).X;
        Vector2 velocity4 = ((Sprite) this).Velocity;
        double offsetY = -(double) ((Vector2) ref velocity4).Y;
        localMatrix2.Translate((float) offsetX, (float) offsetY);
      }
      // ISSUE: explicit constructor call
      ((Vector2) ref velocity1).\u002Ector(0.0f, 150f);
      ((Sprite) this).Velocity = velocity1;
    }

    private void keyDownPressed(double elapsed)
    {
      Matrix localMatrix = ((Sprite) this).m_LocalMatrix;
      Vector2 velocity1 = ((Sprite) this).Velocity;
      double offsetX = (double) ((Vector2) ref velocity1).X * elapsed;
      Vector2 velocity2 = ((Sprite) this).Velocity;
      double offsetY = (double) ((Vector2) ref velocity2).Y * elapsed;
      localMatrix.Translate((float) offsetX, (float) offsetY);
    }

    private void keyUpTriggered()
    {
      Vector2 velocity1;
      if ((double) ((Sprite) this).LocalMatrix.OffsetX < 0.0)
      {
        Matrix localMatrix1 = ((Sprite) this).LocalMatrix;
        Vector2 velocity2 = ((Sprite) this).Velocity;
        double x = (double) ((Vector2) ref velocity2).X;
        Vector2 velocity3 = ((Sprite) this).Velocity;
        double y = (double) ((Vector2) ref velocity3).Y;
        localMatrix1.Translate((float) x, (float) y);
        ((Sprite) this).LocalMatrix.Scale(-1f, 1f);
        Matrix localMatrix2 = ((Sprite) this).LocalMatrix;
        velocity1 = ((Sprite) this).Velocity;
        double offsetX = -(double) ((Vector2) ref velocity1).X;
        Vector2 velocity4 = ((Sprite) this).Velocity;
        double offsetY = -(double) ((Vector2) ref velocity4).Y;
        localMatrix2.Translate((float) offsetX, (float) offsetY);
      }
      // ISSUE: explicit constructor call
      ((Vector2) ref velocity1).\u002Ector(0.0f, -150f);
      ((Sprite) this).Velocity = velocity1;
    }

    private void keyUpPressed(double elapsed)
    {
      Matrix localMatrix = ((Sprite) this).m_LocalMatrix;
      Vector2 velocity1 = ((Sprite) this).Velocity;
      double offsetX = (double) ((Vector2) ref velocity1).X * elapsed;
      Vector2 velocity2 = ((Sprite) this).Velocity;
      double offsetY = (double) ((Vector2) ref velocity2).Y * elapsed;
      localMatrix.Translate((float) offsetX, (float) offsetY);
    }

    private void ActivateArrow()
    {
      Arrow arrow1 = new Arrow(0);
      arrow1.Owner = (Sprite) this;
      arrow1.Visible = true;
      arrow1.ZOrder = 1.5f;
      ((Sprite) this).CurrentIndex = 1;
      arrow1.LocalMatrix.Translate(((Sprite) this).m_LocalMatrix.OffsetX - 25f, ((Sprite) this).m_LocalMatrix.OffsetY);
      arrow1.LocalMatrix.Scale(1.25f, 1.25f);
      Arrow arrow2 = arrow1;
      Vector2 vector2_1;
      // ISSUE: explicit constructor call
      ((Vector2) ref vector2_1).\u002Ector(-775f, 0.0f);
      Vector2 vector2_2 = vector2_1;
      arrow2.Velocity = vector2_2;
      arrow1.CurrentAnimation.Play();
      arrow1.playArrow_Sound(0);
      Game.Add((Sprite) arrow1);
      this.m_dFireElapsed = 1.0;
    }

    public virtual void Update(double elapsed)
    {
      if (this.m_bPause)
      {
        this.m_ChargeupSound = AudioManager.Singleton.LoadAudioSource("../BubblePopper/sound/chargeup.wav");
        this.m_ChargeupSound.Looping = false;
        this.m_ChargeupSound.Play();
        if (!(this.EegChannel.D_Trigger | this.EegChannel.D_Ignore))
          return;
        BubblePopper.AddChargeBar();
      }
      else
      {
        if (Keyboard.IsKeyTriggered(40))
          this.keyDownTriggered();
        else if (Keyboard.IsKeyTriggered(38))
          this.keyUpTriggered();
        else if (Keyboard.IsKeyPressed(38))
          this.keyUpPressed(elapsed);
        else if (Keyboard.IsKeyPressed(40))
          this.keyDownPressed(elapsed);
        if (((Sprite) this).CurrentIndex == 2)
        {
          this.m_dDizzyElapsed -= elapsed;
          if (this.m_dDizzyElapsed <= 0.0)
          {
            ((Sprite) this).CurrentIndex = 0;
            ((Sprite) this).CurrentAnimation.Play();
            this.m_dDizzyElapsed = 3.0;
          }
        }
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

    public void Pause()
    {
      this.m_bPause = true;
      ((Sprite) this).CurrentAnimation.Stop();
      ((Sprite) this).CurrentIndex = 2;
      ((Sprite) this).CurrentAnimation.Looping = true;
      ((Sprite) this).CurrentAnimation.Play();
      this.m_PauseSound = AudioManager.Singleton.LoadAudioSource("../BubblePopper/sound/stunpause.wav");
      this.m_PauseSound.Looping = false;
      this.m_PauseSound.Play();
    }

    public void Unpause()
    {
      this.m_bPause = false;
      ((Sprite) this).CurrentAnimation.Looping = false;
      ((Sprite) this).CurrentAnimation.Stop();
      ((Sprite) this).CurrentIndex = 0;
      ((Sprite) this).CurrentAnimation.Play();
    }
  }
}
