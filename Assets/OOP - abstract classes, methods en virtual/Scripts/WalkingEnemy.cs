using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : Enemy
{
    void Awake()
    {
        Initialize();
    }

    void Update()
    {
        Move();
        Attack();
        TargetDetection();
    }

    public override void Move()
    {
        if (target != null)
        {
            Vector2 direction = target.position - transform.position;
            Vector2 move = new Vector2(direction.x, 0).normalized * speed;
            rb2d.velocity = move;

            if (Vector2.Distance(target.position, transform.position) < attackRange)
            {
                Attack();
            }
        }
    }

    protected override void Attack()
    {
        if (attackTimer <= 0)
        {
            Debug.Log("WALKING ENEMY ATTACK");
        
            //probably set a layermask for less collisions and more performance
            var hits = Physics2D.OverlapCircleAll(transform.position, attackRange);
            foreach (var hit in hits)
            {
                //this performance will improve when using a layermask in the collision
                if (hit.GetComponent<Player>())
                {
                    hit.GetComponent<Player>().TakeDamage(damage);
                }
            }
            
            attackTimer = attackDelay;
        }
        else
        {
            attackTimer -= Time.deltaTime;
        }
    }
}
