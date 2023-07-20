// Decompiled with JetBrains decompiler
// Type: BP_Razor.Monkey
// Assembly: BP_Razor, Version=1.0.2635.17043, Culture=neutral, PublicKeyToken=null
// MVID: 44F336AB-547C-4D12-89AB-EC84272374D7
// Assembly location: C:\Program Files (x86)\Spectrum Learning\BT v11a\dll\BP_Razor.dll

using Nyp.Razor;
using Nyp.Razor.Spectrum;

namespace BP_Razor
{
  public class Monkey : Player
  {
    private Frame MonkeyFrame;
    private Animation MonkeyAnimation;
    private Vector2 TopLeft;
    private Vector2 BottomLeft;
    private Vector2 BottomRight;
    private Vector2 TopRight;
    private HitBox MonkeyHitBox;
    private int m_monkeyID;
    public const int MONKEY_BG1 = 0;
    public const int MONKEY_BG2 = 1;
    public const int MONKEY_BG3 = 2;

    private void LoadBG_1()
    {
      this.MonkeyHitBox = new HitBox();
      ((Vector2) ref this.TopLeft).X = -19f;
      ((Vector2) ref this.TopLeft).Y = -28f;
      ((Vector2) ref this.BottomLeft).X = -19f;
      ((Vector2) ref this.BottomLeft).Y = -13f;
      ((Vector2) ref this.BottomRight).X = 20f;
      ((Vector2) ref this.BottomRight).Y = -13f;
      ((Vector2) ref this.TopRight).X = 20f;
      ((Vector2) ref this.TopRight).Y = -28f;
      ((HitBox) ref this.MonkeyHitBox).Set(this.TopLeft, this.BottomLeft, this.BottomRight, this.TopRight);
      this.MonkeyAnimation = new Animation();
      this.MonkeyFrame = new Frame();
      this.MonkeyFrame.Image = Game.LoadImage("../BubblePopper/images/monkey_empty_bg1.png");
      this.MonkeyFrame.Add(this.MonkeyHitBox);
      this.MonkeyAnimation.Add(this.MonkeyFrame);
      this.MonkeyAnimation.Looping = true;
      ((Sprite) this).Add(this.MonkeyAnimation);
      ((Sprite) this).m_fZOrder = -6f;
    }

    private void LoadBG_2()
    {
      this.MonkeyHitBox = new HitBox();
      ((Vector2) ref this.TopLeft).X = -21f;
      ((Vector2) ref this.TopLeft).Y = -12f;
      ((Vector2) ref this.BottomLeft).X = -21f;
      ((Vector2) ref this.BottomLeft).Y = -2f;
      ((Vector2) ref this.BottomRight).X = 22f;
      ((Vector2) ref this.BottomRight).Y = -2f;
      ((Vector2) ref this.TopRight).X = 22f;
      ((Vector2) ref this.TopRight).Y = -12f;
      ((HitBox) ref this.MonkeyHitBox).Set(this.TopLeft, this.BottomLeft, this.BottomRight, this.TopRight);
      this.MonkeyAnimation = new Animation();
      this.MonkeyFrame = new Frame();
      this.MonkeyFrame.Image = Game.LoadImage("../BubblePopper/images/monkey_empty_bg2.png");
      this.MonkeyFrame.Add(this.MonkeyHitBox);
      this.MonkeyAnimation.Add(this.MonkeyFrame);
      this.MonkeyAnimation.Looping = true;
      ((Sprite) this).Add(this.MonkeyAnimation);
      ((Sprite) this).m_fZOrder = -6f;
    }

    private void LoadBG_3()
    {
      this.MonkeyHitBox = new HitBox();
      ((Vector2) ref this.TopLeft).X = -24f;
      ((Vector2) ref this.TopLeft).Y = -21f;
      ((Vector2) ref this.BottomLeft).X = -24f;
      ((Vector2) ref this.BottomLeft).Y = -12f;
      ((Vector2) ref this.BottomRight).X = 22f;
      ((Vector2) ref this.BottomRight).Y = -12f;
      ((Vector2) ref this.TopRight).X = 22f;
      ((Vector2) ref this.TopRight).Y = -21f;
      ((HitBox) ref this.MonkeyHitBox).Set(this.TopLeft, this.BottomLeft, this.BottomRight, this.TopRight);
      this.MonkeyAnimation = new Animation();
      this.MonkeyFrame = new Frame();
      this.MonkeyFrame.Image = Game.LoadImage("../BubblePopper/images/monkey_empty_bg3.png");
      this.MonkeyFrame.Add(this.MonkeyHitBox);
      this.MonkeyAnimation.Add(this.MonkeyFrame);
      this.MonkeyAnimation.Looping = true;
      ((Sprite) this).Add(this.MonkeyAnimation);
      ((Sprite) this).m_fZOrder = -6f;
    }

    public Monkey(int whichBG)
    {
      switch (whichBG)
      {
        case 0:
          this.LoadBG_1();
          break;
        case 1:
          this.LoadBG_2();
          break;
        case 2:
          this.LoadBG_3();
          break;
      }
    }

    public int MonkeyID
    {
      get => this.m_monkeyID;
      set => this.m_monkeyID = value;
    }
  }
}
