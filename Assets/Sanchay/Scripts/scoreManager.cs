using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreManager : MonoBehaviour
{
    public int Score;
    

    private void Start()
    {
        Score = 0;
    }

    private void Update()
    {
        AddScoreDistance();
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
