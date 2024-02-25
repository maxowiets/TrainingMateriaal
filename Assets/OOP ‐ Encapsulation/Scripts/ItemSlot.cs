using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Color defaultColor = Color.white;
    private Image _sprite;
    private Item _item;
    
    public Item Item
    {
        get => _item;
        set
        {
            if (value != null)
            {
                _item = value;
                _sprite.color = value.ItemColor;
            }
            else
            {
                _item = null;
                _sprite.color = defaultColor;
            }
            
        }
    }

    public void ClearItemSlot()
    {
        Item = null;
    }

    private void Awake()
    {
        _sprite = GetComponent<Image>();
    }
}
