using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance;
    
    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ScoreManager>();
                if (_instance == null)
                {
                    _instance = new GameObject("PlayerDashManager").AddComponent<ScoreManager>();
                }
            }
            return _instance;
        }
    }
    
    private Score _comboScore;
    private Score _highScore;

    private void Awake()
    {
        //might be no reference to a UI element
        _comboScore = gameObject.GetComponent<ComboScore>() ?? gameObject.AddComponent<ComboScore>();
        _highScore = gameObject.GetComponent<HighScore>() ?? gameObject.AddComponent<HighScore>();
    }

    public void AddScore(int value)
    {
        _comboScore.AddScoreValue(value);
    }

    public void SetHighScore(int value)
    {
        _highScore.AddScoreValue(value);
    }
}
