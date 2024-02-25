using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class Character : MonoBehaviour
{
    public float health;
    public float speed;
    public float gravity;

    [HideInInspector] public BoxCollider2D col2d;
    [HideInInspector] public Rigidbody2D rb2d;
    
    public abstract void Move();

    protected virtual void Initialize()
    {
        col2d = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = gravity;
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            OnDie();
        }
    }

    protected virtual void OnDie()
    {
        Destroy(gameObject);
    }
}
