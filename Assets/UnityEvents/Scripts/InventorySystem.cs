using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class InventorySystem : MonoBehaviour
{
    public static event OnItemAddedHandler OnItemAdded;
    public delegate void OnItemAddedHandler(BaseItemSlot itemSlot, int index);

    public static event OnResetHandler OnReset;
    public delegate void OnResetHandler(List<BaseItemSlot> itemSlots);
    
    //[SerializeField] private UnityEvent OnItemRemoved;
    //[SerializeField] private UnityEvent OnReset;

    [SerializeField] private int inventorySize;
    [SerializeField] private List<BaseItemSlot> _inventory;

    private void OnEnable()
    {
        PickUp.OnPickUpCollected += AddItem;
    }

    private void OnDisable()
    {
        PickUp.OnPickUpCollected -= AddItem;
    }

    private void Awake()
    {
        ResetInventory();
    }

    void AddItem(BaseItem newItem)
    {
        BaseItem tempItem = Instantiate(newItem);
        
        #region AddToExistingItemSlot
        //skip this part if item is of type Unique
        if (tempItem.StackType != StackType.Unique)
        {
            //loop through each inventory slot and look if item already exists and then add to it if possible
            for(int i = 0; i < inventorySize; i++)
            {
                if (_inventory[i].Item == null) continue;

                //check if item exists
                if (_inventory[i].Item.ItemId == tempItem.ItemId)
                {
                    //get stack amount
                    ItemStackDictionary.StackTypeDictionary.TryGetValue(tempItem.StackType,
                        out var currentStackTotal);
                    var remainingSpace = currentStackTotal - _inventory[i].StackAmount;

                    //check if amount can be added
                    if (remainingSpace > 0)
                    {
                        //add maximum amount to currentStack
                        _inventory[i].StackAmount += Mathf.Min(tempItem.StackAmount, remainingSpace);
                        Debug.Log($"Added {Mathf.Min(tempItem.StackAmount, remainingSpace)} to existing stack");
                        OnItemAdded?.Invoke(_inventory[i], i);
                        
                        tempItem.StackAmount -= Mathf.Min(tempItem.StackAmount, remainingSpace);
                        Debug.Log($"{tempItem.StackAmount} {tempItem.Name} left");

                        if (tempItem.StackAmount <= 0)
                        {
                            break;
                        }
                    }
                }
            }
        }

        #endregion
        
        #region CreateNewItemSlot
        // If amount remains, add to new slot
        if (tempItem.StackAmount <= 0) return;
            
        for (int i = 0; i < _inventory.Count; i++)
        {
            if (_inventory[i].Item == null)
            {
                // Add the item to a new slot
                _inventory[i].Item = Instantiate(tempItem); // Instantiate new instance
                ItemStackDictionary.StackTypeDictionary.TryGetValue(tempItem.StackType, out var currentStackTotal);
                _inventory[i].StackAmount = Mathf.Min(tempItem.StackAmount, currentStackTotal);
                tempItem.StackAmount -= _inventory[i].StackAmount;
                
                Debug.Log($"Created a new stack of {_inventory[i].StackAmount} {tempItem.Name}");
                OnItemAdded?.Invoke(_inventory[i], i);

                if (tempItem.StackAmount <= 0)
                {
                    break;
                }
            }
        }

        #endregion
       
        #region DropRemainders
            //if no more slots left, 'dump' remaining items
            if (tempItem.StackAmount > 0)
            {
                Debug.Log($"There is still {tempItem.StackAmount} {tempItem.Name} left");
                //drop itemstack
            }
        #endregion
    }

    void RemoveItem(int index)
    {
        //drop item
        
        //remove item from list
        _inventory[index].Item = null;
    }

    void ResetInventory()
    {
        _inventory?.Clear();
        _inventory = new List<BaseItemSlot>();
        for (int i = 0; i < inventorySize; i++)
        {
            _inventory.Add(new BaseItemSlot());
        }
        OnReset?.Invoke(_inventory);
    }
}
