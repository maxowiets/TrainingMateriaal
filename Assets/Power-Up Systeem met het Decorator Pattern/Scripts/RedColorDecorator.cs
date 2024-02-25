using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedColorDecorator : ColorDecorator
{
    public RedColorDecorator(IColor color) : base(color)
    {
           
    }

    public override Color BaseColor()
    {
        return base.BaseColor() + Color.red * 0.1f;
    }
}
