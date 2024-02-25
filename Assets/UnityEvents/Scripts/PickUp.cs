using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour, ICollectable
{
    public static event HandlePickUpCollected OnPickUpCollected;
    public delegate void HandlePickUpCollected(BaseItem baseItem);
    [SerializeField] private BaseItem item;
    
    public void Collect()
    {
        OnPickUpCollected?.Invoke(item);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Collect();
            Collect();
        }
    }
}
