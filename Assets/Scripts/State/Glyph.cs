using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glyph : MonoBehaviour
{
    [SerializeField] private Symbol symbol;

    [SerializeField] private SpriteRenderer shapeRend;
    [SerializeField] private SpriteRenderer outlineRend;
    [SerializeField] private SpriteRenderer patternRend;

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

    private void SetTraits(Symbol.Shapes newShape, Symbol.Colors newColor)
    {
        symbol.Shape = newShape;
        symbol.Color = newColor;

        ShapeData shapeData = GlyphAtlas.Instance.ShapeDatas[symbol.Shape];
        shapeRend.sprite = shapeData.ShapeSprite;
        outlineRend.sprite = shapeData.OutlineSprite;

        ColorData colorData = GlyphAtlas.Instance.ColorDatas[symbol.Color];
        shapeRend.color = colorData.LineColor;
        outlineRend.color = colorData.OutlineColor;
        patternRend.sprite = colorData.ColorblindPattern;
    }
}
