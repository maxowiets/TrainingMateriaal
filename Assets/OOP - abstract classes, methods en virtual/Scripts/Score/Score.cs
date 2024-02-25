using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreUI;
    protected int _scoreValue = 0;

    public abstract void AddScoreValue(int value);
}