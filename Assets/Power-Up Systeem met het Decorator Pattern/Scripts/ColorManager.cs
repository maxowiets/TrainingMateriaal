using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    [SerializeField] private IColor playerColor;
    [SerializeField] private SpriteRenderer sprite;

    private void Start()
    {
        playerColor = new PlayerColor();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerColor = new RedColorDecorator(playerColor);
            ApplyChanges();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerColor = new GreenColorDecorator(playerColor);
            ApplyChanges();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playerColor = new BlueColorDecorator(playerColor);
            ApplyChanges();
        }
    }

    private void ApplyChanges()
    {
        sprite.color = playerColor.BaseColor();
    }
}
