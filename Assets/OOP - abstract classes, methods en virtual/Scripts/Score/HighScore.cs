using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : Score
{
    public override void AddScoreValue(int value)
    {
        if (value > _scoreValue)
        {
            _scoreValue = value;
            scoreUI.text = "Highscore: " + value.ToString();
        }        
    }
}
