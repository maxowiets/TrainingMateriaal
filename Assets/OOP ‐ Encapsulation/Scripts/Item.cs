using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Item", menuName = "Items/Item", order = 1)]
public class Item : ScriptableObject
{
    [SerializeField] private Color itemColor; //would normally be a sprite
    
    public Color ItemColor => itemColor;
}
