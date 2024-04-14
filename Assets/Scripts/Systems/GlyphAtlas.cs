using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GlyphAtlas : MonoBehaviour
{
    public static GlyphAtlas Instance;

    [SerializeField] private ShapeDataPair[] shapeDataPairs;
    public Dictionary<Traits.Shapes, ShapeData> ShapeDatas;
    [SerializeField] private ColorDataPair[] colorDataPairs;
    public Dictionary<Traits.Colors, ColorData> ColorDatas;

    private void Awake()
    {
        if (Instance == null)
            Initialize();
    }

    private void Initialize()
    {
        Instance = this;

        ShapeDatas = new Dictionary<Traits.Shapes, ShapeData>();
        ColorDatas = new Dictionary<Traits.Colors, ColorData>();
        
        foreach (ShapeDataPair pair in shapeDataPairs)
            ShapeDatas.Add(pair.Shape, pair.Data);
        foreach (ColorDataPair pair in colorDataPairs)
            ColorDatas.Add(pair.Color, pair.Data);

        Debug.Log("Initialize Done!");
    }

    [Serializable]
    private class ShapeDataPair
    {
        [SerializeField] public Traits.Shapes Shape;
        [SerializeField] public ShapeData Data;
    }

    [Serializable]
    private class ColorDataPair
    {
        [SerializeField] public Traits.Colors Color;
        [SerializeField] public ColorData Data;
    }
}
