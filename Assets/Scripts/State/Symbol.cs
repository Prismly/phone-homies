using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Symbol
{
    public enum Shapes
    {
        PLANET,
        STAR,
        ROCKET,
        ATOM,
        NEBULA,
        MOLECULE,
        COMET,
        FACE
    }
    public enum Colors
    {
        RED,
        ORANGE,
        YELLOW,
        GREEN,
        BLUE,
        PURPLE
    }

    public Shapes Shape;
    public Colors Color;

    public Symbol(Shapes shape, Colors color)
    {
        Shape = shape;
        Color = color;
    }
}
