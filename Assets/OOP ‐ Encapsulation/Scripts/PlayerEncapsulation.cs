using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerEncapsulation : MonoBehaviour
{
    public EnemyEncapsulation enemy;
    
    [SerializeField] private float maxHealth;
    [SerializeField] private float damage;
    [SerializeField] private Inventory inventory;

    [SerializeField] private List<Item> allItemsList = new List<Item>(); //for simplicity the items are stored here for now.
    
    private float health;
    
    public float Health
    {
        get => health;
        set => health = Mathf.Clamp(value, 0, MaxHealth);
    }

    public float MaxHealth
    {
        get => maxHealth;
        set
        {
            //increase health
            if (value > maxHealth)
            {
                var diff = value - MaxHealth;   //maxHealth or MaxHealth?
                maxHealth = value;                  // do this before "Health += diff", because you might miss out on a heal
                Health += diff;
            }
            else
            {
                maxHealth = value;
                Health = MaxHealth;                 //maxHealth or MaxHealth?
            }
        }
    }

    private void Start()
    {
        health = maxHealth;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            enemy.Health -= damage;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            inventory.TryAddItem(allItemsList[Random.Range(0, allItemsList.Count)]);
        }
    }
}
