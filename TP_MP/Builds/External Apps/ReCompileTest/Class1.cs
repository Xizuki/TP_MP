using Nyp.Razor;
using Nyp.Razor.Spectrum;
using ReCompileTest;
using System;
using System.Collections;
using System.Windows.Forms;
//using Microsoft.VisualBasic.CompilerServices;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using System.Threading;

namespace ReCompileTest
{
    public class Background : Sprite
    {
        public AudioSource m_Music;
        public TreasureHunter.TreasureHunter m_Game;

        public Background() => this.ZOrder = -10f;

        public void Initialize()
        {
            if (this.m_Music != null)
            {
                this.m_Music.Stop();
                this.m_Music = (AudioSource)null;
            }
            this.m_Animations.Clear();
            switch (this.m_Game.Level)
            {
                case -3:
                    this.m_Music = AudioManager.Singleton.LoadAudioSource("../TreasureHunter/Sound/Background.wav");
                    this.m_Music.Looping = true;
                    this.m_Music.Play();
                    Frame frame1 = new Frame();
                    frame1.Image = Game.LoadImage("../TreasureHunter/Images/Background/HighScores.png");
                    Animation animation1 = new Animation();
                    animation1.Add(frame1);
                    this.Add(animation1);
                    break;
                case -2:
                    this.m_Music = AudioManager.Singleton.LoadAudioSource("../TreasureHunter/Sound/Background.wav");
                    this.m_Music.Looping = true;
                    this.m_Music.Play();
                    Frame frame2 = new Frame();
                    frame2.Image = Game.LoadImage("../TreasureHunter/Images/Background/ScoreHistory.png");
                    Animation animation2 = new Animation();
                    animation2.Add(frame2);
                    this.Add(animation2);
                    break;
                case -1:
                    this.m_Music = AudioManager.Singleton.LoadAudioSource("../TreasureHunter/Sound/Background.wav");
                    this.m_Music.Looping = true;
                    this.m_Music.Play();
                    Frame frame3 = new Frame();
                    frame3.Image = Game.LoadImage("../TreasureHunter/Images/Background/ProgressChart.png");
                    Animation animation3 = new Animation();
                    animation3.Add(frame3);
                    this.Add(animation3);
                    break;
                case 0:
                    this.m_Music = AudioManager.Singleton.LoadAudioSource("../TreasureHunter/Sound/Background.wav");
                    this.m_Music.Looping = true;
                    this.m_Music.Play();
                    Frame frame4 = new Frame();
                    frame4.Image = Game.LoadImage("../TreasureHunter/Images/Background/Splash.png");
                    Animation animation4 = new Animation();
                    animation4.Add(frame4);
                    this.Add(animation4);
                    break;
                case 1:
                    Frame frame5 = new Frame();
                    frame5.Image = Game.LoadImage("../TreasureHunter/Images/Background/Level01.png");
                    Vector2 vector2_1;
                    ((Vector2)ref vector2_1).X = -400f;
                    ((Vector2)ref vector2_1).Y = -300f;
                    Vector2 vector2_2;
                    ((Vector2)ref vector2_2).X = -400f;
                    ((Vector2)ref vector2_2).Y = 299f;
                    Vector2 vector2_3;
                    ((Vector2)ref vector2_3).X = -335f;
                    ((Vector2)ref vector2_3).Y = 299f;
                    Vector2 vector2_4;
                    ((Vector2)ref vector2_4).X = -335f;
                    ((Vector2)ref vector2_4).Y = -300f;
                    HitBox hitBox1;
                    ((HitBox)ref hitBox1).Set(vector2_1, vector2_2, vector2_3, vector2_4);
                    frame5.Add(hitBox1);
                    ((Vector2)ref vector2_1).X = 330f;
                    ((Vector2)ref vector2_1).Y = -300f;
                    ((Vector2)ref vector2_2).X = 330f;
                    ((Vector2)ref vector2_2).Y = 299f;
                    ((Vector2)ref vector2_3).X = 399f;
                    ((Vector2)ref vector2_3).Y = 299f;
                    ((Vector2)ref vector2_4).X = 399f;
                    ((Vector2)ref vector2_4).Y = -300f;
                    ((HitBox)ref hitBox1).Set(vector2_1, vector2_2, vector2_3, vector2_4);
                    frame5.Add(hitBox1);
                    ((Vector2)ref vector2_1).X = -400f;
                    ((Vector2)ref vector2_1).Y = -300f;
                    ((Vector2)ref vector2_2).X = -400f;
                    ((Vector2)ref vector2_2).Y = -187f;
                    ((Vector2)ref vector2_3).X = 399f;
                    ((Vector2)ref vector2_3).Y = -187f;
                    ((Vector2)ref vector2_4).X = 399f;
                    ((Vector2)ref vector2_4).Y = -300f;
                    ((HitBox)ref hitBox1).Set(vector2_1, vector2_2, vector2_3, vector2_4);
                    frame5.Add(hitBox1);
                    ((Vector2)ref vector2_1).X = -400f;
                    ((Vector2)ref vector2_1).Y = 232f;
                    ((Vector2)ref vector2_2).X = -400f;
                    ((Vector2)ref vector2_2).Y = 299f;
                    ((Vector2)ref vector2_3).X = 399f;
                    ((Vector2)ref vector2_3).Y = 299f;
                    ((Vector2)ref vector2_4).X = 399f;
                    ((Vector2)ref vector2_4).Y = 232f;
                    ((HitBox)ref hitBox1).Set(vector2_1, vector2_2, vector2_3, vector2_4);
                    frame5.Add(hitBox1);
                    Animation animation5 = new Animation();
                    animation5.Add(frame5);
                    this.Add(animation5);
                    break;
                case 2:
                    Frame frame6 = new Frame();
                    frame6.Image = Game.LoadImage("../TreasureHunter/Images/Background/Level02.png");
                    Vector2 vector2_5;
                    ((Vector2)ref vector2_5).X = -400f;
                    ((Vector2)ref vector2_5).Y = -300f;
                    Vector2 vector2_6;
                    ((Vector2)ref vector2_6).X = -400f;
                    ((Vector2)ref vector2_6).Y = 299f;
                    Vector2 vector2_7;
                    ((Vector2)ref vector2_7).X = -335f;
                    ((Vector2)ref vector2_7).Y = 299f;
                    Vector2 vector2_8;
                    ((Vector2)ref vector2_8).X = -335f;
                    ((Vector2)ref vector2_8).Y = -300f;
                    HitBox hitBox2;
                    ((HitBox)ref hitBox2).Set(vector2_5, vector2_6, vector2_7, vector2_8);
                    frame6.Add(hitBox2);
                    ((Vector2)ref vector2_5).X = 330f;
                    ((Vector2)ref vector2_5).Y = -300f;
                    ((Vector2)ref vector2_6).X = 330f;
                    ((Vector2)ref vector2_6).Y = 299f;
                    ((Vector2)ref vector2_7).X = 399f;
                    ((Vector2)ref vector2_7).Y = 299f;
                    ((Vector2)ref vector2_8).X = 399f;
                    ((Vector2)ref vector2_8).Y = -300f;
                    ((HitBox)ref hitBox2).Set(vector2_5, vector2_6, vector2_7, vector2_8);
                    frame6.Add(hitBox2);
                    ((Vector2)ref vector2_5).X = -400f;
                    ((Vector2)ref vector2_5).Y = -300f;
                    ((Vector2)ref vector2_6).X = -400f;
                    ((Vector2)ref vector2_6).Y = -187f;
                    ((Vector2)ref vector2_7).X = 399f;
                    ((Vector2)ref vector2_7).Y = -187f;
                    ((Vector2)ref vector2_8).X = 399f;
                    ((Vector2)ref vector2_8).Y = -300f;
                    ((HitBox)ref hitBox2).Set(vector2_5, vector2_6, vector2_7, vector2_8);
                    frame6.Add(hitBox2);
                    ((Vector2)ref vector2_5).X = -400f;
                    ((Vector2)ref vector2_5).Y = 232f;
                    ((Vector2)ref vector2_6).X = -400f;
                    ((Vector2)ref vector2_6).Y = 299f;
                    ((Vector2)ref vector2_7).X = 399f;
                    ((Vector2)ref vector2_7).Y = 299f;
                    ((Vector2)ref vector2_8).X = 399f;
                    ((Vector2)ref vector2_8).Y = 232f;
                    ((HitBox)ref hitBox2).Set(vector2_5, vector2_6, vector2_7, vector2_8);
                    frame6.Add(hitBox2);
                    ((Vector2)ref vector2_5).X = -56f;
                    ((Vector2)ref vector2_5).Y = -26f;
                    ((Vector2)ref vector2_6).X = -56f;
                    ((Vector2)ref vector2_6).Y = 83f;
                    ((Vector2)ref vector2_7).X = 105f;
                    ((Vector2)ref vector2_7).Y = 83f;
                    ((Vector2)ref vector2_8).X = 105f;
                    ((Vector2)ref vector2_8).Y = -26f;
                    ((HitBox)ref hitBox2).Set(vector2_5, vector2_6, vector2_7, vector2_8);
                    frame6.Add(hitBox2);
                    ((Vector2)ref vector2_5).X = -108f;
                    ((Vector2)ref vector2_5).Y = 33f;
                    ((Vector2)ref vector2_6).X = -108f;
                    ((Vector2)ref vector2_6).Y = 83f;
                    ((Vector2)ref vector2_7).X = -56f;
                    ((Vector2)ref vector2_7).Y = 83f;
                    ((Vector2)ref vector2_8).X = -56f;
                    ((Vector2)ref vector2_8).Y = 33f;
                    ((HitBox)ref hitBox2).Set(vector2_5, vector2_6, vector2_7, vector2_8);
                    frame6.Add(hitBox2);
                    Animation animation6 = new Animation();
                    animation6.Add(frame6);
                    this.Add(animation6);
                    break;
                case 3:
                    Frame frame7 = new Frame();
                    frame7.Image = Game.LoadImage("../TreasureHunter/Images/Background/Level03.png");
                    Vector2 vector2_9;
                    ((Vector2)ref vector2_9).X = -400f;
                    ((Vector2)ref vector2_9).Y = -300f;
                    Vector2 vector2_10;
                    ((Vector2)ref vector2_10).X = -400f;
                    ((Vector2)ref vector2_10).Y = 299f;
                    Vector2 vector2_11;
                    ((Vector2)ref vector2_11).X = -335f;
                    ((Vector2)ref vector2_11).Y = 299f;
                    Vector2 vector2_12;
                    ((Vector2)ref vector2_12).X = -335f;
                    ((Vector2)ref vector2_12).Y = -300f;
                    HitBox hitBox3;
                    ((HitBox)ref hitBox3).Set(vector2_9, vector2_10, vector2_11, vector2_12);
                    frame7.Add(hitBox3);
                    ((Vector2)ref vector2_9).X = 330f;
                    ((Vector2)ref vector2_9).Y = -300f;
                    ((Vector2)ref vector2_10).X = 330f;
                    ((Vector2)ref vector2_10).Y = 299f;
                    ((Vector2)ref vector2_11).X = 399f;
                    ((Vector2)ref vector2_11).Y = 299f;
                    ((Vector2)ref vector2_12).X = 399f;
                    ((Vector2)ref vector2_12).Y = -300f;
                    ((HitBox)ref hitBox3).Set(vector2_9, vector2_10, vector2_11, vector2_12);
                    frame7.Add(hitBox3);
                    ((Vector2)ref vector2_9).X = -400f;
                    ((Vector2)ref vector2_9).Y = -300f;
                    ((Vector2)ref vector2_10).X = -400f;
                    ((Vector2)ref vector2_10).Y = -187f;
                    ((Vector2)ref vector2_11).X = 399f;
                    ((Vector2)ref vector2_11).Y = -187f;
                    ((Vector2)ref vector2_12).X = 399f;
                    ((Vector2)ref vector2_12).Y = -300f;
                    ((HitBox)ref hitBox3).Set(vector2_9, vector2_10, vector2_11, vector2_12);
                    frame7.Add(hitBox3);
                    ((Vector2)ref vector2_9).X = -400f;
                    ((Vector2)ref vector2_9).Y = 232f;
                    ((Vector2)ref vector2_10).X = -400f;
                    ((Vector2)ref vector2_10).Y = 299f;
                    ((Vector2)ref vector2_11).X = 399f;
                    ((Vector2)ref vector2_11).Y = 299f;
                    ((Vector2)ref vector2_12).X = 399f;
                    ((Vector2)ref vector2_12).Y = 232f;
                    ((HitBox)ref hitBox3).Set(vector2_9, vector2_10, vector2_11, vector2_12);
                    frame7.Add(hitBox3);
                    ((Vector2)ref vector2_9).X = -91f;
                    ((Vector2)ref vector2_9).Y = -5f;
                    ((Vector2)ref vector2_10).X = -91f;
                    ((Vector2)ref vector2_10).Y = 132f;
                    ((Vector2)ref vector2_11).X = 107f;
                    ((Vector2)ref vector2_11).Y = 132f;
                    ((Vector2)ref vector2_12).X = 107f;
                    ((Vector2)ref vector2_12).Y = -5f;
                    ((HitBox)ref hitBox3).Set(vector2_9, vector2_10, vector2_11, vector2_12);
                    frame7.Add(hitBox3);
                    ((Vector2)ref vector2_9).X = -149f;
                    ((Vector2)ref vector2_9).Y = 34f;
                    ((Vector2)ref vector2_10).X = -149f;
                    ((Vector2)ref vector2_10).Y = 132f;
                    ((Vector2)ref vector2_11).X = -91f;
                    ((Vector2)ref vector2_11).Y = 132f;
                    ((Vector2)ref vector2_12).X = -91f;
                    ((Vector2)ref vector2_12).Y = 34f;
                    ((HitBox)ref hitBox3).Set(vector2_9, vector2_10, vector2_11, vector2_12);
                    frame7.Add(hitBox3);
                    ((Vector2)ref vector2_9).X = 225f;
                    ((Vector2)ref vector2_9).Y = -187f;
                    ((Vector2)ref vector2_10).X = 225f;
                    ((Vector2)ref vector2_10).Y = -105f;
                    ((Vector2)ref vector2_11).X = 340f;
                    ((Vector2)ref vector2_11).Y = -105f;
                    ((Vector2)ref vector2_12).X = 340f;
                    ((Vector2)ref vector2_12).Y = -187f;
                    ((HitBox)ref hitBox3).Set(vector2_9, vector2_10, vector2_11, vector2_12);
                    frame7.Add(hitBox3);
                    Animation animation7 = new Animation();
                    animation7.Add(frame7);
                    this.Add(animation7);
                    break;
                case 4:
                    Frame frame8 = new Frame();
                    frame8.Image = Game.LoadImage("../TreasureHunter/Images/Background/Level04.png");
                    Vector2 vector2_13;
                    ((Vector2)ref vector2_13).X = -400f;
                    ((Vector2)ref vector2_13).Y = -300f;
                    Vector2 vector2_14;
                    ((Vector2)ref vector2_14).X = -400f;
                    ((Vector2)ref vector2_14).Y = 299f;
                    Vector2 vector2_15;
                    ((Vector2)ref vector2_15).X = -335f;
                    ((Vector2)ref vector2_15).Y = 299f;
                    Vector2 vector2_16;
                    ((Vector2)ref vector2_16).X = -335f;
                    ((Vector2)ref vector2_16).Y = -300f;
                    HitBox hitBox4;
                    ((HitBox)ref hitBox4).Set(vector2_13, vector2_14, vector2_15, vector2_16);
                    frame8.Add(hitBox4);
                    ((Vector2)ref vector2_13).X = 330f;
                    ((Vector2)ref vector2_13).Y = -300f;
                    ((Vector2)ref vector2_14).X = 330f;
                    ((Vector2)ref vector2_14).Y = 299f;
                    ((Vector2)ref vector2_15).X = 399f;
                    ((Vector2)ref vector2_15).Y = 299f;
                    ((Vector2)ref vector2_16).X = 399f;
                    ((Vector2)ref vector2_16).Y = -300f;
                    ((HitBox)ref hitBox4).Set(vector2_13, vector2_14, vector2_15, vector2_16);
                    frame8.Add(hitBox4);
                    ((Vector2)ref vector2_13).X = -400f;
                    ((Vector2)ref vector2_13).Y = -300f;
                    ((Vector2)ref vector2_14).X = -400f;
                    ((Vector2)ref vector2_14).Y = -187f;
                    ((Vector2)ref vector2_15).X = 399f;
                    ((Vector2)ref vector2_15).Y = -187f;
                    ((Vector2)ref vector2_16).X = 399f;
                    ((Vector2)ref vector2_16).Y = -300f;
                    ((HitBox)ref hitBox4).Set(vector2_13, vector2_14, vector2_15, vector2_16);
                    frame8.Add(hitBox4);
                    ((Vector2)ref vector2_13).X = -400f;
                    ((Vector2)ref vector2_13).Y = 232f;
                    ((Vector2)ref vector2_14).X = -400f;
                    ((Vector2)ref vector2_14).Y = 299f;
                    ((Vector2)ref vector2_15).X = 399f;
                    ((Vector2)ref vector2_15).Y = 299f;
                    ((Vector2)ref vector2_16).X = 399f;
                    ((Vector2)ref vector2_16).Y = 232f;
                    ((HitBox)ref hitBox4).Set(vector2_13, vector2_14, vector2_15, vector2_16);
                    frame8.Add(hitBox4);
                    ((Vector2)ref vector2_13).X = -56f;
                    ((Vector2)ref vector2_13).Y = -71f;
                    ((Vector2)ref vector2_14).X = -56f;
                    ((Vector2)ref vector2_14).Y = 123f;
                    ((Vector2)ref vector2_15).X = 80f;
                    ((Vector2)ref vector2_15).Y = 123f;
                    ((Vector2)ref vector2_16).X = 80f;
                    ((Vector2)ref vector2_16).Y = -71f;
                    ((HitBox)ref hitBox4).Set(vector2_13, vector2_14, vector2_15, vector2_16);
                    frame8.Add(hitBox4);
                    ((Vector2)ref vector2_13).X = -56f;
                    ((Vector2)ref vector2_13).Y = -202f;
                    ((Vector2)ref vector2_14).X = -56f;
                    ((Vector2)ref vector2_14).Y = -165f;
                    ((Vector2)ref vector2_15).X = 80f;
                    ((Vector2)ref vector2_15).Y = -165f;
                    ((Vector2)ref vector2_16).X = 80f;
                    ((Vector2)ref vector2_16).Y = -202f;
                    ((HitBox)ref hitBox4).Set(vector2_13, vector2_14, vector2_15, vector2_16);
                    frame8.Add(hitBox4);
                    ((Vector2)ref vector2_13).X = -56f;
                    ((Vector2)ref vector2_13).Y = 217f;
                    ((Vector2)ref vector2_14).X = -56f;
                    ((Vector2)ref vector2_14).Y = 245f;
                    ((Vector2)ref vector2_15).X = 80f;
                    ((Vector2)ref vector2_15).Y = 245f;
                    ((Vector2)ref vector2_16).X = 80f;
                    ((Vector2)ref vector2_16).Y = 217f;
                    ((HitBox)ref hitBox4).Set(vector2_13, vector2_14, vector2_15, vector2_16);
                    frame8.Add(hitBox4);
                    Animation animation8 = new Animation();
                    animation8.Add(frame8);
                    this.Add(animation8);
                    break;
                case 5:
                    Frame frame9 = new Frame();
                    frame9.Image = Game.LoadImage("../TreasureHunter/Images/Background/Level05.png");
                    Vector2 vector2_17;
                    ((Vector2)ref vector2_17).X = -400f;
                    ((Vector2)ref vector2_17).Y = -300f;
                    Vector2 vector2_18;
                    ((Vector2)ref vector2_18).X = -400f;
                    ((Vector2)ref vector2_18).Y = 299f;
                    Vector2 vector2_19;
                    ((Vector2)ref vector2_19).X = -335f;
                    ((Vector2)ref vector2_19).Y = 299f;
                    Vector2 vector2_20;
                    ((Vector2)ref vector2_20).X = -335f;
                    ((Vector2)ref vector2_20).Y = -300f;
                    HitBox hitBox5;
                    ((HitBox)ref hitBox5).Set(vector2_17, vector2_18, vector2_19, vector2_20);
                    frame9.Add(hitBox5);
                    ((Vector2)ref vector2_17).X = 330f;
                    ((Vector2)ref vector2_17).Y = -300f;
                    ((Vector2)ref vector2_18).X = 330f;
                    ((Vector2)ref vector2_18).Y = 299f;
                    ((Vector2)ref vector2_19).X = 399f;
                    ((Vector2)ref vector2_19).Y = 299f;
                    ((Vector2)ref vector2_20).X = 399f;
                    ((Vector2)ref vector2_20).Y = -300f;
                    ((HitBox)ref hitBox5).Set(vector2_17, vector2_18, vector2_19, vector2_20);
                    frame9.Add(hitBox5);
                    ((Vector2)ref vector2_17).X = -400f;
                    ((Vector2)ref vector2_17).Y = -300f;
                    ((Vector2)ref vector2_18).X = -400f;
                    ((Vector2)ref vector2_18).Y = -187f;
                    ((Vector2)ref vector2_19).X = 399f;
                    ((Vector2)ref vector2_19).Y = -187f;
                    ((Vector2)ref vector2_20).X = 399f;
                    ((Vector2)ref vector2_20).Y = -300f;
                    ((HitBox)ref hitBox5).Set(vector2_17, vector2_18, vector2_19, vector2_20);
                    frame9.Add(hitBox5);
                    ((Vector2)ref vector2_17).X = -400f;
                    ((Vector2)ref vector2_17).Y = 232f;
                    ((Vector2)ref vector2_18).X = -400f;
                    ((Vector2)ref vector2_18).Y = 299f;
                    ((Vector2)ref vector2_19).X = 399f;
                    ((Vector2)ref vector2_19).Y = 299f;
                    ((Vector2)ref vector2_20).X = 399f;
                    ((Vector2)ref vector2_20).Y = 232f;
                    ((HitBox)ref hitBox5).Set(vector2_17, vector2_18, vector2_19, vector2_20);
                    frame9.Add(hitBox5);
                    ((Vector2)ref vector2_17).X = -132f;
                    ((Vector2)ref vector2_17).Y = -188f;
                    ((Vector2)ref vector2_18).X = -132f;
                    ((Vector2)ref vector2_18).Y = 28f;
                    ((Vector2)ref vector2_19).X = -116f;
                    ((Vector2)ref vector2_19).Y = 28f;
                    ((Vector2)ref vector2_20).X = -116f;
                    ((Vector2)ref vector2_20).Y = -188f;
                    ((HitBox)ref hitBox5).Set(vector2_17, vector2_18, vector2_19, vector2_20);
                    frame9.Add(hitBox5);
                    ((Vector2)ref vector2_17).X = -132f;
                    ((Vector2)ref vector2_17).Y = 28f;
                    ((Vector2)ref vector2_18).X = -132f;
                    ((Vector2)ref vector2_18).Y = 98f;
                    ((Vector2)ref vector2_19).X = 67f;
                    ((Vector2)ref vector2_19).Y = 98f;
                    ((Vector2)ref vector2_20).X = 67f;
                    ((Vector2)ref vector2_20).Y = 28f;
                    ((HitBox)ref hitBox5).Set(vector2_17, vector2_18, vector2_19, vector2_20);
                    frame9.Add(hitBox5);
                    ((Vector2)ref vector2_17).X = -132f;
                    ((Vector2)ref vector2_17).Y = 195f;
                    ((Vector2)ref vector2_18).X = -132f;
                    ((Vector2)ref vector2_18).Y = 241f;
                    ((Vector2)ref vector2_19).X = 67f;
                    ((Vector2)ref vector2_19).Y = 241f;
                    ((Vector2)ref vector2_20).X = 67f;
                    ((Vector2)ref vector2_20).Y = 195f;
                    ((HitBox)ref hitBox5).Set(vector2_17, vector2_18, vector2_19, vector2_20);
                    frame9.Add(hitBox5);
                    ((Vector2)ref vector2_17).X = 89f;
                    ((Vector2)ref vector2_17).Y = -90f;
                    ((Vector2)ref vector2_18).X = 89f;
                    ((Vector2)ref vector2_18).Y = 45f;
                    ((Vector2)ref vector2_19).X = 237f;
                    ((Vector2)ref vector2_19).Y = 45f;
                    ((Vector2)ref vector2_20).X = 237f;
                    ((Vector2)ref vector2_20).Y = -90f;
                    ((HitBox)ref hitBox5).Set(vector2_17, vector2_18, vector2_19, vector2_20);
                    frame9.Add(hitBox5);
                    ((Vector2)ref vector2_17).X = 67f;
                    ((Vector2)ref vector2_17).Y = 28f;
                    ((Vector2)ref vector2_18).X = 67f;
                    ((Vector2)ref vector2_18).Y = 45f;
                    ((Vector2)ref vector2_19).X = 89f;
                    ((Vector2)ref vector2_19).Y = 45f;
                    ((Vector2)ref vector2_20).X = 89f;
                    ((Vector2)ref vector2_20).Y = 28f;
                    ((HitBox)ref hitBox5).Set(vector2_17, vector2_18, vector2_19, vector2_20);
                    frame9.Add(hitBox5);
                    Animation animation9 = new Animation();
                    animation9.Add(frame9);
                    this.Add(animation9);
                    break;
            }
            Game.Add((Sprite)this);
        }

        public virtual void Update(double elapsed)
        {
            ArrayList collidedSprites = Game.GetCollidedSprites((Sprite)this);
            try
            {
                foreach (Sprite sprite in collidedSprites)
                {
                    if (!sprite.m_bIsDirty)
                    {
                        bool flag = false;
                        if (sprite is XSpot)
                            checked { --((XSpot)sprite).m_nNumFrames; }
                        HitBox[] hitBoxes1 = this.HitBoxes;
                        int index1 = 0;
                        while (index1 < hitBoxes1.Length)
                        {
                            HitBox hitBox1 = hitBoxes1[index1];
                            HitBox[] hitBoxes2 = sprite.HitBoxes;
                            int index2 = 0;
                            while (index2 < hitBoxes2.Length)
                            {
                                HitBox hitBox2 = hitBoxes2[index2];
                                if (((HitBox)ref hitBox1).IntersectWith(hitBox2))
                                {
                                    Vector2 vector2 = Vector2.op_Subtraction(hitBox2.Center, hitBox1.Center);
                                    float num1 = ((Vector2)ref hitBox2.Extents).X + ((Vector2)ref hitBox1.Extents).X - Math.Abs(((Vector2)ref vector2).X);
                                    float num2 = ((Vector2)ref hitBox2.Extents).Y + ((Vector2)ref hitBox1.Extents).Y - Math.Abs(((Vector2)ref vector2).Y);
                                    if ((double)((Vector2)ref vector2).X < 0.0)
                                        ((Vector2)ref vector2).X = -1f;
                                    else if ((double)((Vector2)ref vector2).X > 0.0)
                                        ((Vector2)ref vector2).X = 1f;
                                    if ((double)((Vector2)ref vector2).Y < 0.0)
                                        ((Vector2)ref vector2).Y = -1f;
                                    else if ((double)((Vector2)ref vector2).Y > 0.0)
                                        ((Vector2)ref vector2).Y = 1f;
                                    if ((double)num2 < (double)num1)
                                        sprite.Translate(0.0f, ((Vector2)ref vector2).Y * (num2 + 1f));
                                    else
                                        sprite.Translate(((Vector2)ref vector2).X * (num1 + 1f), 0.0f);
                                    flag = true;
                                    break;
                                }
                                checked { ++index2; }
                            }
                            if (!flag)
                                checked { ++index1; }
                            else
                                break;
                        }
                    }
                }
            }
            finally
            {
                IEnumerator enumerator;
                if (enumerator is IDisposable)
                    ((IDisposable)enumerator).Dispose();
            }
        }
    }







    public class Effect : Sprite
    {
        public virtual void Update(double elapsed)
        {
            if (this.CurrentAnimation.Playing)
                return;
            Game.Remove((Sprite)this);
        }
    }








    public class Enemy : Sprite
    {
        public int m_nType;
        public int m_nPenalty;
        public int m_nNumTries;
        public int m_nState;
        public int m_nDirection;
        public double m_dIdleElapsed;
        public float m_fSpeed;
        public const int ENEMY_STATE_IDLE = 0;
        public const int ENEMY_STATE_WALK = 4;
        public const int ENEMY_DIRECTION_NORTH = 0;
        public const int ENEMY_DIRECTION_EAST = 1;
        public const int ENEMY_DIRECTION_SOUTH = 2;
        public const int ENEMY_DIRECTION_WEST = 3;
        public const int ENEMY_MAX_NUM_TRIES = 2;
        public const double ENEMY_IDLE_DURATION = 3.0;
        public const int ENEMY_TYPE_CROCODILLE = 0;
        public const int ENEMY_TYPE_MUMMY = 1;

        public Enemy() => this.m_fSpeed = 20f;

        public static Enemy Load(int EnemyType)
        {
            Enemy enemy = (Enemy)null;
            switch (EnemyType)
            {
                case 0:
                    enemy = new Enemy();
                    enemy.m_nType = EnemyType;
                    enemy.m_nPenalty = -40;
                    enemy.ZOrder = -5f;
                    enemy.m_nNumTries = 2;
                    Animation animation1 = new Animation();
                    Frame frame1 = new Frame();
                    frame1.Image = Game.LoadImage("../TreasureHunter/Images/Crocodile/North/01.png");
                    Vector2 vector2_1;
                    ((Vector2)ref vector2_1).X = -6.5f;
                    ((Vector2)ref vector2_1).Y = -49f;
                    Vector2 vector2_2;
                    ((Vector2)ref vector2_2).X = -6.5f;
                    ((Vector2)ref vector2_2).Y = -25f;
                    Vector2 vector2_3;
                    ((Vector2)ref vector2_3).X = 12.5f;
                    ((Vector2)ref vector2_3).Y = -25f;
                    Vector2 vector2_4;
                    ((Vector2)ref vector2_4).X = 12.5f;
                    ((Vector2)ref vector2_4).Y = -49f;
                    HitBox hitBox1;
                    ((HitBox)ref hitBox1).Set(vector2_1, vector2_2, vector2_3, vector2_4);
                    frame1.Add(hitBox1);
                    animation1.Add(frame1);
                    enemy.Add(animation1);
                    Animation animation2 = new Animation();
                    Frame frame2 = new Frame();
                    frame2.Image = Game.LoadImage("../TreasureHunter/Images/Crocodile/East/01.png");
                    ((Vector2)ref vector2_1).X = 19f;
                    ((Vector2)ref vector2_1).Y = -11.5f;
                    ((Vector2)ref vector2_2).X = 19f;
                    ((Vector2)ref vector2_2).Y = 11.5f;
                    ((Vector2)ref vector2_3).X = 47f;
                    ((Vector2)ref vector2_3).Y = 11.5f;
                    ((Vector2)ref vector2_4).X = 47f;
                    ((Vector2)ref vector2_4).Y = -11.5f;
                    ((HitBox)ref hitBox1).Set(vector2_1, vector2_2, vector2_3, vector2_4);
                    frame2.Add(hitBox1);
                    animation2.Add(frame2);
                    enemy.Add(animation2);
                    Animation animation3 = new Animation();
                    Frame frame3 = new Frame();
                    frame3.Image = Game.LoadImage("../TreasureHunter/Images/Crocodile/South/01.png");
                    ((Vector2)ref vector2_1).X = -15f;
                    ((Vector2)ref vector2_1).Y = 18.5f;
                    ((Vector2)ref vector2_2).X = -15f;
                    ((Vector2)ref vector2_2).Y = 48.5f;
                    ((Vector2)ref vector2_3).X = 10f;
                    ((Vector2)ref vector2_3).Y = 48.5f;
                    ((Vector2)ref vector2_4).X = 10f;
                    ((Vector2)ref vector2_4).Y = 18.5f;
                    ((HitBox)ref hitBox1).Set(vector2_1, vector2_2, vector2_3, vector2_4);
                    frame3.Add(hitBox1);
                    animation3.Add(frame3);
                    enemy.Add(animation3);
                    Animation animation4 = new Animation();
                    Frame frame4 = new Frame();
                    frame4.Image = Game.LoadImage("../TreasureHunter/Images/Crocodile/West/01.png");
                    ((Vector2)ref vector2_1).X = -48f;
                    ((Vector2)ref vector2_1).Y = -11.5f;
                    ((Vector2)ref vector2_2).X = -48f;
                    ((Vector2)ref vector2_2).Y = 11.5f;
                    ((Vector2)ref vector2_3).X = -20f;
                    ((Vector2)ref vector2_3).Y = 11.5f;
                    ((Vector2)ref vector2_4).X = -20f;
                    ((Vector2)ref vector2_4).Y = -11.5f;
                    ((HitBox)ref hitBox1).Set(vector2_1, vector2_2, vector2_3, vector2_4);
                    frame4.Add(hitBox1);
                    animation4.Add(frame4);
                    enemy.Add(animation4);
                    Animation animation5 = new Animation();
                    ((Vector2)ref vector2_1).X = -6.5f;
                    ((Vector2)ref vector2_1).Y = -49f;
                    ((Vector2)ref vector2_2).X = -6.5f;
                    ((Vector2)ref vector2_2).Y = -25f;
                    ((Vector2)ref vector2_3).X = 12.5f;
                    ((Vector2)ref vector2_3).Y = -25f;
                    ((Vector2)ref vector2_4).X = 12.5f;
                    ((Vector2)ref vector2_4).Y = -49f;
                    ((HitBox)ref hitBox1).Set(vector2_1, vector2_2, vector2_3, vector2_4);
                    int num1 = 1;
                    do
                    {
                        Frame frame5 = new Frame();
                        frame5.Image = Game.LoadImage("../TreasureHunter/Images/Crocodile/North/" + num1.ToString("D2") + ".png");
                        frame5.Add(hitBox1);
                        animation5.Add(frame5);
                        checked { ++num1; }
                    }
                    while (num1 <= 14);
                    animation5.Looping = true;
                    animation5.Duration = 2.0;
                    enemy.Add(animation5);
                    Animation animation6 = new Animation();
                    ((Vector2)ref vector2_1).X = 19f;
                    ((Vector2)ref vector2_1).Y = -11.5f;
                    ((Vector2)ref vector2_2).X = 19f;
                    ((Vector2)ref vector2_2).Y = 11.5f;
                    ((Vector2)ref vector2_3).X = 47f;
                    ((Vector2)ref vector2_3).Y = 11.5f;
                    ((Vector2)ref vector2_4).X = 47f;
                    ((Vector2)ref vector2_4).Y = -11.5f;
                    ((HitBox)ref hitBox1).Set(vector2_1, vector2_2, vector2_3, vector2_4);
                    int num2 = 1;
                    do
                    {
                        Frame frame6 = new Frame();
                        frame6.Image = Game.LoadImage("../TreasureHunter/Images/Crocodile/East/" + num2.ToString("D2") + ".png");
                        frame6.Add(hitBox1);
                        animation6.Add(frame6);
                        checked { ++num2; }
                    }
                    while (num2 <= 7);
                    animation6.Looping = true;
                    animation6.Duration = 2.0;
                    enemy.Add(animation6);
                    Animation animation7 = new Animation();
                    ((Vector2)ref vector2_1).X = -15f;
                    ((Vector2)ref vector2_1).Y = 18.5f;
                    ((Vector2)ref vector2_2).X = -15f;
                    ((Vector2)ref vector2_2).Y = 48.5f;
                    ((Vector2)ref vector2_3).X = 10f;
                    ((Vector2)ref vector2_3).Y = 48.5f;
                    ((Vector2)ref vector2_4).X = 10f;
                    ((Vector2)ref vector2_4).Y = 18.5f;
                    ((HitBox)ref hitBox1).Set(vector2_1, vector2_2, vector2_3, vector2_4);
                    int num3 = 1;
                    do
                    {
                        Frame frame7 = new Frame();
                        frame7.Image = Game.LoadImage("../TreasureHunter/Images/Crocodile/South/" + num3.ToString("D2") + ".png");
                        frame7.Add(hitBox1);
                        animation7.Add(frame7);
                        checked { ++num3; }
                    }
                    while (num3 <= 12);
                    animation7.Looping = true;
                    animation7.Duration = 2.0;
                    enemy.Add(animation7);
                    Animation animation8 = new Animation();
                    ((Vector2)ref vector2_1).X = -48f;
                    ((Vector2)ref vector2_1).Y = -11.5f;
                    ((Vector2)ref vector2_2).X = -48f;
                    ((Vector2)ref vector2_2).Y = 11.5f;
                    ((Vector2)ref vector2_3).X = -20f;
                    ((Vector2)ref vector2_3).Y = 11.5f;
                    ((Vector2)ref vector2_4).X = -20f;
                    ((Vector2)ref vector2_4).Y = -11.5f;
                    ((HitBox)ref hitBox1).Set(vector2_1, vector2_2, vector2_3, vector2_4);
                    int num4 = 1;
                    do
                    {
                        Frame frame8 = new Frame();
                        frame8.Image = Game.LoadImage("../TreasureHunter/Images/Crocodile/West/" + num4.ToString("D2") + ".png");
                        frame8.Add(hitBox1);
                        animation8.Add(frame8);
                        checked { ++num4; }
                    }
                    while (num4 <= 7);
                    animation8.Looping = true;
                    animation8.Duration = 2.0;
                    enemy.Add(animation8);
                    enemy.State = 4;
                    enemy.Direction = 0;
                    break;
                case 1:
                    enemy = new Enemy();
                    enemy.m_nType = EnemyType;
                    enemy.m_nPenalty = -40;
                    enemy.ZOrder = -5f;
                    enemy.m_nNumTries = 2;
                    Animation animation9 = new Animation();
                    Frame frame9 = new Frame();
                    frame9.Image = Game.LoadImage("../TreasureHunter/Images/Mummy/North/01.png");
                    Vector2 vector2_5;
                    ((Vector2)ref vector2_5).X = -22.5f;
                    ((Vector2)ref vector2_5).Y = -21.5f;
                    Vector2 vector2_6;
                    ((Vector2)ref vector2_6).X = -22.5f;
                    ((Vector2)ref vector2_6).Y = 11.5f;
                    Vector2 vector2_7;
                    ((Vector2)ref vector2_7).X = 21.5f;
                    ((Vector2)ref vector2_7).Y = 11.5f;
                    Vector2 vector2_8;
                    ((Vector2)ref vector2_8).X = 21.5f;
                    ((Vector2)ref vector2_8).Y = -21.5f;
                    HitBox hitBox2;
                    ((HitBox)ref hitBox2).Set(vector2_5, vector2_6, vector2_7, vector2_8);
                    frame9.Add(hitBox2);
                    animation9.Add(frame9);
                    enemy.Add(animation9);
                    Animation animation10 = new Animation();
                    Frame frame10 = new Frame();
                    frame10.Image = Game.LoadImage("../TreasureHunter/Images/Mummy/East/01.png");
                    ((Vector2)ref vector2_5).X = -27f;
                    ((Vector2)ref vector2_5).Y = -26f;
                    ((Vector2)ref vector2_6).X = -27f;
                    ((Vector2)ref vector2_6).Y = 15f;
                    ((Vector2)ref vector2_7).X = 23f;
                    ((Vector2)ref vector2_7).Y = 15f;
                    ((Vector2)ref vector2_8).X = 23f;
                    ((Vector2)ref vector2_8).Y = -26f;
                    ((HitBox)ref hitBox2).Set(vector2_5, vector2_6, vector2_7, vector2_8);
                    frame10.Add(hitBox2);
                    animation10.Add(frame10);
                    enemy.Add(animation10);
                    Animation animation11 = new Animation();
                    Frame frame11 = new Frame();
                    frame11.Image = Game.LoadImage("../TreasureHunter/Images/Mummy/South/01.png");
                    ((Vector2)ref vector2_5).X = -22f;
                    ((Vector2)ref vector2_5).Y = -24f;
                    ((Vector2)ref vector2_6).X = -22f;
                    ((Vector2)ref vector2_6).Y = 12f;
                    ((Vector2)ref vector2_7).X = 21f;
                    ((Vector2)ref vector2_7).Y = 12f;
                    ((Vector2)ref vector2_8).X = 21f;
                    ((Vector2)ref vector2_8).Y = -24f;
                    ((HitBox)ref hitBox2).Set(vector2_5, vector2_6, vector2_7, vector2_8);
                    frame11.Add(hitBox2);
                    animation11.Add(frame11);
                    enemy.Add(animation11);
                    Animation animation12 = new Animation();
                    Frame frame12 = new Frame();
                    frame12.Image = Game.LoadImage("../TreasureHunter/Images/Mummy/West/01.png");
                    ((Vector2)ref vector2_5).X = -23.5f;
                    ((Vector2)ref vector2_5).Y = -26f;
                    ((Vector2)ref vector2_6).X = -23.5f;
                    ((Vector2)ref vector2_6).Y = 15f;
                    ((Vector2)ref vector2_7).X = 26.5f;
                    ((Vector2)ref vector2_7).Y = 15f;
                    ((Vector2)ref vector2_8).X = 26.5f;
                    ((Vector2)ref vector2_8).Y = -26f;
                    ((HitBox)ref hitBox2).Set(vector2_5, vector2_6, vector2_7, vector2_8);
                    frame12.Add(hitBox2);
                    animation12.Add(frame12);
                    enemy.Add(animation12);
                    Animation animation13 = new Animation();
                    ((Vector2)ref vector2_5).X = -22.5f;
                    ((Vector2)ref vector2_5).Y = -21.5f;
                    ((Vector2)ref vector2_6).X = -22.5f;
                    ((Vector2)ref vector2_6).Y = 11.5f;
                    ((Vector2)ref vector2_7).X = 21.5f;
                    ((Vector2)ref vector2_7).Y = 11.5f;
                    ((Vector2)ref vector2_8).X = 21.5f;
                    ((Vector2)ref vector2_8).Y = -21.5f;
                    ((HitBox)ref hitBox2).Set(vector2_5, vector2_6, vector2_7, vector2_8);
                    int num5 = 1;
                    do
                    {
                        Frame frame13 = new Frame();
                        frame13.Image = Game.LoadImage("../TreasureHunter/Images/Mummy/North/" + num5.ToString("D2") + ".png");
                        frame13.Add(hitBox2);
                        animation13.Add(frame13);
                        checked { ++num5; }
                    }
                    while (num5 <= 6);
                    animation13.Looping = true;
                    animation13.Duration = 2.0;
                    enemy.Add(animation13);
                    Animation animation14 = new Animation();
                    ((Vector2)ref vector2_5).X = -27f;
                    ((Vector2)ref vector2_5).Y = -26f;
                    ((Vector2)ref vector2_6).X = -27f;
                    ((Vector2)ref vector2_6).Y = 15f;
                    ((Vector2)ref vector2_7).X = 23f;
                    ((Vector2)ref vector2_7).Y = 15f;
                    ((Vector2)ref vector2_8).X = 23f;
                    ((Vector2)ref vector2_8).Y = -26f;
                    ((HitBox)ref hitBox2).Set(vector2_5, vector2_6, vector2_7, vector2_8);
                    int num6 = 1;
                    do
                    {
                        Frame frame14 = new Frame();
                        frame14.Image = Game.LoadImage("../TreasureHunter/Images/Mummy/East/" + num6.ToString("D2") + ".png");
                        frame14.Add(hitBox2);
                        animation14.Add(frame14);
                        checked { ++num6; }
                    }
                    while (num6 <= 6);
                    animation14.Looping = true;
                    animation14.Duration = 2.0;
                    enemy.Add(animation14);
                    Animation animation15 = new Animation();
                    ((Vector2)ref vector2_5).X = -22f;
                    ((Vector2)ref vector2_5).Y = -24f;
                    ((Vector2)ref vector2_6).X = -22f;
                    ((Vector2)ref vector2_6).Y = 12f;
                    ((Vector2)ref vector2_7).X = 21f;
                    ((Vector2)ref vector2_7).Y = 12f;
                    ((Vector2)ref vector2_8).X = 21f;
                    ((Vector2)ref vector2_8).Y = -24f;
                    ((HitBox)ref hitBox2).Set(vector2_5, vector2_6, vector2_7, vector2_8);
                    int num7 = 1;
                    do
                    {
                        Frame frame15 = new Frame();
                        frame15.Image = Game.LoadImage("../TreasureHunter/Images/Mummy/South/" + num7.ToString("D2") + ".png");
                        frame15.Add(hitBox2);
                        animation15.Add(frame15);
                        checked { ++num7; }
                    }
                    while (num7 <= 7);
                    animation15.Looping = true;
                    animation15.Duration = 2.0;
                    enemy.Add(animation15);
                    Animation animation16 = new Animation();
                    ((Vector2)ref vector2_5).X = -23.5f;
                    ((Vector2)ref vector2_5).Y = -26f;
                    ((Vector2)ref vector2_6).X = -23.5f;
                    ((Vector2)ref vector2_6).Y = 15f;
                    ((Vector2)ref vector2_7).X = 26.5f;
                    ((Vector2)ref vector2_7).Y = 15f;
                    ((Vector2)ref vector2_8).X = 26.5f;
                    ((Vector2)ref vector2_8).Y = -26f;
                    ((HitBox)ref hitBox2).Set(vector2_5, vector2_6, vector2_7, vector2_8);
                    int num8 = 1;
                    do
                    {
                        Frame frame16 = new Frame();
                        frame16.Image = Game.LoadImage("../TreasureHunter/Images/Mummy/West/" + num8.ToString("D2") + ".png");
                        frame16.Add(hitBox2);
                        animation16.Add(frame16);
                        checked { ++num8; }
                    }
                    while (num8 <= 6);
                    animation16.Looping = true;
                    animation16.Duration = 2.0;
                    enemy.Add(animation16);
                    enemy.State = 4;
                    enemy.Direction = 0;
                    break;
            }
            return enemy;
        }

        public virtual void Update(double elapsed)
        {
            ArrayList collidedSprites = Game.GetCollidedSprites((Sprite)this);
            bool flag = false;
            try
            {
                foreach (Sprite sprite in collidedSprites)
                {
                    if (!sprite.m_bIsDirty & !(sprite is XSpot) & !(sprite is Hunter))
                    {
                        HitBox hitBox1 = this.HitBoxes[0];
                        HitBox[] hitBoxes = sprite.HitBoxes;
                        int index = 0;
                        while (index < hitBoxes.Length)
                        {
                            HitBox hitBox2 = hitBoxes[index];
                            if (((HitBox)ref hitBox2).IntersectWith(hitBox1))
                            {
                                Vector2 vector2 = Vector2.op_Subtraction(hitBox1.Center, hitBox2.Center);
                                float num1 = ((Vector2)ref hitBox2.Extents).X + ((Vector2)ref hitBox1.Extents).X - Math.Abs(((Vector2)ref vector2).X);
                                float num2 = ((Vector2)ref hitBox2.Extents).Y + ((Vector2)ref hitBox1.Extents).Y - Math.Abs(((Vector2)ref vector2).Y);
                                if ((double)((Vector2)ref vector2).X < 0.0)
                                    ((Vector2)ref vector2).X = -1f;
                                else if ((double)((Vector2)ref vector2).X > 0.0)
                                    ((Vector2)ref vector2).X = 1f;
                                if ((double)((Vector2)ref vector2).Y < 0.0)
                                    ((Vector2)ref vector2).Y = -1f;
                                else if ((double)((Vector2)ref vector2).Y > 0.0)
                                    ((Vector2)ref vector2).Y = 1f;
                                if ((double)num2 < (double)num1)
                                    this.Translate(0.0f, ((Vector2)ref vector2).Y * (num2 + 1f));
                                else
                                    this.Translate(((Vector2)ref vector2).X * (num1 + 1f), 0.0f);
                                this.State = 0;
                                this.m_dIdleElapsed = 3.0;
                                this.CurrentAnimation.Play();
                                flag = true;
                                break;
                            }
                            if (!flag)
                                checked { ++index; }
                            else
                                break;
                        }
                    }
                }
            }
            finally
            {
                IEnumerator enumerator;
                if (enumerator is IDisposable)
                    ((IDisposable)enumerator).Dispose();
            }
            switch (this.State)
            {
                case 0:
                    this.m_dIdleElapsed -= elapsed;
                    if (this.m_dIdleElapsed > 0.0)
                        break;
                    checked { --this.m_nNumTries; }
                    if (this.m_nNumTries <= 0)
                    {
                        this.m_nNumTries = 2;
                        checked { ++this.Direction; }
                    }
                    this.State = 4;
                    this.CurrentAnimation.Play();
                    break;
                case 4:
                    switch (this.Direction)
                    {
                        case 0:
                            this.Translate(0.0f, -this.m_fSpeed * (float)elapsed);
                            return;
                        case 1:
                            this.Translate(this.m_fSpeed * (float)elapsed, 0.0f);
                            return;
                        case 2:
                            this.Translate(0.0f, this.m_fSpeed * (float)elapsed);
                            return;
                        case 3:
                            this.Translate(-this.m_fSpeed * (float)elapsed, 0.0f);
                            return;
                        default:
                            return;
                    }
            }
        }

        public int State
        {
            get => this.m_nState;
            set
            {
                switch (value)
                {
                    case 0:
                    case 4:
                        this.m_nState = value;
                        this.CurrentAnimation.Stop();
                        this.CurrentIndex = checked(this.m_nState + this.m_nDirection);
                        break;
                }
            }
        }




        public int Direction
        {
            get => this.m_nDirection;
            set
            {
                switch (value)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        this.m_nDirection = value;
                        this.CurrentAnimation.Stop();
                        this.CurrentIndex = checked(this.m_nState + this.m_nDirection);
                        break;
                    default:
                        this.m_nDirection = 0;
                        this.CurrentAnimation.Stop();
                        this.CurrentIndex = checked(this.m_nState + this.m_nDirection);
                        break;
                }
            }
        }
    }





    public class HiScoresData : IComparable
    {
        public string Name;
        public int Scores;

        public int CompareTo(object obj)
        {
            if (obj is HiScoresData)
                return checked(((HiScoresData)obj).Scores - this.Scores);
            throw new ArgumentException("object is not an instance of HiScoresData class!");
        }

        public override string ToString() => this.Name + " " + this.Scores.ToString();
    }
}














public class Hunter : Player
{
    public float m_fHealthBarX;
    public float m_fHealthBarY;
    public float m_fIntervalBarX;
    public float m_fIntervalBarY;
    public Stack m_HealthBar;
    public ArrayList m_IntervalScores;
    public int m_nHighScores;
    public float m_fScoresTextX;
    public float m_fScoresTextY;
    public float m_fArtifactX;
    public float m_fArtifactY;
    public Text2D m_ScoresText;
    public bool m_bIsStunned;
    public double m_dCheckBandD;
    public ArrayList m_ScoresHistory;
    public string m_strResPath;
    public XSpot m_XSpot;
    public double m_dDiggingElapsed;
    public int m_nBagSize;
    public int m_nDirection;
    public int m_nState;
    public int m_nKeyUp;
    public int m_nKeyDown;
    public int m_nKeyRight;
    public int m_nKeyLeft;
    public double m_dGiddyElapsed;
    public TreasureHunter.TreasureHunter m_Game;
    public const float HUNTER_HEALTHBAR_VGAP = -36f;
    public const float HUNTER_INTERVALBAR_HGAP = 70f;
    public const float HUNTER_HEALTHBAR_MAXBALLS = 10f;
    public const double HUNTER_DURATION_GIDDY = 2.0;
    public const double HUNTER_DURATION_DIGGING = 2.0;
    public const double HUNTER_SPEED_NORMAL = 100.0;
    public const int HUNTER_STATE_IDLE = 0;
    public const int HUNTER_STATE_WALK = 1;
    public const int HUNTER_STATE_DIG = 2;
    public const int HUNTER_STATE_GIDDY = 3;
    public const int HUNTER_DIRECTION_NORTH = 0;
    public const int HUNTER_DIRECTION_SOUTH = 4;
    public const int HUNTER_DIRECTION_EAST = 8;
    public const int HUNTER_DIRECTION_WEST = 12;
    public const int HUNTER_BAGSIZE_SMALL = 0;
    public const int HUNTER_BAGSIZE_MEDIUM = 16;
    public const int HUNTER_BAGSIZE_LARGE = 32;

    public Hunter()
    {
        this.m_fHealthBarX = -369f;
        this.m_fHealthBarY = 188f;
        this.m_fIntervalBarX = -320f;
        this.m_fIntervalBarY = 188f;
        this.m_HealthBar = new Stack();
        this.m_fScoresTextX = -205f;
        this.m_fScoresTextY = -256f;
        this.m_fArtifactX = -269f;
        this.m_fArtifactY = -239f;
        this.m_bIsStunned = false;
        this.m_dCheckBandD = 0.0;
        this.m_nBagSize = 0;
        this.m_nDirection = 0;
        this.m_nState = 0;
        this.m_nKeyUp = 89;
        this.m_nKeyDown = 72;
        this.m_nKeyRight = 74;
        this.m_nKeyLeft = 71;
        this.m_dGiddyElapsed = 0.0;
        this.m_ScoresHistory = new ArrayList();
        this.m_IntervalScores = new ArrayList();
        this.m_strResPath = "../TreasureHunter/Images/HunterA/";
    }

    public void Initialize()
    {
        ((Sprite)this).m_Animations.Clear();
        Vector2 vector2_1;
        ((Vector2)ref vector2_1).X = -17f;
        ((Vector2)ref vector2_1).Y = -17f;
        Vector2 vector2_2;
        ((Vector2)ref vector2_2).X = -17f;
        ((Vector2)ref vector2_2).Y = 11f;
        Vector2 vector2_3;
        ((Vector2)ref vector2_3).X = 17f;
        ((Vector2)ref vector2_3).Y = 11f;
        Vector2 vector2_4;
        ((Vector2)ref vector2_4).X = 17f;
        ((Vector2)ref vector2_4).Y = -17f;
        HitBox hitBox;
        ((HitBox)ref hitBox).Set(vector2_1, vector2_2, vector2_3, vector2_4);
        Animation animation1 = new Animation();
        Frame frame1 = new Frame();
        frame1.Image = Game.LoadImage(this.m_strResPath + "SmallBag/North/Walk/01.png");
        frame1.Add(hitBox);
        animation1.Add(frame1);
        ((Sprite)this).Add(animation1);
        Animation animation2 = new Animation();
        int num1 = 1;
        do
        {
            Frame frame2 = new Frame();
            switch (num1)
            {
                case 1:
                case 5:
                case 9:
                    frame2.Image = Game.LoadImage(this.m_strResPath + "SmallBag/North/Walk/01.png");
                    break;
                case 4:
                    frame2.Image = Game.LoadImage(this.m_strResPath + "SmallBag/North/Walk/03.png");
                    break;
                case 8:
                    frame2.Image = Game.LoadImage(this.m_strResPath + "SmallBag/North/Walk/07.png");
                    break;
                default:
                    frame2.Image = Game.LoadImage(this.m_strResPath + "SmallBag/North/Walk/" + num1.ToString("D2") + ".png");
                    break;
            }
            frame2.Add(hitBox);
            animation2.Add(frame2);
            checked { ++num1; }
        }
        while (num1 <= 9);
        animation2.Duration = 1.0;
        animation2.Looping = true;
        ((Sprite)this).Add(animation2);
        Animation animation3 = new Animation();
        int num2 = 1;
        do
        {
            Frame frame3 = new Frame();
            switch (num2)
            {
                case 5:
                    frame3.Image = Game.LoadImage(this.m_strResPath + "SmallBag/North/Dig/04.png");
                    break;
                case 8:
                    frame3.Image = Game.LoadImage(this.m_strResPath + "SmallBag/North/Dig/07.png");
                    break;
                default:
                    frame3.Image = Game.LoadImage(this.m_strResPath + "SmallBag/North/Dig/" + num2.ToString("D2") + ".png");
                    break;
            }
            animation3.Add(frame3);
            checked { ++num2; }
        }
        while (num2 <= 8);
        animation3.Duration = 1.0;
        animation3.Looping = true;
        ((Sprite)this).Add(animation3);
        Animation animation4 = new Animation();
        int num3 = 1;
        do
        {
            animation4.Add(new Frame()
            {
                Image = Game.LoadImage(this.m_strResPath + "SmallBag/North/Giddy/" + num3.ToString("D2") + ".png")
            });
            checked { ++num3; }
        }
        while (num3 <= 8);
        animation4.Duration = 1.0;
        animation4.Looping = true;
        ((Sprite)this).Add(animation4);
        ((Vector2)ref vector2_1).X = -17.5f;
        ((Vector2)ref vector2_1).Y = -16.5f;
        ((Vector2)ref vector2_2).X = -17.5f;
        ((Vector2)ref vector2_2).Y = 9.5f;
        ((Vector2)ref vector2_3).X = 15.5f;
        ((Vector2)ref vector2_3).Y = 9.5f;
        ((Vector2)ref vector2_4).X = 15.5f;
        ((Vector2)ref vector2_4).Y = -16.5f;
        ((HitBox)ref hitBox).Set(vector2_1, vector2_2, vector2_3, vector2_4);
        Animation animation5 = new Animation();
        Frame frame4 = new Frame();
        frame4.Image = Game.LoadImage(this.m_strResPath + "SmallBag/South/Walk/01.png");
        frame4.Add(hitBox);
        animation5.Add(frame4);
        ((Sprite)this).Add(animation5);
        Animation animation6 = new Animation();
        int num4 = 1;
        do
        {
            Frame frame5 = new Frame();
            switch (num4)
            {
                case 1:
                case 5:
                case 9:
                    frame5.Image = Game.LoadImage(this.m_strResPath + "SmallBag/South/Walk/01.png");
                    break;
                case 4:
                    frame5.Image = Game.LoadImage(this.m_strResPath + "SmallBag/South/Walk/03.png");
                    break;
                case 8:
                    frame5.Image = Game.LoadImage(this.m_strResPath + "SmallBag/South/Walk/07.png");
                    break;
                default:
                    frame5.Image = Game.LoadImage(this.m_strResPath + "SmallBag/South/Walk/" + num4.ToString("D2") + ".png");
                    break;
            }
            frame5.Add(hitBox);
            animation6.Add(frame5);
            checked { ++num4; }
        }
        while (num4 <= 9);
        animation6.Duration = 1.0;
        animation6.Looping = true;
        ((Sprite)this).Add(animation6);
        Animation animation7 = new Animation();
        int num5 = 1;
        do
        {
            Frame frame6 = new Frame();
            switch (num5)
            {
                case 5:
                    frame6.Image = Game.LoadImage(this.m_strResPath + "SmallBag/South/Dig/04.png");
                    break;
                case 8:
                    frame6.Image = Game.LoadImage(this.m_strResPath + "SmallBag/South/Dig/07.png");
                    break;
                default:
                    frame6.Image = Game.LoadImage(this.m_strResPath + "SmallBag/South/Dig/" + num5.ToString("D2") + ".png");
                    break;
            }
            animation7.Add(frame6);
            checked { ++num5; }
        }
        while (num5 <= 8);
        animation7.Duration = 1.0;
        animation7.Looping = true;
        ((Sprite)this).Add(animation7);
        Animation animation8 = new Animation();
        int num6 = 1;
        do
        {
            animation8.Add(new Frame()
            {
                Image = Game.LoadImage(this.m_strResPath + "SmallBag/South/Giddy/" + num6.ToString("D2") + ".png")
            });
            checked { ++num6; }
        }
        while (num6 <= 8);
        animation8.Duration = 1.0;
        animation8.Looping = true;
        ((Sprite)this).Add(animation8);
        ((Vector2)ref vector2_1).X = -14f;
        ((Vector2)ref vector2_1).Y = -17.5f;
        ((Vector2)ref vector2_2).X = -14f;
        ((Vector2)ref vector2_2).Y = 15.5f;
        ((Vector2)ref vector2_3).X = 12f;
        ((Vector2)ref vector2_3).Y = 15.5f;
        ((Vector2)ref vector2_4).X = 12f;
        ((Vector2)ref vector2_4).Y = -17.5f;
        ((HitBox)ref hitBox).Set(vector2_1, vector2_2, vector2_3, vector2_4);
        Animation animation9 = new Animation();
        Frame frame7 = new Frame();
        frame7.Image = Game.LoadImage(this.m_strResPath + "SmallBag/East/Walk/01.png");
        frame7.Add(hitBox);
        animation9.Add(frame7);
        ((Sprite)this).Add(animation9);
        Animation animation10 = new Animation();
        int num7 = 1;
        do
        {
            Frame frame8 = new Frame();
            switch (num7)
            {
                case 1:
                case 5:
                case 9:
                    frame8.Image = Game.LoadImage(this.m_strResPath + "SmallBag/East/Walk/01.png");
                    break;
                case 4:
                    frame8.Image = Game.LoadImage(this.m_strResPath + "SmallBag/East/Walk/03.png");
                    break;
                case 8:
                    frame8.Image = Game.LoadImage(this.m_strResPath + "SmallBag/East/Walk/07.png");
                    break;
                default:
                    frame8.Image = Game.LoadImage(this.m_strResPath + "SmallBag/East/Walk/" + num7.ToString("D2") + ".png");
                    break;
            }
            frame8.Add(hitBox);
            animation10.Add(frame8);
            checked { ++num7; }
        }
        while (num7 <= 9);
        animation10.Duration = 1.0;
        animation10.Looping = true;
        ((Sprite)this).Add(animation10);
        Animation animation11 = new Animation();
        int num8 = 1;
        do
        {
            Frame frame9 = new Frame();
            switch (num8)
            {
                case 5:
                    frame9.Image = Game.LoadImage(this.m_strResPath + "SmallBag/East/Dig/04.png");
                    break;
                case 8:
                    frame9.Image = Game.LoadImage(this.m_strResPath + "SmallBag/East/Dig/07.png");
                    break;
                default:
                    frame9.Image = Game.LoadImage(this.m_strResPath + "SmallBag/East/Dig/" + num8.ToString("D2") + ".png");
                    break;
            }
            animation11.Add(frame9);
            checked { ++num8; }
        }
        while (num8 <= 8);
        animation11.Duration = 1.0;
        animation11.Looping = true;
        ((Sprite)this).Add(animation11);
        Animation animation12 = new Animation();
        int num9 = 1;
        do
        {
            animation12.Add(new Frame()
            {
                Image = Game.LoadImage(this.m_strResPath + "SmallBag/East/Giddy/" + num9.ToString("D2") + ".png")
            });
            checked { ++num9; }
        }
        while (num9 <= 8);
        animation12.Duration = 1.0;
        animation12.Looping = true;
        ((Sprite)this).Add(animation12);
        ((Vector2)ref vector2_1).X = -15f;
        ((Vector2)ref vector2_1).Y = -17.5f;
        ((Vector2)ref vector2_2).X = -15f;
        ((Vector2)ref vector2_2).Y = 16.5f;
        ((Vector2)ref vector2_3).X = 12f;
        ((Vector2)ref vector2_3).Y = 16.5f;
        ((Vector2)ref vector2_4).X = 12f;
        ((Vector2)ref vector2_4).Y = -17.5f;
        ((HitBox)ref hitBox).Set(vector2_1, vector2_2, vector2_3, vector2_4);
        Animation animation13 = new Animation();
        Frame frame10 = new Frame();
        frame10.Image = Game.LoadImage(this.m_strResPath + "SmallBag/West/Walk/01.png");
        frame10.Add(hitBox);
        animation13.Add(frame10);
        ((Sprite)this).Add(animation13);
        Animation animation14 = new Animation();
        int num10 = 1;
        do
        {
            Frame frame11 = new Frame();
            switch (num10)
            {
                case 1:
                case 5:
                case 9:
                    frame11.Image = Game.LoadImage(this.m_strResPath + "SmallBag/West/Walk/01.png");
                    break;
                case 4:
                    frame11.Image = Game.LoadImage(this.m_strResPath + "SmallBag/West/Walk/03.png");
                    break;
                case 8:
                    frame11.Image = Game.LoadImage(this.m_strResPath + "SmallBag/West/Walk/07.png");
                    break;
                default:
                    frame11.Image = Game.LoadImage(this.m_strResPath + "SmallBag/West/Walk/" + num10.ToString("D2") + ".png");
                    break;
            }
            frame11.Add(hitBox);
            animation14.Add(frame11);
            checked { ++num10; }
        }
        while (num10 <= 9);
        animation14.Duration = 1.0;
        animation14.Looping = true;
        ((Sprite)this).Add(animation14);
        Animation animation15 = new Animation();
        int num11 = 1;
        do
        {
            Frame frame12 = new Frame();
            switch (num11)
            {
                case 5:
                    frame12.Image = Game.LoadImage(this.m_strResPath + "SmallBag/West/Dig/04.png");
                    break;
                case 8:
                    frame12.Image = Game.LoadImage(this.m_strResPath + "SmallBag/West/Dig/07.png");
                    break;
                default:
                    frame12.Image = Game.LoadImage(this.m_strResPath + "SmallBag/West/Dig/" + num11.ToString("D2") + ".png");
                    break;
            }
            animation15.Add(frame12);
            checked { ++num11; }
        }
        while (num11 <= 8);
        animation15.Duration = 1.0;
        animation15.Looping = true;
        ((Sprite)this).Add(animation15);
        Animation animation16 = new Animation();
        int num12 = 1;
        do
        {
            animation16.Add(new Frame()
            {
                Image = Game.LoadImage(this.m_strResPath + "SmallBag/West/Giddy/" + num12.ToString("D2") + ".png")
            });
            checked { ++num12; }
        }
        while (num12 <= 8);
        animation16.Duration = 1.0;
        animation16.Looping = true;
        ((Sprite)this).Add(animation16);
        ((Vector2)ref vector2_1).X = -17f;
        ((Vector2)ref vector2_1).Y = -19.5f;
        ((Vector2)ref vector2_2).X = -17f;
        ((Vector2)ref vector2_2).Y = 9.5f;
        ((Vector2)ref vector2_3).X = 17f;
        ((Vector2)ref vector2_3).Y = 9.5f;
        ((Vector2)ref vector2_4).X = 17f;
        ((Vector2)ref vector2_4).Y = -19.5f;
        ((HitBox)ref hitBox).Set(vector2_1, vector2_2, vector2_3, vector2_4);
        Animation animation17 = new Animation();
        Frame frame13 = new Frame();
        frame13.Image = Game.LoadImage(this.m_strResPath + "MediumBag/North/Walk/01.png");
        frame13.Add(hitBox);
        animation17.Add(frame13);
        ((Sprite)this).Add(animation17);
        Animation animation18 = new Animation();
        int num13 = 1;
        do
        {
            Frame frame14 = new Frame();
            switch (num13)
            {
                case 1:
                case 5:
                case 9:
                    frame14.Image = Game.LoadImage(this.m_strResPath + "MediumBag/North/Walk/01.png");
                    break;
                case 4:
                    frame14.Image = Game.LoadImage(this.m_strResPath + "MediumBag/North/Walk/03.png");
                    break;
                case 8:
                    frame14.Image = Game.LoadImage(this.m_strResPath + "MediumBag/North/Walk/07.png");
                    break;
                default:
                    frame14.Image = Game.LoadImage(this.m_strResPath + "MediumBag/North/Walk/" + num13.ToString("D2") + ".png");
                    break;
            }
            frame14.Add(hitBox);
            animation18.Add(frame14);
            checked { ++num13; }
        }
        while (num13 <= 9);
        animation18.Duration = 1.0;
        animation18.Looping = true;
        ((Sprite)this).Add(animation18);
        Animation animation19 = new Animation();
        int num14 = 1;
        do
        {
            Frame frame15 = new Frame();
            switch (num14)
            {
                case 5:
                    frame15.Image = Game.LoadImage(this.m_strResPath + "MediumBag/North/Dig/04.png");
                    break;
                case 8:
                    frame15.Image = Game.LoadImage(this.m_strResPath + "MediumBag/North/Dig/07.png");
                    break;
                default:
                    frame15.Image = Game.LoadImage(this.m_strResPath + "MediumBag/North/Dig/" + num14.ToString("D2") + ".png");
                    break;
            }
            animation19.Add(frame15);
            checked { ++num14; }
        }
        while (num14 <= 8);
        animation19.Duration = 1.0;
        animation19.Looping = true;
        ((Sprite)this).Add(animation19);
        Animation animation20 = new Animation();
        int num15 = 1;
        do
        {
            animation20.Add(new Frame()
            {
                Image = Game.LoadImage(this.m_strResPath + "MediumBag/North/Giddy/" + num15.ToString("D2") + ".png")
            });
            checked { ++num15; }
        }
        while (num15 <= 8);
        animation20.Duration = 1.0;
        animation20.Looping = true;
        ((Sprite)this).Add(animation20);
        ((Vector2)ref vector2_1).X = -16.5f;
        ((Vector2)ref vector2_1).Y = -11.5f;
        ((Vector2)ref vector2_2).X = -16.5f;
        ((Vector2)ref vector2_2).Y = 16.5f;
        ((Vector2)ref vector2_3).X = 16.5f;
        ((Vector2)ref vector2_3).Y = 16.5f;
        ((Vector2)ref vector2_4).X = 16.5f;
        ((Vector2)ref vector2_4).Y = -11.5f;
        ((HitBox)ref hitBox).Set(vector2_1, vector2_2, vector2_3, vector2_4);
        Animation animation21 = new Animation();
        Frame frame16 = new Frame();
        frame16.Image = Game.LoadImage(this.m_strResPath + "MediumBag/South/Walk/01.png");
        frame16.Add(hitBox);
        animation21.Add(frame16);
        ((Sprite)this).Add(animation21);
        Animation animation22 = new Animation();
        int num16 = 1;
        do
        {
            Frame frame17 = new Frame();
            switch (num16)
            {
                case 1:
                case 5:
                case 9:
                    frame17.Image = Game.LoadImage(this.m_strResPath + "MediumBag/South/Walk/01.png");
                    break;
                case 4:
                    frame17.Image = Game.LoadImage(this.m_strResPath + "MediumBag/South/Walk/03.png");
                    break;
                case 8:
                    frame17.Image = Game.LoadImage(this.m_strResPath + "MediumBag/South/Walk/07.png");
                    break;
                default:
                    frame17.Image = Game.LoadImage(this.m_strResPath + "MediumBag/South/Walk/" + num16.ToString("D2") + ".png");
                    break;
            }
            frame17.Add(hitBox);
            animation22.Add(frame17);
            checked { ++num16; }
        }
        while (num16 <= 9);
        animation22.Duration = 1.0;
        animation22.Looping = true;
        ((Sprite)this).Add(animation22);
        Animation animation23 = new Animation();
        int num17 = 1;
        do
        {
            Frame frame18 = new Frame();
            switch (num17)
            {
                case 5:
                    frame18.Image = Game.LoadImage(this.m_strResPath + "MediumBag/South/Dig/04.png");
                    break;
                case 8:
                    frame18.Image = Game.LoadImage(this.m_strResPath + "MediumBag/South/Dig/07.png");
                    break;
                default:
                    frame18.Image = Game.LoadImage(this.m_strResPath + "MediumBag/South/Dig/" + num17.ToString("D2") + ".png");
                    break;
            }
            animation23.Add(frame18);
            checked { ++num17; }
        }
        while (num17 <= 8);
        animation23.Duration = 1.0;
        animation23.Looping = true;
        ((Sprite)this).Add(animation23);
        Animation animation24 = new Animation();
        int num18 = 1;
        do
        {
            animation24.Add(new Frame()
            {
                Image = Game.LoadImage(this.m_strResPath + "MediumBag/South/Giddy/" + num18.ToString("D2") + ".png")
            });
            checked { ++num18; }
        }
        while (num18 <= 8);
        animation24.Duration = 1.0;
        animation24.Looping = true;
        ((Sprite)this).Add(animation24);
        ((Vector2)ref vector2_1).X = -11.5f;
        ((Vector2)ref vector2_1).Y = -17.5f;
        ((Vector2)ref vector2_2).X = -11.5f;
        ((Vector2)ref vector2_2).Y = 15.5f;
        ((Vector2)ref vector2_3).X = 15.5f;
        ((Vector2)ref vector2_3).Y = 15.5f;
        ((Vector2)ref vector2_4).X = 15.5f;
        ((Vector2)ref vector2_4).Y = -17.5f;
        ((HitBox)ref hitBox).Set(vector2_1, vector2_2, vector2_3, vector2_4);
        Animation animation25 = new Animation();
        Frame frame19 = new Frame();
        frame19.Image = Game.LoadImage(this.m_strResPath + "MediumBag/East/Walk/01.png");
        frame19.Add(hitBox);
        animation25.Add(frame19);
        ((Sprite)this).Add(animation25);
        Animation animation26 = new Animation();
        int num19 = 1;
        do
        {
            Frame frame20 = new Frame();
            switch (num19)
            {
                case 1:
                case 5:
                case 9:
                    frame20.Image = Game.LoadImage(this.m_strResPath + "MediumBag/East/Walk/01.png");
                    break;
                case 4:
                    frame20.Image = Game.LoadImage(this.m_strResPath + "MediumBag/East/Walk/03.png");
                    break;
                case 8:
                    frame20.Image = Game.LoadImage(this.m_strResPath + "MediumBag/East/Walk/07.png");
                    break;
                default:
                    frame20.Image = Game.LoadImage(this.m_strResPath + "MediumBag/East/Walk/" + num19.ToString("D2") + ".png");
                    break;
            }
            frame20.Add(hitBox);
            animation26.Add(frame20);
            checked { ++num19; }
        }
        while (num19 <= 9);
        animation26.Duration = 1.0;
        animation26.Looping = true;
        ((Sprite)this).Add(animation26);
        Animation animation27 = new Animation();
        int num20 = 1;
        do
        {
            Frame frame21 = new Frame();
            switch (num20)
            {
                case 5:
                    frame21.Image = Game.LoadImage(this.m_strResPath + "MediumBag/East/Dig/04.png");
                    break;
                case 8:
                    frame21.Image = Game.LoadImage(this.m_strResPath + "MediumBag/East/Dig/07.png");
                    break;
                default:
                    frame21.Image = Game.LoadImage(this.m_strResPath + "MediumBag/East/Dig/" + num20.ToString("D2") + ".png");
                    break;
            }
            animation27.Add(frame21);
            checked { ++num20; }
        }
        while (num20 <= 8);
        animation27.Duration = 1.0;
        animation27.Looping = true;
        ((Sprite)this).Add(animation27);
        Animation animation28 = new Animation();
        int num21 = 1;
        do
        {
            animation28.Add(new Frame()
            {
                Image = Game.LoadImage(this.m_strResPath + "MediumBag/East/Giddy/" + num21.ToString("D2") + ".png")
            });
            checked { ++num21; }
        }
        while (num21 <= 8);
        animation28.Duration = 1.0;
        animation28.Looping = true;
        ((Sprite)this).Add(animation28);
        ((Vector2)ref vector2_1).X = -19f;
        ((Vector2)ref vector2_1).Y = -18.5f;
        ((Vector2)ref vector2_2).X = -19f;
        ((Vector2)ref vector2_2).Y = 14.5f;
        ((Vector2)ref vector2_3).X = 10f;
        ((Vector2)ref vector2_3).Y = 14.5f;
        ((Vector2)ref vector2_4).X = 10f;
        ((Vector2)ref vector2_4).Y = -18.5f;
        ((HitBox)ref hitBox).Set(vector2_1, vector2_2, vector2_3, vector2_4);
        Animation animation29 = new Animation();
        Frame frame22 = new Frame();
        frame22.Image = Game.LoadImage(this.m_strResPath + "MediumBag/West/Walk/01.png");
        frame22.Add(hitBox);
        animation29.Add(frame22);
        ((Sprite)this).Add(animation29);
        Animation animation30 = new Animation();
        int num22 = 1;
        do
        {
            Frame frame23 = new Frame();
            switch (num22)
            {
                case 1:
                case 5:
                case 9:
                    frame23.Image = Game.LoadImage(this.m_strResPath + "MediumBag/West/Walk/01.png");
                    break;
                case 4:
                    frame23.Image = Game.LoadImage(this.m_strResPath + "MediumBag/West/Walk/03.png");
                    break;
                case 8:
                    frame23.Image = Game.LoadImage(this.m_strResPath + "MediumBag/West/Walk/07.png");
                    break;
                default:
                    frame23.Image = Game.LoadImage(this.m_strResPath + "MediumBag/West/Walk/" + num22.ToString("D2") + ".png");
                    break;
            }
            frame23.Add(hitBox);
            animation30.Add(frame23);
            checked { ++num22; }
        }
        while (num22 <= 9);
        animation30.Duration = 1.0;
        animation30.Looping = true;
        ((Sprite)this).Add(animation30);
        Animation animation31 = new Animation();
        int num23 = 1;
        do
        {
            Frame frame24 = new Frame();
            switch (num23)
            {
                case 5:
                    frame24.Image = Game.LoadImage(this.m_strResPath + "MediumBag/West/Dig/04.png");
                    break;
                case 8:
                    frame24.Image = Game.LoadImage(this.m_strResPath + "MediumBag/West/Dig/07.png");
                    break;
                default:
                    frame24.Image = Game.LoadImage(this.m_strResPath + "MediumBag/West/Dig/" + num23.ToString("D2") + ".png");
                    break;
            }
            animation31.Add(frame24);
            checked { ++num23; }
        }
        while (num23 <= 8);
        animation31.Duration = 1.0;
        animation31.Looping = true;
        ((Sprite)this).Add(animation31);
        Animation animation32 = new Animation();
        int num24 = 1;
        do
        {
            animation32.Add(new Frame()
            {
                Image = Game.LoadImage(this.m_strResPath + "MediumBag/West/Giddy/" + num24.ToString("D2") + ".png")
            });
            checked { ++num24; }
        }
        while (num24 <= 8);
        animation32.Duration = 1.0;
        animation32.Looping = true;
        ((Sprite)this).Add(animation32);
        ((Vector2)ref vector2_1).X = -16.5f;
        ((Vector2)ref vector2_1).Y = -22.5f;
        ((Vector2)ref vector2_2).X = -16.5f;
        ((Vector2)ref vector2_2).Y = 4.5f;
        ((Vector2)ref vector2_3).X = 15.5f;
        ((Vector2)ref vector2_3).Y = 4.5f;
        ((Vector2)ref vector2_4).X = 15.5f;
        ((Vector2)ref vector2_4).Y = -22.5f;
        ((HitBox)ref hitBox).Set(vector2_1, vector2_2, vector2_3, vector2_4);
        Animation animation33 = new Animation();
        Frame frame25 = new Frame();
        frame25.Image = Game.LoadImage(this.m_strResPath + "LargeBag/North/Walk/01.png");
        frame25.Add(hitBox);
        animation33.Add(frame25);
        ((Sprite)this).Add(animation33);
        Animation animation34 = new Animation();
        int num25 = 1;
        do
        {
            Frame frame26 = new Frame();
            switch (num25)
            {
                case 1:
                case 5:
                case 9:
                    frame26.Image = Game.LoadImage(this.m_strResPath + "LargeBag/North/Walk/01.png");
                    break;
                case 4:
                    frame26.Image = Game.LoadImage(this.m_strResPath + "LargeBag/North/Walk/03.png");
                    break;
                case 8:
                    frame26.Image = Game.LoadImage(this.m_strResPath + "LargeBag/North/Walk/07.png");
                    break;
                default:
                    frame26.Image = Game.LoadImage(this.m_strResPath + "LargeBag/North/Walk/" + num25.ToString("D2") + ".png");
                    break;
            }
            frame26.Add(hitBox);
            animation34.Add(frame26);
            checked { ++num25; }
        }
        while (num25 <= 9);
        animation34.Duration = 1.0;
        animation34.Looping = true;
        ((Sprite)this).Add(animation34);
        Animation animation35 = new Animation();
        int num26 = 1;
        do
        {
            Frame frame27 = new Frame();
            switch (num26)
            {
                case 5:
                    frame27.Image = Game.LoadImage(this.m_strResPath + "LargeBag/North/Dig/04.png");
                    break;
                case 8:
                    frame27.Image = Game.LoadImage(this.m_strResPath + "LargeBag/North/Dig/07.png");
                    break;
                default:
                    frame27.Image = Game.LoadImage(this.m_strResPath + "LargeBag/North/Dig/" + num26.ToString("D2") + ".png");
                    break;
            }
            animation35.Add(frame27);
            checked { ++num26; }
        }
        while (num26 <= 8);
        animation35.Duration = 1.0;
        animation35.Looping = true;
        ((Sprite)this).Add(animation35);
        Animation animation36 = new Animation();
        int num27 = 1;
        do
        {
            animation36.Add(new Frame()
            {
                Image = Game.LoadImage(this.m_strResPath + "LargeBag/North/Giddy/" + num27.ToString("D2") + ".png")
            });
            checked { ++num27; }
        }
        while (num27 <= 8);
        animation36.Duration = 1.0;
        animation36.Looping = true;
        ((Sprite)this).Add(animation36);
        ((Vector2)ref vector2_1).X = -17f;
        ((Vector2)ref vector2_1).Y = -5f;
        ((Vector2)ref vector2_2).X = -17f;
        ((Vector2)ref vector2_2).Y = 23f;
        ((Vector2)ref vector2_3).X = 20f;
        ((Vector2)ref vector2_3).Y = 23f;
        ((Vector2)ref vector2_4).X = 20f;
        ((Vector2)ref vector2_4).Y = -5f;
        ((HitBox)ref hitBox).Set(vector2_1, vector2_2, vector2_3, vector2_4);
        Animation animation37 = new Animation();
        Frame frame28 = new Frame();
        frame28.Image = Game.LoadImage(this.m_strResPath + "LargeBag/South/Walk/01.png");
        frame28.Add(hitBox);
        animation37.Add(frame28);
        ((Sprite)this).Add(animation37);
        Animation animation38 = new Animation();
        int num28 = 1;
        do
        {
            Frame frame29 = new Frame();
            switch (num28)
            {
                case 1:
                case 5:
                case 9:
                    frame29.Image = Game.LoadImage(this.m_strResPath + "LargeBag/South/Walk/01.png");
                    break;
                case 4:
                    frame29.Image = Game.LoadImage(this.m_strResPath + "LargeBag/South/Walk/03.png");
                    break;
                case 8:
                    frame29.Image = Game.LoadImage(this.m_strResPath + "LargeBag/South/Walk/07.png");
                    break;
                default:
                    frame29.Image = Game.LoadImage(this.m_strResPath + "LargeBag/South/Walk/" + num28.ToString("D2") + ".png");
                    break;
            }
            frame29.Add(hitBox);
            animation38.Add(frame29);
            checked { ++num28; }
        }
        while (num28 <= 9);
        animation38.Duration = 1.0;
        animation38.Looping = true;
        ((Sprite)this).Add(animation38);
        Animation animation39 = new Animation();
        int num29 = 1;
        do
        {
            Frame frame30 = new Frame();
            switch (num29)
            {
                case 5:
                    frame30.Image = Game.LoadImage(this.m_strResPath + "LargeBag/South/Dig/04.png");
                    break;
                case 8:
                    frame30.Image = Game.LoadImage(this.m_strResPath + "LargeBag/South/Dig/07.png");
                    break;
                default:
                    frame30.Image = Game.LoadImage(this.m_strResPath + "LargeBag/South/Dig/" + num29.ToString("D2") + ".png");
                    break;
            }
            animation39.Add(frame30);
            checked { ++num29; }
        }
        while (num29 <= 8);
        animation39.Duration = 1.0;
        animation39.Looping = true;
        ((Sprite)this).Add(animation39);
        Animation animation40 = new Animation();
        int num30 = 1;
        do
        {
            animation40.Add(new Frame()
            {
                Image = Game.LoadImage(this.m_strResPath + "LargeBag/South/Giddy/" + num30.ToString("D2") + ".png")
            });
            checked { ++num30; }
        }
        while (num30 <= 8);
        animation40.Duration = 1.0;
        animation40.Looping = true;
        ((Sprite)this).Add(animation40);
        ((Vector2)ref vector2_1).X = -6.5f;
        ((Vector2)ref vector2_1).Y = -17.5f;
        ((Vector2)ref vector2_2).X = -6.5f;
        ((Vector2)ref vector2_2).Y = 15.5f;
        ((Vector2)ref vector2_3).X = 21.5f;
        ((Vector2)ref vector2_3).Y = 15.5f;
        ((Vector2)ref vector2_4).X = 21.5f;
        ((Vector2)ref vector2_4).Y = -17.5f;
        ((HitBox)ref hitBox).Set(vector2_1, vector2_2, vector2_3, vector2_4);
        Animation animation41 = new Animation();
        Frame frame31 = new Frame();
        frame31.Image = Game.LoadImage(this.m_strResPath + "LargeBag/East/Walk/01.png");
        frame31.Add(hitBox);
        animation41.Add(frame31);
        ((Sprite)this).Add(animation41);
        Animation animation42 = new Animation();
        int num31 = 1;
        do
        {
            Frame frame32 = new Frame();
            switch (num31)
            {
                case 1:
                case 5:
                case 9:
                    frame32.Image = Game.LoadImage(this.m_strResPath + "LargeBag/East/Walk/01.png");
                    break;
                case 4:
                    frame32.Image = Game.LoadImage(this.m_strResPath + "LargeBag/East/Walk/03.png");
                    break;
                case 8:
                    frame32.Image = Game.LoadImage(this.m_strResPath + "LargeBag/East/Walk/07.png");
                    break;
                default:
                    frame32.Image = Game.LoadImage(this.m_strResPath + "LargeBag/East/Walk/" + num31.ToString("D2") + ".png");
                    break;
            }
            frame32.Add(hitBox);
            animation42.Add(frame32);
            checked { ++num31; }
        }
        while (num31 <= 9);
        animation42.Duration = 1.0;
        animation42.Looping = true;
        ((Sprite)this).Add(animation42);
        Animation animation43 = new Animation();
        int num32 = 1;
        do
        {
            Frame frame33 = new Frame();
            switch (num32)
            {
                case 5:
                    frame33.Image = Game.LoadImage(this.m_strResPath + "LargeBag/East/Dig/04.png");
                    break;
                case 8:
                    frame33.Image = Game.LoadImage(this.m_strResPath + "LargeBag/East/Dig/07.png");
                    break;
                default:
                    frame33.Image = Game.LoadImage(this.m_strResPath + "LargeBag/East/Dig/" + num32.ToString("D2") + ".png");
                    break;
            }
            animation43.Add(frame33);
            checked { ++num32; }
        }
        while (num32 <= 8);
        animation43.Duration = 1.0;
        animation43.Looping = true;
        ((Sprite)this).Add(animation43);
        Animation animation44 = new Animation();
        int num33 = 1;
        do
        {
            animation44.Add(new Frame()
            {
                Image = Game.LoadImage(this.m_strResPath + "LargeBag/East/Giddy/" + num33.ToString("D2") + ".png")
            });
            checked { ++num33; }
        }
        while (num33 <= 8);
        animation44.Duration = 1.0;
        animation44.Looping = true;
        ((Sprite)this).Add(animation44);
        ((Vector2)ref vector2_1).X = -22.5f;
        ((Vector2)ref vector2_1).Y = -20.5f;
        ((Vector2)ref vector2_2).X = -22.5f;
        ((Vector2)ref vector2_2).Y = 15.5f;
        ((Vector2)ref vector2_3).X = 8.5f;
        ((Vector2)ref vector2_3).Y = 15.5f;
        ((Vector2)ref vector2_4).X = 8.5f;
        ((Vector2)ref vector2_4).Y = -20.5f;
        ((HitBox)ref hitBox).Set(vector2_1, vector2_2, vector2_3, vector2_4);
        Animation animation45 = new Animation();
        Frame frame34 = new Frame();
        frame34.Image = Game.LoadImage(this.m_strResPath + "LargeBag/West/Walk/01.png");
        frame34.Add(hitBox);
        animation45.Add(frame34);
        ((Sprite)this).Add(animation45);
        Animation animation46 = new Animation();
        int num34 = 1;
        do
        {
            Frame frame35 = new Frame();
            switch (num34)
            {
                case 1:
                case 5:
                case 9:
                    frame35.Image = Game.LoadImage(this.m_strResPath + "LargeBag/West/Walk/01.png");
                    break;
                case 4:
                    frame35.Image = Game.LoadImage(this.m_strResPath + "LargeBag/West/Walk/03.png");
                    break;
                case 8:
                    frame35.Image = Game.LoadImage(this.m_strResPath + "LargeBag/West/Walk/07.png");
                    break;
                default:
                    frame35.Image = Game.LoadImage(this.m_strResPath + "LargeBag/West/Walk/" + num34.ToString("D2") + ".png");
                    break;
            }
            frame35.Add(hitBox);
            animation46.Add(frame35);
            checked { ++num34; }
        }
        while (num34 <= 9);
        animation46.Duration = 1.0;
        animation46.Looping = true;
        ((Sprite)this).Add(animation46);
        Animation animation47 = new Animation();
        int num35 = 1;
        do
        {
            Frame frame36 = new Frame();
            switch (num35)
            {
                case 5:
                    frame36.Image = Game.LoadImage(this.m_strResPath + "LargeBag/West/Dig/04.png");
                    break;
                case 8:
                    frame36.Image = Game.LoadImage(this.m_strResPath + "LargeBag/West/Dig/07.png");
                    break;
                default:
                    frame36.Image = Game.LoadImage(this.m_strResPath + "LargeBag/West/Dig/" + num35.ToString("D2") + ".png");
                    break;
            }
            animation47.Add(frame36);
            checked { ++num35; }
        }
        while (num35 <= 8);
        animation47.Duration = 1.0;
        animation47.Looping = true;
        ((Sprite)this).Add(animation47);
        Animation animation48 = new Animation();
        int num36 = 1;
        do
        {
            animation48.Add(new Frame()
            {
                Image = Game.LoadImage(this.m_strResPath + "LargeBag/West/Giddy/" + num36.ToString("D2") + ".png")
            });
            checked { ++num36; }
        }
        while (num36 <= 8);
        animation48.Duration = 1.0;
        animation48.Looping = true;
        ((Sprite)this).Add(animation48);
    }

    public virtual void Update(double elapsed)
    {
        bool BandA = this.EegChannel.A_Trigger | this.EegChannel.A_Ignore;
        bool BandB = this.EegChannel.B_Trigger | this.EegChannel.B_Ignore;
        bool BandC = this.EegChannel.C_Trigger | this.EegChannel.C_Ignore;
        if (!((Sprite)this).m_bIsDirty)
        {
            ArrayList collidedSprites = Game.GetCollidedSprites((Sprite)this);
            double num1 = this.Shield(BandB);
            try
            {
                foreach (Sprite sprite in collidedSprites)
                {
                    switch (sprite)
                    {
                        case Obstacle _:
                            AudioSource audioSource1 = AudioManager.Singleton.LoadAudioSource("../TreasureHunter/Sound/Obstacles.wav");
                            audioSource1.Looping = false;
                            audioSource1.Play();
                            if (num1 <= 0.2)
                            {
                                checked { this.Scores += ((Obstacle)sprite).m_nPenalty; }
                                this.m_ScoresText.Text = this.Scores.ToString("D4");
                            }
                            if (num1 <= 0.1)
                                Game.Remove(this.Decharge());
                            HitBox hitBox1 = ((Sprite)this).HitBoxes[0];
                            HitBox[] hitBoxes1 = sprite.HitBoxes;
                            int index1 = 0;
                            while (index1 < hitBoxes1.Length)
                            {
                                HitBox hitBox2 = hitBoxes1[index1];
                                if (((HitBox)ref hitBox2).IntersectWith(hitBox1))
                                {
                                    Vector2 vector2 = Vector2.op_Subtraction(hitBox1.Center, hitBox2.Center);
                                    float num2 = ((Vector2)ref hitBox2.Extents).X + ((Vector2)ref hitBox1.Extents).X - Math.Abs(((Vector2)ref vector2).X);
                                    float num3 = ((Vector2)ref hitBox2.Extents).Y + ((Vector2)ref hitBox1.Extents).Y - Math.Abs(((Vector2)ref vector2).Y);
                                    if ((double)((Vector2)ref vector2).X < 0.0)
                                        ((Vector2)ref vector2).X = -1f;
                                    else if ((double)((Vector2)ref vector2).X > 0.0)
                                        ((Vector2)ref vector2).X = 1f;
                                    if ((double)((Vector2)ref vector2).Y < 0.0)
                                        ((Vector2)ref vector2).Y = -1f;
                                    else if ((double)((Vector2)ref vector2).Y > 0.0)
                                        ((Vector2)ref vector2).Y = 1f;
                                    if ((double)num3 < (double)num2)
                                    {
                                        ((Sprite)this).Translate(0.0f, ((Vector2)ref vector2).Y * (num3 + 1f));
                                        break;
                                    }
                                  ((Sprite)this).Translate(((Vector2)ref vector2).X * (num2 + 1f), 0.0f);
                                    break;
                                }
                                checked { ++index1; }
                            }
                            this.State = 3;
                            AudioSource audioSource2 = AudioManager.Singleton.LoadAudioSource("../TreasureHunter/Sound/Giddy.wav");
                            audioSource2.Looping = false;
                            audioSource2.Play();
                            this.m_dGiddyElapsed = 2.0;
                            ((Sprite)this).CurrentAnimation.Play();
                            goto label_73;
                        case XSpot _:
                            if (this.State == 0 & ((XSpot)sprite).m_nDiggingUnit > 0 & ((XSpot)sprite).m_Hunter == null & BandA & BandB & BandC)
                            {
                                this.m_XSpot = (XSpot)sprite;
                                this.m_XSpot.m_Hunter = this;
                                this.State = 2;
                                this.m_dDiggingElapsed = 2.0;
                                ((Sprite)this).CurrentAnimation.Play();
                                AudioSource audioSource3 = AudioManager.Singleton.LoadAudioSource("../TreasureHunter/Sound/Digging.wav");
                                audioSource3.Looping = false;
                                audioSource3.Play();
                                goto label_73;
                            }
                            else
                                continue;
                        case Enemy _:
                            if (num1 <= 0.2)
                            {
                                checked { this.Scores += ((Enemy)sprite).m_nPenalty; }
                                this.m_ScoresText.Text = this.Scores.ToString("D4");
                            }
                            if (num1 <= 0.1)
                                Game.Remove(this.Decharge());
                            if (num1 > 0.2)
                            {
                                Enemy enemy = (Enemy)sprite;
                                enemy.State = 0;
                                enemy.m_dIdleElapsed = 3.0;
                            }
                            HitBox hitBox3 = ((Sprite)this).HitBoxes[0];
                            HitBox[] hitBoxes2 = sprite.HitBoxes;
                            int index2 = 0;
                            while (index2 < hitBoxes2.Length)
                            {
                                HitBox hitBox4 = hitBoxes2[index2];
                                if (((HitBox)ref hitBox4).IntersectWith(hitBox3))
                                {
                                    Vector2 vector2 = Vector2.op_Subtraction(hitBox3.Center, hitBox4.Center);
                                    float num4 = ((Vector2)ref hitBox4.Extents).X + ((Vector2)ref hitBox3.Extents).X - Math.Abs(((Vector2)ref vector2).X);
                                    float num5 = ((Vector2)ref hitBox4.Extents).Y + ((Vector2)ref hitBox3.Extents).Y - Math.Abs(((Vector2)ref vector2).Y);
                                    if ((double)((Vector2)ref vector2).X < 0.0)
                                        ((Vector2)ref vector2).X = -1f;
                                    else if ((double)((Vector2)ref vector2).X > 0.0)
                                        ((Vector2)ref vector2).X = 1f;
                                    if ((double)((Vector2)ref vector2).Y < 0.0)
                                        ((Vector2)ref vector2).Y = -1f;
                                    else if ((double)((Vector2)ref vector2).Y > 0.0)
                                        ((Vector2)ref vector2).Y = 1f;
                                    if ((double)num5 < (double)num4)
                                    {
                                        ((Sprite)this).Translate(0.0f, ((Vector2)ref vector2).Y * (num5 + 1f));
                                        break;
                                    }
                                  ((Sprite)this).Translate(((Vector2)ref vector2).X * (num4 + 1f), 0.0f);
                                    break;
                                }
                                checked { ++index2; }
                            }
                            this.State = 3;
                            AudioSource audioSource4 = AudioManager.Singleton.LoadAudioSource("../TreasureHunter/Sound/Giddy.wav");
                            audioSource4.Looping = false;
                            audioSource4.Play();
                            AudioSource audioSource5 = AudioManager.Singleton.LoadAudioSource("../TreasureHunter/Sound/Enemies.wav");
                            audioSource5.Looping = false;
                            audioSource5.Play();
                            this.m_dGiddyElapsed = 2.0;
                            ((Sprite)this).CurrentAnimation.Play();
                            goto label_73;
                        case Hunter _:
                            Hunter hunter = (Hunter)sprite;
                            if (num1 <= 0.2)
                            {
                                checked { this.Scores -= 30; }
                                this.m_ScoresText.Text = this.Scores.ToString("D4");
                            }
                            double num6 = hunter.Shield(hunter.EegChannel.B_Trigger);
                            if (num6 <= 0.2)
                            {
                                checked { hunter.Scores -= 30; }
                                hunter.m_ScoresText.Text = hunter.Scores.ToString("D4");
                            }
                            if (num1 <= 0.1)
                                Game.Remove(this.Decharge());
                            if (num6 <= 0.1)
                                Game.Remove(hunter.Decharge());
                            HitBox hitBox5 = ((Sprite)this).HitBoxes[0];
                            HitBox hitBox6 = ((Sprite)hunter).HitBoxes[0];
                            Vector2 vector2_1 = Vector2.op_Subtraction(hitBox5.Center, hitBox6.Center);
                            float num7 = ((Vector2)ref hitBox6.Extents).X + ((Vector2)ref hitBox5.Extents).X - Math.Abs(((Vector2)ref vector2_1).X);
                            float num8 = ((Vector2)ref hitBox6.Extents).Y + ((Vector2)ref hitBox5.Extents).Y - Math.Abs(((Vector2)ref vector2_1).Y);
                            if ((double)((Vector2)ref vector2_1).X < 0.0)
                                ((Vector2)ref vector2_1).X = -1f;
                            else if ((double)((Vector2)ref vector2_1).X > 0.0)
                                ((Vector2)ref vector2_1).X = 1f;
                            if ((double)((Vector2)ref vector2_1).Y < 0.0)
                                ((Vector2)ref vector2_1).Y = -1f;
                            else if ((double)((Vector2)ref vector2_1).Y > 0.0)
                                ((Vector2)ref vector2_1).Y = 1f;
                            if ((double)num8 < (double)num7)
                                ((Sprite)this).Translate(0.0f, ((Vector2)ref vector2_1).Y * (num8 + 1f));
                            else
                                ((Sprite)this).Translate(((Vector2)ref vector2_1).X * (num7 + 1f), 0.0f);
                            this.State = 3;
                            hunter.State = 3;
                            AudioSource audioSource6 = AudioManager.Singleton.LoadAudioSource("../TreasureHunter/Sound/Giddy.wav");
                            audioSource6.Looping = false;
                            audioSource6.Play();
                            AudioSource audioSource7 = AudioManager.Singleton.LoadAudioSource("../TreasureHunter/Sound/Giddy.wav");
                            audioSource7.Looping = false;
                            audioSource7.Play();
                            AudioSource audioSource8 = AudioManager.Singleton.LoadAudioSource("../TreasureHunter/Sound/Enemies.wav");
                            audioSource8.Looping = false;
                            audioSource8.Play();
                            this.m_dGiddyElapsed = 2.0;
                            hunter.m_dGiddyElapsed = 2.0;
                            ((Sprite)this).CurrentAnimation.Play();
                            ((Sprite)hunter).CurrentAnimation.Play();
                            goto label_73;
                        default:
                            continue;
                    }
                }
            }
            finally
            {
                IEnumerator enumerator;
                if (enumerator is IDisposable)
                    ((IDisposable)enumerator).Dispose();
            }
        }
    label_73:
        if (this.m_nScores >= 1200 & this.m_nBagSize != 32)
        {
            this.BagSize = 32;
            ((Sprite)this).CurrentAnimation.Play();
            AudioSource audioSource = AudioManager.Singleton.LoadAudioSource("../TreasureHunter/Sound/Transition.wav");
            audioSource.Looping = false;
            audioSource.Play();
        }
        else if (this.m_nScores < 1200 & this.m_nScores >= 800 & this.m_nBagSize != 16)
        {
            this.BagSize = 16;
            ((Sprite)this).CurrentAnimation.Play();
            AudioSource audioSource = AudioManager.Singleton.LoadAudioSource("../TreasureHunter/Sound/Transition.wav");
            audioSource.Looping = false;
            audioSource.Play();
        }
        switch (this.State)
        {
            case 0:
            case 1:
                Vector2 vector2_2;
                if (Keyboard.IsKeyPressed(this.m_nKeyUp))
                {
                    if (this.Direction != 0)
                    {
                        this.Direction = 0;
                        ((Sprite)this).CurrentAnimation.Play();
                    }
                  ((Vector2)ref vector2_2).Set(0.0f, (float)(-this.Speed(BandC) * elapsed));
                }
                else if (Keyboard.IsKeyPressed(this.m_nKeyDown))
                {
                    if (this.Direction != 4)
                    {
                        this.Direction = 4;
                        ((Sprite)this).CurrentAnimation.Play();
                    }
                  ((Vector2)ref vector2_2).Set(0.0f, (float)(this.Speed(BandC) * elapsed));
                }
                else if (Keyboard.IsKeyPressed(this.m_nKeyLeft))
                {
                    if (this.Direction != 12)
                    {
                        this.Direction = 12;
                        ((Sprite)this).CurrentAnimation.Play();
                    }
                  ((Vector2)ref vector2_2).Set((float)(-this.Speed(BandC) * elapsed), 0.0f);
                }
                else if (Keyboard.IsKeyPressed(this.m_nKeyRight))
                {
                    if (this.Direction != 8)
                    {
                        this.Direction = 8;
                        ((Sprite)this).CurrentAnimation.Play();
                    }
                  ((Vector2)ref vector2_2).Set((float)(this.Speed(BandC) * elapsed), 0.0f);
                }
                else if (this.State != 0)
                {
                    this.State = 0;
                    ((Sprite)this).CurrentAnimation.Play();
                }
                if (!((double)((Vector2)ref vector2_2).X != 0.0 | (double)((Vector2)ref vector2_2).Y != 0.0))
                    break;
                if (this.State != 1)
                {
                    this.State = 1;
                    ((Sprite)this).CurrentAnimation.Play();
                }
            ((Sprite)this).Translate(((Vector2)ref vector2_2).X, ((Vector2)ref vector2_2).Y);
                break;
            case 2:
                this.m_dDiggingElapsed -= elapsed;
                if (this.m_dDiggingElapsed > 0.0)
                    break;
                checked { this.m_XSpot.m_nDiggingUnit -= this.DiggingUnit(BandA); }
                if (this.m_XSpot.m_nDiggingUnit <= 0)
                {
                    Game.Remove((Sprite)this.m_XSpot);
                    this.m_Game.GenerateXSpot();
                    checked { this.Scores += this.m_XSpot.m_nPoints; }
                    this.m_ScoresText.Text = this.Scores.ToString("D4");
                    Sprite sprite = XSpot.LoadArtifact(this.m_XSpot.m_nArtifact);
                    sprite.Translate(this.m_fArtifactX, this.m_fArtifactY);
                    sprite.CurrentAnimation.Duration = 2.0;
                    sprite.CurrentAnimation.Play();
                    AudioSource audioSource = AudioManager.Singleton.LoadAudioSource("../TreasureHunter/Sound/Treasure.wav");
                    audioSource.Looping = false;
                    audioSource.Play();
                    Game.Add(sprite);
                }
                this.State = 0;
                this.m_XSpot.m_Hunter = (Hunter)null;
                this.m_XSpot = (XSpot)null;
                break;
            case 3:
                if (this.m_dGiddyElapsed > 0.0)
                    this.m_dGiddyElapsed -= elapsed;
                if (this.m_dGiddyElapsed > 0.0)
                    break;
                if (this.m_bIsStunned)
                {
                    this.m_dCheckBandD -= elapsed;
                    if (this.m_dCheckBandD > 0.0)
                        break;
                    if (this.EegChannel.D_Trigger | this.EegChannel.D_Ignore)
                    {
                        Sprite sprite = this.Charge();
                        if (sprite == null)
                        {
                            this.m_bIsStunned = false;
                        }
                        else
                        {
                            Game.Add(sprite);
                            AudioSource audioSource = AudioManager.Singleton.LoadAudioSource("../TreasureHunter/Sound/ChargeUp.wav");
                            audioSource.Looping = false;
                            audioSource.Play();
                        }
                    }
                    this.m_dCheckBandD = 0.5;
                    break;
                }
                if (this.m_HealthBar.Count <= 0)
                {
                    this.m_bIsStunned = true;
                    this.m_dCheckBandD = 0.0;
                    break;
                }
                this.State = 0;
                ((Sprite)this).CurrentAnimation.Play();
                break;
        }
    }

    public int DiggingUnit(bool BandA)
    {
        bool flag = !BandA ? this.EegChannel.A_Value >= this.EegChannel.A_Threshold : this.EegChannel.A_Value < this.EegChannel.A_Threshold;
        double num1 = this.EegChannel.A_Value / this.EegChannel.A_Threshold;
        double num2 = !flag ? num1 - 1.0 : 1.0 - num1;
        if (num2 > 0.2)
            return 4;
        return num2 > 0.1 ? 2 : 1;
    }

    public ArrayList IntervalBars()
    {
        ArrayList arrayList = new ArrayList();
        float fIntervalBarX = this.m_fIntervalBarX;
        try
        {
            foreach (object intervalScore in this.m_IntervalScores)
            {
                int num1 = IntegerType.FromObject(intervalScore);
                if (this.m_nHighScores <= 0 | num1 <= 0)
                {
                    arrayList.Add((object)null);
                }
                else
                {
                    float num2 = -36f;
                    int num3 = checked((int)Math.Round(unchecked((double)checked(num1 * 10) / (double)this.m_nHighScores)));
                    if (num3 > 0)
                    {
                        Sprite sprite1 = new Sprite();
                        sprite1.ZOrder = -9f;
                        Animation animation = new Animation();
                        animation.Add(new Frame()
                        {
                            Image = Game.LoadImage(this.m_strResPath + "HealthBar/Ball.png")
                        });
                        sprite1.Add(animation);
                        sprite1.Translate(fIntervalBarX, this.m_fIntervalBarY);
                        arrayList.Add((object)sprite1);
                        int num4 = checked(num3 - 1);
                        while (num4 > 0)
                        {
                            Sprite sprite2 = (Sprite)sprite1.Clone();
                            sprite2.m_fOffsetX = 0.0f;
                            sprite2.m_fOffsetY = num2;
                            sprite2.MarkDirty();
                            sprite1.Add(sprite2);
                            num2 += -36f;
                            checked { --num4; }
                        }
                        Game.Add(sprite1);
                    }
                    else
                        arrayList.Add((object)null);
                }
                fIntervalBarX += 70f;
            }
        }
        finally
        {
            IEnumerator enumerator;
            if (enumerator is IDisposable)
                ((IDisposable)enumerator).Dispose();
        }
        return arrayList;
    }

    public double Speed(bool BandC)
    {
        if (!BandC)
            return 100.0;
        bool flag = this.EegChannel.C_Value < this.EegChannel.C_Threshold;
        double num1 = this.EegChannel.C_Value / this.EegChannel.C_Threshold;
        double num2 = !flag ? num1 - 1.0 : 1.0 - num1;
        if (num2 > 0.2)
            return 130.0;
        return num2 > 0.1 ? 120.0 : 110.00000000000001;
    }

    public double Shield(bool BandB)
    {
        if (!BandB)
            return 0.0;
        bool flag = this.EegChannel.B_Value < this.EegChannel.B_Threshold;
        double num = this.EegChannel.B_Value / this.EegChannel.B_Threshold;
        return !flag ? num - 1.0 : 1.0 - num;
    }

    public Sprite Charge()
    {
        if ((double)this.m_HealthBar.Count >= 10.0)
            return (Sprite)null;
        Animation animation = new Animation();
        animation.Add(new Frame()
        {
            Image = Game.LoadImage(this.m_strResPath + "HealthBar/Ball.png")
        });
        Sprite sprite = new Sprite();
        sprite.Add(animation);
        sprite.ZOrder = -9f;
        sprite.m_fOffsetX = this.m_fHealthBarX;
        sprite.m_fOffsetY = this.m_fHealthBarY + -36f * (float)this.m_HealthBar.Count;
        sprite.MarkDirty();
        this.m_HealthBar.Push((object)sprite);
        return sprite;
    }

    public Sprite Decharge() => this.m_HealthBar.Count <= 0 ? (Sprite)null : (Sprite)this.m_HealthBar.Pop();

    public void Reset()
    {
        this.State = 0;
        this.BagSize = 0;
        this.m_bIsStunned = false;
        do
            ;
        while (this.Charge() != null);
        try
        {
            foreach (Sprite sprite in this.m_HealthBar)
                Game.Add(sprite);
        }
        finally
        {
            IEnumerator enumerator;
            if (enumerator is IDisposable)
                ((IDisposable)enumerator).Dispose();
        }
        this.Scores = 0;
        this.m_ScoresText = new Text2D("Courier New", 26f, FontStyle.Bold);
        this.m_ScoresText.Color = Color.Snow;
        this.m_ScoresText.Position = new PointF(this.m_fScoresTextX, this.m_fScoresTextY);
        this.m_ScoresText.Text = this.Scores.ToString("D4");
        Game.Add(this.m_ScoresText);
        this.m_XSpot = (XSpot)null;
    }

    public void LoadHistory()
    {
        FileStream fileStream = (FileStream)null;
        StreamReader streamReader = (StreamReader)null;
        try
        {
            if (File.Exists("../TreasureHunter/Data/Clients/" + this.m_strName + ".txt"))
            {
                fileStream = File.OpenRead("../TreasureHunter/Data/Clients/" + this.m_strName + ".txt");
                streamReader = new StreamReader((Stream)fileStream);
                char[] charArray = " \\t\\r\\n/".ToCharArray();
                while (streamReader.Peek() >= 0)
                {
                    string[] strArray = streamReader.ReadLine().Split(charArray);
                    this.m_ScoresHistory.Add((object)new ScoresHistoryData()
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
        this.m_ScoresHistory.Sort();
        int num1 = checked(this.m_ScoresHistory.Count - 10);
        int num2 = 1;
        while (num2 <= num1)
        {
            this.m_ScoresHistory.RemoveAt(checked(this.m_ScoresHistory.Count - 1));
            checked { ++num2; }
        }
    }

    public void SaveHistory()
    {
        this.m_ScoresHistory.Sort();
        int num1 = checked(this.m_ScoresHistory.Count - 10);
        int num2 = 1;
        while (num2 <= num1)
        {
            this.m_ScoresHistory.RemoveAt(checked(this.m_ScoresHistory.Count - 1));
            checked { ++num2; }
        }
        StreamWriter streamWriter = (StreamWriter)null;
        try
        {
            streamWriter = File.CreateText("../TreasureHunter/Data/Clients/" + this.m_strName + ".txt");
            try
            {
                foreach (ScoresHistoryData scoresHistoryData in this.m_ScoresHistory)
                    streamWriter.WriteLine(scoresHistoryData.ToString());
            }
            finally
            {
                IEnumerator enumerator;
                if (enumerator is IDisposable)
                    ((IDisposable)enumerator).Dispose();
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
            streamWriter?.Close();
        }
    }

    public void AddHistoryData(ScoresHistoryData data)
    {
        if (data == null)
            return;
        this.m_ScoresHistory.Add((object)data);
        this.m_ScoresHistory.Sort();
        int num1 = checked(this.m_ScoresHistory.Count - 10);
        int num2 = 1;
        while (num2 <= num1)
        {
            this.m_ScoresHistory.RemoveAt(checked(this.m_ScoresHistory.Count - 1));
            checked { ++num2; }
        }
    }

    public int BagSize
    {
        get => this.m_nBagSize;
        set
        {
            switch (value)
            {
                case 0:
                case 16:
                case 32:
                    this.m_nBagSize = value;
                    ((Sprite)this).CurrentAnimation.Stop();
                    ((Sprite)this).CurrentIndex = checked(this.m_nBagSize + this.m_nDirection + this.m_nState);
                    break;
            }
        }
    }

    public int Direction
    {
        get => this.m_nDirection;
        set
        {
            switch (value)
            {
                case 0:
                case 4:
                case 8:
                case 12:
                    this.m_nDirection = value;
                    ((Sprite)this).CurrentAnimation.Stop();
                    ((Sprite)this).CurrentIndex = checked(this.m_nBagSize + this.m_nDirection + this.m_nState);
                    break;
            }
        }
    }

    public int State
    {
        get => this.m_nState;
        set
        {
            switch (value)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    this.m_nState = value;
                    ((Sprite)this).CurrentAnimation.Stop();
                    ((Sprite)this).CurrentIndex = checked(this.m_nBagSize + this.m_nDirection + this.m_nState);
                    break;
            }
        }
    }
}











public class Obstacle : Sprite
{
    public int m_nType;
    public int m_nPenalty;
    public const int OBSTACLE_TYPE_ROCK = 0;
    public const int OBSTACLE_TYPE_LOG = 1;
    public const int OBSTACLE_TYPE_CRATE = 2;
    public const int OBSTACLE_TYPE_THORNBUSH = 3;
    public const int OBSTACLE_TYPE_SPIKETRAP = 4;
    public const int OBSTACLE_TYPE_SARCOPHAGUS = 5;
    public const int OBSTACLE_TYPE_TRAPDOOR = 6;

    private Obstacle() => this.m_nPenalty = 0;

    public static Obstacle Load(int ObstacleType)
    {
        Obstacle obstacle = (Obstacle)null;
        switch (ObstacleType)
        {
            case 0:
                obstacle = new Obstacle();
                obstacle.m_nType = ObstacleType;
                obstacle.m_nPenalty = -10;
                obstacle.ZOrder = -5f;
                Vector2 vector2_1;
                ((Vector2)ref vector2_1).X = -18f;
                ((Vector2)ref vector2_1).Y = -10.5f;
                Vector2 vector2_2;
                ((Vector2)ref vector2_2).X = -18f;
                ((Vector2)ref vector2_2).Y = 12.5f;
                Vector2 vector2_3;
                ((Vector2)ref vector2_3).X = 16f;
                ((Vector2)ref vector2_3).Y = 12.5f;
                Vector2 vector2_4;
                ((Vector2)ref vector2_4).X = 16f;
                ((Vector2)ref vector2_4).Y = -10.5f;
                HitBox hitBox1;
                ((HitBox)ref hitBox1).Set(vector2_1, vector2_2, vector2_3, vector2_4);
                Animation animation1 = new Animation();
                Frame frame1 = new Frame();
                frame1.Image = Game.LoadImage("../TreasureHunter/Images/Obstacles/Rock.png");
                frame1.Add(hitBox1);
                animation1.Add(frame1);
                obstacle.Add(animation1);
                break;
            case 1:
                obstacle = new Obstacle();
                obstacle.m_nType = ObstacleType;
                obstacle.m_nPenalty = -10;
                obstacle.ZOrder = -5f;
                Vector2 vector2_5;
                ((Vector2)ref vector2_5).X = -32f;
                ((Vector2)ref vector2_5).Y = -7.5f;
                Vector2 vector2_6;
                ((Vector2)ref vector2_6).X = -32f;
                ((Vector2)ref vector2_6).Y = 5.5f;
                Vector2 vector2_7;
                ((Vector2)ref vector2_7).X = 28f;
                ((Vector2)ref vector2_7).Y = 5.5f;
                Vector2 vector2_8;
                ((Vector2)ref vector2_8).X = 28f;
                ((Vector2)ref vector2_8).Y = -7.5f;
                HitBox hitBox2;
                ((HitBox)ref hitBox2).Set(vector2_5, vector2_6, vector2_7, vector2_8);
                Animation animation2 = new Animation();
                Frame frame2 = new Frame();
                frame2.Image = Game.LoadImage("../TreasureHunter/Images/Obstacles/Log.png");
                frame2.Add(hitBox2);
                animation2.Add(frame2);
                obstacle.Add(animation2);
                break;
            case 2:
                obstacle = new Obstacle();
                obstacle.m_nType = ObstacleType;
                obstacle.m_nPenalty = -10;
                obstacle.ZOrder = -5f;
                Vector2 vector2_9;
                ((Vector2)ref vector2_9).X = -24.5f;
                ((Vector2)ref vector2_9).Y = -23f;
                Vector2 vector2_10;
                ((Vector2)ref vector2_10).X = -24.5f;
                ((Vector2)ref vector2_10).Y = 22f;
                Vector2 vector2_11;
                ((Vector2)ref vector2_11).X = 23.5f;
                ((Vector2)ref vector2_11).Y = 22f;
                Vector2 vector2_12;
                ((Vector2)ref vector2_12).X = 23.5f;
                ((Vector2)ref vector2_12).Y = -23f;
                HitBox hitBox3;
                ((HitBox)ref hitBox3).Set(vector2_9, vector2_10, vector2_11, vector2_12);
                Animation animation3 = new Animation();
                Frame frame3 = new Frame();
                frame3.Image = Game.LoadImage("../TreasureHunter/Images/Obstacles/Crate.png");
                frame3.Add(hitBox3);
                animation3.Add(frame3);
                obstacle.Add(animation3);
                break;
            case 3:
                obstacle = new Obstacle();
                obstacle.m_nType = ObstacleType;
                obstacle.m_nPenalty = -10;
                obstacle.ZOrder = -5f;
                Vector2 vector2_13;
                ((Vector2)ref vector2_13).X = -23.5f;
                ((Vector2)ref vector2_13).Y = -18f;
                Vector2 vector2_14;
                ((Vector2)ref vector2_14).X = -23.5f;
                ((Vector2)ref vector2_14).Y = 17f;
                Vector2 vector2_15;
                ((Vector2)ref vector2_15).X = 22.5f;
                ((Vector2)ref vector2_15).Y = 17f;
                Vector2 vector2_16;
                ((Vector2)ref vector2_16).X = 22.5f;
                ((Vector2)ref vector2_16).Y = -18f;
                HitBox hitBox4;
                ((HitBox)ref hitBox4).Set(vector2_13, vector2_14, vector2_15, vector2_16);
                Animation animation4 = new Animation();
                Frame frame4 = new Frame();
                frame4.Image = Game.LoadImage("../TreasureHunter/Images/Obstacles/ThornBush.png");
                frame4.Add(hitBox4);
                animation4.Add(frame4);
                obstacle.Add(animation4);
                break;
            case 4:
                obstacle = new Obstacle();
                obstacle.m_nType = ObstacleType;
                obstacle.m_nPenalty = -20;
                obstacle.ZOrder = -5f;
                Animation animation5 = new Animation();
                Frame frame5 = new Frame();
                frame5.Image = Game.LoadImage("../TreasureHunter/Images/Obstacles/SpikeTrap/01.png");
                animation5.Add(frame5);
                int num1 = 2;
                do
                {
                    animation5.Add((Frame)frame5.Clone());
                    checked { ++num1; }
                }
                while (num1 <= 36);
                Vector2 vector2_17;
                ((Vector2)ref vector2_17).X = -32f;
                ((Vector2)ref vector2_17).Y = -25f;
                Vector2 vector2_18;
                ((Vector2)ref vector2_18).X = -32f;
                ((Vector2)ref vector2_18).Y = 23f;
                Vector2 vector2_19;
                ((Vector2)ref vector2_19).X = 15f;
                ((Vector2)ref vector2_19).Y = 23f;
                Vector2 vector2_20;
                ((Vector2)ref vector2_20).X = 15f;
                ((Vector2)ref vector2_20).Y = -25f;
                HitBox hitBox5;
                ((HitBox)ref hitBox5).Set(vector2_17, vector2_18, vector2_19, vector2_20);
                Frame frame6 = new Frame();
                frame6.Image = Game.LoadImage("../TreasureHunter/Images/Obstacles/SpikeTrap/37.png");
                frame6.Add(hitBox5);
                animation5.Add(frame6);
                ((Vector2)ref vector2_17).X = -34f;
                ((Vector2)ref vector2_17).Y = -28f;
                ((Vector2)ref vector2_18).X = -34f;
                ((Vector2)ref vector2_18).Y = 30f;
                ((Vector2)ref vector2_19).X = 19f;
                ((Vector2)ref vector2_19).Y = 30f;
                ((Vector2)ref vector2_20).X = 19f;
                ((Vector2)ref vector2_20).Y = -28f;
                ((HitBox)ref hitBox5).Set(vector2_17, vector2_18, vector2_19, vector2_20);
                Frame frame7 = new Frame();
                frame7.Image = Game.LoadImage("../TreasureHunter/Images/Obstacles/SpikeTrap/38.png");
                frame7.Add(hitBox5);
                animation5.Add(frame7);
                ((Vector2)ref vector2_17).X = -38f;
                ((Vector2)ref vector2_17).Y = -32f;
                ((Vector2)ref vector2_18).X = -38f;
                ((Vector2)ref vector2_18).Y = 32f;
                ((Vector2)ref vector2_19).X = 24f;
                ((Vector2)ref vector2_19).Y = 32f;
                ((Vector2)ref vector2_20).X = 24f;
                ((Vector2)ref vector2_20).Y = -32f;
                ((HitBox)ref hitBox5).Set(vector2_17, vector2_18, vector2_19, vector2_20);
                Frame frame8 = new Frame();
                frame8.Image = Game.LoadImage("../TreasureHunter/Images/Obstacles/SpikeTrap/39.png");
                frame8.Add(hitBox5);
                animation5.Add(frame8);
                int num2 = 40;
                do
                {
                    animation5.Add((Frame)frame8.Clone());
                    checked { ++num2; }
                }
                while (num2 <= 67);
                ((Vector2)ref vector2_17).X = -34f;
                ((Vector2)ref vector2_17).Y = -28f;
                ((Vector2)ref vector2_18).X = -34f;
                ((Vector2)ref vector2_18).Y = 30f;
                ((Vector2)ref vector2_19).X = 19f;
                ((Vector2)ref vector2_19).Y = 30f;
                ((Vector2)ref vector2_20).X = 19f;
                ((Vector2)ref vector2_20).Y = -28f;
                ((HitBox)ref hitBox5).Set(vector2_17, vector2_18, vector2_19, vector2_20);
                Frame frame9 = new Frame();
                frame9.Image = Game.LoadImage("../TreasureHunter/Images/Obstacles/SpikeTrap/38.png");
                frame9.Add(hitBox5);
                animation5.Add(frame9);
                animation5.Add((Frame)frame9.Clone());
                ((Vector2)ref vector2_17).X = -32f;
                ((Vector2)ref vector2_17).Y = -25f;
                ((Vector2)ref vector2_18).X = -32f;
                ((Vector2)ref vector2_18).Y = 23f;
                ((Vector2)ref vector2_19).X = 15f;
                ((Vector2)ref vector2_19).Y = 23f;
                ((Vector2)ref vector2_20).X = 15f;
                ((Vector2)ref vector2_20).Y = -25f;
                ((HitBox)ref hitBox5).Set(vector2_17, vector2_18, vector2_19, vector2_20);
                Frame frame10 = new Frame();
                frame10.Image = Game.LoadImage("../TreasureHunter/Images/Obstacles/SpikeTrap/37.png");
                frame10.Add(hitBox5);
                animation5.Add(frame10);
                animation5.Add((Frame)frame10.Clone());
                animation5.Add(new Frame()
                {
                    Image = Game.LoadImage("../TreasureHunter/Images/Obstacles/SpikeTrap/01.png")
                });
                animation5.Looping = true;
                animation5.Duration = 6.0;
                obstacle.Add(animation5);
                break;
            case 5:
                obstacle = new Obstacle();
                obstacle.m_nType = ObstacleType;
                obstacle.m_nPenalty = -10;
                obstacle.ZOrder = -5f;
                Vector2 vector2_21;
                ((Vector2)ref vector2_21).X = -16f;
                ((Vector2)ref vector2_21).Y = -43f;
                Vector2 vector2_22;
                ((Vector2)ref vector2_22).X = -16f;
                ((Vector2)ref vector2_22).Y = 42f;
                Vector2 vector2_23;
                ((Vector2)ref vector2_23).X = 15f;
                ((Vector2)ref vector2_23).Y = 42f;
                Vector2 vector2_24;
                ((Vector2)ref vector2_24).X = 15f;
                ((Vector2)ref vector2_24).Y = -43f;
                HitBox hitBox6;
                ((HitBox)ref hitBox6).Set(vector2_21, vector2_22, vector2_23, vector2_24);
                Animation animation6 = new Animation();
                Frame frame11 = new Frame();
                frame11.Image = Game.LoadImage("../TreasureHunter/Images/Obstacles/Sarcophagus.png");
                frame11.Add(hitBox6);
                animation6.Add(frame11);
                obstacle.Add(animation6);
                break;
            case 6:
                obstacle = new Obstacle();
                obstacle.m_nType = ObstacleType;
                obstacle.m_nPenalty = -20;
                obstacle.ZOrder = 5f;
                Animation animation7 = new Animation();
                Frame frame12 = new Frame();
                frame12.Image = Game.LoadImage("../TreasureHunter/Images/Obstacles/ClosingDoor/01.png");
                Vector2 vector2_25;
                ((Vector2)ref vector2_25).X = -21f;
                ((Vector2)ref vector2_25).Y = -47f;
                Vector2 vector2_26;
                ((Vector2)ref vector2_26).X = -21f;
                ((Vector2)ref vector2_26).Y = -44f;
                Vector2 vector2_27;
                ((Vector2)ref vector2_27).X = 20f;
                ((Vector2)ref vector2_27).Y = -44f;
                Vector2 vector2_28;
                ((Vector2)ref vector2_28).X = 20f;
                ((Vector2)ref vector2_28).Y = -47f;
                HitBox hitBox7;
                ((HitBox)ref hitBox7).Set(vector2_25, vector2_26, vector2_27, vector2_28);
                frame12.Add(hitBox7);
                ((Vector2)ref vector2_25).X = -21f;
                ((Vector2)ref vector2_25).Y = 43f;
                ((Vector2)ref vector2_26).X = -21f;
                ((Vector2)ref vector2_26).Y = 46f;
                ((Vector2)ref vector2_27).X = 20f;
                ((Vector2)ref vector2_27).Y = 46f;
                ((Vector2)ref vector2_28).X = 20f;
                ((Vector2)ref vector2_28).Y = 43f;
                ((HitBox)ref hitBox7).Set(vector2_25, vector2_26, vector2_27, vector2_28);
                frame12.Add(hitBox7);
                animation7.Add(frame12);
                int num3 = 2;
                do
                {
                    animation7.Add((Frame)frame12.Clone());
                    checked { ++num3; }
                }
                while (num3 <= 25);
                Frame frame13 = new Frame();
                frame13.Image = Game.LoadImage("../TreasureHunter/Images/Obstacles/ClosingDoor/26.png");
                ((Vector2)ref vector2_25).X = -21f;
                ((Vector2)ref vector2_25).Y = -47f;
                ((Vector2)ref vector2_26).X = -21f;
                ((Vector2)ref vector2_26).Y = -24f;
                ((Vector2)ref vector2_27).X = 20f;
                ((Vector2)ref vector2_27).Y = -24f;
                ((Vector2)ref vector2_28).X = 20f;
                ((Vector2)ref vector2_28).Y = -47f;
                ((HitBox)ref hitBox7).Set(vector2_25, vector2_26, vector2_27, vector2_28);
                frame13.Add(hitBox7);
                ((Vector2)ref vector2_25).X = -21f;
                ((Vector2)ref vector2_25).Y = 24f;
                ((Vector2)ref vector2_26).X = -21f;
                ((Vector2)ref vector2_26).Y = 46f;
                ((Vector2)ref vector2_27).X = 20f;
                ((Vector2)ref vector2_27).Y = 46f;
                ((Vector2)ref vector2_28).X = 20f;
                ((Vector2)ref vector2_28).Y = 24f;
                ((HitBox)ref hitBox7).Set(vector2_25, vector2_26, vector2_27, vector2_28);
                frame13.Add(hitBox7);
                animation7.Add(frame13);
                Frame frame14 = new Frame();
                frame14.Image = Game.LoadImage("../TreasureHunter/Images/Obstacles/ClosingDoor/27.png");
                ((Vector2)ref vector2_25).X = -21f;
                ((Vector2)ref vector2_25).Y = -47f;
                ((Vector2)ref vector2_26).X = -21f;
                ((Vector2)ref vector2_26).Y = 46f;
                ((Vector2)ref vector2_27).X = 20f;
                ((Vector2)ref vector2_27).Y = 46f;
                ((Vector2)ref vector2_28).X = 20f;
                ((Vector2)ref vector2_28).Y = -47f;
                ((HitBox)ref hitBox7).Set(vector2_25, vector2_26, vector2_27, vector2_28);
                frame14.Add(hitBox7);
                animation7.Add(frame14);
                int num4 = 28;
                do
                {
                    animation7.Add((Frame)frame14.Clone());
                    checked { ++num4; }
                }
                while (num4 <= 43);
                Frame frame15 = new Frame();
                frame15.Image = Game.LoadImage("../TreasureHunter/Images/Obstacles/ClosingDoor/44.png");
                ((Vector2)ref vector2_25).X = -21f;
                ((Vector2)ref vector2_25).Y = -47f;
                ((Vector2)ref vector2_26).X = -21f;
                ((Vector2)ref vector2_26).Y = -12f;
                ((Vector2)ref vector2_27).X = 20f;
                ((Vector2)ref vector2_27).Y = -12f;
                ((Vector2)ref vector2_28).X = 20f;
                ((Vector2)ref vector2_28).Y = -47f;
                ((HitBox)ref hitBox7).Set(vector2_25, vector2_26, vector2_27, vector2_28);
                frame15.Add(hitBox7);
                ((Vector2)ref vector2_25).X = -21f;
                ((Vector2)ref vector2_25).Y = 10f;
                ((Vector2)ref vector2_26).X = -21f;
                ((Vector2)ref vector2_26).Y = 46f;
                ((Vector2)ref vector2_27).X = 20f;
                ((Vector2)ref vector2_27).Y = 46f;
                ((Vector2)ref vector2_28).X = 20f;
                ((Vector2)ref vector2_28).Y = 10f;
                ((HitBox)ref hitBox7).Set(vector2_25, vector2_26, vector2_27, vector2_28);
                frame15.Add(hitBox7);
                animation7.Add(frame15);
                animation7.Add((Frame)frame15.Clone());
                Frame frame16 = new Frame();
                frame16.Image = Game.LoadImage("../TreasureHunter/Images/Obstacles/ClosingDoor/46.png");
                ((Vector2)ref vector2_25).X = -21f;
                ((Vector2)ref vector2_25).Y = -47f;
                ((Vector2)ref vector2_26).X = -21f;
                ((Vector2)ref vector2_26).Y = -24f;
                ((Vector2)ref vector2_27).X = 20f;
                ((Vector2)ref vector2_27).Y = -24f;
                ((Vector2)ref vector2_28).X = 20f;
                ((Vector2)ref vector2_28).Y = -47f;
                ((HitBox)ref hitBox7).Set(vector2_25, vector2_26, vector2_27, vector2_28);
                frame16.Add(hitBox7);
                ((Vector2)ref vector2_25).X = -21f;
                ((Vector2)ref vector2_25).Y = 24f;
                ((Vector2)ref vector2_26).X = -21f;
                ((Vector2)ref vector2_26).Y = 46f;
                ((Vector2)ref vector2_27).X = 20f;
                ((Vector2)ref vector2_27).Y = 46f;
                ((Vector2)ref vector2_28).X = 20f;
                ((Vector2)ref vector2_28).Y = 24f;
                ((HitBox)ref hitBox7).Set(vector2_25, vector2_26, vector2_27, vector2_28);
                frame16.Add(hitBox7);
                animation7.Add(frame16);
                Frame frame17 = new Frame();
                frame17.Image = Game.LoadImage("../TreasureHunter/Images/Obstacles/ClosingDoor/47.png");
                ((Vector2)ref vector2_25).X = -21f;
                ((Vector2)ref vector2_25).Y = -47f;
                ((Vector2)ref vector2_26).X = -21f;
                ((Vector2)ref vector2_26).Y = -37f;
                ((Vector2)ref vector2_27).X = 20f;
                ((Vector2)ref vector2_27).Y = -37f;
                ((Vector2)ref vector2_28).X = 20f;
                ((Vector2)ref vector2_28).Y = -47f;
                ((HitBox)ref hitBox7).Set(vector2_25, vector2_26, vector2_27, vector2_28);
                frame17.Add(hitBox7);
                ((Vector2)ref vector2_25).X = -21f;
                ((Vector2)ref vector2_25).Y = 37f;
                ((Vector2)ref vector2_26).X = -21f;
                ((Vector2)ref vector2_26).Y = 46f;
                ((Vector2)ref vector2_27).X = 20f;
                ((Vector2)ref vector2_27).Y = 46f;
                ((Vector2)ref vector2_28).X = 20f;
                ((Vector2)ref vector2_28).Y = 37f;
                ((HitBox)ref hitBox7).Set(vector2_25, vector2_26, vector2_27, vector2_28);
                frame17.Add(hitBox7);
                animation7.Add(frame17);
                animation7.Add((Frame)frame17.Clone());
                Frame frame18 = new Frame();
                frame18.Image = Game.LoadImage("../TreasureHunter/Images/Obstacles/ClosingDoor/01.png");
                ((Vector2)ref vector2_25).X = -21f;
                ((Vector2)ref vector2_25).Y = -47f;
                ((Vector2)ref vector2_26).X = -21f;
                ((Vector2)ref vector2_26).Y = -44f;
                ((Vector2)ref vector2_27).X = 20f;
                ((Vector2)ref vector2_27).Y = -44f;
                ((Vector2)ref vector2_28).X = 20f;
                ((Vector2)ref vector2_28).Y = -47f;
                ((HitBox)ref hitBox7).Set(vector2_25, vector2_26, vector2_27, vector2_28);
                frame18.Add(hitBox7);
                ((Vector2)ref vector2_25).X = -21f;
                ((Vector2)ref vector2_25).Y = 43f;
                ((Vector2)ref vector2_26).X = -21f;
                ((Vector2)ref vector2_26).Y = 46f;
                ((Vector2)ref vector2_27).X = 20f;
                ((Vector2)ref vector2_27).Y = 46f;
                ((Vector2)ref vector2_28).X = 20f;
                ((Vector2)ref vector2_28).Y = 43f;
                ((HitBox)ref hitBox7).Set(vector2_25, vector2_26, vector2_27, vector2_28);
                frame18.Add(hitBox7);
                animation7.Add(frame18);
                animation7.Looping = true;
                animation7.Duration = 6.0;
                obstacle.Add(animation7);
                break;
        }
        return obstacle;
    }

    public virtual void Update(double elapsed)
    {
        ArrayList collidedSprites = Game.GetCollidedSprites((Sprite)this);
        try
        {
            foreach (Sprite sprite in collidedSprites)
            {
                if (!(sprite is Hunter) & !(sprite is Background) && !sprite.m_bIsDirty)
                {
                    HitBox hitBox1 = this.HitBoxes[0];
                    HitBox[] hitBoxes = sprite.HitBoxes;
                    int index = 0;
                    while (index < hitBoxes.Length)
                    {
                        HitBox hitBox2 = hitBoxes[index];
                        if (((HitBox)ref hitBox2).IntersectWith(hitBox1))
                        {
                            Vector2 vector2 = Vector2.op_Subtraction(hitBox2.Center, hitBox1.Center);
                            float num1 = ((Vector2)ref hitBox2.Extents).X + ((Vector2)ref hitBox1.Extents).X - Math.Abs(((Vector2)ref vector2).X);
                            float num2 = ((Vector2)ref hitBox2.Extents).Y + ((Vector2)ref hitBox1.Extents).Y - Math.Abs(((Vector2)ref vector2).Y);
                            if ((double)((Vector2)ref vector2).X < 0.0)
                                ((Vector2)ref vector2).X = -1f;
                            else if ((double)((Vector2)ref vector2).X > 0.0)
                                ((Vector2)ref vector2).X = 1f;
                            if ((double)((Vector2)ref vector2).Y < 0.0)
                                ((Vector2)ref vector2).Y = -1f;
                            else if ((double)((Vector2)ref vector2).Y > 0.0)
                                ((Vector2)ref vector2).Y = 1f;
                            if ((double)num2 < (double)num1)
                            {
                                sprite.Translate(0.0f, ((Vector2)ref vector2).Y * (num2 + 1f));
                                break;
                            }
                            sprite.Translate(((Vector2)ref vector2).X * (num1 + 1f), 0.0f);
                            break;
                        }
                        checked { ++index; }
                    }
                }
            }
        }
        finally
        {
            IEnumerator enumerator;
            if (enumerator is IDisposable)
                ((IDisposable)enumerator).Dispose();
        }
    }













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
                return checked(((ScoresHistoryData)obj).Scores - this.Scores);
            throw new ArgumentException("object is not instance of ScoresHistoryData class!");
        }

        public override string ToString() => this.Scores.ToString("D5") + " " + this.Level.ToString("D2") + " " + this.Day.ToString("D2") + "/" + this.Month.ToString("D2") + "/" + this.Year.ToString();
    }










    public class TreasureHunter : Game
    {
        public ArrayList m_HiScoresList;
        public int m_nNumIntervals;
        public Background m_Background;
        public int m_nNumResources;
        public bool m_bLoaded;
        public int m_nActiveClient;
        public bool m_bNeedUpdate;
        public Thread m_LoadingResThread;

        public TreasureHunter()
        {
            this.m_HiScoresList = new ArrayList();
            this.m_nNumIntervals = 0;
            this.m_bLoaded = false;
            this.m_nNumResources = 0;
            Game.MinScores = 0;
            Game.MaxScores = 9999;
            this.FrameRate = 30.0;
            ((UserControl)this).Text = "Treasure Hunter";
            this.m_nMaxClients = 2;
            this.m_Background = new Background();
            this.m_Background.m_Game = this;
            float[] elements = this.m_WorldMatrix.Elements;
            elements[0] = 1f;
            elements[1] = 0.0f;
            elements[2] = 0.0f;
            elements[3] = 1f;
            elements[4] = (float)Game.m_Resolution.Width * 0.5f;
            elements[5] = (float)Game.m_Resolution.Height * 0.5f;
            this.m_WorldMatrix = new Matrix(elements[0], elements[1], elements[2], elements[3], elements[4], elements[5]);
        }

        public void LoadResources()
        {
            Game.LoadImage("../TreasureHunter/Images/Background/Splash.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Background/ScoreHistory.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Background/HighScores.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Background/Level01.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Background/Level02.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Background/Level03.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Background/Level04.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Background/Level05.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Background/Pause.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Background/ProgressChart.png");
            checked { ++this.m_nNumResources; }
            int num1 = 1;
            do
            {
                if (num1 == 4)
                    num1 = 6;
                string str = num1.ToString("D2");
                Game.LoadImage("../TreasureHunter/Images/HunterA/SmallBag/North/Walk/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/SmallBag/South/Walk/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/SmallBag/East/Walk/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/SmallBag/West/Walk/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/MediumBag/North/Walk/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/MediumBag/South/Walk/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/MediumBag/East/Walk/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/MediumBag/West/Walk/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/LargeBag/North/Walk/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/LargeBag/South/Walk/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/LargeBag/East/Walk/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/LargeBag/West/Walk/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/SmallBag/North/Walk/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/SmallBag/South/Walk/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/SmallBag/East/Walk/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/SmallBag/West/Walk/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/MediumBag/North/Walk/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/MediumBag/South/Walk/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/MediumBag/East/Walk/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/MediumBag/West/Walk/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/LargeBag/North/Walk/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/LargeBag/South/Walk/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/LargeBag/East/Walk/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/LargeBag/West/Walk/" + str + ".png");
                checked { ++this.m_nNumResources; }
                checked { ++num1; }
            }
            while (num1 <= 7);
            int num2 = 1;
            do
            {
                if (num2 == 5)
                    num2 = 6;
                string str = num2.ToString("D2");
                Game.LoadImage("../TreasureHunter/Images/HunterA/SmallBag/North/Dig/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/SmallBag/South/Dig/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/SmallBag/East/Dig/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/SmallBag/West/Dig/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/MediumBag/North/Dig/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/MediumBag/South/Dig/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/MediumBag/East/Dig/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/MediumBag/West/Dig/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/LargeBag/North/Dig/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/LargeBag/South/Dig/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/LargeBag/East/Dig/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/LargeBag/West/Dig/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/SmallBag/North/Dig/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/SmallBag/South/Dig/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/SmallBag/East/Dig/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/SmallBag/West/Dig/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/MediumBag/North/Dig/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/MediumBag/South/Dig/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/MediumBag/East/Dig/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/MediumBag/West/Dig/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/LargeBag/North/Dig/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/LargeBag/South/Dig/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/LargeBag/East/Dig/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/LargeBag/West/Dig/" + str + ".png");
                checked { ++this.m_nNumResources; }
                checked { ++num2; }
            }
            while (num2 <= 7);
            int num3 = 1;
            do
            {
                string str = num3.ToString("D2");
                Game.LoadImage("../TreasureHunter/Images/HunterA/SmallBag/North/Giddy/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/SmallBag/South/Giddy/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/SmallBag/East/Giddy/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/SmallBag/West/Giddy/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/MediumBag/North/Giddy/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/MediumBag/South/Giddy/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/MediumBag/East/Giddy/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/MediumBag/West/Giddy/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/LargeBag/North/Giddy/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/LargeBag/South/Giddy/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/LargeBag/East/Giddy/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterA/LargeBag/West/Giddy/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/SmallBag/North/Giddy/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/SmallBag/South/Giddy/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/SmallBag/East/Giddy/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/SmallBag/West/Giddy/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/MediumBag/North/Giddy/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/MediumBag/South/Giddy/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/MediumBag/East/Giddy/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/MediumBag/West/Giddy/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/LargeBag/North/Giddy/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/LargeBag/South/Giddy/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/LargeBag/East/Giddy/" + str + ".png");
                checked { ++this.m_nNumResources; }
                Game.LoadImage("../TreasureHunter/Images/HunterB/LargeBag/West/Giddy/" + str + ".png");
                checked { ++this.m_nNumResources; }
                checked { ++num3; }
            }
            while (num3 <= 8);
            Game.LoadImage("../TreasureHunter/Images/HunterA/HealthBar/Ball.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/HunterB/HealthBar/Ball.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/HunterA/HealthBar/Bar.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/HunterB/HealthBar/Bar.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Obstacles/XSpot.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Obstacles/Crate.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Obstacles/Log.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Obstacles/Rock.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Obstacles/ThornBush.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Obstacles/Sarcophagus.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Obstacles/SpikeTrap/01.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Obstacles/SpikeTrap/37.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Obstacles/SpikeTrap/38.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Obstacles/SpikeTrap/39.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Obstacles/ClosingDoor/01.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Obstacles/ClosingDoor/26.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Obstacles/ClosingDoor/27.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Obstacles/ClosingDoor/44.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Obstacles/ClosingDoor/46.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Obstacles/ClosingDoor/47.png");
            checked { ++this.m_nNumResources; }
            int num4 = 1;
            do
            {
                Game.LoadImage("../TreasureHunter/Images/Crocodile/North/" + num4.ToString("D2") + ".png");
                checked { ++this.m_nNumResources; }
                checked { ++num4; }
            }
            while (num4 <= 14);
            int num5 = 1;
            do
            {
                Game.LoadImage("../TreasureHunter/Images/Mummy/North/" + num5.ToString("D2") + ".png");
                checked { ++this.m_nNumResources; }
                checked { ++num5; }
            }
            while (num5 <= 6);
            this.m_bLoaded = true;
            Game.LoadImage("../TreasureHunter/Images/Treasures/Coins.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Treasures/Diamond.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Treasures/Emerald.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Treasures/Ruby.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Treasures/Fossil.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Treasures/Statuette.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Treasures/Amulet.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Treasures/Shield.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Treasures/Sword.png");
            checked { ++this.m_nNumResources; }
            Game.LoadImage("../TreasureHunter/Images/Treasures/Ingot.png");
            checked { ++this.m_nNumResources; }
            int num6 = 1;
            do
            {
                Game.LoadImage("../TreasureHunter/Images/Crocodile/South/" + num6.ToString("D2") + ".png");
                checked { ++this.m_nNumResources; }
                checked { ++num6; }
            }
            while (num6 <= 12);
            int num7 = 1;
            do
            {
                Game.LoadImage("../TreasureHunter/Images/Crocodile/East/" + num7.ToString("D2") + ".png");
                checked { ++this.m_nNumResources; }
                checked { ++num7; }
            }
            while (num7 <= 7);
            int num8 = 1;
            do
            {
                Game.LoadImage("../TreasureHunter/Images/Crocodile/West/" + num8.ToString("D2") + ".png");
                checked { ++this.m_nNumResources; }
                checked { ++num8; }
            }
            while (num8 <= 7);
            int num9 = 1;
            do
            {
                Game.LoadImage("../TreasureHunter/Images/Mummy/South/" + num9.ToString("D2") + ".png");
                checked { ++this.m_nNumResources; }
                checked { ++num9; }
            }
            while (num9 <= 7);
            int num10 = 1;
            do
            {
                Game.LoadImage("../TreasureHunter/Images/Mummy/East/" + num10.ToString("D2") + ".png");
                checked { ++this.m_nNumResources; }
                checked { ++num10; }
            }
            while (num10 <= 6);
            int num11 = 1;
            do
            {
                Game.LoadImage("../TreasureHunter/Images/Mummy/West/" + num11.ToString("D2") + ".png");
                checked { ++this.m_nNumResources; }
                checked { ++num11; }
            }
            while (num11 <= 6);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.m_LoadingResThread != null)
            {
                this.m_LoadingResThread.Join();
                this.m_LoadingResThread = (Thread)null;
            }
            this.SaveHiScores();
            try
            {
                foreach (Hunter client in Game.m_Clients)
                    client.SaveHistory();
            }
            finally
            {
                IEnumerator enumerator;
                if (enumerator is IDisposable)
                    ((IDisposable)enumerator).Dispose();
            }
            base.Dispose(disposing);
        }

        public virtual void Initialize()
        {
            AudioManager.Singleton.LoadAudioSample("../TreasureHunter/Sound/Background.wav");
            checked { ++this.m_nNumResources; }
            AudioManager.Singleton.LoadAudioSample("../TreasureHunter/Sound/Obstacles.wav");
            checked { ++this.m_nNumResources; }
            AudioManager.Singleton.LoadAudioSample("../TreasureHunter/Sound/Giddy.wav");
            checked { ++this.m_nNumResources; }
            AudioManager.Singleton.LoadAudioSample("../TreasureHunter/Sound/Digging.wav");
            checked { ++this.m_nNumResources; }
            AudioManager.Singleton.LoadAudioSample("../TreasureHunter/Sound/Treasure.wav");
            checked { ++this.m_nNumResources; }
            AudioManager.Singleton.LoadAudioSample("../TreasureHunter/Sound/Enemies.wav");
            checked { ++this.m_nNumResources; }
            AudioManager.Singleton.LoadAudioSample("../TreasureHunter/Sound/ChargeUp.wav");
            checked { ++this.m_nNumResources; }
            AudioManager.Singleton.LoadAudioSample("../TreasureHunter/Sound/Transition.wav");
            checked { ++this.m_nNumResources; }
            AudioManager.Singleton.LoadAudioSample("../TreasureHunter/Sound/Croc.wav");
            checked { ++this.m_nNumResources; }
            AudioManager.Singleton.LoadAudioSample("../TreasureHunter/Sound/Mummy.wav");
            checked { ++this.m_nNumResources; }
            this.m_LoadingResThread = new Thread(new ThreadStart(this.LoadResources));
            this.m_LoadingResThread.Start();
            this.LoadHiScores();
            while (!this.m_bLoaded)
                Thread.Sleep(100);
            this.Level = 0;
        }

        public virtual bool AddClient(string name)
        {
            if (Game.m_Clients.Count >= this.m_nMaxClients | name == null)
                return false;
            Hunter hunter = new Hunter();
            hunter.Client_Name = StringType.FromObject(name.Clone());
            hunter.LoadHistory();
            if (Game.m_Clients.Count > 0 && string.Compare(((Hunter)Game.m_Clients[checked(Game.m_Clients.Count - 1)]).m_strResPath, "../TreasureHunter/Images/HunterA/", true) == 0)
            {
                hunter.m_strResPath = "../TreasureHunter/Images/HunterB/";
                hunter.m_nKeyUp = 38;
                hunter.m_nKeyDown = 40;
                hunter.m_nKeyRight = 39;
                hunter.m_nKeyLeft = 37;
                hunter.m_fHealthBarX *= -1f;
                hunter.m_fScoresTextX = 130f;
                hunter.m_fArtifactX *= -1f;
                hunter.m_fArtifactX += 20f;
                hunter.m_fIntervalBarX = -290f;
            }
            hunter.Initialize();
            Game.m_Clients.Add((object)hunter);
            hunter.m_Game = this;
            return true;
        }

        public Hunter PlayerOne => (Hunter)Game.m_Clients[0];

        public Hunter PlayerTwo => (Hunter)Game.m_Clients[checked(this.m_nMaxClients - 1)];

        public virtual double R_Value_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.R_Value = value;
            }
        }

        public virtual double R_Threshold_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.R_Threshold = value;
            }
        }

        public virtual bool R_Trigger_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.R_Trigger = value;
            }
        }

        public virtual bool R_Ignore_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.R_Ignore = value;
            }
        }

        public virtual double A_Value_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.A_Value = value;
            }
        }

        public virtual double A_Threshold_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.A_Threshold = value;
            }
        }

        public virtual bool A_Trigger_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.A_Trigger = value;
            }
        }

        public virtual bool A_Ignore_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.A_Ignore = value;
            }
        }

        public virtual double B_Value_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.B_Value = value;
            }
        }

        public virtual double B_Threshold_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.B_Threshold = value;
            }
        }

        public virtual bool B_Trigger_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.B_Trigger = value;
            }
        }

        public virtual bool B_Ignore_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.B_Ignore = value;
            }
        }

        public virtual double C_Value_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.C_Value = value;
            }
        }

        public virtual double C_Threshold_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.C_Threshold = value;
            }
        }

        public virtual bool C_Trigger_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.C_Trigger = value;
            }
        }

        public virtual bool C_Ignore_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.C_Ignore = value;
            }
        }

        public virtual double D_Value_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.D_Value = value;
            }
        }

        public virtual double D_Threshold_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.D_Threshold = value;
            }
        }

        public virtual bool D_Trigger_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.D_Trigger = value;
            }
        }

        public virtual bool D_Ignore_A
        {
            set
            {
                if (Game.m_Clients.Count <= 0)
                    return;
                this.PlayerOne.EegChannel.D_Ignore = value;
            }
        }

        public virtual double R_Value_B
        {
            set
            {
                if (Game.m_Clients.Count < 2)
                    return;
                this.PlayerTwo.EegChannel.R_Value = value;
            }
        }

        public virtual double R_Threshold_B
        {
            set
            {
                if (Game.m_Clients.Count < 2)
                    return;
                this.PlayerTwo.EegChannel.R_Threshold = value;
            }
        }

        public virtual bool R_Trigger_B
        {
            set
            {
                if (Game.m_Clients.Count < 2)
                    return;
                this.PlayerTwo.EegChannel.R_Trigger = value;
            }
        }

        public virtual bool R_Ignore_B
        {
            set
            {
                if (Game.m_Clients.Count < 2)
                    return;
                this.PlayerTwo.EegChannel.R_Ignore = value;
            }
        }

        public virtual double A_Value_B
        {
            set
            {
                if (Game.m_Clients.Count < 2)
                    return;
                this.PlayerTwo.EegChannel.A_Value = value;
            }
        }

        public virtual double A_Threshold_B
        {
            set
            {
                if (Game.m_Clients.Count < 2)
                    return;
                this.PlayerTwo.EegChannel.A_Threshold = value;
            }
        }

        public virtual bool A_Trigger_B
        {
            set
            {
                if (Game.m_Clients.Count < 2)
                    return;
                this.PlayerTwo.EegChannel.A_Trigger = value;
            }
        }

        public virtual bool A_Ignore_B
        {
            set
            {
                if (Game.m_Clients.Count < 2)
                    return;
                this.PlayerTwo.EegChannel.A_Ignore = value;
            }
        }

        public virtual double B_Value_B
        {
            set
            {
                if (Game.m_Clients.Count < 2)
                    return;
                this.PlayerTwo.EegChannel.B_Value = value;
            }
        }

        public virtual double B_Threshold_B
        {
            set
            {
                if (Game.m_Clients.Count < 2)
                    return;
                this.PlayerTwo.EegChannel.B_Threshold = value;
            }
        }

        public virtual bool B_Trigger_B
        {
            set
            {
                if (Game.m_Clients.Count < 2)
                    return;
                this.PlayerTwo.EegChannel.B_Trigger = value;
            }
        }

        public virtual bool B_Ignore_B
        {
            set
            {
                if (Game.m_Clients.Count < 2)
                    return;
                this.PlayerTwo.EegChannel.B_Ignore = value;
            }
        }

        public virtual double C_Value_B
        {
            set
            {
                if (Game.m_Clients.Count < 2)
                    return;
                this.PlayerTwo.EegChannel.C_Value = value;
            }
        }

        public virtual double C_Threshold_B
        {
            set
            {
                if (Game.m_Clients.Count < 2)
                    return;
                this.PlayerTwo.EegChannel.C_Threshold = value;
            }
        }

        public virtual bool C_Trigger_B
        {
            set
            {
                if (Game.m_Clients.Count < 2)
                    return;
                this.PlayerTwo.EegChannel.C_Trigger = value;
            }
        }

        public virtual bool C_Ignore_B
        {
            set
            {
                if (Game.m_Clients.Count < 2)
                    return;
                this.PlayerTwo.EegChannel.C_Ignore = value;
            }
        }

        public virtual double D_Value_B
        {
            set
            {
                if (Game.m_Clients.Count < 2)
                    return;
                this.PlayerTwo.EegChannel.D_Value = value;
            }
        }

        public virtual double D_Threshold_B
        {
            set
            {
                if (Game.m_Clients.Count < 2)
                    return;
                this.PlayerTwo.EegChannel.D_Threshold = value;
            }
        }

        public virtual bool D_Trigger_B
        {
            set
            {
                if (Game.m_Clients.Count < 2)
                    return;
                this.PlayerTwo.EegChannel.D_Trigger = value;
            }
        }

        public virtual bool D_Ignore_B
        {
            set
            {
                if (Game.m_Clients.Count < 2)
                    return;
                this.PlayerTwo.EegChannel.D_Ignore = value;
            }
        }

        public virtual void Update(double elapsed)
        {
            if (this.m_bNeedUpdate)
            {
                int index1 = 0;
                Hunter client = (Hunter)Game.m_Clients[this.m_nActiveClient];
                Text2D text1 = (Text2D)Game.m_Texts[index1];
                text1.Text = client.Client_Name;
                text1.Visible = true;
                int index2 = checked(index1 + 1);
                try
                {
                    foreach (ScoresHistoryData scoresHistoryData in client.m_ScoresHistory)
                    {
                        Text2D text2 = (Text2D)Game.m_Texts[index2];
                        text2.Text = scoresHistoryData.Scores.ToString("D5");
                        text2.Visible = true;
                        checked { ++index2; }
                        Text2D text3 = (Text2D)Game.m_Texts[index2];
                        text3.Text = scoresHistoryData.Level.ToString("D2");
                        text3.Visible = true;
                        checked { ++index2; }
                        Text2D text4 = (Text2D)Game.m_Texts[index2];
                        text4.Text = scoresHistoryData.Day.ToString("D2") + "/" + scoresHistoryData.Month.ToString("D2") + "/" + scoresHistoryData.Year.ToString("D4");
                        text4.Visible = true;
                        checked { ++index2; }
                    }
                }
                finally
                {
                    IEnumerator enumerator;
                    if (enumerator is IDisposable)
                        ((IDisposable)enumerator).Dispose();
                }
                int num1 = index2;
                int num2 = checked(Game.m_Texts.Count - 1);
                int index3 = num1;
                while (index3 <= num2)
                {
                    ((Text2D)Game.m_Texts[index3]).Visible = false;
                    checked { ++index3; }
                }
                this.m_bNeedUpdate = false;
            }
            if (this.Level != -2)
                return;
            if (Keyboard.IsKeyTriggered(1))
            {
                checked { --this.m_nActiveClient; }
                if (this.m_nActiveClient < 0)
                    this.m_nActiveClient = checked(Game.m_Clients.Count - 1);
                this.m_bNeedUpdate = true;
            }
            if (!Keyboard.IsKeyTriggered(2))
                return;
            checked { ++this.m_nActiveClient; }
            if (this.m_nActiveClient >= Game.m_Clients.Count)
                this.m_nActiveClient = 0;
            this.m_bNeedUpdate = true;
        }

        public virtual void LoadLevel()
        {
            this.m_Background.Initialize();
            this.m_nActiveClient = 0;
            PointF pointF1;
            if (this.Level > 0)
            {
                checked { ++this.m_nNumIntervals; }
                this.PlayerOne.Reset();
                this.PlayerOne.Direction = 4;
                ((Sprite)this.PlayerOne).CurrentAnimation.Play();
                ((Sprite)this.PlayerOne).m_fOffsetX = -286f;
                ((Sprite)this.PlayerOne).m_fOffsetY = -144f;
                ((Sprite)this.PlayerOne).MarkDirty();
                if (this.m_nNumIntervals == 1)
                {
                    this.PlayerOne.m_nHighScores = 0;
                    this.PlayerOne.m_IntervalScores.Clear();
                }
                if (Game.m_Clients.Count > 1)
                {
                    this.PlayerTwo.Reset();
                    this.PlayerTwo.Direction = 0;
                    ((Sprite)this.PlayerTwo).CurrentAnimation.Play();
                    ((Sprite)this.PlayerTwo).m_fOffsetX = 290f;
                    ((Sprite)this.PlayerTwo).m_fOffsetY = 200f;
                    ((Sprite)this.PlayerTwo).MarkDirty();
                    if (this.m_nNumIntervals == 1)
                    {
                        this.PlayerTwo.m_nHighScores = 0;
                        this.PlayerTwo.m_IntervalScores.Clear();
                    }
                }
                Text2D text2D1 = new Text2D("Courier New", 25f, FontStyle.Bold);
                text2D1.Color = Color.White;
                text2D1.Text = this.Level.ToString("D2");
                if (this.Level >= 5)
                {
                    Text2D text2D2 = text2D1;
                    pointF1 = new PointF(-44f, -244f);
                    PointF pointF2 = pointF1;
                    text2D2.Position = pointF2;
                }
                else if (this.Level < 3)
                {
                    Text2D text2D3 = text2D1;
                    pointF1 = new PointF(-39f, -233f);
                    PointF pointF3 = pointF1;
                    text2D3.Position = pointF3;
                }
                else
                {
                    Text2D text2D4 = text2D1;
                    pointF1 = new PointF(-37f, -248f);
                    PointF pointF4 = pointF1;
                    text2D4.Position = pointF4;
                }
                Game.Add(text2D1);
                Text2D text2D5 = new Text2D("Courier New", 25f, FontStyle.Bold);
                text2D5.Color = Color.White;
                text2D5.Text = this.m_nNumIntervals.ToString("D2");
                if (this.Level >= 5)
                {
                    Text2D text2D6 = text2D5;
                    pointF1 = new PointF(14f, -244f);
                    PointF pointF5 = pointF1;
                    text2D6.Position = pointF5;
                }
                else if (this.Level < 3)
                {
                    Text2D text2D7 = text2D5;
                    pointF1 = new PointF(10f, -233f);
                    PointF pointF6 = pointF1;
                    text2D7.Position = pointF6;
                }
                else
                {
                    Text2D text2D8 = text2D5;
                    pointF1 = new PointF(12f, -248f);
                    PointF pointF7 = pointF1;
                    text2D8.Position = pointF7;
                }
                Game.Add(text2D5);
            }
            switch (this.Level)
            {
                case -3:
                    float y1 = -174f;
                    try
                    {
                        foreach (HiScoresData hiScores in this.m_HiScoresList)
                        {
                            Text2D text2D9 = new Text2D("Courier New", 20f, FontStyle.Bold);
                            text2D9.Text = hiScores.Name;
                            text2D9.Color = Color.White;
                            Text2D text2D10 = text2D9;
                            pointF1 = new PointF(-330f, y1);
                            PointF pointF8 = pointF1;
                            text2D10.Position = pointF8;
                            Game.Add(text2D9);
                            Text2D text2D11 = new Text2D("Courier New", 20f, FontStyle.Bold);
                            text2D11.Color = Color.White;
                            text2D11.Text = hiScores.Scores.ToString("D5");
                            Text2D text2D12 = text2D11;
                            pointF1 = new PointF(270f, y1);
                            PointF pointF9 = pointF1;
                            text2D12.Position = pointF9;
                            Game.Add(text2D11);
                            y1 += 45f;
                        }
                        break;
                    }
                    finally
                    {
                        IEnumerator enumerator;
                        if (enumerator is IDisposable)
                            ((IDisposable)enumerator).Dispose();
                    }
                case -2:
                    Text2D text2D13 = new Text2D("Courier New", 20f, FontStyle.Bold);
                    text2D13.Color = Color.White;
                    Text2D text2D14 = text2D13;
                    pointF1 = new PointF(-278f, -213f);
                    PointF pointF10 = pointF1;
                    text2D14.Position = pointF10;
                    Game.Add(text2D13);
                    float y2 = -148f;
                    int num1 = 1;
                    do
                    {
                        Text2D text2D15 = new Text2D("Courier New", 20f, FontStyle.Bold);
                        text2D15.Color = Color.White;
                        Text2D text2D16 = text2D15;
                        pointF1 = new PointF(-215f, y2);
                        PointF pointF11 = pointF1;
                        text2D16.Position = pointF11;
                        Game.Add(text2D15);
                        Text2D text2D17 = new Text2D("Courier New", 20f, FontStyle.Bold);
                        text2D17.Color = Color.White;
                        Text2D text2D18 = text2D17;
                        pointF1 = new PointF(35f, y2);
                        PointF pointF12 = pointF1;
                        text2D18.Position = pointF12;
                        Game.Add(text2D17);
                        Text2D text2D19 = new Text2D("Courier New", 12f, FontStyle.Bold);
                        text2D19.Color = Color.White;
                        Text2D text2D20 = text2D19;
                        pointF1 = new PointF(172f, y2 + 5f);
                        PointF pointF13 = pointF1;
                        text2D20.Position = pointF13;
                        Game.Add(text2D19);
                        y2 += 45f;
                        checked { ++num1; }
                    }
                    while (num1 <= 10);
                    this.m_bNeedUpdate = true;
                    break;
                case -1:
                    if (this.m_nSavedLevel == this.Level)
                        break;
                    try
                    {
                        foreach (Hunter client in Game.m_Clients)
                        {
                            if (client.Scores > client.m_nHighScores)
                                client.m_nHighScores = client.Scores;
                            client.m_IntervalScores.Add((object)client.Scores);
                            client.IntervalBars();
                        }
                        break;
                    }
                    finally
                    {
                        IEnumerator enumerator;
                        if (enumerator is IDisposable)
                            ((IDisposable)enumerator).Dispose();
                    }
                case 1:
                    int num2 = 1;
                    do
                    {
                        Sprite sprite = (Sprite)Obstacle.Load(Game.Random.Next(0, 2));
                        sprite.Translate((float)Game.Random.Next(-333, 333), (float)Game.Random.Next(-181, 235));
                        Game.Add(sprite);
                        sprite.CurrentAnimation.Play();
                        checked { ++num2; }
                    }
                    while (num2 <= 3);
                    int num3 = 1;
                    do
                    {
                        this.GenerateXSpot();
                        checked { ++num3; }
                    }
                    while (num3 <= 3);
                    break;
                case 2:
                    int num4 = 1;
                    do
                    {
                        Sprite sprite = (Sprite)Obstacle.Load(Game.Random.Next(0, 2));
                        double num5 = Game.Random.NextDouble();
                        if (num5 > 0.8)
                            sprite.Translate((float)Game.Random.Next(-333, -57), (float)Game.Random.Next(-181, 33));
                        else if (num5 > 0.6)
                            sprite.Translate((float)Game.Random.Next(-333, -108), (float)Game.Random.Next(33, 235));
                        else if (num5 > 0.4)
                            sprite.Translate((float)Game.Random.Next(-108, 333), (float)Game.Random.Next(84, 235));
                        else if (num5 > 0.2)
                            sprite.Translate((float)Game.Random.Next(105, 333), (float)Game.Random.Next(-181, 84));
                        else
                            sprite.Translate((float)Game.Random.Next(-55, 105), (float)Game.Random.Next(-181, -26));
                        Game.Add(sprite);
                        sprite.CurrentAnimation.Play();
                        checked { ++num4; }
                    }
                    while (num4 <= 4);
                    int num6 = 1;
                    do
                    {
                        this.GenerateXSpot();
                        checked { ++num6; }
                    }
                    while (num6 <= 4);
                    break;
                case 3:
                    int num7 = 1;
                    do
                    {
                        Sprite sprite = (Sprite)Obstacle.Load(Game.Random.Next(0, 4));
                        double num8 = Game.Random.NextDouble();
                        if (num8 > 0.8333)
                            sprite.Translate((float)Game.Random.Next(-333, -92), (float)Game.Random.Next(-181, 32));
                        else if (num8 > 0.6666)
                            sprite.Translate((float)Game.Random.Next(-333, -150), (float)Game.Random.Next(32, 235));
                        else if (num8 > 0.5)
                            sprite.Translate((float)Game.Random.Next(-150, 333), (float)Game.Random.Next(133, 235));
                        else if (num8 > 0.3333)
                            sprite.Translate((float)Game.Random.Next(107, 333), (float)Game.Random.Next(-106, 133));
                        else if (num8 > 0.1666)
                            sprite.Translate((float)Game.Random.Next(-92, 224), (float)Game.Random.Next(-181, -106));
                        else
                            sprite.Translate((float)Game.Random.Next(-92, 107), (float)Game.Random.Next(-106, -6));
                        Game.Add(sprite);
                        sprite.CurrentAnimation.Play();
                        checked { ++num7; }
                    }
                    while (num7 <= 3);
                    Sprite sprite1 = (Sprite)Enemy.Load(0);
                    sprite1.Translate((float)Game.Random.Next(-333, 333), (float)Game.Random.Next(-132, 235));
                    Game.Add(sprite1);
                    sprite1.CurrentAnimation.Play();
                    AudioSource audioSource1 = AudioManager.Singleton.LoadAudioSource("../TreasureHunter/Sound/Croc.wav");
                    audioSource1.Looping = true;
                    audioSource1.Play();
                    int num9 = 1;
                    do
                    {
                        this.GenerateXSpot();
                        checked { ++num9; }
                    }
                    while (num9 <= 4);
                    break;
                case 4:
                    int num10 = 1;
                    do
                    {
                        Sprite sprite2 = (Sprite)Obstacle.Load(Game.Random.Next(0, 5));
                        if (Game.Random.NextDouble() > 0.5)
                            sprite2.Translate((float)Game.Random.Next(-333, -100), (float)Game.Random.Next(-181, 235));
                        else
                            sprite2.Translate((float)Game.Random.Next(126, 333), (float)Game.Random.Next(-181, 235));
                        Game.Add(sprite2);
                        sprite2.CurrentAnimation.Play();
                        checked { ++num10; }
                    }
                    while (num10 <= 4);
                    Sprite sprite3 = (Sprite)Enemy.Load(0);
                    sprite3.Translate((float)Game.Random.Next(-333, 333), (float)Game.Random.Next(-132, 235));
                    Game.Add(sprite3);
                    sprite3.CurrentAnimation.Play();
                    AudioSource audioSource2 = AudioManager.Singleton.LoadAudioSource("../TreasureHunter/Sound/Croc.wav");
                    audioSource2.Looping = true;
                    audioSource2.Play();
                    int num11 = 1;
                    do
                    {
                        this.GenerateXSpot();
                        checked { ++num11; }
                    }
                    while (num11 <= 5);
                    break;
                case 5:
                    int num12 = 1;
                    do
                    {
                        Sprite sprite4 = (Sprite)Obstacle.Load(Game.Random.Next(0, 6));
                        double num13 = Game.Random.NextDouble();
                        if (num13 > 0.6666)
                            sprite4.Translate((float)Game.Random.Next(-333, -172), (float)Game.Random.Next(-181, 235));
                        else if (num13 > 0.3333)
                            sprite4.Translate((float)Game.Random.Next(-115, 50), (float)Game.Random.Next(-181, 28));
                        else
                            sprite4.Translate((float)Game.Random.Next(108, 333), (float)Game.Random.Next(86, 235));
                        Game.Add(sprite4);
                        sprite4.CurrentAnimation.Play();
                        checked { ++num12; }
                    }
                    while (num12 <= 4);
                    Sprite sprite5 = (Sprite)Obstacle.Load(6);
                    sprite5.Translate(-32f, 147.15f);
                    Game.Add(sprite5);
                    sprite5.CurrentAnimation.Play();
                    Sprite sprite6 = (Sprite)Enemy.Load(0);
                    sprite6.Translate((float)Game.Random.Next(-333, 333), (float)Game.Random.Next(-132, 235));
                    Game.Add(sprite6);
                    sprite6.CurrentAnimation.Play();
                    AudioSource audioSource3 = AudioManager.Singleton.LoadAudioSource("../TreasureHunter/Sound/Croc.wav");
                    audioSource3.Looping = true;
                    audioSource3.Play();
                    Sprite sprite7 = (Sprite)Enemy.Load(1);
                    sprite7.Translate((float)Game.Random.Next(-333, 333), (float)Game.Random.Next(-181, 235));
                    Game.Add(sprite7);
                    sprite7.CurrentAnimation.Play();
                    AudioSource audioSource4 = AudioManager.Singleton.LoadAudioSource("../TreasureHunter/Sound/Mummy.wav");
                    audioSource4.Looping = true;
                    audioSource4.Play();
                    int num14 = 1;
                    do
                    {
                        this.GenerateXSpot();
                        checked { ++num14; }
                    }
                    while (num14 <= 7);
                    break;
            }
        }

        public virtual void Stop_Game()
        {
            if (this.Level > 0 | this.Level == -1)
            {
                this.m_nNumIntervals = 0;
                DateTime now = DateTime.Now;
                try
                {
                    foreach (Hunter client in Game.m_Clients)
                    {
                        ScoresHistoryData data = new ScoresHistoryData();
                        try
                        {
                            foreach (object intervalScore in client.m_IntervalScores)
                            {
                                int num = IntegerType.FromObject(intervalScore);
                                checked { data.Scores += num; }
                            }
                        }
                        finally
                        {
                            IEnumerator enumerator;
                            if (enumerator is IDisposable)
                                ((IDisposable)enumerator).Dispose();
                        }
                        data.Level = this.Level > 0 ? this.Level : this.m_nSavedLevel;
                        data.Day = now.Day;
                        data.Month = now.Month;
                        data.Year = now.Year;
                        client.AddHistoryData(data);
                        this.AddHiScoresData(new HiScoresData()
                        {
                            Name = StringType.FromObject(client.Client_Name.Clone()),
                            Scores = data.Scores
                        });
                    }
                }
                finally
                {
                    IEnumerator enumerator;
                    if (enumerator is IDisposable)
                        ((IDisposable)enumerator).Dispose();
                }
            }
            base.Stop_Game();
            this.m_nSavedLevel = -1;
        }

        public XSpot GenerateXSpot()
        {
            XSpot xspot = new XSpot();
            xspot.m_Game = this;
            switch (this.Level)
            {
                case 1:
                    xspot.m_nEndSelection = 4;
                    break;
                case 2:
                    xspot.m_nEndSelection = 6;
                    break;
                case 3:
                    xspot.m_nEndSelection = 8;
                    break;
                case 4:
                    xspot.m_nEndSelection = 9;
                    break;
                case 5:
                    xspot.m_nEndSelection = 10;
                    break;
            }
            xspot.Initialize();
            xspot.Translate((float)Game.Random.Next(-317, 315), (float)Game.Random.Next(-168, 222));
            Game.Add((Sprite)xspot);
            return xspot;
        }

        public virtual void Pause_Game()
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
                IEnumerator enumerator;
                if (enumerator is IDisposable)
                    ((IDisposable)enumerator).Dispose();
            }
            try
            {
                foreach (Sprite sprite in Game.m_Sprites)
                    sprite.Active = false;
            }
            finally
            {
                IEnumerator enumerator;
                if (enumerator is IDisposable)
                    ((IDisposable)enumerator).Dispose();
            }
            Frame frame = new Frame();
            frame.Image = Game.LoadImage("../TreasureHunter/Images/Background/Pause.png");
            Animation animation = new Animation();
            animation.Add(frame);
            Sprite sprite1 = new Sprite();
            sprite1.Add(animation);
            sprite1.ZOrder = 10f;
            Game.Add(sprite1);
            this.m_bIsPaused = true;
            base.Pause_Game();
        }

        public void LoadHiScores()
        {
            FileStream fileStream = (FileStream)null;
            StreamReader streamReader = (StreamReader)null;
            if (File.Exists("../TreasureHunter/Data/HiScores/list.txt"))
            {
                try
                {
                    fileStream = File.OpenRead("../TreasureHunter/Data/HiScores/list.txt");
                    streamReader = new StreamReader((Stream)fileStream);
                    char[] charArray = " \\t\\n\\r".ToCharArray();
                    while (streamReader.Peek() >= 0)
                    {
                        string[] strArray = streamReader.ReadLine().Split(charArray);
                        this.m_HiScoresList.Add((object)new HiScoresData()
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
            }
            else
            {
                int num = 1;
                do
                {
                    this.m_HiScoresList.Add((object)new HiScoresData()
                    {
                        Name = "Demo",
                        Scores = 10
                    });
                    checked { ++num; }
                }
                while (num <= 10);
            }
            this.m_HiScoresList.Sort();
            int num1 = checked(this.m_HiScoresList.Count - 10);
            int num2 = 1;
            while (num2 <= num1)
            {
                this.m_HiScoresList.RemoveAt(checked(this.m_HiScoresList.Count - 1));
                checked { ++num2; }
            }
        }

        public void SaveHiScores()
        {
            this.m_HiScoresList.Sort();
            int num1 = checked(this.m_HiScoresList.Count - 10);
            int num2 = 1;
            while (num2 <= num1)
            {
                this.m_HiScoresList.RemoveAt(checked(this.m_HiScoresList.Count - 1));
                checked { ++num2; }
            }
            StreamWriter streamWriter = (StreamWriter)null;
            try
            {
                streamWriter = File.CreateText("../TreasureHunter/Data/HiScores/list.txt");
                try
                {
                    foreach (HiScoresData hiScores in this.m_HiScoresList)
                        streamWriter.WriteLine(hiScores.ToString());
                }
                finally
                {
                    IEnumerator enumerator;
                    if (enumerator is IDisposable)
                        ((IDisposable)enumerator).Dispose();
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
                streamWriter?.Close();
            }
        }

        public void AddHiScoresData(HiScoresData data)
        {
            if (data == null)
                return;
            this.m_HiScoresList.Add((object)data);
            this.m_HiScoresList.Sort();
            int num1 = checked(this.m_HiScoresList.Count - 10);
            int num2 = 1;
            while (num2 <= num1)
            {
                this.m_HiScoresList.RemoveAt(checked(this.m_HiScoresList.Count - 1));
                checked { ++num2; }
            }
        }
    }

















    public class XSpot : Sprite
    {
        public int m_nDiggingUnit;
        public int m_nArtifact;
        public int m_nEndSelection;
        public int m_nPoints;
        public Hunter m_Hunter;
        public int m_nNumFrames;
        public TreasureHunter.TreasureHunter m_Game;
        public const int XSPOT_ARTIFACTS_COINS = 0;
        public const int XSPOT_ARTIFACTS_DIAMOND = 1;
        public const int XSPOT_ARTIFACTS_EMERALD = 2;
        public const int XSPOT_ARTIFACTS_RUBY = 3;
        public const int XSPOT_ARTIFACTS_FOSSIL = 4;
        public const int XSPOT_ARTIFACTS_STATUETTE = 5;
        public const int XSPOT_ARTIFACTS_SWORD = 6;
        public const int XSPOT_ARTIFACTS_SHIELD = 7;
        public const int XSPOT_ARTIFACTS_AMULET = 8;
        public const int XSPOT_ARTIFACTS_INGOT = 9;
        public const int XSPOT_ARTIFACTS_TOTAL = 10;

        public void Initialize()
        {
            this.m_nArtifact = Game.m_Randomizer.Next(0, this.m_nEndSelection);
            Frame frame = new Frame();
            frame.Image = Game.LoadImage("../TreasureHunter/Images/Obstacles/XSpot.png");
            Vector2 vector2_1;
            ((Vector2)ref vector2_1).X = -4.5f;
            ((Vector2)ref vector2_1).Y = -5f;
            Vector2 vector2_2;
            ((Vector2)ref vector2_2).X = -4.5f;
            ((Vector2)ref vector2_2).Y = 1f;
            Vector2 vector2_3;
            ((Vector2)ref vector2_3).X = 2.5f;
            ((Vector2)ref vector2_3).Y = 1f;
            Vector2 vector2_4;
            ((Vector2)ref vector2_4).X = 2.5f;
            ((Vector2)ref vector2_4).Y = -5f;
            HitBox hitBox;
            ((HitBox)ref hitBox).Set(vector2_1, vector2_2, vector2_3, vector2_4);
            frame.Add(hitBox);
            Animation animation = new Animation();
            animation.Add(frame);
            this.Add(animation);
            this.ZOrder = -6f;
            this.m_nNumFrames = 30;
            switch (this.m_nArtifact)
            {
                case 0:
                case 1:
                    this.m_nDiggingUnit = 4;
                    this.m_nPoints = 10;
                    break;
                case 2:
                case 3:
                    this.m_nDiggingUnit = 6;
                    this.m_nPoints = 20;
                    break;
                case 4:
                case 5:
                    this.m_nDiggingUnit = 8;
                    this.m_nPoints = 40;
                    break;
                case 6:
                case 7:
                    this.m_nDiggingUnit = 12;
                    this.m_nPoints = 60;
                    break;
                case 8:
                    this.m_nDiggingUnit = 16;
                    this.m_nPoints = 80;
                    break;
                case 9:
                    this.m_nDiggingUnit = 20;
                    this.m_nPoints = 100;
                    break;
            }
        }

        public static Sprite LoadArtifact(int Id)
        {
            Effect effect = (Effect)null;
            switch (Id)
            {
                case 0:
                    effect = new Effect();
                    Animation animation1 = new Animation();
                    animation1.Add(new Frame()
                    {
                        Image = Game.LoadImage("../TreasureHunter/Images/Treasures/Coins.png")
                    });
                    effect.Add(animation1);
                    break;
                case 1:
                    effect = new Effect();
                    Animation animation2 = new Animation();
                    animation2.Add(new Frame()
                    {
                        Image = Game.LoadImage("../TreasureHunter/Images/Treasures/Diamond.png")
                    });
                    effect.Add(animation2);
                    break;
                case 2:
                    effect = new Effect();
                    Animation animation3 = new Animation();
                    animation3.Add(new Frame()
                    {
                        Image = Game.LoadImage("../TreasureHunter/Images/Treasures/Emerald.png")
                    });
                    effect.Add(animation3);
                    break;
                case 3:
                    effect = new Effect();
                    Animation animation4 = new Animation();
                    animation4.Add(new Frame()
                    {
                        Image = Game.LoadImage("../TreasureHunter/Images/Treasures/Ruby.png")
                    });
                    effect.Add(animation4);
                    break;
                case 4:
                    effect = new Effect();
                    Animation animation5 = new Animation();
                    animation5.Add(new Frame()
                    {
                        Image = Game.LoadImage("../TreasureHunter/Images/Treasures/Fossil.png")
                    });
                    effect.Add(animation5);
                    break;
                case 5:
                    effect = new Effect();
                    Animation animation6 = new Animation();
                    animation6.Add(new Frame()
                    {
                        Image = Game.LoadImage("../TreasureHunter/Images/Treasures/Statuette.png")
                    });
                    effect.Add(animation6);
                    break;
                case 6:
                    effect = new Effect();
                    Animation animation7 = new Animation();
                    animation7.Add(new Frame()
                    {
                        Image = Game.LoadImage("../TreasureHunter/Images/Treasures/Sword.png")
                    });
                    effect.Add(animation7);
                    break;
                case 7:
                    effect = new Effect();
                    Animation animation8 = new Animation();
                    animation8.Add(new Frame()
                    {
                        Image = Game.LoadImage("../TreasureHunter/Images/Treasures/Shield.png")
                    });
                    effect.Add(animation8);
                    break;
                case 8:
                    effect = new Effect();
                    Animation animation9 = new Animation();
                    animation9.Add(new Frame()
                    {
                        Image = Game.LoadImage("../TreasureHunter/Images/Treasures/Amulet.png")
                    });
                    effect.Add(animation9);
                    break;
                case 9:
                    effect = new Effect();
                    Animation animation10 = new Animation();
                    animation10.Add(new Frame()
                    {
                        Image = Game.LoadImage("../TreasureHunter/Images/Treasures/Ingot.png")
                    });
                    effect.Add(animation10);
                    break;
            }
            return (Sprite)effect;
        }

        public virtual void Update(double elapsed)
        {
            if (this.m_nNumFrames <= 0)
            {
                Game.Remove((Sprite)this);
                this.m_Game.GenerateXSpot();
            }
            else
            {
                if (this.m_bIsDirty)
                    return;
                ArrayList collidedSprites = Game.GetCollidedSprites((Sprite)this);
                try
                {
                    foreach (Sprite sprite in collidedSprites)
                    {
                        if (!(sprite is Hunter) & !(sprite is Enemy) & !(sprite is Background))
                        {
                            HitBox hitBox1 = this.HitBoxes[0];
                            HitBox[] hitBoxes = sprite.HitBoxes;
                            int index = 0;
                            while (index < hitBoxes.Length)
                            {
                                HitBox hitBox2 = hitBoxes[index];
                                if (((HitBox)ref hitBox2).IntersectWith(hitBox1))
                                {
                                    Vector2 vector2 = Vector2.op_Subtraction(hitBox1.Center, hitBox2.Center);
                                    float num1 = ((Vector2)ref hitBox2.Extents).X + ((Vector2)ref hitBox1.Extents).X - Math.Abs(((Vector2)ref vector2).X);
                                    float num2 = ((Vector2)ref hitBox2.Extents).Y + ((Vector2)ref hitBox1.Extents).Y - Math.Abs(((Vector2)ref vector2).Y);
                                    if ((double)((Vector2)ref vector2).X < 0.0)
                                        ((Vector2)ref vector2).X = -1f;
                                    else if ((double)((Vector2)ref vector2).X > 0.0)
                                        ((Vector2)ref vector2).X = 1f;
                                    if ((double)((Vector2)ref vector2).Y < 0.0)
                                        ((Vector2)ref vector2).Y = -1f;
                                    else if ((double)((Vector2)ref vector2).Y > 0.0)
                                        ((Vector2)ref vector2).Y = 1f;
                                    if ((double)num2 < (double)num1)
                                    {
                                        this.Translate(0.0f, ((Vector2)ref vector2).Y * (num2 + 1f));
                                        break;
                                    }
                                    this.Translate(((Vector2)ref vector2).X * (num1 + 1f), 0.0f);
                                    break;
                                }
                                checked { ++index; }
                            }
                            break;
                        }
                    }
                }
                finally
                {
                    IEnumerator enumerator;
                    if (enumerator is IDisposable)
                        ((IDisposable)enumerator).Dispose();
                }
            }
        }
    }
}