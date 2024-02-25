using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDecorator : IColor
{
    private IColor _color;

    public ColorDecorator(IColor color)
    {
        _color = color;
    }
    
    public virtual Color BaseColor()
    {
        return _color.BaseColor();
    }
}
