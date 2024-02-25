using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteractable : MonoBehaviour, IDamageable
{
    [SerializeField] private int health;

    public void TakeDamage(int damage)
    {
        Debug.Log("Enemy took " + damage + " damage");
        health -= damage;
        if (health <= 0)
        {
            OnDie();
        }
    }

    public void OnDie()
    {
        Destroy(gameObject);
    }
}