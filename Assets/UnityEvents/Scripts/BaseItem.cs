using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Item", menuName = "Items/BaseItem", order = 1)]
public class BaseItem : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private int itemId;
    [SerializeField] private string description;
    [SerializeField] private Sprite icon;
    [SerializeField] private int stackAmount;
    [SerializeField] private StackType stackType;

    public string Name => itemName;
    public int ItemId => itemId;
    public string Description => description;
    public Sprite Icon => icon;

    public int StackAmount
    {
        get => stackAmount;
        set => stackAmount = value;
    }
    public StackType StackType => stackType;
}

public enum StackType
{
    Unique = 0,     // == 1
    Small,          // == 4
    Medium,         // == 16
    Large           // == 64
}

public static class ItemStackDictionary
{
    public static Dictionary<StackType, int> StackTypeDictionary = new Dictionary<StackType, int>
    {
        { StackType.Unique, 1 },
        { StackType.Small, 4 },
        { StackType.Medium, 16 },
        { StackType.Large, 64 }
    };
}