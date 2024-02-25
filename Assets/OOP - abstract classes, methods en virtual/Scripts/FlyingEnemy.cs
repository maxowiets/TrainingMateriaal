using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : Enemy
{
    [SerializeField] private float stunDuration;
    private bool _stunned;
    private Coroutine _stunnedCoroutine;
    
    private void Awake()
    {
        Initialize();
    }

    private void Update()
    {
        Move();
        Attack();
        TargetDetection();
    }

    public override void Move()
    {
        if (target != null && !_stunned)
        {
            Vector2 move = (target.position - transform.position).normalized * speed;
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
            Debug.Log("FLYING ENEMY ATTACK");
        
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

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);

        if (_stunnedCoroutine != null)
        {
            StopCoroutine(_stunnedCoroutine);
        }

        _stunnedCoroutine = StartCoroutine(StunnedCoroutine());
    }

    IEnumerator StunnedCoroutine()
    {
        _stunned = true;
        rb2d.gravityScale = -Physics2D.gravity.y;

        yield return new WaitForSeconds(stunDuration);

        _stunned = false;
        rb2d.gravityScale = gravity;
    }
}
