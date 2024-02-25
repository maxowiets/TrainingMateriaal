using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AggressiveCharacter : Character
{
    public float damage;
    
    protected abstract void Attack();
}
