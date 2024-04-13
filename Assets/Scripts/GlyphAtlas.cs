using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GlyphAtlas : MonoBehaviour
{
    public static GlyphAtlas Instance;

    [SerializeField] private ShapeDataPair[] shapeDataPairs;
    public Dictionary<Glyph.Shapes, ShapeData> ShapeDatas;
    [SerializeField] private ColorDataPair[] colorDataPairs;
    public Dictionary<Glyph.Colors, ColorData> ColorDatas;

    private void Start()
    {
        if (Instance == null)
            Initialize();
    }

    private void Initialize()
    {
        Instance = this;

        ShapeDatas = new Dictionary<Glyph.Shapes, ShapeData>();
        ColorDatas = new Dictionary<Glyph.Colors, ColorData>();
        
        foreach (ShapeDataPair pair in shapeDataPairs)
            ShapeDatas.Add(pair.shape, pair.data);
        foreach (ColorDataPair pair in colorDataPairs)
            ColorDatas.Add(pair.color, pair.data);

        Debug.Log("Initialize Done!");
    }

    [Serializable]
    private class ShapeDataPair
    {
        [SerializeField] public Glyph.Shapes shape;
        [SerializeField] public ShapeData data;
    }

    [Serializable]
    private class ColorDataPair
    {
        [SerializeField] public Glyph.Colors color;
        [SerializeField] public ColorData data;
    }
}
