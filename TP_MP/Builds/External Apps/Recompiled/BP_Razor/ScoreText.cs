// Decompiled with JetBrains decompiler
// Type: BP_Razor.ScoreText
// Assembly: BP_Razor, Version=1.0.2635.17043, Culture=neutral, PublicKeyToken=null
// MVID: 44F336AB-547C-4D12-89AB-EC84272374D7
// Assembly location: C:\Program Files (x86)\Spectrum Learning\BT v11a\dll\BP_Razor.dll

using Nyp.Razor;
using Nyp.Razor.Spectrum;
using System.Drawing;

namespace BP_Razor
{
  public class ScoreText : Text2D
  {
    public ScoreText()
      : base("Courier New", 24f, FontStyle.Bold)
    {
      this.Text = Game.Scores.ToString("D4");
      this.Position = new PointF(230f, -230f);
      this.Color = Color.Snow;
    }

    public override void Update(double elapsed) => this.Text = Game.Scores.ToString("D4");
  }
}
