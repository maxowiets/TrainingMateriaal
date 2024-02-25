using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider;
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();

        _spriteRenderer.color = Color.white;

        _collider.isTrigger = false;
    }

    public void Interact()
    {
        Debug.Log("Invert Door");
        _collider.isTrigger = !_collider.isTrigger;

        _spriteRenderer.color = new Color(1, 1, 1, _collider.isTrigger ? 0.2f : 1f);

    }
}
