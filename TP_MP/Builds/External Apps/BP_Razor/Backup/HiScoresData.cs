// Decompiled with JetBrains decompiler
// Type: BP_Razor.HiScoresData
// Assembly: BP_Razor, Version=1.0.2635.17043, Culture=neutral, PublicKeyToken=null
// MVID: 44F336AB-547C-4D12-89AB-EC84272374D7
// Assembly location: C:\Program Files (x86)\Spectrum Learning\BT v11a\dll\BP_Razor.dll

using System;

namespace BP_Razor
{
  public class HiScoresData : IComparable
  {
    public int Scores;
    public string Name;

    public int CompareTo(object obj)
    {
      if (obj is HiScoresData)
        return checked (((HiScoresData) obj).Scores - this.Scores);
      throw new ArgumentException("object is not an instance of HiScoresData class!");
    }

    public override string ToString() => this.Name + " " + this.Scores.ToString();
  }
}
