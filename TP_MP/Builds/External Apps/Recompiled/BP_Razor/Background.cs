// Decompiled with JetBrains decompiler
// Type: BP_Razor.Background
// Assembly: BP_Razor, Version=1.0.2635.17043, Culture=neutral, PublicKeyToken=null
// MVID: 44F336AB-547C-4D12-89AB-EC84272374D7
// Assembly location: C:\Program Files (x86)\Spectrum Learning\BT v11a\dll\BP_Razor.dll

using Nyp.Razor;
using Nyp.Razor.Spectrum;

namespace BP_Razor
{
  public class Background : Sprite
  {
    private Animation BackgroundAnimation;
    private Frame BackgroundFrame;
    private Vector2 TopLeft;
    private Vector2 BottomLeft;
    private Vector2 BottomRight;
    private Vector2 TopRight;
    private HitBox BackgroundHitBox;
    public const int BG1 = 0;
    public const int BG2 = 1;
    public const int BG3 = 2;

    private HitBox getBGHitbox_Left()
    {
      this.BackgroundHitBox = new HitBox();
      (TopLeft).X = -400f;
      (TopLeft).Y = -300f;
      (BottomLeft).X = -400f;
      (BottomLeft).Y = 299f;
      (BottomRight).X = -370f;
      (BottomRight).Y = 299f;
      (TopRight).X = -370f;
      (TopRight).Y = -300f;
      (BackgroundHitBox).Set(this.TopLeft, this.BottomLeft, this.BottomRight, this.TopRight);
      return this.BackgroundHitBox;
    }

    private HitBox getBGHitbox_Right()
    {
      this.BackgroundHitBox = new HitBox();
      (TopLeft).X = 320f;
      (TopLeft).Y = -300f;
      (BottomLeft).X = 320f;
      (BottomLeft).Y = 300f;
      (BottomRight).X = 399f;
      (BottomRight).Y = 300f;
      (TopRight).X = 399f;
      (TopRight).Y = -300f;
      (BackgroundHitBox).Set(this.TopLeft, this.BottomLeft, this.BottomRight, this.TopRight);
      return this.BackgroundHitBox;
    }

    private HitBox getBGHitbox_Top()
    {
      this.BackgroundHitBox = new HitBox();
      (TopLeft).X = 230f;
      (TopLeft).Y = -200f;
      (BottomLeft).X = 230f;
      (BottomLeft).Y = -180f;
      (BottomRight).X = 290f;
      (BottomRight).Y = -180f;
      (TopRight).X = 290f;
      (TopRight).Y = -200f;
      (BackgroundHitBox).Set(this.TopLeft, this.BottomLeft, this.BottomRight, this.TopRight);
      return this.BackgroundHitBox;
    }

    private HitBox getBGHitbox_Bottom()
    {
      this.BackgroundHitBox = new HitBox();
      (TopLeft).X = 230f;
      (TopLeft).Y = 240f;
      (BottomLeft).X = 230f;
      (BottomLeft).Y = 260f;
      (BottomRight).X = 290f;
      (BottomRight).Y = 260f;
      (TopRight).X = 290f;
      (TopRight).Y = 240f;
      (BackgroundHitBox).Set(this.TopLeft, this.BottomLeft, this.BottomRight, this.TopRight);
      return this.BackgroundHitBox;
    }

    public Background(int whichBG)
    {
      this.BackgroundAnimation = new Animation();
      this.BackgroundFrame = new Frame();
      switch (whichBG)
      {
        case 0:
          this.BackgroundFrame.Image = Game.LoadImage("../BubblePopper/images/bg1.png");
          break;
        case 1:
          this.BackgroundFrame.Image = Game.LoadImage("../BubblePopper/images/bg2.png");
          break;
        case 2:
          this.BackgroundFrame.Image = Game.LoadImage("../BubblePopper/images/bg3.png");
          break;
      }
      this.BackgroundFrame.Add(this.getBGHitbox_Left());
      this.BackgroundFrame.Add(this.getBGHitbox_Right());
      this.BackgroundFrame.Add(this.getBGHitbox_Top());
      this.BackgroundFrame.Add(this.getBGHitbox_Bottom());
      this.BackgroundAnimation.Add(this.BackgroundFrame);
      this.Add(this.BackgroundAnimation);
      this.m_fZOrder = -10f;
    }
  }
}
