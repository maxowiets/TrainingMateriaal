using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour, IDamageable
{
    public void TakeDamage(int damage)
    {
        OnDie();
    }

    public void OnDie()
    {
        Destroy(gameObject);
    }
}
