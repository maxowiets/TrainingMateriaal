using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpForceDecorator : StatDecorator
{
    public JumpForceDecorator(IStats stats) : base(stats)
    {
        
    }

    public override float JumpForce()
    {
        return base.JumpForce() + 2f;
    }
}
