using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scoreManager : MonoBehaviour
{
    public int Score;
    public TextMeshProUGUI scoreText;

    

    private void Start()
    {
        Score = 0;
        InvokeRepeating("AddScoreDistance", 1f, 1f);
    }

    private void Update()
    {
        //AddScoreDistance();
        scoreText.text = Score.ToString();
    }

   


    public void AddScoreDistance()
    {
        Score++;
    }

    public void ReduceScore()
    {
        Score -= 50;
    }

    public void AddScoreWeed()
    {
        Score += 5;
    }

    public void AddScoreAlcohol()
    {
        Score += 10;
    }
}
