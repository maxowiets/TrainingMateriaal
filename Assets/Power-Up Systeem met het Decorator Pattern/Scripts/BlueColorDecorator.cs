using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueColorDecorator : ColorDecorator
{
    public BlueColorDecorator(IColor color) : base(color)
    {
           
    }

    public override Color BaseColor()
    {
        return base.BaseColor() + Color.blue * 0.1f;
    }
}
