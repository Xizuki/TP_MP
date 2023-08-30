using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tweening : MonoBehaviour
{
    public static bool comboUp;

    public GameObject combo;
    public GameObject score;
    public void ComboUp() //Scale the combo to the indicated scale
    {

        LeanTween.scale(combo, new Vector3(0.75f, 0.75f, 0.75f), 0.025f).setOnComplete(ComboUp2).setEaseInCirc();

    }

    public void ScoreUp()
    {

        //LeanTween.scale(score, new Vector3(1f, 1f, 1f), 0.025f).setOnComplete(ScoreUp2).setEaseInCirc();

    }

    /*    public void ComboUp1()
        {
            LeanTween.scale(combo, new Vector3(1f, 1f, 1f), 0.05f).setOnComplete(ComboUp2).setEaseLinear();
        }*/

    public void ComboUp2() //Scale the combo to this scale when called by SetOnComplete
    {
        LeanTween.scale(combo, new Vector3(1.2f, 1.25f, 1.25f), 0.1f).setLoopPingPong(1).setEaseOutCirc();
    }

    public void ScoreUp2()
    {
        LeanTween.scale(score, new Vector3(1.1f, 1.1f, 1.1f), 0.1f).setLoopPingPong(1).setEaseOutCirc();
    }

    /*public void ReturnToSize()
    {
        LeanTween.scale(combo, new Vector3(0.75f, 0.75f, 0.75f), 0.25f).setEaseOutCirc();
    }*/
    private void Update()
    {
        if (comboUp == true)
        {
            ComboUp();
            ScoreUp();
            comboUp = false;
        }
    }
}
