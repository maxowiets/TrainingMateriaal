using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboScore : Score
{
    [SerializeField] private float baseFontSize;
    [SerializeField] private int comboDuration;
    private Coroutine _comboCoroutine;

    private void Awake()
    {
        scoreUI.text = string.Empty;
    }

    public override void AddScoreValue(int value)
    {
        _scoreValue += value;
        scoreUI.text = _scoreValue.ToString();
        scoreUI.fontSize = baseFontSize + _scoreValue * 0.1f;

        if (_comboCoroutine != null)
        {
            StopCoroutine(_comboCoroutine);
        }
        _comboCoroutine = StartCoroutine(ComboCoroutine());
    }

    private IEnumerator ComboCoroutine()
    {
        yield return new WaitForSeconds(comboDuration);
        ScoreManager.Instance.SetHighScore(_scoreValue);
        _scoreValue = 0;
        scoreUI.text = string.Empty;
    }
}
