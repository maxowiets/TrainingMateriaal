using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Inventory : MonoBehaviour
{
    [SerializeField] private ItemSlot[] itemSlots;

    public void TryAddItem(Item newItem)
    {
        foreach (var slot in itemSlots)
        {
            if (slot.Item == null)
            {
                slot.Item = newItem;
                return;
            }
        }

        return;
    }

    private void AddItemToInventory(Item newItem, int index)
    {
        itemSlots[index].Item = newItem;
    }
}
