using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEncapsulation : MonoBehaviour
{
    public PlayerEncapsulation player;
    
    [SerializeField] private float maxHealth;
    [SerializeField] private float armor;
    [SerializeField] private float damage;
    
    private float health;
    
    public float Health
    {
        get => health;
        set
        {
            //calculate difference
            var diff = Health - value;
            if (diff > 0)
            {
                //subtract armor
                diff = Mathf.Clamp(diff - armor, 0, diff);
                //if still > 0, take damage and increase armor
                if (diff > 0)
                {
                    health = Mathf.Clamp(health - diff, 0, maxHealth);
                    armor += 1;
                }
            }
            else
            {
                health = value;
            }
        }
    }

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            player.Health -= damage;
        }
    }
}
