using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    [SerializeField] private InventoryUISlot itemSlotUI;
    private List<InventoryUISlot> _itemSlotUis;
    
    private void OnEnable()
    {
        InventorySystem.OnItemAdded += UpdateUI;
        InventorySystem.OnReset += Reset;
    }

    private void OnDisable()
    {
        InventorySystem.OnItemAdded -= UpdateUI;
        InventorySystem.OnReset -= Reset;
    }

    private void UpdateUI(BaseItemSlot itemSlot, int index)
    {
        _itemSlotUis[index].UpdateSlot(itemSlot);
    }

    private void Reset(List<BaseItemSlot> itemSlots)
    {
        _itemSlotUis = new List<InventoryUISlot>();
        for (int i = 0; i < itemSlots.Count; i++)
        {
            var newItemSlotUi = Instantiate(itemSlotUI, transform);
            newItemSlotUi.UpdateSlot(itemSlots[i]);
            _itemSlotUis.Add(newItemSlotUi);
            
        }
    }
}
