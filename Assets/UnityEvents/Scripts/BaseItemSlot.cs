using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseItemSlot
{
    private BaseItem _item = null;
    private int _stackAmount = 0;

    public BaseItem Item
    {
        get
        {
            return _item; 
        }
        set
        {
            _item = value;
            
            if (_item == null)
            {
                StackAmount = 0;
            }
        }
    }

    public int StackAmount
    {
        get
        {
            return _stackAmount; 
        }
        set
        {
            ItemStackDictionary.StackTypeDictionary.TryGetValue(Item.StackType, out var tempAmount);
            _stackAmount = Mathf.Clamp(value, 0, tempAmount);
        }        
    }
}
