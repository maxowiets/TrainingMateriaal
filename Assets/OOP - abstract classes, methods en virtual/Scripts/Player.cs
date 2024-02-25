using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : AggressiveCharacter
{
    private void Awake()
    {
        Initialize();
    }

    private void Update()
    {
        Move();
        Attack();
    }

    public override void Move()
    {
        Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;
        rb2d.velocity = move;
    }

    protected override void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("PLAYER ATTACK");
            //probably set a layermask for less collisions and more performance
            var hits = Physics2D.OverlapCircleAll(transform.position, 5);
            foreach (var hit in hits)
            {
                //this performance will improve when using a layermask in the collision
                if (hit.GetComponent<Enemy>())
                {
                    hit.GetComponent<Enemy>().TakeDamage(damage);
                    ScoreManager.Instance.AddScore((int)damage);
                }
            }
        }
    }
}
