using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSpeedDecorator : StatDecorator
{
    public MovementSpeedDecorator(IStats stats) : base(stats)
    {
        
    }

    public override float MovementSpeed()
    {
        return base.MovementSpeed() + 1f;
    }
}
