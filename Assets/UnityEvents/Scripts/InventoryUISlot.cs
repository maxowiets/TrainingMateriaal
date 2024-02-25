using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InventoryUISlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemValue;
    [SerializeField] private Image image;

    public void ClearSlot()
    {
        itemValue.enabled = false;
        image.enabled = false;
    }

    public void UpdateSlot(BaseItemSlot itemSlot)
    {
        if (itemSlot == null)
        {
            ClearSlot();
            return;
        }

        itemValue.text = itemSlot.StackAmount > 1 ? itemSlot.StackAmount.ToString() : string.Empty;
        itemValue.enabled = true;
        
        if (itemSlot.Item == null)
        {
            image.enabled = false;
        }
        else
        {
            image.sprite = itemSlot.Item.Icon;
            image.enabled = true;
        }
    }
}
