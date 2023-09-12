using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public GameObject player;
    public TMP_Text scoreTxt;
    public static float score;
    

    // Score = how high they manage to go up

    // Update is called once per frame
    void Update()
    {
        //score = Mathf.Round(player.transform.position.y);
        //scoreTxt.text = "Score: " + score;

        //if (score < 0)
        //{
        //    score = 0;
        //}
        scoreTxt.text = Mathf.Round(score).ToString();
    }

    public void AddScore(float multiplyer, float platformYDistance, bool fullyCharge)
    {
        float iterationScore = 0;
        if (fullyCharge)
            iterationScore = 5;

        iterationScore += (platformYDistance * multiplyer);

        score += iterationScore;

        scoreTxt.text = Mathf.Round(score).ToString();
    }
}
