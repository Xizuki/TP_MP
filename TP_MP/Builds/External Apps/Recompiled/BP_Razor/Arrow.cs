// Decompiled with JetBrains decompiler
// Type: BP_Razor.Arrow
// Assembly: BP_Razor, Version=1.0.2635.17043, Culture=neutral, PublicKeyToken=null
// MVID: 44F336AB-547C-4D12-89AB-EC84272374D7
// Assembly location: C:\Program Files (x86)\Spectrum Learning\BT v11a\dll\BP_Razor.dll

using Nyp.Razor;
using Nyp.Razor.Spectrum;
using System;
using System.Collections;

namespace BP_Razor
{
  public class Arrow : Sprite
  {
    private Animation ArrowAnimation;
    private Frame ArrowFrame;
    private Vector2 TopLeft;
    private Vector2 BottomLeft;
    private Vector2 BottomRight;
    private Vector2 TopRight;
    private HitBox ArrowHitBox;
    private Sprite m_Owner;
    private AudioSource m_ArrowSound;
    private AudioSource m_HitSound;
    public const int ARROW_NORMAL = 0;
    public const int ARROW_ICE = 1;
    public const int ARROW_FIRE = 2;
    public const int ARROW_PENALTY = 10;

    private HitBox getNormalArrowHitbox()
    {
      (TopLeft).X = -28.5f;
      (TopLeft).Y = -5.5f;
      (BottomLeft).X = -28.5f;
      (BottomLeft).Y = 4.5f;
      (BottomRight).X = -18.5f;
      (BottomRight).Y = 4.5f;
      (TopRight).X = -18.5f;
      (TopRight).Y = -5.5f;
      (ArrowHitBox).Set(this.TopLeft, this.BottomLeft, this.BottomRight, this.TopRight);
      return this.ArrowHitBox;
    }

    private HitBox getOtherArrowHitbox()
    {
      (TopLeft).X = -28.5f;
      (TopLeft).Y = -5.5f;
      (BottomLeft).X = -28.5f;
      (BottomLeft).Y = 5.5f;
      (BottomRight).X = 11.5f;
      (BottomRight).Y = 5.5f;
      (TopRight).X = 11.5f;
      (TopRight).Y = -5.5f;
      (ArrowHitBox).Set(this.TopLeft, this.BottomLeft, this.BottomRight, this.TopRight);
      return this.ArrowHitBox;
    }

    public Arrow(int whichArrow)
    {
      this.ArrowHitBox = new HitBox();
      this.ArrowAnimation = new Animation();
      this.ArrowFrame = new Frame();
      switch (whichArrow)
      {
        case 0:
          this.ArrowFrame.Image = Game.LoadImage("../BubblePopper/images/normalarrow.png");
          this.ArrowHitBox = this.getNormalArrowHitbox();
          (m_Velocity).X = -10f;
          break;
        case 1:
          this.ArrowFrame.Image = Game.LoadImage("../BubblePopper/images/icearrow.png");
          this.ArrowHitBox = this.getOtherArrowHitbox();
          (m_Velocity).X = 15f;
          break;
        case 2:
          this.ArrowFrame.Image = Game.LoadImage("../BubblePopper/images/firearrow.png");
          this.ArrowHitBox = this.getOtherArrowHitbox();
          (m_Velocity).X = 20f;
          break;
      }
      this.ArrowFrame.Add(this.ArrowHitBox);
      this.ArrowAnimation.Add(this.ArrowFrame);
      this.ArrowAnimation.Looping = true;
      this.Add(this.ArrowAnimation);
    }

    private void playHit_Sound()
    {
      this.m_HitSound = AudioManager.Singleton.LoadAudioSource("../BubblePopper/sound/tarzanhit.wav");
      this.m_HitSound.Looping = false;
      this.m_HitSound.Play();
    }

    public void playArrow_Sound(int whichArrow)
    {
      switch (whichArrow)
      {
        case 0:
          this.m_ArrowSound = AudioManager.Singleton.LoadAudioSource("../BubblePopper/sound/normalarrow.wav");
          break;
        case 1:
          this.m_ArrowSound = AudioManager.Singleton.LoadAudioSource("../BubblePopper/sound/icearrow.wav");
          break;
        case 2:
          this.m_ArrowSound = AudioManager.Singleton.LoadAudioSource("../BubblePopper/sound/firearrow.wav");
          break;
      }
      this.m_ArrowSound.Looping = false;
      this.m_ArrowSound.Play();
    }

    public override void Update(double elapsed)
    {
      this.LocalMatrix.Translate((m_Velocity).X * (float) elapsed, (m_Velocity).Y * (float) elapsed);
      ArrayList collidedSprites = Game.GetCollidedSprites((Sprite) this);
      try
      {
        foreach (Sprite sprite in collidedSprites)
        {
          if (sprite is TarzanBoy)
          {
            if (!(this.m_Owner is TarzanBoy))
            {
              this.playHit_Sound();
              sprite.CurrentIndex = 2;
              checked { Game.Scores -= 10; }
              BubblePopper.RemoveChargeBar();
              Game.Remove((Sprite) this);
            }
          }
          else if (sprite is Background)
            Game.Remove((Sprite) this);
        }
      }
      finally
      {
        IEnumerator enumerator = null;
        if (enumerator is IDisposable)
          ((IDisposable) enumerator).Dispose();
      }
    }

    public Sprite Owner
    {
      get => this.m_Owner;
      set => this.m_Owner = value;
    }
  }
}
