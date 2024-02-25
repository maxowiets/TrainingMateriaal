using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : AggressiveCharacter
{
    public float aggroRange;
    [HideInInspector] public Transform target;
    
    public float attackDelay;
    [HideInInspector] public float attackTimer;
    public float attackRange;
    
    protected virtual void TargetDetection()
    {
        //probably set a layermask for less collisions and more performance
        var hits = Physics2D.OverlapCircleAll(transform.position, aggroRange);
        foreach (var hit in hits)
        {
            //this performance will improve when using a layermask in the collision
            if (hit.GetComponent<Player>())
            {
                target = hit.transform;
                return;
            }
        }
        target = null;
    }
}
