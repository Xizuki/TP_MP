// Decompiled with JetBrains decompiler
// Type: BP_Razor.Basket
// Assembly: BP_Razor, Version=1.0.2635.17043, Culture=neutral, PublicKeyToken=null
// MVID: 44F336AB-547C-4D12-89AB-EC84272374D7
// Assembly location: C:\Program Files (x86)\Spectrum Learning\BT v11a\dll\BP_Razor.dll

using Nyp.Razor;
using Nyp.Razor.Spectrum;

namespace BP_Razor
{
  public class Basket : Sprite
  {
    private Animation BasketAnimation;
    private Frame BasketFrame;
    private Vector2 TopLeft;
    private Vector2 BottomLeft;
    private Vector2 BottomRight;
    private Vector2 TopRight;
    private HitBox BasketHitBox;
    private AudioSource m_Sound;
    public const int BASKET_UP = 0;
    public const int BASKET_DOWN = 1;
    public const double BASKET_DOWN_DUR = 0.20000000298023224;
    private double m_dBasketDown;

    private HitBox getBasket1Hitbox()
    {
      (TopLeft).X = -100f;
      (TopLeft).Y = -20f;
      (BottomLeft).X = -100f;
      (BottomLeft).Y = -10f;
      (BottomRight).X = 100f;
      (BottomRight).Y = -10f;
      (TopRight).X = 100f;
      (TopRight).Y = -20f;
      (BasketHitBox).Set(this.TopLeft, this.BottomLeft, this.BottomRight, this.TopRight);
      return this.BasketHitBox;
    }

    private HitBox getBasket2Hitbox()
    {
      (TopLeft).X = -100f;
      (TopLeft).Y = -10f;
      (BottomLeft).X = -100f;
      (BottomLeft).Y = 0.0f;
      (BottomRight).X = 100f;
      (BottomRight).Y = 0.0f;
      (TopRight).X = 100f;
      (TopRight).Y = -10f;
      (BasketHitBox).Set(this.TopLeft, this.BottomLeft, this.BottomRight, this.TopRight);
      return this.BasketHitBox;
    }

    public Basket()
    {
      this.m_dBasketDown = 0.20000000298023224;
      this.BasketHitBox = this.getBasket1Hitbox();
      this.BasketAnimation = new Animation();
      this.BasketFrame = new Frame();
      this.BasketFrame.Image = Game.LoadImage("../BubblePopper/images/basket1.png");
      this.BasketFrame.Add(this.BasketHitBox);
      this.BasketAnimation.Add(this.BasketFrame);
      this.Add(this.BasketAnimation);
      this.BasketHitBox = this.getBasket2Hitbox();
      this.BasketAnimation = new Animation();
      this.BasketFrame = new Frame();
      this.BasketFrame.Image = Game.LoadImage("../BubblePopper/images/basket2.png");
      this.BasketFrame.Add(this.BasketHitBox);
      this.BasketAnimation.Add(this.BasketFrame);
      this.Add(this.BasketAnimation);
      this.m_fZOrder = -5f;
      this.CurrentIndex = 1;
    }

    public void receiveBubble()
    {
      this.CurrentIndex = 1;
      this.CurrentAnimation.Play();
      this.m_Sound = AudioManager.Singleton.LoadAudioSource("../BubblePopper/sound/basket.wav");
      this.m_Sound.Looping = false;
      this.m_Sound.Play();
    }

    public override void Update(double elapsed)
    {
      if (this.CurrentIndex != 1)
        return;
      this.m_dBasketDown -= elapsed;
      if (this.m_dBasketDown > 0.0)
        return;
      this.CurrentIndex = 0;
      this.m_dBasketDown = 0.20000000298023224;
      this.CurrentAnimation.Play();
    }
  }
}
