using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenColorDecorator : ColorDecorator
{
    public GreenColorDecorator(IColor color) : base(color)
    {
           
    }

    public override Color BaseColor()
    {
        return base.BaseColor() + Color.green * 0.1f;
    }
}
