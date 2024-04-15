using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlyphUI : MonoBehaviour
{
    [SerializeField] private bool isVisible;

    [SerializeField] private Symbol symbol;

    [SerializeField] private Image shapeImg;
    [SerializeField] private Image outlineImg;
    [SerializeField] private Image patternImg;

    private void Awake()
    {
        SetVisible(isVisible);
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.A))
    //        SetTraits(Symbol.Shapes.ATOM, Symbol.Colors.RED);
    //    if (Input.GetKeyDown(KeyCode.B))
    //        SetTraits(Symbol.Shapes.PLANET, Symbol.Colors.ORANGE);
    //    if (Input.GetKeyDown(KeyCode.C))
    //        SetTraits(Symbol.Shapes.PLANET, Symbol.Colors.YELLOW);
    //    if (Input.GetKeyDown(KeyCode.D))
    //        SetTraits(Symbol.Shapes.FACE, Symbol.Colors.GREEN);
    //    if (Input.GetKeyDown(KeyCode.E))
    //        SetTraits(Symbol.Shapes.MOLECULE, Symbol.Colors.BLUE);
    //    if (Input.GetKeyDown(KeyCode.F))
    //        SetTraits(Symbol.Shapes.ROCKET, Symbol.Colors.PURPLE);
    //}

    public void SetTraits(Symbol.Shapes newShape, Symbol.Colors newColor)
    {
        symbol.Shape = newShape;
        symbol.Color = newColor;

        ShapeData shapeData = GlyphAtlas.Instance.ShapeDatas[symbol.Shape];
        shapeImg.sprite = shapeData.ShapeSprite;
        outlineImg.sprite = shapeData.OutlineSprite;

        ColorData colorData = GlyphAtlas.Instance.ColorDatas[symbol.Color];
        shapeImg.color = colorData.LineColor;
        outlineImg.color = colorData.OutlineColor;
        patternImg.sprite = colorData.ColorblindPattern;
    }

    public Symbol GetSymbol() { return symbol; }

    public Symbol.Shapes GetShape()
    {
        return symbol.Shape;
    }

    public Symbol.Colors GetColor()
    {
        return symbol.Color;
    }

    public void SetVisible(bool visible)
    {
        shapeImg.enabled = visible;
        outlineImg.enabled = visible;
        patternImg.enabled = visible;
    }
}
