// Decompiled with JetBrains decompiler
// Type: BP_Razor.ScoresHistoryData
// Assembly: BP_Razor, Version=1.0.2635.17043, Culture=neutral, PublicKeyToken=null
// MVID: 44F336AB-547C-4D12-89AB-EC84272374D7
// Assembly location: C:\Program Files (x86)\Spectrum Learning\BT v11a\dll\BP_Razor.dll

using System;

namespace BP_Razor
{
  public class ScoresHistoryData : IComparable
  {
    public int Scores;
    public int Level;
    public int Day;
    public int Month;
    public int Year;

    public int CompareTo(object obj)
    {
      if (obj is ScoresHistoryData)
        return checked (((ScoresHistoryData) obj).Scores - this.Scores);
      throw new ArgumentException("object is not instance of ScoresHistoryData class!");
    }

    public override string ToString() => this.Scores.ToString() + " " + this.Level.ToString() + " " + this.Day.ToString() + "/" + this.Month.ToString() + "/" + this.Year.ToString();
  }
}
