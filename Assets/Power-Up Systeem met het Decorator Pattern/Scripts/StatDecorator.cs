using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatDecorator : IStats
{
    private IStats _stats;

    public StatDecorator(IStats stats)
    {
        _stats = stats;
    }
    
    public virtual float MovementSpeed()
    {
        return _stats.MovementSpeed();
    }

    public virtual float JumpForce()
    {
        return _stats.JumpForce();
    }
}